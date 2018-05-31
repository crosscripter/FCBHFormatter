using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Path = @"C:\FCBH\";

            string[] Testaments = 
            { 
                "OT", 
                "NT" 
            };

            string[] books = 
            {
                "Genesis",
                "Exodus",
                "Leviticus",
                "Numbers",
                "Deuteronomy",
                "Joshua",
                "Judges",
                "Ruth",
                "1Samuel",
                "2Samuel",
                "1Kings",
                "2Kings",
                "1Chronicles",
                "2Chronicles",
                "Esther",
                "Nehemiah",
                "Ezra",
                "Job",
                "Psalms",
                "Proverbs",
                "Ecclesiastes",
                "SongofSongs",
                "Isaiah",
                "Jeremiah",
                "Lamentations",
                "Ezekiel",
                "Daniel",
                "Hosea",
                "Joel",
                "Amos",
                "Obadiah",
                "Jonah",
                "Micah",
                "Nahum",
                "Habakkuk",
                "Zephaniah",
                "Haggai",
                "Zechariah",
                "Malachi",

                "Matthew",
                "Mark",
                "Luke",
                "John",
                "Acts",
                "Romans",
                "1Corinthians",
                "2Corinthians",
                "Galatians",
                "Ephesians",
                "Philippians",
                "Colossians",
                "1Thess",
                "2Thess",
                "1Timothy",
                "2Timothy",
                "Titus",
                "Philemon",
                "Hebrews",
                "James",
                "1Peter",
                "2Peter",
                "1John",
                "2John",
                "3John",
                "Jude",
                "Revelation"
            };

            foreach (var testament in Testaments)
            {
                foreach (var file in Directory.GetFiles(Path + @"\" + testament,
                                                    "*.mp3", SearchOption.AllDirectories))
                {
                    var info = new FileInfo(file);
                    var directory = info.Directory.Name;
                    var name = info.Name;
                    string[] parts = name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                    var prefix = parts[0];

                    // var number = int.Parse(prefix.Substring(1));
                    var chapter = int.Parse(parts[1]);
                    var book = parts[2];
                    book = book.Replace("ENGKJVC2DA.mp3", "");
                    var number = Array.IndexOf(books, book) + 1;

                    var newName = string.Format(@"{0:00}-{1}.mp3", chapter, book);

                    if (book == "Psalms")
                    {
                        newName = string.Format(@"{0:000}-{1}.mp3", chapter, book);
                    }

                    var newDirectory = string.Format(@"{0}\{1:00}-{2}", Path, number, directory);
                    string newPath = string.Format(@"{0}\{1}", newDirectory, newName);

                    try
                    {
                        if (!Directory.Exists(newDirectory))
                        {
                            Directory.CreateDirectory(newDirectory);
                        }

                        Console.WriteLine("{0} => {1}", info.FullName, newPath);
                        File.Copy(info.FullName, newPath);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
