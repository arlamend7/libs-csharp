using FluentAssertions;
using Linq.Fluent.Expressions.Conditions;
using Linq.Fluent.Expressions.IExpressionBuilder;
using Linq.Fluent.Expressions.Starters;
using Linq.Fluent.Funcs.Conditions;
using Linq.Fluent.Funcs.FuncBuilders;
using Linq.Fluent.Funcs.Starters;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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
            listComplex = new List<ComplexClass>() { null, firstComplexClass, secondComplexClass };
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
            listInt.WhereParam(x => x).Should().BeOfType<FuncBuilder<int?, int?>>();

            listInt.AsQueryable().WhereParam(x => x).Should().BeOfType<ExpressionBuilder<int?,int?>>();
            
            listComplex.WhereParam(x => x.DateTime).Should().BeOfType<FuncBuilder<ComplexClass, DateTime?>>();

            listComplex.AsQueryable().WhereParam(x => x.DateTime).Should().BeOfType<ExpressionBuilder<ComplexClass, DateTime?>>();
        }
        [Fact]
        public void WhereQuery()
        {
            listInt.WhereQuery().Should().BeOfType<FuncBuilder<int?, int?>>();

            listInt.AsQueryable().WhereQuery().Should().BeOfType<ExpressionBuilder<int?, int?>>();

            listComplex.WhereQuery().Should().BeOfType<FuncBuilder<ComplexClass, ComplexClass>>();
        }

        [Fact]
        public void IsNotNull()
        {
            listComplex.WhereQuery().IsNotNull().Should().HaveCount(2);
            listComplex.AsQueryable()
                       .WhereQuery().IsNotNull().Should().HaveCount(2);
        }
        [Fact]
        public void Contains()
        {
            listComplex.WhereQuery().IsNotNull()
                       .WhereParam(x => x.listInt).Contains(1).Should().HaveCount(1);

            listComplex.AsQueryable()
                       .WhereQuery().IsNotNull()
                       .WhereParam(x => x.listInt).Contains(1).Should().HaveCount(1);
        }
    }

}
