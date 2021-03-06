﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject
{
    class Program
    {
        public static List<Student> getStudents()
        {
            List<Student> myStudents = new List<Student>(){
                new Student(){Name="Kerim", Age=21},
                new Student(){Name="Vural", Age=22},
                new Student(){Name="Aurdvan", Age=20},
                new Student(){Name="Selim", Age=25},
                new Student(){Name="Rehmi", Age=10},
                new Student(){Name="Joseph", Age=23}
            };
            return myStudents;
        }
        static void Main(string[] args)
        {
            var listofstudents = Program.getStudents();//Implicitly typed variable
            var filter = from i in listofstudents//Can also be added into single line
                         where i.Age > 19
                         where i.Name.Length>5
                         select i.Name; //Query-Expressions Style which uses clauses; this is deffered/lazy evaluation of a query
           
            foreach(var i in filter)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

            var filter2 = (from i in listofstudents
                           where i.Name.Contains("a")
                           select i.Name).ToArray();//Immediate/eager evaluation of a query using an extention method.

            foreach (var i in filter2)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

            var filter1 = listofstudents.Where<Student>(i => i.Age > 5).Select(i=>i.Name);//Method-Based-Query Style which uses Extention Methods.
            foreach (var i in filter1)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
