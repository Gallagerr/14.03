using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace modul18
{
  class Program
  {
    static void Main(string[] args)
    {
      DateTime date1 = new DateTime(1995, 1, 01);
      DateTime date2 = new DateTime(2004, 1, 01);
      DateTime date3 = new DateTime(2015, 1, 01);
      List<Book> books = new List<Book>();

      Book book = new Book
      {
        Name = "1001 рецепт готовки бананов",
        Price = 4000,
        AuthorName = "Д.Грин",
        Year = date1
      };
      Book book2 = new Book
      {
        Name = "Лом против всего",
        Price = 10000,
        AuthorName = "Роберт Прайс",
        Year = date2
      };
      Book book3 = new Book
      {
        Name = "Как не угодить в яму",
        Price = 3000,
        AuthorName = "М.Шельман",
        Year = date3
      };
      books.Add(book);
      books.Add(book2);
      books.Add(book3);

      string driveName = "";
      DriveInfo[] drives = DriveInfo.GetDrives();


      for (int i = 0; i < drives.Length; i++)
      {
        Console.WriteLine($"{i}.{drives[i].Name}");
      }

      Console.WriteLine("Введите номер диска, на который будет записан файл");

      string driveNumberAsString = Console.ReadLine();

      int driveNumber = 0;
      if (!int.TryParse(driveNumberAsString, out driveNumber))
      {
        Console.WriteLine("Ошибка ввода, будет произведена запись на первый указанный диск.");
      }
      driveName = drives[driveNumber].Name;

      BinaryFormatter formatter = new BinaryFormatter();
      if (!Directory.Exists(driveName + @"/data"))
      {
        Directory.CreateDirectory(driveName + @"/data");
      }
      using (FileStream stream = File.Create(driveName + @"/data/book.bin"))
      {
        formatter.Serialize(stream, books);
      }

      using (FileStream stream = File.OpenRead(driveName + @"/data/book.bin"))
      {
        var resultPerson = formatter.Deserialize(stream) as List<Book>;
        int count = 1;
        foreach (var element in resultPerson)
        {
          Console.WriteLine(count + ". Название книги: " + element.Name);
          Console.WriteLine("   Цена книги: " + element.Price);
          Console.WriteLine("   Автор книги: " + element.AuthorName);
          Console.WriteLine("   Год книги: " + element.Year.Year + "\n");
          count++;
        }

      }


      Console.ReadLine();
    }
  }
}
