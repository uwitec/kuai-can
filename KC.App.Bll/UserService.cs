using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KC.App.Contract;
using KC.App.Entity;
using Microsoft.Practices.ServiceLocation;
using KC.App.IDAL;
using System.ComponentModel.Composition;
using KC.App.DAL;

namespace KC.App.Bll
{
    [Export(typeof(IUserLoginContract))]
    public class UserService : ServiceBase<UserLogin>, IUserLoginContract
    {
        [Import]
        public override IBaseDAL<UserLogin> CurrentDAL
        {
            get
            {
                return new UserLoginDAL();
            }
        }
    }
}