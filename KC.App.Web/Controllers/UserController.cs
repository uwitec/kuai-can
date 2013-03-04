using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KC.App.Contract;
using Microsoft.Practices.ServiceLocation;
using KC.App.Bll;
using System.ComponentModel.Composition;
using System.Web.Routing;
using KC.App.Entity;

namespace KC.App.Web.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserController : Controller
    {
        //
        // GET: /User/
        [Import]
        private IUserLoginContract userContract = new UserService();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            userContract.Save(new Entity.UserLogin()
            {
                UserName = "Kevin",
            });
            return View();
        }
    }
}
