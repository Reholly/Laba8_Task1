using System;
using System.Timers;


namespace Laba8
{
    internal class SubtitleDisplay
    {
        private Subtitle[] subtitles;
        private int currentTime = 0;
        public SubtitleDisplay(Subtitle[] subtitles)
        {
            this.subtitles = subtitles;
        }

        public void Start()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += Tick;
            timer.AutoReset = true;
            timer.Enabled = true;

        }
        private void Tick(Object obj, ElapsedEventArgs e)
        {
            foreach (var subtitle in subtitles)
            {
                if (subtitle.SubtitleStart == currentTime) WriteSubtitle(subtitle);
                else if (subtitle.SubtitleEnd == currentTime) DeleteSubtitle(subtitle);
            }
            currentTime++;
        }

        private void DeleteSubtitle(Subtitle subtitle)
        {
            SetSubtitlePlace(subtitle);
            for (int i = 0; i < subtitle.SubtitleText.Length; i++)
                Console.Write(" ");
        }

        private void WriteSubtitle(Subtitle subtitle)
        {
            SetSubtitlePlace(subtitle);
            Console.Write(subtitle.SubtitleText);

        }
        private void SetSubtitlePlace(Subtitle subtitle)
        {
            switch (subtitle.DisplaySide)
            {
                case "Right":
                    Console.SetCursorPosition(GetRightPosition(subtitle)[0], GetRightPosition(subtitle)[1]);
                    break;
                case "Left":
                    Console.SetCursorPosition(GetLeftPosition(subtitle)[0], GetLeftPosition(subtitle)[1]);
                    break;
                case "Bottom":
                    Console.SetCursorPosition(GetBottomPosition(subtitle)[0], GetBottomPosition(subtitle)[1]);
                    break;
                case "Top":
                    Console.SetCursorPosition(GetTopPosition(subtitle)[0], GetTopPosition(subtitle)[1]);
                    break;
                default:
                    break;
            }       
        }
        private int[] GetRightPosition(Subtitle sub)
        {
            int centerX = Console.WindowWidth - (sub.SubtitleText.Length);
            int centerY = (Console.WindowHeight / 2) - (sub.SubtitleText.Length) + 1;

            return new int[] { centerX, centerY };
        }

        private int[] GetLeftPosition(Subtitle sub)
        {
            int centerX = sub.SubtitleText.Length;
            int centerY = (Console.WindowHeight / 2) - (sub.SubtitleText.Length);

            return new int[] { centerX, centerY };
        }

        private int[] GetBottomPosition(Subtitle sub)
        {
            int centerX = (Console.WindowWidth / 2) - (sub.SubtitleText.Length / 2);
            int centerY = Console.WindowHeight - 2;

            return new int[] { centerX, centerY };
        }

        private int[] GetTopPosition(Subtitle sub)
        {
            int centerX = (Console.WindowWidth / 2) - (sub.SubtitleText.Length / 2);
            int centerY = 1;

            return new int[] { centerX, centerY };
        }
    }
}