using System;
using DinkToPdf;

namespace Core.Framework.Docs.PDF
{
    #region enums
    public enum ColorMode
    {
        Color,
        Grayscale
    }

    public enum Orientation
    {
        Portrait,
        Landscape
    }
    #endregion

    public class PDFDoc : IDoc
    {
        BasicConverter _converter;

        public string Title
        { get; set; }

        public string Content
        { get; set; }

        public ColorMode ColorMode
        { get; set; }

        public Orientation Orientation
        { get; set; }

        public string Out
        { get; set; }

        public HeaderSettings HeaderSettings
        { get; set; }

        public FooterSettings FooterSettings
        { get; set; }

        public WebSettings WebSettings
        { get; set; }

        public PDFDoc(string title, string content, string output)
        {
            Title = title;
            Content = content;
            Out = output;
            Initializer();
        }

        public PDFDoc(string title, string content)
        {
            Title = title;
            Content = content;
            Initializer();
        }

        public PDFDoc(string content)
        {
            Content = content;
            Initializer();
        }

        void Initializer()
        {
            _converter = new BasicConverter(new PdfTools());
            HeaderSettings = new HeaderSettings();
            FooterSettings = new FooterSettings();
            WebSettings = new WebSettings();
        }

        public virtual string Generate()
        {
            try
            {
                if (string.IsNullOrEmpty(Content))
                    throw new ArgumentNullException(nameof(Content));

                #region settings
                DinkToPdf.ColorMode colorm = DinkToPdf.ColorMode.Color;
                DinkToPdf.Orientation orientation = DinkToPdf.Orientation.Portrait;

                switch (ColorMode)
                {
                    case ColorMode.Grayscale:
                        colorm = DinkToPdf.ColorMode.Grayscale;
                        break;
                }

                switch (Orientation)
                {
                    case Orientation.Landscape:
                        orientation = DinkToPdf.Orientation.Landscape;
                        break;
                }
                #endregion

                var doc = new HtmlToPdfDocument
                {
                    GlobalSettings =
                    {
                        ColorMode = colorm,
                        Orientation = orientation,
                        PaperSize = PaperKind.A4Plus,
                        DocumentTitle = Title,
                        Out = Out
                    },
                    Objects =
                    {
                        new ObjectSettings
                        {
                            HtmlContent = Content,
                            HeaderSettings =
                            {
                                 Center = HeaderSettings.Center,
                                 FontName = HeaderSettings.FontName,
                                 FontSize = HeaderSettings.FontSize,
                                 HtmUrl = HeaderSettings.HtmlURL,
                                 Left = HeaderSettings.Left,
                                 Line = HeaderSettings.Line,
                                 Right = HeaderSettings.Right,
                                 Spacing = HeaderSettings.Spacing
                            },
                            FooterSettings =
                            {
                                 Center = FooterSettings.Center,
                                 FontName = FooterSettings.FontName,
                                 FontSize = FooterSettings.FontSize,
                                 HtmUrl = FooterSettings.HtmlURL,
                                 Left = FooterSettings.Left,
                                 Line = FooterSettings.Line,
                                 Right = FooterSettings.Right,
                                 Spacing = FooterSettings.Spacing
                            },
                            WebSettings =
                            {
                                DefaultEncoding = WebSettings.DefaultEncoding,
                                UserStyleSheet = WebSettings.UserStylesheet
                            }
                        }
                    }
                };

                return Convert.ToBase64String(_converter.Convert(doc));
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
