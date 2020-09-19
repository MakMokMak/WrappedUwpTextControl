using System;
using System.Collections.Generic;

namespace WrappedUwpTextBlock4.WrappedUwpControls.Containers
{
    public class InlineDataContainer
    {
        public InlineDataContainer(InlineDataOperation operation = InlineDataOperation.Replace)
        {
            Operation = operation;
        }

        private readonly List<(ContaintKind, string, string)> _container = new List<(ContaintKind, string, string)>();

        public InlineDataOperation Operation { get; }

        public List<(ContaintKind containtKind, string text, string urlString)> Container
        {
            get => _container;
        }

        public void AddText(string text)
        {
            if (text == null)
            {
                throw new ArgumentException(nameof(text));
            }

            _container.Add((ContaintKind.Text, text, null));
        }

        public void AddLink(string text, string uriString)
        {
            if (text == null)
            {
                throw new ArgumentException(nameof(text));
            }
            if (uriString == null)
            {
                throw new ArgumentException(nameof(uriString));
            }

            _container.Add((ContaintKind.Uri, text, uriString));
        }

        public void AddLineBreak()
        {
            _container.Add((ContaintKind.NewLine, null, null));
        }
    }

    /// <summary>
    /// <see cref="InlineDataContainer.Operation"/> へ設定する InlineDataOperation 列挙型です。
    /// </summary>
    public enum InlineDataOperation
    {
        /// <summary>
        /// 追加操作を表します。
        /// </summary>
        Append,
        /// <summary>
        /// 置き換え操作を表します。
        /// </summary>
        Replace,
    }

    /// <summary>
    /// エレメントの種別を表す ContaintKind 列挙型です。
    /// </summary>
    public enum ContaintKind
    {
        /// <summary>
        /// テキストを表します。
        /// </summary>
        Text,
        /// <summary>
        /// URI を表します
        /// </summary>
        Uri,
        /// <summary>
        /// 改行を表します。
        /// </summary>
        NewLine,
    }
}
