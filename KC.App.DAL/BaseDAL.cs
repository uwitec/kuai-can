using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KC.App.IDAL;
using NHibernate;
using NHibernate.Linq;
using System.Linq.Dynamic;
using FluentNHibernate.Cfg;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg.Db;
using KC.App.Entity;
using System.ComponentModel.Composition;

namespace KC.App.DAL
{
    /// <summary>
    /// 数据访问层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseDAL<T> : IBaseDAL<T> where T : class
    {
        private static ISessionFactory sessionFactory = null;
        /// <summary>
        /// 会话工厂
        /// </summary>
        protected static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    sessionFactory = CreateSessionFactory();
                }
                return sessionFactory;
            }
        }

        /// <summary>
        /// 会话
        /// </summary>
        protected ISession Session
        {
            get
            {
                return SessionFactory.OpenSession();
            }
        }

        /// <summary>
        /// 创建会话工厂
        /// </summary>
        /// <returns></returns>
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                .ConnectionString(s => s.Server(".")
                                      .Database("Dinner")
                                      .Password("123456")
                                      .Username("sa")
                                      )
                          )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserLogin>()
                //.ExportTo("G:\\电子商务\\网上订餐系统\\KC.App\\KC.App.Web\\Entity\\Map")
                )
                //.ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual object Save(T entity)
        {
            return Session.Save(entity);//this.HibernateTemplate.Save(entity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetModel(object id)
        {
            return Session.Get<T>(id);
        }

        /// <summary>
        /// 加载实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Load(object id)
        {
            return Session.Load<T>(id);
        }

        /// <summary>
        /// 加载全部
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> LoadAll()
        {
            var result = Session.Query<T>();
            return result;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            Session.Update(entity);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            var entity = Session.Get<T>(id);
            if (entity == null)
            {
                return;
            }

            Session.Delete(entity);
        }

        /// <summary>
        /// 检索分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="pageCount"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public virtual IQueryable<T> Retrieves(int pageIndex, int pageSize, out int rowCount, out int pageCount, string strWhere)
        {
            var result = Session.Query<T>().Where(strWhere);
            rowCount = result.Count();
            pageCount = (int)Math.Ceiling(0.01 * (rowCount / pageSize) * 100);
            return result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 检索分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public virtual IQueryable<T> Retrieves(int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            var result = Session.Query<T>();
            rowCount = result.Count();
            pageCount = (int)Math.Ceiling(0.01 * (rowCount / pageSize) * 100);
            return result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        public virtual void Delete(IList<object> idList)
        {
            foreach (var item in idList)
            {
                var entity = Session.Get<T>(item);
                if (entity == null)
                {
                    return;
                }

                Session.Delete(entity);
            }
        }
        /// <summary>
        /// 保存或更新
        /// </summary>
        /// <param name="entity"></param>
        public virtual void SaveOrUpdate(T entity)
        {
            Session.SaveOrUpdate(entity);
        }
    }
}
