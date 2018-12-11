using System;
namespace Core.Framework.Docs.PDF
{
    public sealed class HeaderSettings
    {
        public string Left { get; set; }
        public string Center { get; set; }
        public string Right { get; set; }
        public string FontName { get; set; }
        public int? FontSize { get; set; }
        public bool? Line { get; set; }
        public double? Spacing { get; set; }
        public string HtmlURL { get; set; }
    }
}
