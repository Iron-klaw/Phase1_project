using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class TeacherDetails
    {
        public int Id;
        public string TName;
        public int TClass;
        public string TSection;
        public string subject;

        public TeacherDetails()
        {

        }

        public TeacherDetails(int id, string name, int cls, string section, string subject)
        {
            this.Id = id;
            this.TName = name;
            this.TClass = cls;
            this.TSection = section;
            this.subject = subject;
        }
    }

    class Teacher
    {
        //public List<TeacherDetails> teachers;

        //public Teacher()
        //{
        //    teachers = new List<TeacherDetails>();
        //}


        public void AddTeacher(TeacherDetails t, StreamWriter sw)
        {
            //teachers.Add(t);
            sw.WriteLine("\n" + t.Id + "," + t.TName + "," + t.TClass + ","  + t.TSection + "," + t.subject + "\n");
        }

        public void GetAllTeachers(StreamReader sr)
        {
            while (sr.Peek() >= 0)
            {
                string det = sr.ReadLine();
                Console.WriteLine(det);
            }
        }

        public void UpdateTeachers(TeacherDetails t, string path)
        {
            List<string> list1 = new List<string>();
            StreamReader sr = new StreamReader(path);
            int status = 0;
            while (sr.Peek() >= 0)
            {
                string det = sr.ReadLine();
                List<string> data = det.Split(",", 5).ToList();
                string s2;
                if (data[0] == t.Id.ToString())
                {
                    status = 1;
                    data[1] = t.TName;
                    data[2] = t.TClass.ToString();
                    data[3] = t.TSection;
                    data[4] = t.subject;
                    s2 = string.Join(",", data);
                    list1.Add(s2);
                }
                else
                {
                    s2 = string.Join(",", data);
                    list1.Add(s2);
                }
            }
            sr.Close();
            string s3 = string.Join("\n", list1);
            StreamWriter sw3 = new StreamWriter(path);
            sw3.WriteLine(s3);
            sw3.Close();
            if (status == 0)
                Console.WriteLine("Teacher ID not found");            
        }

        public void DeleteTeachers(int ID, string path)
        {
            List<string> list2 = new List<string>();
            StreamReader sr = new StreamReader(path);
            int status = 0;
            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();
                List<string> data = line.Split(",", 5).ToList();
                string s2;
                if (data[0] == ID.ToString())
                {

                }
                else
                {
                    s2 = string.Join(",", data);
                    list2.Add(s2);
                }
            }
            sr.Close();
            string s3 = string.Join("\n", list2);
            StreamWriter sw3 = new StreamWriter(path);
            sw3.WriteLine(s3);
            sw3.Close();
            if (status == 1)
                Console.WriteLine("Teacher ID not found");
            else
                Console.WriteLine("\nTeacher ID deleted");
            
        }

        public void GetTeacherByID(int Id, StreamReader sr)
        {
            int status = 0;
            while (sr.Peek() >= 0)
            {
                string det = sr.ReadLine();
                List<string> data = det.Split(",", 5).ToList();
                string s2;
                if (data[0] == Id.ToString())
                {
                    status = 1;
                    s2 = string.Join(",", data);
                    Console.WriteLine();
                    Console.WriteLine(s2);
                }                             
            }
            if (status == 0)
                Console.WriteLine("Teacher ID not found");
        }
    }

    class Phase_1_Project
    {
        static void Main(string[] args)
        {
            Teacher teac = new Teacher();
            string path = @"C:\Users\11035902\Teacher.txt";
            int n = 0;

            while (n==0)
            {
                Console.WriteLine("\nEnter your choice:\n 1] Get all Teacher Details\n 2] Add Teacher Details\n 3] Update Teacher Details based on ID\n 4] Delete Teacher Details based on ID\n 5] Get Teacher Details by ID \n 6] Exit");
                int choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        StreamReader sr = new StreamReader(path);
                        teac.GetAllTeachers(sr);
                        sr.Close();
                        break;

                    case 2:
                        TeacherDetails t1 = new TeacherDetails();
                        StreamWriter sw = new StreamWriter(path, append: true);
                        Console.WriteLine(" Enter ID: ");
                        int ID = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(" Enter Name: ");
                        string TName = Console.ReadLine();

                        Console.WriteLine(" Enter Class:");
                        int TClass = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Section:");
                        string sec = Console.ReadLine();
                                              
                        Console.WriteLine("Enter Subject:");
                        string sub = Console.ReadLine();

                        t1 = new TeacherDetails(ID, TName, TClass, sec, sub);
                        teac.AddTeacher(t1, sw);
                        sw.Close();
                        break;

                    case 3:
                        TeacherDetails t2 = new TeacherDetails();
                        Console.WriteLine(" Enter ID: ");
                        int ID1 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(" Enter Name: ");
                        string TName1 = Console.ReadLine();

                        Console.WriteLine(" Enter Class:");
                        int TClass1 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Section:");
                        string sec1 = Console.ReadLine();

                        Console.WriteLine(" Enter Subject: ");
                        string sub1 = Console.ReadLine();

                        t2 = new TeacherDetails(ID1, TName1, TClass1, sec1, sub1);
                        teac.UpdateTeachers(t2, path);
                        break;

                    case 4:
                        TeacherDetails t3 = new TeacherDetails();
                        Console.WriteLine(" Enter ID: ");
                        int ID2 = Convert.ToInt32(Console.ReadLine());
                                               
                        teac.DeleteTeachers(ID2, path);
                        break;

                    case 5:
                        StreamReader sr1 = new StreamReader(path);
                        Console.WriteLine("Enter ID: ");
                        int ID3 = int.Parse(Console.ReadLine());
                        teac.GetTeacherByID(ID3, sr1);

                        break;

                    case 6:
                        Console.WriteLine("Process Completed, Thank you");
                        n=1;
                        break;

                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }
            }
        }
    }
}
