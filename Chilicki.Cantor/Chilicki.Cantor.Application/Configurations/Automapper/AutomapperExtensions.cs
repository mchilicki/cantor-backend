﻿using AutoMapper;
using System;
using System.Linq.Expressions;

namespace Chilicki.Cantor.Application.Configurations.Automapper
{
    public static class AutomapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> map,
            Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }
    }
}
