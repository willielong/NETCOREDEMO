using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkFlow.AutoMapper.TypeConvertert
{
    public class GenderTypeConvertert<T1, T2> : ITypeConverter<T1, T2>
    {
        public T2 Convert(T1 source, T2 destination, ResolutionContext context)
        {
            var intvalue = typeof(int);
            if (source.GetType() == typeof(int))
            {

            }
            if (source.GetType() == typeof(string))
            {

            }
            if (source.GetType() == typeof(bool))
            {

            }
            if (source.GetType() == typeof(decimal))
            {

            }
            if (source.GetType() == typeof(double))
            {

            }
            if (source.GetType() == typeof(decimal))
            {

            }
            return destination;
        }
    }
}
