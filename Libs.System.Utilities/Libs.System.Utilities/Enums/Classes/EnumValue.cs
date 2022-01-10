using Libs.System.Extensions;
using System;

namespace Libs.System.Utilities.Enums.Classes
{
    public class EnumValue
    {
        public string Name { get; }
        public int Value { get; }
        public string Description { get;}
        public Enum Enumeration { get; }
        public EnumValue(Enum enumeration)
        {
            Name = enumeration.ToString();
            Description = enumeration.GetDescription();
            Enumeration = enumeration;
            Value = Convert.ToInt32(Enumeration);
        }
        public char? GetCharValue()
        {
            return Convert.ToChar(Value);
        }
    }
}