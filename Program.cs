using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileName = "BirthdayList.txt";
            var outputFileName = "OutputBirthdayList.txt";
            var birthdayList = ReadBirthdayListFromFile(fileName);
            birthdayList = birthdayList.OrderByDescending(x => x.Date).ToList();
            WriteBirthdayListToFile(outputFileName, birthdayList);
        }

        public static List<BirthDay> ReadBirthdayListFromFile(string path)
        {
            var infoList = File.ReadAllLines(path);
            var birthdayList = new List<BirthDay>();
            foreach (var line in infoList)
            {
                var lineParts = line.Split(new string[] { ";" }, StringSplitOptions.None);
                var birthday = new BirthDay();
                birthday.Person = lineParts[0];
                var dateParts = lineParts[1].Split(new string[] { "_" }, StringSplitOptions.None);
                var year = int.Parse(dateParts[0]);
                var month = int.Parse(dateParts[1]);
                var day = int.Parse(dateParts[2]);
                birthday.Date = new DateTime(year, month, day);
                birthdayList.Add(birthday);
            }
            return birthdayList;
        }

        public static void WriteBirthdayListToFile(string path, List<BirthDay> birthdayList)
        {
            var birthdaysStrings = new List<string>();
            foreach (var birthday in birthdayList)
            {
                birthdaysStrings.Add(birthday.Person + " " + birthday.Date.ToString("dd.MM.yyyy"));
            }
            File.WriteAllLines(path, birthdaysStrings);
        }
    }
}