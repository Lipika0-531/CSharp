// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment7
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class
        /// </summary>
        /// <param name="args">arguments</param>
        public static void Main(string[] args)
        {
            int id = 1;
            string name = "test";
            Menu menu = new Menu(id, name);
            int valuetype = 0;
            Console.WriteLine("The value of valuetype and referencetype before the method called");
            Tasks.Print(menu, valuetype);
            Tasks.Modify(menu, valuetype);
            Console.WriteLine("The value of valuetype and referencetype after the method called");
            Tasks.Print(menu, valuetype);
            Tasks tasks = new Tasks();
            Console.ReadKey();
            Tasks.Largearr();
            Console.ReadKey();
            Tasks.ArrayInteger();
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Tasks class
    /// </summary>
    public class Tasks
    {
        /// <summary>
        /// Modify method accepts
        /// </summary>
        /// <param name="menu">menu </param>
        /// <param name="valuetype">valuetype</param>
        public static void Modify(Menu menu, int valuetype)
        {
            menu.id += 1;
            menu.Name = "xiabao";
        }

        /// <summary>
        /// Print
        /// </summary>
        /// <param name="menu">menu </param>
        /// <param name="valuetype">valuetype</param>
        public static void Print(Menu menu, int valuetype)
        {
            Console.WriteLine($"The id is: {menu.id}");
            Console.WriteLine($"The Name is: {menu.Name}");
            Console.WriteLine($"The valuetype is: {valuetype}");
        }

        /// <summary>
        /// Largearr
        /// </summary>
        public static void Largearr()
        {
            int a = 0;
            int b = 1;
            int c = 2;
            int d = 3;
            int e = 4;
            int f = 5;
            int g = 6;
            int h = 7;
            int i = 8;
            int j = 9;
            int k = 10;
            int l = 11;
            Thread.Sleep(1000);
            Console.ReadKey();
            Console.WriteLine($"1: {a}\n2: {b}\n3: {c}4: {d}5: {e}\n6: {f}\n7: {g}\n8: {h}\n9: {i}\n10: {j}\n11: {k}\n12: {l}");
        }

        /// <summary>
        /// ArrayInteger
        /// </summary>
        public static void ArrayInteger()
        {
            int[] a = new int[100];
            for (int i = 1; i < a.Length; i++)
            {
                a[0] = 1;
                a[i] = a[i - 1] + 1;
                Console.WriteLine(a[i]);
            }

            Console.ReadKey();
        }
    }
}