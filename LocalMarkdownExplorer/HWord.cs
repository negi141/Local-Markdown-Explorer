using System;
using System.Drawing;

namespace LocalMarkdownExplorer
{
    class HWord
    {
        public string token { get; set; }
        public Color color { get; set; }
        public FontStyle fontStyle { get; set; }
        public float fontSize { get; set; }

        public HWord(string token, Color color, FontStyle fontStyle, float fontSize)
        {
            this.token = token;
            this.color = color;
            this.fontStyle = fontStyle;
            this.fontSize = fontSize;
        }
    }
}
