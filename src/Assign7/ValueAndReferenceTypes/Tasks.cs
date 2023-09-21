// <copyright file="Tasks.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Tasks class contains methods that perform certain operations
    /// </summary>
    public class Tasks
    {
        /// <summary>
        /// Modify method accepts valuetype as a input
        /// </summary>
        /// <param name="menu">class menu would set id and name</param>
        /// <param name="valuetype">sets the variable as valuetype</param>
        public static void Modify(Menu menu, int valuetype)
        {
            menu.Id += 1;
            menu.Name = "xiabao";
            valuetype = 7;
        }

        /// <summary>
        /// Print method would print the valuetype variables
        /// </summary>
        /// <param name="menu">class menu would set id and name </param>
        /// <param name="valuetype">sets the variable as valuetype</param>
        public static void Print(Menu menu, int valuetype)
        {
            Console.WriteLine($"The id is: {menu.Id}");
            Console.WriteLine($"The Name is: {menu.Name}");
            Console.WriteLine($"The valuetype is: {valuetype}");
        }

        /// <summary>
        /// ArrayInteger method defined to view stack memory
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
        /// Largearr method defined to view heap memory
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
}