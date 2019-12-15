using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IMapper<T,U> where T: class
                           where U: class
    {
        T Map(U dbClass);
        U Map(T dtoClass);
    }
}
