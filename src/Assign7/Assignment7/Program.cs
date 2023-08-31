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
            Console.WriteLine("Press any key to view Stack memory");
            Console.ReadKey();
            Tasks.ArrayInteger();
            Console.WriteLine("Press any key to view Heap memory");
            Console.ReadKey();
            Tasks.Largearr();
            Console.ReadKey();
            Console.WriteLine("Press any key to enter garbage collection");
            Console.ReadKey();
            GarbageCollection.Garbage();
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
            menu.Id += 1;
            menu.Name = "xiabao";
        }

        /// <summary>
        /// Print
        /// </summary>
        /// <param name="menu">menu </param>
        /// <param name="valuetype">valuetype</param>
        public static void Print(Menu menu, int valuetype)
        {
            Console.WriteLine($"The id is: {menu.Id}");
            Console.WriteLine($"The Name is: {menu.Name}");
            Console.WriteLine($"The valuetype is: {valuetype}");
        }

        /// <summary>
        /// Largearr
        /// </summary>
        public static void ArrayInteger()
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
            Console.WriteLine("Press any key to exit stack memory");
            Console.ReadKey();
            Console.WriteLine($"1: {a}\n2: {b}\n3: {c}\n4: {d}\n5: {e}\n6: {f}\n7: {g}\n8: {h}\n9: {i}\n10: {j}\n11: {k}\n12: {l}");
        }

        /// <summary>
        /// ArrayInteger
        /// </summary>
        public static void Largearr()
        {
            int[] a = new int[100];
            for (int i = 1; i < a.Length; i++)
            {
                a[0] = 1;
                a[i] = a[i - 1] + 1;
                Console.WriteLine(a[i]);
            }

            Console.WriteLine("Press any key to exit heap memory");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// GarbageCollection class which contains a method to implement garbage collection
    /// </summary>
    public class GarbageCollection
    {
        /// <summary>
        /// Garbage method creates and destroys a large number of objects
        /// </summary>
        public static void Garbage()
        {
            for (int i=0; i<100000; i++)
            {
                object obj = new object();
                obj = null;
            }

            Console.WriteLine("press any key to start GC...");
            Console.ReadKey();
            GC.Collect();
        }
    }
}