using Laba8;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {    
        string path = Environment.CurrentDirectory + "\\Subtitles.txt";
        var fileStrings = File.ReadAllLines(path);

        SubtitleConverter converter = new SubtitleConverter();
        var subtitles = converter.GetConvertedSubtitles(fileStrings);
        SubtitleDisplay display = new SubtitleDisplay(subtitles);

        display.Start();

        Console.ReadLine();
    }
}