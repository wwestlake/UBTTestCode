using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UBTTestCode.Data;
using UBTTestCode.ViewModels;

namespace UBTTestCode.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public async Task<ActionResult> Index()         {
            var vm = InitViewModel<AccountViewModel>(); return await Task.Run( () => View(vm) );
        }


        public async Task<ActionResult> CreateAccount() {
            var vm = InitViewModel<AccountViewModel>(); vm.PageTitle = "Create Account"; return await Task.Run( () => View(vm) );   }

        [HttpPost]
        public async Task<ActionResult> CreateAccountPostBack(AccountViewModel vm)
        {
        using (var ctx = new UBTTestContext())
        {
        ctx.Users.Add(vm.User);
        await ctx.SaveChangesAsync();
        Session["User"] = vm.User;
        }
        return await Task.Run( () => RedirectToAction("Index", "Home") );
        }

        public async Task<ActionResult> ChangePassword()
        {
                    var vm = InitViewModel<AccountViewModel>();
        vm.PageTitle = "Change Password";  return await Task.Run( () => View(vm) );
        }

        public async Task<ActionResult> ChangePasswordPostback(AccountViewModel vm)
        {
            using (var ctx = new UBTTestContext())
            {
            var user = ctx.Users.Where(x => x.UserName == vm.User.UserName && x.Password == vm.User.Password).FirstOrDefault();
            if (user != null)
            {user.Password = vm.NewPassword;

                    var sql = string.Format("UPDATE Users SET Password = '{0}' WHERE UserId = {1}", vm.NewPassword, user.UserId);

                    ctx.Database.ExecuteSqlCommand(sql); 

             return await Task.Run( () => RedirectToAction("Index", "Home") );      } }
            return await Task.Run( () => RedirectToAction("ChangePassword", "Account") );
        }


        public async Task<ActionResult> Login()
        {
            var vm = InitViewModel<AccountViewModel>();
            vm.PageTitle = "Login";
            return await Task.Run( () => View(vm) );
        }

        [HttpPost]
        public async Task<ActionResult> LoginPostBack(AccountViewModel vm)
        {
            using (var ctx = new UBTTestContext())
            {
                var user = ctx.Users.Where(x => x.UserName == vm.User.UserName && x.Password == vm.User.Password).FirstOrDefault();
                if (user != null)
                { Session["User"] = user; return await Task.Run( () => RedirectToAction("Index", "Home") ); }
            } return await Task.Run(() => RedirectToAction("Login", "Account"));
        }


        public async Task<ActionResult> Logout()
        {
            Session.Clear(); return await Task.Run( () => RedirectToAction("Index", "Home") );
        }

    }
}