using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Drawing;
using System;
using System.Security;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Reflection;
using System.Xml.Linq;
using System.Diagnostics.Metrics;
using System.Formats.Asn1;

namespace Assignment_1_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 Enum and Struct

            #region   1. Create an enum called "WeekDays" with the days of the week(Monday to Sunday) 
            //as its members.Then, write a C# program that prints out all the days of the week using this enum.

            //foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            //    Console.WriteLine(day);

            #endregion

            #region   2. Define a struct "Person" with properties "Name" and "Age". 
            //Create an array of three "Person" objects and populate it with data.Then, write a C# program to display the details of all the persons in the array.

            /*           Person[] person = new Person[3];

                       person[0] = new Person() { name = "Hossam", age = 25 };
                       person[1] = new Person() { name = "Nada", age = 26 };
                       person[2] = new Person() { name = "Radwa", age = 27 };

                       foreach (var p in person)
                       {
                           Console.WriteLine(p.ToString());
                       }
           */
            #endregion

            #region  3. Create an enum called "Season" with the four seasons(Spring, Summer, Autumn, Winter) 
            //as its members.Write a C# program that takes a season name as input from the user and displays
            //the corresponding month range for that season.
            //Note range for seasons ( spring march to may , summer june to august , autumn September to November ,
            //winter December to February)

            //Console.Write("Enter a season (Spring, Summer, Autumn or Winter): ");
            //  string input = Console.ReadLine();

            //  if (Enum.TryParse(input, out Season season))
            //  {
            //      switch (season)
            //      {
            //          case Season.Spring:
            //              Console.WriteLine("Spring: March to May");
            //              break;
            //          case Season.Summer:
            //              Console.WriteLine("Summer: June to August");
            //              break;
            //          case Season.Autumn:
            //              Console.WriteLine("Autumn: September to November");
            //              break;
            //          case Season.Winter:
            //              Console.WriteLine("Winter: December to February");
            //              break;
            //      }
            //  }
            //  else
            //      Console.WriteLine("Invalid input.");

            #endregion

            #region   4. Assign the following Permissions (Read, Write, Delete, Execute) in a form of Enum.
            //●	Create Variable from previous Enum to Add and Remove Permission from variable,
            //   check if specific Permission is existed inside variable

            //Permissions p = Permissions.Read;

            //Console.WriteLine($"Initial Permissions: {p}");

            //p |= Permissions.Execute;
            //Console.WriteLine($"After Adding Execute: {p}");

            //p &= ~Permissions.Read;
            //Console.WriteLine($"After Removing Write: {p}");

            //bool hasRead = (p & Permissions.Read) == Permissions.Read;
            //Console.WriteLine($"Read has a Permission? {hasRead}");

            #endregion

            #region  5. Create an enum called "Colors" with the basic colors(Red, Green, Blue) 
            //as its members.Write a C# program that takes a color name as input from the user
            //and displays a message indicating whether the input color is a primary color or not.

            //Console.Write("Enter a Color: ");
            //string input = Console.ReadLine();

            //if (Enum.TryParse(input, out Colors color))
            //{
            //    if (color == Colors.Red || color == Colors.Green || color == Colors.Blue)
            //        Console.WriteLine("Color is a primary color.");
            //}
            //else
            //    Console.WriteLine("Color isn't a primary color.");

            #endregion

            #region  6. Create a struct called "Point" to represent a 2D point with properties "X" and "Y". 
            //Write a C# program that takes two points as input from the user and calculates the distance between them.

            Point[] point = new Point[2];

            //for (int i = 0; i < point.Length; i++)
            //{
            //    Console.WriteLine($"Enter point X{i + 1}:");
            //    point[i].x = double.Parse(Console.ReadLine());

            //    Console.WriteLine($"Enter point Y{i + 1}:");
            //    point[i].y = double.Parse(Console.ReadLine());
            //}

            //double distance = Math.Sqrt(Math.Pow(point[0].x - point[1].x, 2) +
            //                            Math.Pow(point[0].y - point[1].y, 2));
            //Console.WriteLine($"Distance = {distance}");

            #endregion

            #region  7. Create a struct called "Person" with properties "Name" and "Age". 
            //Write a C# program that takes details of 3 persons as input from the user
            //and displays the name and age of the oldest person.

            //Person[] person = new Person[3];
            //int oldestPersonAge = int.MinValue;
            //string oldestPersonName = string.Empty;

            //for (int i = 0; i < person.Length; i++)
            //{
            //    Console.WriteLine($"Enter Name {i + 1}:");
            //    person[i].name = Console.ReadLine();

            //    Console.WriteLine($"Enter Age {i + 1}:");
            //    person[i].age = int.Parse(Console.ReadLine());

            //    if (person[i].age > oldestPersonAge)
            //    {
            //        oldestPersonAge = person[i].age;
            //        oldestPersonName = person[i].name;
            //    }
            //}

            //Console.WriteLine($"Oldest Person Name: {oldestPersonName}, {oldestPersonAge} years old.");

            #endregion
            #endregion
            /////////////////////////////////////////////////////////////////////////////////////
            #region   Part 02 :Encapsulation
            //1.Design and implement a Class for the employees in a company:
            //Employee is identified by an ID, Name, security level, salary, hire date and Gender.

            // 2.Develop a Class to represent the Hiring Date Data:
            //  consisting of fields to hold the day, month and Years.
            //  
            //3.We need to restrict the Gender field to be only M or F[Male or Female]
            //4.Assign the following security privileges to the employee
            //(guest, Developer, secretary and DBA) in a form of Enum

            //5.We want to provide the Employee Class to represent Employee data in a string Form(override ToString()),
            //display employee salary in a currency format. [use String.Format Function]

            //6.Create an array of Employees with size three
            //a DBA, Guest and the third one is security officer who have full permissions.
            //(Employee[] EmpArr;)

            //Employee[] EmpArr = new Employee[3];

            //EmpArr[0] = new Employee(
            //    id: 1,
            //    name: "Hossam",
            //    securityLevel: SecurityLevel.DBA,
            //    salary: 50_000_000,
            //    hireDate: new HiringDate(1, 11, 2025),
            //    gender: Gender.M
            //);

            //EmpArr[1] = new Employee(

            //    id: 2,
            //    name: "Nada",
            //    securityLevel: SecurityLevel.Guest,
            //    salary: 35000,
            //    hireDate: new HiringDate(1, 9, 2023),
            //    gender: Gender.F
            //);

            //EmpArr[2] = new Employee(

            //    id: 3,
            //    name: "Radwa",
            //    securityLevel: SecurityLevel.DBA | SecurityLevel.Guest |
            //                    SecurityLevel.Developer | SecurityLevel.Secretary,
            //    salary: 45000,
            //    hireDate: new HiringDate(1, 12, 2024),
            //    gender: Gender.F
            //);

            //foreach (var Emp in EmpArr)
            //{
            //    Console.WriteLine(Emp);
            //}

            #endregion


            /*Notes:
    ⮚	Implement All the Necessary Member Functions on the Class(Getters, Setters)
    ⮚	Define all the Necessary Constructors for the Class
    ⮚	Allow NO RUNTIME errors if the user inputs any data
    ⮚	Write down all the necessary Properties(Instead of setters and getters)
            */
        }
    }
}
