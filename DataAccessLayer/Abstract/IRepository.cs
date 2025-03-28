﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Add(T item);

        T Get(Expression<Func<T, bool>> filter);

        void Update(T item);
        void Delete(T item);

        List<T> List(Expression<Func<T, bool>> filter);
    }
}
