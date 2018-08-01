using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UBTTestCode.Data;

namespace UBTTestCode.ViewModels
{
    public class BaseViewModel
    {

        public string PageTitle { get; set; }
        public User User { get; set; }

    }
}