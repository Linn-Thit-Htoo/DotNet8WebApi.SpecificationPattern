﻿using DotNet8WebApi.SpecificationPattern.Repositories.Features.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.SpecificationPattern.Repositories
{
    public static class DevCode
    {
        public static IQueryable<T> ApplySpecification<T>(this IQueryable<T> query, ISpecification<T> specification) where T : class
        {
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            return query;
        }
    }
}
