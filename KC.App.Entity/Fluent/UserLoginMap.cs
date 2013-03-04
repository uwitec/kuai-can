using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace KC.App.Entity
{
    /// <summary>
    /// 用户登录表映射类
    /// </summary>
    public class UserLoginMap : ClassMap<UserLogin>
    {
        public UserLoginMap()
        {
            Id(p => p.Id).GeneratedBy.Identity().Default(100000);
            Map(p => p.UserName).Length(20).Not.Nullable();
            Map(p => p.Pwd).Length(50).Not.Nullable();
            Map(p => p.Salt).Length(10).Not.Nullable();
            Map(p => p.Email).Length(32).Not.Nullable();
            Map(p => p.Mobile).Length(20);
            Map(p => p.LoginCont).Default("0");
            Map(p => p.LastLoginIp).Default(string.Empty);
            Map(p => p.LastLoginTime).Default("0");
            Map(p => p.RegisterTime).Default("0");
            Map(p => p.Status).Default("0");
            Map(p => p.UserType).Default("0");
            HasOne<UserLogin>(p => p.UserInfo)
                .Cascade.All();
        }
    }
}
