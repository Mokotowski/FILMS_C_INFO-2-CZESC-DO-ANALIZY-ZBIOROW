using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



/*

USE [DbStreaming]
GO

INSERT INTO [dbo].[Video]
           ([Nazwa]
           ,[Format]
           ,[Path]
           ,[Fps]
           ,[Height]
           ,[Width]
     VALUES







GO







 */


namespace VideoFileProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] extensions = { ".3g2", ".avi", ".mkv", ".mp4", ".mts", ".ts" };
            string folderPath = @"F:\Filmy gotowe";
            string outputFile = @"F:\video_file_properties.txt";
            string inputFile = @"F:\resolution.txt";
            List<string> list = new List<string>();

            foreach (string line in File.ReadLines(inputFile))
            {
                list.Add(line);

            }
            StringBuilder sb = new StringBuilder();

            int i = 0;

            string[] files = Directory.GetFiles(folderPath, "*");
            foreach (string file in files)
            {

                FileInfo fileInfo = new FileInfo(file);

                string Nazwa = fileInfo.Name;
                int index = Nazwa.IndexOf(".");
                if (index > 0)
                {
                    Nazwa = Nazwa.Substring(0, index);
                }

                string format = fileInfo.Name;
                int j = format.IndexOf(".");
                if (j > 0)
                {
                    format = format.Substring(j);
                }

                sb.AppendLine($"('" + Nazwa + "','" + format + "','" + fileInfo.Name + "'," + list.ElementAt(i) + "'),");
                i++;
            }

            File.WriteAllText(outputFile, sb.ToString());
            Console.WriteLine("Właściwości plików zostały zapisane w pliku " + outputFile);
        }
    }
}
