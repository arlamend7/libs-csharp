using FluentAssertions;
using Linq.Fluent.Expressions;
using Linq.Fluent.Expressions.IExpressionBuilder;
using Linq.Fluent.Funcs;
using Linq.Fluent.Funcs.FuncBuilders;
using Linq.Fluent.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Linq.Fluent.Tests
{
    public class ConditionsTests : BaseDataTests
    {
        [Fact]
        public void Conditions()
        {
            listInt.WhereParam(x => x).Conditions.Should().BeOfType<FuncConditionsBuilder<int?, int?>>();

            listInt.AsQueryable().WhereParam(x => x).Conditions.Should().BeOfType<ExpressionConditionsBuilder<int?,int?>>();

            listComplex.WhereParam(x => x.DateTime).Conditions.Should().BeOfType<FuncConditionsBuilder<ComplexClass, DateTime?>>();

            listComplex.AsQueryable().WhereParam(x => x.DateTime).Conditions.Should().BeOfType<ExpressionConditionsBuilder<ComplexClass, DateTime?>>();
        }

        public class ListComplexConditionsTest : SimplesTests
        {
            private readonly List<ComplexClass> listComplexValue;
            public ListComplexConditionsTest()
            {
                listComplexValue = listComplex.WhereQuery().IsNotNull().ToList();
            }
            [Fact]
            public void ComplexConditions()
            {
                listComplexValue.WhereQuery().Conditions.Not.Condition(x => x.DateTime == null)
                                                        .Condition(x => x.listInt != null)
                                                        .Create()
                                                        .Should().HaveCount(0);

                var query = listComplexValue.AsQueryable()
                               .WhereParam(x => x).Conditions.Condition(y => y.DateTime == null)
                                                                        .Create();
                 query.Should().HaveCount(1);
            }
        }
    }
}
