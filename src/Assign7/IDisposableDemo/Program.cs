// <copyright _file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Text;

namespace IDisposableDemo
{
    /// <summary>
    /// Program class is initiated for IDisposable class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class
        /// </summary>
        /// <param name="args">arguments</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using (Idisposable idisposable = new Idisposable())
            {
                idisposable.Filewrite();
            }

            var path = "Best.txt";
            FileStream file = System.IO.File.OpenRead(path);
            byte[] buf = new byte[1024];
            int c;
            while ((c = file.Read(buf, 0, buf.Length )) >0)
            {
                Console.WriteLine(Encoding.UTF8.GetString(buf, 0, c));
            }
        }
    }
}