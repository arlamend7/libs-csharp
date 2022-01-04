using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Linq.Fluent.Expressions.Starters;
using Linq.Fluent.Funcs.Starters;
using Linq.Fluent.Expressions.Conditions;
using Linq.Fluent.Funcs.Conditions;
using System;

namespace Linq.Fluent.Tests
{
    public class BaseTestes
    {
        private readonly List<int?> listInt;
        private readonly List<long?> listLong;
        private readonly List<DateTime?> listDateTime;
        private readonly List<string> listString;
        private readonly List<ComplexClass> listComplex;

        private readonly ComplexClass firstComplexClass;
        private readonly ComplexClass secondComplexClass;

        public BaseTestes()
        {
            listInt  = new List<int?>() { null, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            listLong = new List<long?>() { null, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            listDateTime = new List<DateTime?>() { null, DateTime.Now, DateTime.MinValue, DateTime.MaxValue };
            listString = new List<string>() { null, "", " ", "test", "someone" };

            firstComplexClass = new ComplexClass() { listInt = new List<int>(), DateTime = null, Int = null, Long = null, listComplex = new List<ComplexClass>(), String = null  };
            secondComplexClass = new ComplexClass() { listInt = new List<int>() { 1 }, DateTime = DateTime.Now, Int = 1, Long = 1, String = "test", listComplex = new List<ComplexClass>() { firstComplexClass} };
            listComplex = new List<ComplexClass>() { null,firstComplexClass, secondComplexClass };
        }
        public class ComplexClass
        {
            public List<int> listInt { get; set; }
            public List<ComplexClass> listComplex { get; set; }
            public long? Long { get; set; }
            public int? Int { get; set; }
            public string String { get; set; }
            public DateTime? DateTime { get; set; }
        }

        [Fact]
        public void WhereParam()
        {
            listInt.WhereParam(x => x).IsEqual(1).Should().HaveCount(1);

            listInt.AsQueryable().WhereParam(x => x).IsEqual(1).Should().HaveCount(1);
        }
        [Fact]
        public void WhereQuery()
        {
            listInt.WhereQuery().IsEqual(1).Count().Should().Be(1);

            listInt.AsQueryable().WhereQuery().IsEqual(1).Count().Should().Be(1);
        }
        [Fact]
        public void Contains()
        {
            listComplex.WhereParam(x => x.listInt).Contains(1).Should().HaveCount(1);
            listComplex.AsQueryable().WhereQuery().IsNotNull()
                                     .WhereParam(x => x.listInt).Contains(1).Should().HaveCount(1);
        }
    }

}
