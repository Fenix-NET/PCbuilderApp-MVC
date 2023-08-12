using ASP.NET_MVC_61.Models;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utility;

namespace ASP.NET_MVC_61.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly IUserService UserService;
        public AccountController(IConfiguration Configuration, IUserService UserService)
        {
            this.Configuration = Configuration;
            this.UserService = UserService;
        }


        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {

                var userRoles = ((ClaimsIdentity)User.Identity).Claims
                                                               .Where(c => c.Type == ClaimTypes.Role)
                                                               .Select(c => c.Value).ToList();

                if (userRoles.Contains(Enums.UserRoles.Admin.GetEnumDescription()))
                    return RedirectToAction("Index", "AdminDashboard");
                if (userRoles.Contains(Enums.UserRoles.Employee.GetEnumDescription()))
                    return RedirectToAction("Index", "EmployeeDashboard");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel loginModel, string returnUrl)
        {
            try
            {
                var userDetails = UserService.GetUserDetailsEmailPassword(loginModel.Email, loginModel.Password);

                if (userDetails != null)
                {
                    //---------------------------------------------------------------------------------------------------
                    //Authorization Begin

                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                    identity.AddClaim(new Claim("UserId", userDetails.UserId.ToString()));
                    identity.AddClaim(new Claim("Email", userDetails.Email));
                    identity.AddClaim(new Claim("UserFullName", userDetails.FirstName + " " + userDetails.LastName));

                    foreach (var role in userDetails.UserRoleModelList)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, role.Role));
                    }

                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                        new AuthenticationProperties
                        {
                            IsPersistent = false,
                            ExpiresUtc = DateTime.UtcNow.AddDays(1),
                        });

                    //Authorization End


                    //Session Begin
                    //HttpContext.Session.SetString("UserId", objUser.UserId);
                    //HttpContext.Session.Set<Domain.UserDetails>("UserDetails", userDetails);
                    //Session End


                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                    {
                        //return RedirectToAction("Index", "Dashboard");

                        if (userDetails.UserRoleModelList.Where(x => x.Role == Enums.UserRoles.Admin.GetEnumDescription()).Count() > 0)
                            return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });
                        if (userDetails.UserRoleModelList.Where(x => x.Role == Enums.UserRoles.Employee.GetEnumDescription()).Count() > 0)
                            return RedirectToAction("Index", "EmployeeDashboard", new { area = "Employee" });

                    }
                }
                else
                {
                    ViewBag.FormResponseMessage = "User does not exist";
                }
            }
            catch (Exception ex)
            {
                ElmahCore.ElmahExtensions.RiseError(ex);
            }

            return View();
        }



        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            //return LocalRedirect("Account/Login");
            return RedirectToAction("Login", "Account");
        }
        public ActionResult AccessDenied()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
