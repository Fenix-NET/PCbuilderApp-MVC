using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PcBuilderApp.Controllers
{
	public class RegistrationController : Controller
	{
		// GET: RegistrationController
		public ActionResult CreateNewAccaunt()
		{
			return View();
		}

		// GET: RegistrationController
		public ActionResult Auth()
		{
			return View();
		}

		// GET: RegistrationController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: RegistrationController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: RegistrationController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: RegistrationController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: RegistrationController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: RegistrationController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
