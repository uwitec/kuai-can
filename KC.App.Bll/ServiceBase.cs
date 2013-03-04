using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KC.App.Contract;
using KC.App.IDAL;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;

namespace KC.App.Bll
{
    public abstract class ServiceBase<T> : IBaseContract<T> where T : class
    {
        public abstract IBaseDAL<T> CurrentDAL { get; }

        public virtual T GetModel(object id)
        {
            if (id == null)
            {
                return null;
            }
            return this.CurrentDAL.GetModel(id);
        }

        public virtual T Load(object id)
        {
            if (id == null)
            {
                return null;
            }
            return this.CurrentDAL.Load(id);
        }

        public virtual object Save(T entity)
        {
            if (entity == null)
            {
                return null;
            }
            return this.CurrentDAL.Save(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                return;
            }

            this.CurrentDAL.Update(entity);
        }

        public virtual void Delete(object id)
        {
            if (id == null)
            {
                return;
            }

            this.CurrentDAL.Delete(id);
        }

        public virtual IList<T> LoadAll()
        {
            return this.CurrentDAL.LoadAll().ToList();
        }

        public virtual IList<T> Retrieves(int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            return this.CurrentDAL.Retrieves(pageIndex, pageSize, out rowCount, out pageCount).ToList();
        }


        public virtual void Delete(IList<object> idList)
        {
            if (idList == null || idList.Count == 0)
            {
                return;
            }

            this.CurrentDAL.Delete(idList);
        }

        public virtual void SaveOrUpdate(T entity)
        {
            if (entity == null)
            {
                return;
            }

            this.CurrentDAL.SaveOrUpdate(entity);
        }
    }
}
