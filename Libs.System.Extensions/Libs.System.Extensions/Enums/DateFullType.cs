using System.ComponentModel;

namespace Libs.System.Extensions.Enums
{
    public enum DateFullType
    {
        [Description("dddd, dd MMMM yyyy HH:mm:ss")]
        Complete,
        [Description("dddd, dd MMMM yyyy")]
        WithoutHours
    }
}
