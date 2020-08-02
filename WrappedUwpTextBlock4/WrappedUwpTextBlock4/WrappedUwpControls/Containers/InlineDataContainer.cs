using System;
using System.Collections.Generic;
using UWPD = Windows.UI.Xaml.Documents;

namespace WrappedUwpTextBlock4.WrappedUwpControls.Containers
{
    public class InlineDataContainer
    {
        public InlineDataContainer(InlineDataOperation operation = InlineDataOperation.Replace)
        {
            Operation = operation;
        }

        private readonly UwpInlineBuilder _builder = new UwpInlineBuilder();

        public InlineDataOperation Operation { get; }

        public void AddText(string text)
        {
            if (text == null)
            {
                throw new ArgumentException(nameof(text));
            }

            _builder.AddText(text);
        }

        public void AddLink(string text, string uriString)
        {
            AddLink(text, new Uri(uriString));
        }

        public void AddLink(string text, Uri uri)
        {
            if (text == null)
            {
                throw new ArgumentException(nameof(text));
            }
            if (uri == null)
            {
                throw new ArgumentException(nameof(uri));
            }

            _builder.AddLink(text, uri);
        }

        public void AddLineBreak()
        {
            _builder.AddLineBreak();
        }

        public IEnumerable<UWPD.Inline> ToInlines()
        {
            return _builder.ToInLines();
        }
    }

    public enum InlineDataOperation
    {
        Append,
        Replace,
    }
}
