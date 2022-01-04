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
    public class BaseTests
    {
        private readonly List<int?> listInt;
        private readonly List<long?> listLong;
        private readonly List<DateTime?> listDateTime;
        private readonly List<string> listString;
        private readonly List<ComplexClass> listComplex;

        private readonly ComplexClass firstComplexClass;
        private readonly ComplexClass secondComplexClass;

        public BaseTests()
        {
            listInt  = new List<int?>() { null, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            listLong = new List<long?>() { null, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            listDateTime = new List<DateTime?>() { null, DateTime.Now, DateTime.MinValue, DateTime.MaxValue };
            listString = new List<string>() { null, "", " ", "test", "someone" };

            firstComplexClass = new ComplexClass() { listInt = new List<int>(), DateTime = null, Int = null, Long = null, listComplex = new List<ComplexClass>(), String = null,  Boolean = false };
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
            public bool? Boolean { get; set; }
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
        public void IsNull()
        {
            listComplex.WhereQuery().IsNull().Should().HaveCount(1);
            listComplex.AsQueryable()
                       .WhereQuery().IsNull().Should().HaveCount(1);
        }

        public class ListComplexSimpleTest : BaseTests
        {
            private readonly List<ComplexClass> listComplexValue;
            public ListComplexSimpleTest()
            {
                listComplexValue = listComplex.WhereQuery().IsNotNull().ToList();
            }

            [Fact]
            public void IsTrue()
            {
                listComplexValue.WhereParam(x => x.Boolean).IsTrue().Should().HaveCount(0);
                listComplexValue.AsQueryable()
                                .WhereParam(x => x.Boolean).IsTrue().Should().HaveCount(0);
            }
            [Fact]
            public void IsFalse()
            {
                listComplexValue.WhereParam(x => x.Boolean).IsFalse().Should().HaveCount(1);
                listComplexValue.AsQueryable()
                                .WhereParam(x => x.Boolean).IsFalse().Should().HaveCount(1);
            }
            [Fact]
            public void Contains()
            {
                listComplexValue.WhereParam(x => x.listInt).Contains(1).Should().HaveCount(1);

                listComplexValue.AsQueryable()
                                .WhereParam(x => x.listInt).Contains(1).Should().HaveCount(1);
            }
            [Fact]
            public void Have()
            {
                listComplexValue.WhereParam(x => x.listInt).Have(1).Should().HaveCount(1);

                listComplexValue.AsQueryable()
                                .WhereParam(x => x.listInt).Have(1).Should().HaveCount(1);
            }
            [Fact]
            public void HaveLessThen()
            {
                listComplexValue.WhereParam(x => x.listInt).HaveLessThen(3).Should().HaveCount(2);

                listComplexValue.AsQueryable()
                                .WhereParam(x => x.listInt).HaveLessThen(3).Should().HaveCount(2);
            }
            [Fact]
            public void HaveMoreThen()
            {
                listComplexValue.WhereParam(x => x.listInt).HaveMoreThen(0).Should().HaveCount(1);

                listComplexValue.AsQueryable()
                                .WhereParam(x => x.listInt).HaveMoreThen(0).Should().HaveCount(1);
            }
            [Fact]
            public void In()
            {
                listComplexValue.WhereParam(x => x.Int).In(1,2,3).Should().HaveCount(1);
                listComplexValue.AsQueryable()
                                .WhereParam(x => x.Int).In(1,2,3).Should().HaveCount(1);
            }
            [Fact]
            public void IsBetween()
            {
                listComplexValue.WhereParam(x => x.Int).IsBetween(0, 2).Should().HaveCount(1);
                listComplexValue.AsQueryable()
                                .WhereParam(x => x.Int).IsBetween(0, 2).Should().HaveCount(1);
            }
            [Fact]
            public void IsBiggerThen()
            {
                listComplexValue.WhereParam(x => x.Int).IsBiggerThen(0).Should().HaveCount(1);
                listComplexValue.AsQueryable()
                                .WhereParam(x => x.Int).IsBiggerThen(0).Should().HaveCount(1);
            }
            [Fact]
            public void IsSmallerThen()
            {
                listComplexValue.WhereParam(x => x.Int).IsSmallerThen(0).Should().HaveCount(0);
                listComplexValue.AsQueryable()
                                .WhereParam(x => x.Int).IsSmallerThen(0).Should().HaveCount(0);
            }
            [Fact]
            public void IsEqual()
            {
                listComplexValue.WhereParam(x => x.Int).IsEqual(0).Should().HaveCount(0);
                listComplexValue.AsQueryable()
                                .WhereParam(x => x.Int).IsEqual(0).Should().HaveCount(0);
            }
            [Fact]
            public void Like()
            {
                listComplexValue.WhereParam(x => x.Int).Like('2').Should().HaveCount(0);
                listComplexValue.AsQueryable()
                                .WhereParam(x => x.Int).Like("1").Should().HaveCount(1);
            }
            [Fact]
            public void IsNullOrEmpty()
            {
                listComplexValue.WhereParam(x => x.listInt).IsNullOrEmpty().Should().HaveCount(1);
                listComplexValue.AsQueryable()
                                .WhereParam(x => x.listInt).IsNullOrEmpty().Should().HaveCount(1);
            }
        }
    }

}
