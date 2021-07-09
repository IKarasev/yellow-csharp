using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Streams and Files
            string curPath = Directory.GetCurrentDirectory();
            Console.WriteLine(curPath);

            // Writing to file
            StreamWriter wr = new StreamWriter("test.txt");
            wr.WriteLine("Hello World!");
            wr.WriteLine("Second line!");
            wr.WriteLine("Third line!");
            wr.Close();

            // Read from file
            StreamReader re = new StreamReader("test.txt");
            Console.WriteLine("Reading firs line: ");
            string line = re.ReadLine();
            Console.WriteLine($"    current line: {line}");

            // read until end of file
            Console.WriteLine("Read rest of file: ");
            while (re.EndOfStream == false)
            {
                line = re.ReadLine();
                Console.WriteLine($"    current line: {line}");
            }

            re.Close();


            Console.ReadKey();
        }
    }
}
