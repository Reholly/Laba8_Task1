using System;

namespace Laba8
{
    class Subtitle
    {
        public double SubtitleStart { get; private set; }
        public double SubtitleEnd { get; private set; }
        public string DisplaySide { get; private set; }
        public string SubtitleColor { get; private set; }
        public string SubtitleText { get; private set; }

        public Subtitle(double start, double end, string side, string color, string text)
        {
            SubtitleStart = start;
            SubtitleEnd = end;
            DisplaySide = side;
            SubtitleColor = color;
            SubtitleText = text;

            if (DisplaySide == "") DisplaySide = "Bottom";
            if (SubtitleColor == "") SubtitleColor = "White";
        }      
    }
}
