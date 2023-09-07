// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Person class is iniatiated to get and set the values received by the user
/// </summary>
internal class Person
{
    /// <summary>
    /// Gets or sets will receive the value
    /// </summary>
    /// <value>
    /// Will receive the value
    /// </value>
    private static int _globalId = 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="Person"/> class.
    /// constructor Person is iniatiated to pass the values
    /// </summary>
    /// <param name="name" >arguments: name</param>
    /// <param name="email">arguments: email</param>
    /// <param name="number">arguments: number</param>
    /// <param name="desp">arguments: Description</param>
    public Person(string name, string number, string email, string desp)
    {
        this.Name = name;
        this.Number = number;
        this.Email = email;
        this.Description = desp;
        this.Id = _globalId;
        _globalId++;
    }

    /// <summary>
    /// Gets or sets will receive the value
    /// </summary>
    /// <value>
    /// Will receive the value named ID
    /// </value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets will receive the value
    /// </summary>
    /// <value>
    /// Will receive the value, Name
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets will receive the value
    /// </summary>
    /// <value>
    /// Will receive the value Number
    /// </value>
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets will receive the value
    /// </summary>
    /// <value>
    /// Will receive the value Email
    /// </value>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets will receive the value
    /// </summary>
    /// <value>
    /// Will receive the value Description
    /// </value>
    public string Description { get; set; }
}
