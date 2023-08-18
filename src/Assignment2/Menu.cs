// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;

/// <summary>
/// Menu class is iniatiated to perform certain operations like Add contact, Edit contact, Display contact , and delete contact.
/// </summary>
internal class Menu
{
    /// <summary>
    /// List named _people is iniatiated to store the details
    /// </summary>
    private List<Person> _people = new ();

    /// <summary>
    /// MainMenu :Display options.
    /// </summary>
    public void MainMenu()
    {
        Console.WriteLine("Please select any one of the options listed below:");
        Console.WriteLine("1.View Persons");
        Console.WriteLine("2.Add Person");
        Console.WriteLine("3.Search For Person");
        Console.WriteLine("4.Edit Details");
        Console.WriteLine("5.Delete Details");
        Console.WriteLine("6.Exit");
        Console.WriteLine("\nEnter Your Choice :");
        var input = Console.ReadLine();
        if (int.TryParse(input, out int inputnum))
        {
            switch (inputnum)
            {
                case 1:
                    this.DisplayContactNames();
                    break;
                case 2:
                    this.AddPerson();
                    break;
                case 3:
                    this.SearchListContacts(true);
                    break;
                case 4:
                    this.Getchoice(false);
                    break;
                case 5:
                    this.Getchoice(true);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input\n\n");
                    this.MainMenu();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid Input\n\n");
            this.MainMenu();
        }

        return;
    }

    /// <summary>
    /// Display all names and their Id's in list.
    /// </summary>
    public void DisplayContactNames()
    {
        if (this._people.Count == 0)
        {
            Console.WriteLine("No People To Display Yet.\n\n");
            this.MainMenu();
        }
        else
        {
            Console.WriteLine("List of Current People:\n");
            foreach (Person person in this._people)
            {
                Console.WriteLine("ID: " + " " + person.Id + "   NAME: " + " - " + person.Name + "   NUMBER:" + " - " + person.Number);
            }

            Console.WriteLine("\n\n");
            this.MainMenu();
        }

        return;
    }

    /// <summary>
    /// Add a new person to the list.
    /// </summary>
    public void AddPerson()
    {
        Console.WriteLine("Please Enter The Person's Name: ");
        string pattern = "^[A-Za-z]+$";
        string result = Console.ReadLine() !;
        while (string.IsNullOrEmpty(result) || !Regex.IsMatch(result, pattern))
        {
            Console.WriteLine("Enter valid names!");
            result = Console.ReadLine() !;
        }

        Console.WriteLine("Please Enter The Mobile Number: ");
        var num = Console.ReadLine();
        pattern = "^[0-9]+$";
        while (string.IsNullOrEmpty(num) || !Regex.IsMatch(num, pattern) || num.Length < 10 || num.Length! > 10)
        {
            Console.WriteLine("Enter valid numbers!");
            num = Console.ReadLine();
        }

        Console.WriteLine("Please Enter The Email: ");
        var email = Console.ReadLine();
        pattern = "^[^@]+@[^@]+$";
        while (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, pattern))
        {
            Console.WriteLine("Enter valid email!");
            email = Console.ReadLine();
        }

        Console.WriteLine("Please enter the Description: ");
        string desp = Console.ReadLine() !;
        while (string.IsNullOrEmpty(desp))
        {
            Console.WriteLine("value can't be empty! Input your value once more");
            desp = Console.ReadLine() !;
        }

        Person newPerson = new Person(result, num, email, desp);
        this._people.Add(newPerson);
        Console.WriteLine(newPerson.Name + " " + newPerson.Number + " added successfully.\n\n");
        this.MainMenu();
        return;
    }

    /// <summary>
    /// Find and display search results.
    /// </summary>
    /// <param name="mainMenu">boolean</param>
    /// <returns> number of result found </returns>
    public int SearchListContacts(bool mainMenu)
    {
        Console.WriteLine("Search : ");
        var result = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(result))
        {
            Console.WriteLine("value can't be empty! Input your value once more");
            result = Console.ReadLine();
        }

        var searchResults = this._people.Where(n => n.Name.Contains(result, StringComparison.OrdinalIgnoreCase)).ToList();
        var searchNumber = this._people.Where(n => n.Number.Contains(result, StringComparison.OrdinalIgnoreCase)).ToList();
        if (searchResults.Count == 0 && searchNumber.Count == 0)
        {
            Console.WriteLine("No Results Were Found");
        }
        else
        {
            Console.WriteLine("The Following Results Were Found: \n");
            foreach (Person person in searchResults)
            {
                Console.WriteLine("ID:" + " - " + person.Id + " \n" + "NAME:" + " - " + person.Name + "\n" + "EMAIL:" + " - " + person.Email + "\n" + "NUMBER:" + " - " + person.Number);
            }

            foreach (Person person in searchNumber)
            {
                Console.WriteLine("ID:" + " - " + person.Id + " \n" + "NAME:" + " - " + person.Name + "\n" + "EMAIL:" + " - " + person.Email + " \n" + "NUMBER:" + " - " + person.Number);
            }
        }

        Console.WriteLine("\n\n");
        if (mainMenu == true)
        {
            this.MainMenu();
        }

        return searchNumber.Count + searchResults.Count;
    }

    /// <summary>
    /// Edit the details of the user by name, email, number
    /// </summary>
    /// <param name="isDel">boolean</param>
    public void Getchoice(bool isDel)
    {
        if (isDel == false)
        {
            Console.WriteLine("Please Enter which details to be edited: ");
            Console.WriteLine("1.Name");
            Console.WriteLine("2.Phone Number");
            Console.WriteLine("3.Email");
            Console.WriteLine("4.Exit"); 
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("invalid ID!!! ");
            }

            if (value <= 4)
            {
                int count = 0;
                switch (value)
                {
                    case 1:
                        count = this.SearchListContacts(false);
                        if (count > 0)
                        {
                            Console.WriteLine("Enter your id");
                            int editid;
                            while (!int.TryParse(Console.ReadLine(), out editid))
                            {
                                Console.WriteLine("invalid ID!!! ");
                            }

                            while (this.IdCheck(editid))
                            {
                                Console.WriteLine("Enter valid id");
                                while (!int.TryParse(Console.ReadLine(), out editid))
                                {
                                    Console.WriteLine("invalid ID!!! ");
                                }
                            }

                            if (this._people.Count >= editid)
                            {
                                Console.WriteLine("Enter your name");
                                var editname = Console.ReadLine() !;
                                while (string.IsNullOrWhiteSpace(editname))
                                {
                                    Console.WriteLine("value can't be empty! Input your value once more");
                                    editname = Console.ReadLine();
                                }

                                this._people[editid - 1].Name = editname;
                            }
                        }

                        break;
                    case 2:
                        {
                            count = this.SearchListContacts(false);
                            if (count > 0)
                            {
                                Console.WriteLine("Enter your id");
                                int editid;
                                while (!int.TryParse(Console.ReadLine(), out editid))
                                {
                                    Console.WriteLine("invalid ID!!! ");
                                }

                                while (this.IdCheck(editid))
                                {
                                    Console.WriteLine("Enter valid id");
                                    while (!int.TryParse(Console.ReadLine(), out editid))
                                    {
                                        Console.WriteLine("invalid ID!!! ");
                                    }
                                }

                                if (this._people.Count >= editid)
                                {
                                    Console.WriteLine("Enter your number");

                                    var editnum = Console.ReadLine();
                                    string pattern = "^[0-9]+$";
                                    while (string.IsNullOrEmpty(editnum) || !Regex.IsMatch(editnum, pattern) || editnum.Length < 10 || editnum.Length! > 10)
                                    {
                                        Console.WriteLine("Enter valid numbers!");
                                        editnum = Console.ReadLine();
                                    }

                                    this._people[editid - 1].Number = editnum;
                                }
                            }
                        }

                        break;
                    case 3:
                        {
                            count = this.SearchListContacts(false);
                            if (count > 0)
                            {
                                Console.WriteLine("Enter your id");
                                int editid;
                                while (!int.TryParse(Console.ReadLine(), out editid))
                                {
                                    Console.WriteLine("invalid ID!!! ");
                                }

                                while (this.IdCheck(editid))
                                {
                                    Console.WriteLine("Enter valid id");
                                    while (!int.TryParse(Console.ReadLine(), out editid))
                                    {
                                        Console.WriteLine("invalid ID!!! ");
                                    }
                                }

                                if (this._people.Count >= editid)
                                {
                                    Console.WriteLine("Enter your email");
                                    var editmail = Console.ReadLine();
                                    while (string.IsNullOrWhiteSpace(editmail))
                                    {
                                        Console.WriteLine("value can't be empty! Input your value once more");
                                        editmail = Console.ReadLine();
                                    }

                                    this._people[editid - 1].Email = editmail;
                                }
                            }
                        }

                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input\n\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Enter valid options");
                while (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("invalid ID!!! ");
                }
            }

            this.MainMenu();
        }
        else
        {
            if (isDel)
            {
                int count = this.SearchListContacts(false);
                if (count > 0)
                {
                    Console.WriteLine("Enter your id");
                    int delid;
                    while (!int.TryParse(Console.ReadLine(), out delid))
                    {
                        Console.WriteLine("invalid ID!!! ");
                    }

                    while (this.IdCheck(delid))
                    {
                        Console.WriteLine("Enter valid id");
                        while (!int.TryParse(Console.ReadLine(), out delid))
                        {
                            Console.WriteLine("invalid ID!!! ");
                        }
                    }

                    if (this._people.Count >= delid)
                    {
                        this._people.Remove(this._people[delid - 1]);
                    }
                }
            }

            this.MainMenu();
        }
    }

    /// <summary>
    /// IdCheck method is used to check the id is valid or not
    /// </summary>
    /// <param name="id"> Integer ID to check</param>
    /// <returns> valdity of ID in boolean </returns>
    public bool IdCheck(int id)
    {
        if (this._people == null)
        {
            return true;
        }

        foreach (Person obj in this._people)
        {
            if (id == obj.Id)
            {
                return false;
            }
        }

        return true;
    }
}
