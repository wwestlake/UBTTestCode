using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UBTTestCode.Data;
using UBTTestCode.ViewModels;

namespace UBTTestCode.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var vm = InitViewModel<HomeViewModel>();
            return await Task.Run( () => View(vm) );
        }

        public async Task<ActionResult> About()
        {
            var vm = InitViewModel<HomeViewModel>();
            ViewBag.Message = "UBT Test Application.";

            return await Task.Run( () => View(vm) );
        }

        public async Task<ActionResult> Contact()
        {
            var vm = InitViewModel<HomeViewModel>();
            ViewBag.Message = "Your contact page.";

            return await Task.Run( () => View(vm) );
        }



    }
}