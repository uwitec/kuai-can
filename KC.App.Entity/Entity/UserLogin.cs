using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KC.App.Entity
{
    public class UserLogin
    {
        /// <summary>
        /// 用户编号（100000开始-登录）
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 用户名（显示）
        /// </summary>
        public virtual string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Pwd { get; set; }
        /// <summary>
        /// 盐值
        /// </summary>
        public virtual string Salt { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public virtual int RegisterTime { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public virtual int LoginCont { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public virtual int LastLoginTime { get; set; }
        /// <summary>
        /// 最后登录Ip
        /// </summary>
        public virtual string LastLoginIp { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual int Status { get; set; }
        /// <summary>
        /// 邮箱（登录）
        /// </summary>
        public virtual string Email { get; set; }
        /// <summary>
        /// 手机（登录）
        /// </summary>
        public virtual string Mobile { get; set; }
        /// <summary>
        /// 用户类型（0买家、1卖家）
        /// </summary>
        public virtual int UserType { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }

    }
}
