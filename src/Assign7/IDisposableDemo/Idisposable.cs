// <copyright file="Idisposable.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace IDisposableDemo
{
    using System.Text;

    /// <summary>
    /// Idisposable class is defined to automatically dispose the unmanaged resources
    /// </summary>
    public class Idisposable : IDisposable
    {
        private FileStream _file;

        /// <summary>
        /// Initializes a new instance of the <see cref="Idisposable"/> class.
        /// </summary>
        public Idisposable()
        {
            var path = "Best.txt";
            _file = System.IO.File.OpenWrite(path);
        }

        /// <summary>
        /// Dispose() method to dispose the unmanaged resources
        /// </summary>
        public void Dispose()
        {
            _file.Close();
            Console.WriteLine("Dispose method executed");
        }

        /// <summary>
        /// Filewrite method would write the _file
        /// </summary>
        public void Filewrite()
        {
            Console.WriteLine("Enter the text to be entered in the _file");
            string? text = Console.ReadLine();
            while (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Enter valid text");
                text = Console.ReadLine();
            }

            byte[] bytes = Encoding.UTF8.GetBytes(text);
            _file.Write(bytes, 0, bytes.Length);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The entered text was successfully written");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}