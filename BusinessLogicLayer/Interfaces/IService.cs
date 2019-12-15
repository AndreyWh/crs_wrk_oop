using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    interface IService<T>
    {
        List<T> GetAllEntities();
        void Add(T entity);
        void Remove(T entity);
        void Update(T newEntity, T oldEntity);
    }
}
