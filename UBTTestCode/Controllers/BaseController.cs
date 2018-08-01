using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UBTTestCode.Data;
using UBTTestCode.ViewModels;

namespace UBTTestCode.Controllers
{
    public class BaseController : Controller
    {
        protected T InitViewModel<T>() where T: BaseViewModel, new()
        {
            var user = Session["User"] as User;
            return new T()
            {
                PageTitle = "Home",
                User = user
            };
        }
    }
}