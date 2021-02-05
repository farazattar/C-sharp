using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*public class ReadTextFileEx
{
    static void Main()
    {
        string content = File.ReadAllText(@"C:\Users\p\Documents\Visual Studio 2012\Projects\ConsoleApplication3\ConsoleApplication3\thermopylae.txt", Encoding.UTF8);

        Console.WriteLine(content);
    }
}*/
/*public class ReadTextFileEx2
{
    static void Main()
    {
        string[] lines = File.ReadAllLines(@"C:\Users\p\Documents\Visual Studio 2012\Projects\ConsoleApplication3\ConsoleApplication3\thermopylae.txt", Encoding.UTF8);

        foreach (string line in lines)
        {

            Console.WriteLine(line);
        }
    }
}*/
namespace Open
{
    public class ReadTextFileEx3
    {
        static void Main()
        {
            string content = String.Empty; ;
            FileStream fs = new FileStream(@"C:\Users\p\Documents\Visual Studio 2012\Projects\ConsoleApplication3\ConsoleApplication3\thermopylae.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fs, Encoding.UTF8))
            {
                content = streamReader.ReadToEnd();
            }

            Console.WriteLine(content);
        }
    }
}