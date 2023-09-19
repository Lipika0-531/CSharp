# Task 1: Shape Hierarchy
  
In the task, class hierarchy is created, that models various shapes. A base class called Shape with some common properties and methods is iniatiated. Then, two derived classes, **Rectangle and Circle**, that inherit from the Shape class and provide specific implementations for calculating their areas and displaying their details is iniatiated.

## Shape Class
 base class Shape has the following properties and methods:

**Properties:**

    - Color (string): color property represents the color of the shape. Each shape can have its own color.
**Methods:**

    - CalculateArea(): An abstract method that will be overridden by each shape's derived class. It calculates and returns the area of the shape.

    - PrintDetails(): The method displays the color and area of the shape. Since the CalculateArea() method is abstract and needs to be implemented in derived classes,this method is to print the area.

    - Derived Classes: Rectangle and Circle
    creating two derived classes from the Shape class, namely Rectangle and Circle. These classes will provide specific implementations for their corresponding shapes.

**Rectangle Class**
    
    The Rectangle class will implement the CalculateArea() method to calculate the area of a rectangle. The formula to calculate the area of a rectangle is length * width.
    The PrintDetails() method in the Rectangle class will display the color, shape type ("Rectangle"), and the area of the rectangle.

**Circle Class**

    The Circle class will implement the CalculateArea() method to calculate the area of a circle. The formula to calculate the area of a circle is π * radius^2.
    The PrintDetails() method in the Circle class will display the color, shape type ("Circle"), and the area of the circle.

