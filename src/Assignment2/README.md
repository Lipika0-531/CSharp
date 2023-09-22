<style>
  .main
  {
    font-size: 20px;
    text-align: justify;
  }
</style>
<div class="main">

# **Contact App**

## Introduction :
 This console application could be able to store name of the person, contact number (phone number) of the person, Email ID of the person and some description of the person. It could perfrom some operation on the contact which is stored already added, like search contact, edit contact, delete contact, view contact etc. There are three different classes used to construct this contact app, they are **Main class**, **Person class** and **Menu class**. The main class is base class of this contact app. And it create object of the other classes to store the person's data.

## Main class :

This class is base class of the whole contact application.This class has a switch case, where the user could choose the operation to work with. The case switches based on the input. With the help of the Menu class it will store all the information of the contact. For each and every new contact, a new object is created and stored in a list to know all the contact. It contains some method they are,

- ### DisplayContactNames
  This method would display all the contacts that are stored in the list. It traverses all the elements in the list and prints the elements in the same order as its stored in the list.

- ### AddPerson
  This method will help to add new contact to the list. This method will create a new object of the class and get all the needed information from the user and create a new contact and add that object to the list which help to store the data about the contact.

- ### SearchListContacts
  This method is used to search a contact by the name or phone number of the existing contact. It also search the second name of the person by not a continuous sub string in the middle. String Comparison method in the  class is called to check whether search string matches with name or phone number of contact.

- ### Getchoice
  This method is used to edit and delete , by their name, phone number, Email ID of the existing contact. It could edit their name, phone  number, email id, and their description. This method will search the contact with the given name and ask user that which property that wanted to be edit. And as per the input of the uses it could edit the contact. The delete method will search the contact with the given name and ask for the exact ID to delete. And it will delete the contact and remove the contact from the list.


## Menu class

 This class will store each and every contact in seperate space. it also have some properties and methods to store the data and process those data respectively. The properties are **Name** to store the name of the person, **Number** to store the contact number (phone number) of the person, **Email** to store the email Id of the person and at last **Desp** to store some descriptions about the person. And there is method for search.

## CONCLUSION
 Overall , building Contact console Application was a valuable learning on various different concepts.

</div>