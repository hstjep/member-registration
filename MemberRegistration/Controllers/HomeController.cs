using MemberRegistration.Service.Common;
using MemberRegistration.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Xml.Linq;

namespace MemberRegistration.Controllers
{
    public class HomeController : Controller
    {
        #region Properties

        protected IMemberService Service { get; private set; }

        #endregion Properties


        #region Constructors

        public HomeController(IMemberService service)
        {
            this.Service = service;
        }

        #endregion Constructors


        #region Methods

        public ActionResult Index()
        {
            //var Member = await Service.GetCurrentAsync();
            //return View(AutoMapper.Mapper.Map<MemberViewModel>(Member));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #endregion Methods
    }
}