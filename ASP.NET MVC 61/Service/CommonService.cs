using DataAccess.DemoDB;
using Infrastructure;

namespace Service
{
    public class CommonService : ICommonService
    {
        private readonly DemoDBContext DemoDBContext;
        public CommonService(DemoDBContext DemoDBContext)
        {
            this.DemoDBContext = DemoDBContext;
        }




    }
}
