# Task2: Employee Hierarchy
A class hierarchy that represents different types of employees is initiated.Starting by creating a base class called Employee that will define common properties and methods. Then extending the base class by creating two derived classes, Manager and Developer, each with their own specific implementations.

## Employee Class
The base class Employee is constructed with the following attributes:

**Properties:**

     - Name (string): This property holds the name of the employee. Each employee has a unique name.
    - Salary (decimal): This property stores the salary of the employee. The salary can be a floating-point value.

**Methods:**

    - CalculateBonus(): This is an abstract method that's declared but not implemented in the Employee class. The idea here is that each derived class will provide its own logic for calculating the bonus amount based on specific criteria.
    - PrintDetails(): This method is responsible for displaying essential information about the employee, including their name, salary, and bonus. Since the calculation of the bonus is dependent on the derived classes, this method relies on the abstract CalculateBonus() method to retrieve the bonus value.
    - Derived Classes: Manager and Developer

## Manager Class

 In the Manager class, overriding the **CalculateBonus()** method to implement the bonus calculation specific to managers. For instance, a manager's bonus might be calculated as a certain percentage of their salary. The actual bonus calculation logic will be unique to the Manager class.

The **PrintDetails()** method in the Manager class will use the overridden CalculateBonus() method to retrieve the manager's bonus, and it will display the name, position ("Manager"), salary, and bonus amount.

## Developer Class
In the Developer class, overriding the **CalculateBonus()** method to define how bonuses are calculated for developers.
The **PrintDetails()** method in the Developer class will leverage the overridden CalculateBonus() method to compute the developer's bonus, and it will show the name, position ("Developer"), salary, and bonus amount.
