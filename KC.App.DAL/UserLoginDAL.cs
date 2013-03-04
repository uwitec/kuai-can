using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KC.App.IDAL;
using KC.App.Entity;
using System.ComponentModel.Composition;

namespace KC.App.DAL
{
    [Export(typeof(IUserLoginDAL))]
    public class UserLoginDAL : BaseDAL<UserLogin>, IUserLoginDAL
    {
    }
}
