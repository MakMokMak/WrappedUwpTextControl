using System;
using System.Collections.Generic;
using UWPD = Windows.UI.Xaml.Documents;

namespace WrappedUwpTextBlock4.WrappedUwpControls.Containers
{
    internal class UwpInlineBuilder
    {
        private readonly List<UWPD.Inline> _inlines = new List<UWPD.Inline>();

        public void AddText(string text)
        {
            var run = new UWPD.Run
            {
                Text = text
            };
            _inlines.Add(run);
        }

        public void AddLink(string text, string uriString)
        {
            AddLink(text, new Uri(uriString));
        }

        public void AddLink(string text, Uri uri)
        {
            var run = new UWPD.Run
            {
                Text = text
            };
            var hypelink = new UWPD.Hyperlink
            {
                NavigateUri = uri
            };
            hypelink.Inlines.Add(run);
            _inlines.Add(hypelink);
        }

        public void AddLineBreak()
        {
            var lineBreak = new UWPD.LineBreak();
            _inlines.Add(lineBreak);
        }

        public IEnumerable<UWPD.Inline> ToInLines()
        {
            return _inlines;
        }
    }
}
