using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace TeachersData
{
    internal class Program
    {
        static string Path = @"teacher.txt";
        static List<Teacher> Listteacher = new List<Teacher>();
        static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n1. ADD\n2. SEARCH\n3. UPDATE\n4. DELETE\n5. DISPLAY_LIST\n6. EXIT");
                Console.WriteLine("\nEnter your choice");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Addteacher();
                        break;
                    case 2:
                        SearchTeacher();
                        break;
                    case 3:
                        UpdateTeacher();
                        break;
                    case 4:
                        DeleteTeacher();
                        break;
                    case 5:
                        DisplayAllTeacher();
                        break;
                    case 6:
                        exit = true;
                        break;
                }
            }
        }
        internal class Teacher
        {

            public int Id { get; set; }
            public string Name { get; set; }
            public int Class { get; set; }
            public char Section { get; set; }
        }
        static void Addteacher()
        {
            FileStream file = new FileStream(Path, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            Teacher teacher = new Teacher();

            Console.WriteLine("\nEnter the Id of teacher");
            teacher.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Name of teacher");
            teacher.Name = Console.ReadLine();
            Console.WriteLine("Enter the Class of teacher");
            teacher.Class = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Section of teacher");
            teacher.Section = Convert.ToChar(Console.ReadLine());

            writer.WriteLine(teacher.Id + "," + teacher.Name + "," + teacher.Class + "," + teacher.Section);

            writer.Flush();
            writer.Close();
            file.Close();
        }
        static void SearchTeacher()
        {
            string[] arrteacher = File.ReadAllLines(Path);

            Console.WriteLine("\nEnter ID to search");
            int search = int.Parse(Console.ReadLine());
            List<Teacher> Listteacher = new List<Teacher>();
            foreach (string line in arrteacher)
            {
                string[] l = line.Split(',');
                Teacher teacher = new Teacher();
                teacher.Id = Convert.ToInt32(l[0]);
                teacher.Name = l[1];
                teacher.Class = Convert.ToInt32(l[2]);
                teacher.Section = Convert.ToChar(l[3]);
                Listteacher.Add((teacher));
            }
            foreach (Teacher t2 in Listteacher)
            {
                if (search == t2.Id)
                {
                    Console.WriteLine($" \nTeachers Data found  \nId={t2.Id}  Name={t2.Name}  Class={t2.Class}   Section={t2.Section}");
                    break;
                }
            }
        }
        static void UpdateTeacher()
        {
            string[] arrteacher = File.ReadAllLines(Path);
            List<Teacher> Listteacher = new List<Teacher>();
            Console.WriteLine("\nEnter ID to Update Teacher data");
            int id = int.Parse(Console.ReadLine());

            foreach (string line in arrteacher)
            {
                string[] l = line.Split(',');
                Teacher teacher = new Teacher();
                teacher.Id = Convert.ToInt32(l[0]);
                teacher.Name = l[1];
                teacher.Class = Convert.ToInt32(l[2]);
                teacher.Section = Convert.ToChar(l[3]);
                Listteacher.Add(teacher);
            }

            foreach (Teacher t1 in Listteacher)
            {
                if (t1.Id == id)
                {
                    Console.WriteLine("Enter Name of the teacher");
                    string Name1 = Console.ReadLine();
                    Console.WriteLine("Enter Class of the teacher ");
                    int Class1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Section of the teacher");
                    char Section1 = Convert.ToChar(Console.ReadLine());

                    t1.Name = Name1;
                    t1.Class = Class1;
                    t1.Section = Section1;

                    Console.WriteLine("Updated teacher data is");
                    Console.WriteLine($"Id={t1.Id} Name={t1.Name} Class={t1.Class} Section{t1.Section}");
                    break;

                }
            }
            int count = 0;
            string[] arr = new string[Listteacher.Count];
            foreach (Teacher t in Listteacher)
            {
                string s = ($"{t.Id},{t.Name},{t.Class},{t.Section}");
                arr[count] = s;
                count++;
            }
            File.WriteAllLines(Path, arr);
        }
        static void DeleteTeacher()
        {
            string[] arrteacher = File.ReadAllLines(Path);
            List<Teacher> Listteacher = new List<Teacher>();
            Console.WriteLine("\nEnter ID to delete teacher data");
            int delete = int.Parse(Console.ReadLine());

            foreach (string line in arrteacher)
            {
                string[] l = line.Split(',');
                Teacher teacher = new Teacher();
                teacher.Id = Convert.ToInt32(l[0]);
                teacher.Name = l[1];
                teacher.Class = Convert.ToInt32(l[2]);
                teacher.Section = Convert.ToChar(l[3]);
                Listteacher.Add(teacher);
            }

            foreach (Teacher t1 in Listteacher)
            {
                if (t1.Id == delete)
                {
                    Listteacher.Remove(t1);
                    Console.WriteLine("Teacher data deleted");
                    break;
                }
            }
            int count = 0;
            string[] arr = new string[Listteacher.Count];
            foreach (Teacher t in Listteacher)
            {
                string s = ($"{t.Id},{t.Name},{t.Class},{t.Section}");
                arr[count] = s;
                count++;
            }
            File.WriteAllLines(Path, arr);
        }
        static void DisplayAllTeacher()
        {


            List<Teacher> Listteacher = new List<Teacher>();

            string[] arrteacher = File.ReadAllLines(Path);
            foreach (string line in arrteacher)
            {
                string[] l = line.Split(',');
                Teacher teacher = new Teacher();
                teacher.Id = Convert.ToInt32(l[0]);
                teacher.Name = l[1];
                teacher.Class = Convert.ToInt32(l[2]);
                teacher.Section = Convert.ToChar(l[3]);
                Listteacher.Add(teacher);
            }
            if (Listteacher.Count == 0)
            {
                Console.WriteLine("Teacher List is empty");
            }
            else
            {
                Console.WriteLine("List of Teachers present in the file\n");
                foreach (Teacher t in Listteacher)
                {
                    Console.WriteLine($"Id={t.Id} Name={t.Name} Class{t.Class} Section={t.Section}");
                }

                Console.WriteLine("\nList of Teachers After Sorting\n");
                Listteacher.Sort((a, b) => a.Id.CompareTo(b.Id));
                foreach (Teacher t in Listteacher)
                {
                    Console.WriteLine($"Id={t.Id} Name={t.Name} Class{t.Class} Section={t.Section}");
                }
            }
        }

    }
}
