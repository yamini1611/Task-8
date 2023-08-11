using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Task_8
{
    internal class Program
    {
        public int id;
        public string name;
        public string Degree;
        public double salary;
        public double bonus;
        public string Details;

        public void Trainee()
        {
            Console.WriteLine("Enter Employee id:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Trainee Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Trainee Degree: ");
            Degree = Console.ReadLine();
            Console.WriteLine("Enter Trainee Salary: ");
            salary = Convert.ToDouble(Console.ReadLine());

           
            bonus = salary * 0.1; 

            Details += ($"\nTrainee {name}'s id is {id}, trainee has Degree {Degree}, salary is {salary}, and bonus is {bonus}");
            Console.WriteLine(Details);
        }
        public void display()
        {
            FileInfo file = new FileInfo(@"E:/C# Read Write.txt");
            FileStream fileStream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(fileStream);
            try
            {
                writer.WriteLine(Details);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                writer.Close();
                fileStream.Close();
            }
        }
        public void GenerateCSV(List<string> lines)
        {
            FileInfo file = new FileInfo(@"E:/C# Report.csv");
            FileStream fileStream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(fileStream);
            foreach (string line in lines)
            {
                writer.WriteLine(line);
            }
            writer.Close();
            fileStream.Close();
        }

        public void DisplayCSV(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public void Append()
        {
            FileInfo file = new FileInfo(@"E:/C# Read Write.txt");
            FileStream fileStream = file.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter writer1 = new StreamWriter(fileStream);
            try
            {
  
                writer1.WriteLine($"\nTrainee {name}'s id is {id} and trainee has Degree {Degree}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                writer1.Close();
                fileStream.Close();
            }
        }

        public void Copy()
        {
            string SourceFile = @"E:/C# Read Write.txt";
            string destinationFile = @"E:/C# Copytext.txt";

            try
            {
                File.Copy(SourceFile, destinationFile);
                Console.WriteLine("copied Successfully");
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
        }
        public void Move()
        {
            string SourceFile = @"E:/C# Copytext.txt";
            string destinationFile = @"E:/C# Move.txt";
            try
            {
                File.Move(SourceFile, destinationFile);
                Console.WriteLine("Moved Successfully");
            }
            catch (Exception ei)
            {
                Console.WriteLine(ei.Message);
            }

        }
        public void Delete()
        {
            string file = @"E:/C# Copytext.txt";
            if (File.Exists(file))
            {
                Console.WriteLine("file exists , so deleting the file");
                File.Delete(file);
            }
            else
            {
                Console.WriteLine("file does not exist so creating a file");
                FileInfo file1 = new FileInfo(@"E:/C# Copytext.txt");
                FileStream fileStream = file1.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter writer = new StreamWriter(fileStream);

                try
                {
                    writer.WriteLine("file deleted and created successfully");
                    Console.WriteLine(file1);
                }
                catch (Exception y)
                {
                    Console.WriteLine(y.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Trainee();

            Console.WriteLine("Enter number of employees:");
            int count = Convert.ToInt32(Console.ReadLine());

            List<string> employeeLines = new List<string>();

            for (int i = 0; i < count; i++)
            {
                program.Trainee();
                employeeLines.Add($"{program.id},{program.name},{program.Degree},{program.salary},{program.bonus}");
            }

            string csvFilePath = @"E:/C# Report.csv";

            program.GenerateCSV(employeeLines);
            program.display();
            Console.WriteLine("-----------------------");
            program.Append();
            Console.WriteLine("-----------------------");
            program.Copy();
            Console.WriteLine("-----------------------");
            program.Move();
            Console.WriteLine("-----------------------");
            program.Delete();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Employee details stored in CSV file:");
            program.DisplayCSV(csvFilePath);
            Console.WriteLine("-----------------------");
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine($"Application Name: {assembly.GetName().Name}");
            Console.WriteLine($"Version: {assembly.GetName().Version}");
            Console.WriteLine($"Location: {assembly.Location}");

            Console.ReadLine();
        }
    }
}
