using System;

namespace Laba8
{
    class SubtitleConverter
    {
        private Subtitle[] convertedSubtitles;
        public Subtitle[] GetConvertedSubtitles(string[] subtitles)
        {
            convertedSubtitles = new Subtitle[subtitles.Length];
            for (int i = 0; i < subtitles.Length; i++)
            {
                convertedSubtitles[i] = ConvertTextToSubtitleData(subtitles[i]);
            }

            return convertedSubtitles;
        }
        public Subtitle ConvertTextToSubtitleData(string text)
        {
            var data = text.Split(" ");
            var startTime = Convert.ToDouble(data[0].Split(":")[0]) * 60 + Convert.ToDouble(data[0].Split(":")[1]);
            var endTime = Convert.ToDouble(data[2].Split(":")[0]) * 60 + Convert.ToDouble(data[2].Split(":")[1]);

            string side = "";
            string color = "";
            string subtitleText = "";
            if (data[3].StartsWith("["))
            {
                side = data[3].Substring(1, data[3].Length-2);
                color = data[4].Substring(0, data[4].Length-1);
                for(int i = 5; i < data.Length; i++)
                {
                    subtitleText += data[i];
                }

                return new Subtitle(startTime, endTime, side, color, subtitleText);
            }
            
            for( int i = 3; i < data.Length; i++)
            {
                subtitleText+= data[i] + " ";
            }

            return new Subtitle(startTime, endTime, side, color, subtitleText);
        }
    }   
}
