using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Nullifier
{
    internal class Program
    {
        static void Main()
        {
            List<KDA> list1 = new List<KDA>();
            List<KDA> list = new List<KDA>();
            KDA invoker = new KDA("invoker", 10, 5, 3);
            KDA teamlar = new KDA("templar", 5, 0, 7);
            list.Add(invoker);
            list.Add(teamlar);
            
            
            Console.WriteLine("Enter file path:");
            string filePath = Console.ReadLine();
            

            FileWork fileManager = new FileWork();

            Console.WriteLine("Press F1 to save or Escape to exit");
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
                list1 = fileManager.LoadFile(filePath, list);
                for (int i = 0; i < list1.Count; i++)
                {
                    Console.WriteLine(list[i].namePerson);
                    Console.WriteLine(list[i].kill);
                    Console.WriteLine(list[i].death);
                    Console.WriteLine(list[i].assist);
                }
                if (keyInfo.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    string filePath1 = Console.ReadLine();
                    fileManager.SaveFile(list, filePath1);
                    Console.WriteLine("File saved successfully");
                }

            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}