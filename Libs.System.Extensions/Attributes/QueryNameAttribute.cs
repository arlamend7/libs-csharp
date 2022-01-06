using System;

namespace Libs.System.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryNameAttribute : Attribute
    {
        public string Name { get; }
        public QueryNameAttribute(string name)
        {
            Name = name;
        }
    }
}
