using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KC.App.Entity
{
    /// <summary>
    /// 用户信息实体
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public virtual int UId { get; set; }
    }
}
