﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
     
        void Add(T entity);
     
        void Update(T entity);
        void Remove(T entity);
     
        
    }
}
