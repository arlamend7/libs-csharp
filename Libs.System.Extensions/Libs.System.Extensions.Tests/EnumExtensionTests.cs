using FluentAssertions;
using Xunit;

namespace Libs.System.Extensions.Tests
{
    public class EnumExtensionTests
    {
        public enum TesteEnum
        {
            Currency = 'C'
        }

        [Fact]
        public void Teste()
        {
            char teste = TesteEnum.Currency.GetCharValue();
            teste.ToString().Should().Be("C");
        }
    }
}
