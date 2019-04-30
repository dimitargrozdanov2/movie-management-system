﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieManagement.Infrastructure
{
    public interface IMappingProvider
    {
        TDestination MapTo<TDestination>(object source);
        IEnumerable<TDestination> ProjectTo<TDestination>(IEnumerable<object> source);
        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable<object> source);
    }
}
