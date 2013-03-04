using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace KC.App.Entity
{

    /// <summary>
    /// 用户信息映射类
    /// </summary>
    public class UserInfoMap : ClassMap<UserInfo>
    {
        public UserInfoMap()
        {
            Id(p => p.Id).GeneratedBy.Identity().Default(1);            
            HasOne<UserLogin>(p => p.UId).ForeignKey("UId")
                .Cascade
                .All()
                .LazyLoad();
        }
    }
}
