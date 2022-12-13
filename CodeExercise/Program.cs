using System;
using System.Collections;
using System.IO;

namespace CodeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int numericUserInput;
            Console.Write("Please enter an integer: ");
            // Ensure the user enters numbers only!
            while (!Int32.TryParse(Console.ReadLine(), out numericUserInput))
            {
                Console.WriteLine("This value is not valid, please enter integers only: ");
            }
            Console.WriteLine("Your input: {0}", numericUserInput);
            UpdateTextFile(numericUserInput);
        }

        public static string CreateFileAppendText(int numericUserInput)
        {
            var NumberList = new ArrayList();
            for(int i = 0; i <= numericUserInput; i++)
            {
                NumberList.Add("");
            }
            return String.Join(",", NumberList.ToArray());
        }

        static void UpdateTextFile(int numericUserInput)
        {
            string fileName = "C:\\Users\\jeffe\\source\\repos\\CodeExercise\\CodeExercise\\Files\\sampleTextFile.txt";
            string tempfile = Path.GetTempFileName();
            using (var writer = new StreamWriter(tempfile))
            using (var reader = new StreamReader(fileName))
            {
                writer.WriteLine(CreateFileAppendText(numericUserInput));
                while (!reader.EndOfStream)
                {
                    writer.WriteLine(reader.ReadLine());
                }
            }
            File.Copy(tempfile, fileName, true);
            File.Delete(tempfile);
        }
    }
}
