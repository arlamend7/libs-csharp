using System.ComponentModel;

namespace Libs.Fluent.Net.Mail.Enums
{
    public enum ContentTypeEnum
    {
        [Description("application/octet-stream")]
        Excel,
        [Description("application/pdf")]
        PDF,
        [Description("application/json")]
        Json,
        [Description("application/rtf")]
        Word,
        [Description("application/soap+xml")]
        Txt,
        [Description("application/zip")]
        Zip,
        [Description("image/png")]
        PNG,
        [Description("image/jpeg")]
        Jpeg,
        [Description("image/gif")]
        gif,
        [Description("image/x-icon")]
        Icon,
        [Description("image/svg+xml")]
        Svg,
        [Description("multipart/form-data")]
        MultPart,
        [Description("video/mp4")]
        VideoMp4,
        [Description("video/mpeg")]
        VideoMPeg,
        [Description("video/quicktime")]
        VideoQuickTime,
        [Description("text/css")]
        Css,
        [Description("text/csv")]
        Csv,
        [Description("text/html")]
        Html,
        [Description("text/javascript")]
        JavaScript,
        [Description("text/xml")]
        Xml
    }
}