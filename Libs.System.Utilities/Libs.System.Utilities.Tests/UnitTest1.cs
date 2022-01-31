using FluentAssertions;
using Libs.System.Utilities.Enums;
using Libs.System.Utilities.Enums.Classes;
using System;
using System.Collections.Generic;
using Xunit;

namespace Libs.System.Utilities.Tests
{
    public class UnitTest1
    {
        public enum Testes
        {
            Complete,
            Complete2
        }
        [Fact]
        public void Test1()
        {
           IEnumerable<EnumValue> teste = EnumUtilities.GetValues<Testes>();

            teste.Should().HaveCount(2);
        }
        [Fact]
        public void GetByText()
        {
            Testes enumerador = EnumUtilities.GetByName<Testes>("complete");
            enumerador.Should().Be(Testes.Complete);
        }
    }
}
