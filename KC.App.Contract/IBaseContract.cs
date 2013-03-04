﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KC.App.Contract
{
    public interface IBaseContract<T> where T : class
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        T GetModel(object id);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        T Load(object id);

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>ID</returns>
        object Save(T entity);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update(T entity);

        /// <summary>
        /// 修改或保存实体
        /// </summary>
        /// <param name="entity">实体</param>
        void SaveOrUpdate(T entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">ID</param>
        void Delete(object id);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="idList">ID集合</param>
        void Delete(IList<object> idList);

        /// <summary>
        /// 获取全部集合
        /// </summary>
        /// <returns>集合</returns>
        IList<T> LoadAll();

        /// <summary>
        /// 分页获取全部集合
        /// </summary>
        /// <param name="rowCount">记录总数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageCount"></param>
        /// <returns>集合</returns>
        IList<T> Retrieves(int pageIndex, int pageSize,out int rowCount,out int pageCount );
    }
}
