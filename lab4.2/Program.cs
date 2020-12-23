using System;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace lab4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Directory.GetFiles($@"{Directory.GetCurrentDirectory()}\pic\");
            string[] names = Directory.GetFiles($@"{Directory.GetCurrentDirectory()}\pic\").Select(Path.GetFileName).ToArray();
            Regex regexExtForImage = new Regex("^((.bmp)|(.gif)|(.tiff?)|(.jpe?g)|(.png))$", RegexOptions.IgnoreCase);
            for (int i = 0; i < path.Length; i++)
            {
                try
                {
                    if (regexExtForImage.IsMatch(Path.GetExtension(path[i])))
                    {
                        Bitmap bitmap = (Bitmap)Bitmap.FromFile(path[i]);
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                        bitmap.Save($@"{Directory.GetCurrentDirectory()}\pic\" + names[i].Split('.')[0] + "-mirrored.gif", ImageFormat.Gif);
                        Console.WriteLine("Зображення створено та збережено у {0}.", ($@"{Directory.GetCurrentDirectory()}\pic\"));
                    }
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine("Файл має розширення зображення, проте не є зображенням");
                }
            }
            Console.ReadKey();
        }
    }
}
