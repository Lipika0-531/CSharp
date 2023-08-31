// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment7
{
    /// <summary>
    /// Menu class
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// Menu
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        public Menu(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets and sets the value for id
        /// </summary>
        /// <value>
        /// And sets the value for id
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets and sets the value for Name
        /// </summary>
        /// <value>
        /// And sets the value for Name
        /// </value>
        public string Name { get; set; }
    }
}
