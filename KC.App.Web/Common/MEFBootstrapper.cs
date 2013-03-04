
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Web.Hosting;

namespace KC.App.Web
{
    /// <summary>
    /// MEF防止依赖注入启动类
    /// </summary>
    public class MEFBootstrapper
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialize()
        {
            var path = HostingEnvironment.MapPath("~/bin");

            if (path == null) throw new Exception("Unable to find the path");

            var catalog = new DirectoryCatalog(path);

            //AssemblyCatalog catalog = new AssemblyCatalog(typeof(MEFBootstrapper).Assembly);

            //将需要防止依赖注入的对象所在动态库添加到容器
            var container = new CompositionContainer(catalog);
            
            DependencyResolver.SetResolver(new MEFDependencyResolver(container));
        }
    }
}

