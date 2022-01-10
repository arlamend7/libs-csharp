using System;
using System.Collections.Generic;

namespace Linq.Fluent.Tests.Base
{
    public class ComplexClass
    {
        public List<int> listInt { get; set; }
        public List<ComplexClass> listComplex { get; set; }
        public long? Long { get; set; }
        public int? Int { get; set; }
        public string String { get; set; }
        public DateTime? DateTime { get; set; }
        public bool? Boolean { get; set; }
    }
}
