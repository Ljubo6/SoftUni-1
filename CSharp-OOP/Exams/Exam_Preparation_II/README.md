# OOP Basics Exam – SoftUniRestaurant

### Overview

As we all love food, today you were chosen to build a simple restaurant system. This system must have support for **food** , **drinks** and **tables** in the restaurant. The project will consist of **model classes** and a **controller class** , which manages the **interaction** between the **food** , **drinks** and **tables**.

### Setup

Open the provided skeleton. Don&#39;t change the given namespaces. **Not following this rule will lead to your code not compiling in the Judge system**.

**Name your fields and properties**  **exactly**  **how they are given in this document.**

# Task 1: Structure (50 points)

You are given **3** interfaces, which you have to implement **by yourself** and then implement their functionality in the **correct classes**.

There are **3** types of entities in the application: **Tables** , **Food** and **Drinks** :

### Food

The **Food** is a **base class** for any **type of food** and it **should not be able to be instantiated**.

#### Data

- ****** Name **–** string (If the name is null or whitespace throw an ArgumentException with message ****&quot; ****Name cannot be null or white space!****&quot;)**
- ****** ServingSize **–** int (can&#39;t be less or equal to 0. In these cases, throw an ArgumentException with message &quot; ****Serving size cannot be less or equal to zero****&quot;)**
- ****** Price **–** decimal (can&#39;t be less or equal to 0. In these cases, throw an ArgumentException with message &quot; ****Price cannot be less or equal to zero!&quot;**** )**

#### Behavior

##### string ToString()

Returns a **string** with information about **each food**. The returned string must be in the following format:

**&quot;{current food name}: {current serving size}g - {current price - formatted to the second digit}&quot;**

#### Constructor

A **food** should take the following values upon initialization:

string name, int servingSize, decimal price

#### Child Classes

There are several concrete types of **food** :

- ****** Dessert – **with constant value for** InitialServingSize - 200**
- ****** Salad - **with constant value for** InitialServingSize - 300**
- ****** Soup - **with constant value for** InitialServingSize - 245**
- ****** MainCourse - **with constant value for** InitialServingSize - 500**

### Drink

The **Drink** is a **base class** for any **type of drink** and it **should not be able to be instantiated**.

#### Data

- ****** Name **–** string (If the name is null or whitespace throw an ArgumenException with message ****&quot; ****Name cannot be null or white space!****&quot;****)**
- ****** ServingSize **–** int (if the serving size is less than or equal to 0, throw an ArgumentException with message &quot; ****Serving size cannot be less or equal to zero****&quot;)**
- ****** Price **–** decimal (if the price is less than or equal to 0, throw an ArgumentException with message &quot; ****Price cannot be less or equal to zero****&quot;)**
- ****** Brand -  ****string (If the brand is null or whitespace thrown ArgumentException with message**  **&quot;**** Brand cannot be null or white space! ****&quot;**** )**

#### Behavior

##### string ToString()

Returns a **string** with information about **each drink**. The returned string must be in the following format:

**&quot;{current drink name} {current brand name} - {current serving size}ml - {current price - formatted to the second digit}lv&quot;**

#### Constructor

A **drink** should take the following values upon initialization:

string name, int servingSize, decimal price, string brand

#### Child Classes

There are several concrete types of **drink** , which have **different prices** :

- ****** FuzzyDrink **– with constant value for** FuzzyDrinkPrice - 2.50**
- ****** Juice **– with constant value for** JuicePrice - 1.80**
- ****** Water **– with constant value for** WaterPrice - 1.50**
- ****** Alcohol **– with constant value for** AlcoholPrice - 3.50**

### Table

The **Table** is a base **class** for different types of tables and **should not be able to be instantiated**.

#### Data

- ****** FoodOrders ****–**  **collection of foods**  **accessible only by the**  **base class****.**
- ****** DrinkOrders ****–**  **collection of drinks**  **accessible only by the**  **base class****.**
- ****** TableNumber **–** int** the table number
- ****** Capacity **–** int**the table capacity(capacity can&#39;t be less than zero. In these cases,**throw an ArgumentException **** with message ****&quot;Capacity has to be greater than 0&quot;)**
- ****** NumberOfPeople **–** int**the count of people who want a table (number of people cannot be less or equal to 0. In these cases,**throw an ArgumentException **** with message ****&quot;Cannot place zero or less people!&quot;)**
- ****** PricePerPerson – decimal** the price per person for the table
- ****** IsReserved – bool** returns true if the table is reserved
- ****** Price –** calculated property, which calculates the price for all people

#### Constructor

A **table** should take the following values upon initialization:

int tableNumber, int capacity, decimal pricePerPerson

#### Child Classes

There are several concrete types of **tables** , which have **different prices** :

- ****** InsideTable **– with constant value for** InitialPricePerPerson - 2.50**
- ****** OutsideTable **– with constant value for** InitialPricePerPerson - 3.50**

#### Behavior

##### void Reserve(int numberOfPeople)

Reserves the table with the count of people given.

##### void OrderFood(IFood food)

Orders the provided food (think of a way to collect all the food which is ordered).

##### void OrderDrink(IDrink drink)

Orders the provided drink (think of a way to collect all the drinks which are ordered).

##### decimal GetBill()

Returns the bill for all of the ordered drinks and food.

##### void Clear()

Removes all of the ordered drinks and food and finally frees the table and sets the count of people to 0.

##### string GetFreeTableInfo()

Return a string with the following format:

&quot;Table: {table number}&quot;

&quot;Type: {table type}&quot;

&quot;Capacity: {table capacity}&quot;

&quot;Price per Person: {price per person for the current table}&quot;

##### string GetOccupiedTableInfo()

Return a string with the following format:

&quot;Table: {table number}&quot;

&quot;Type: {table type}&quot;

&quot;Number of people: {table number of people}&quot;

If there aren&#39;t any food orders append the following message to the text above:

&quot;Food orders: None&quot;

If there are food orders:

&quot;Food orders: {food orders count}&quot;

Finally append each food ToString() method

The same logic you can use for the ordered drinks. If there aren&#39;t any drink orders just append the message:

&quot;Drink orders: None&quot;

But in the other case:

&quot;Drink orders: {drink orders count}&quot;

Finally append each drink ToString() method. If you got confused just look in the input output examples and you will understand it 😊

# Task 2: Business Logic (150 points)

### The Controller Class

The business logic of the program should be concentrated around several **commands**. Implement a class called **RestaurantController** , which will hold the **main functionality**.

**Note: The**  **RestaurantController**  **class SHOULD NOT handle exceptions! The tests are designed to expect exceptions, not messages!**

The main functionality is represented by these **public**** methods**:

| RestaurantController.cs |
| --- |
| publicstring AddFood(string type, string name, decimal price){    thrownew NotImplementedException();} publicstring AddDrink(string type, string name, int servingSize, string brand){    thrownew NotImplementedException();} publicstring AddTable(string type, int tableNumber, int capacity){    thrownew NotImplementedException();} publicstring ReserveTable(int numberOfPeople){    thrownew NotImplementedException();} publicstring OrderFood(int tableNumber, string foodName){    thrownew NotImplementedException();} publicstring OrderDrink(int tableNumber, string drinkName, string drinkBrand){    thrownew NotImplementedException();} publicstring LeaveTable(int tableNumber){    thrownew NotImplementedException();} publicstring GetFreeTablesInfo(){    thrownew NotImplementedException();} publicstring GetOccupiedTablesInfo(){    thrownew NotImplementedException();} publicstring GetSummary(){    thrownew NotImplementedException();} |

Also, the controller holds all **foods** , **drinks** and **tables** :

- **menu** – List of foods – ** ** foods offered by the restaurant
- **drinks** – List of drinks – the drinks the restaurant offers
- **tables** – List of tables – all tables in the restaurant

**NOTE: The**  **RestaurantController**  **class should not handle any exceptions. That should be the responsibility of the class, which reads the commands and passes them to the**  **RestaurantController****.**

### Commands

There are several commands, which control the business logic of the application. They are stated below.

#### AddFood Command

##### Parameters

- ****** Type **–** string**
- ****** Name **–  ** string**
- ****** Price **–** decimal**

##### Functionality

Creates a food with the correct type. If the food is created successful, returns:

&quot;Added {food name} ({food type}) with price {food price:f2} to the pool&quot;

#### AddDrink Command

##### Parameters

- ****** Type **–** string**
- ****** Name **–  ** string**
- ****** ServingSize **–** int**
- ****** Brand - string**

##### Functionality

Creates a drink with the correct type. If the drink is created successful, returns:

#### &quot;Added {drink name} ({drink brand}) to the drink pool&quot;

#### AddTable Command

##### Parameters

- ****** Type - string**
- ****** TableNumber – int**
- ****** Capacity - int**

##### Functionality

Creates a table with the correct type and returns:

&quot;Added table number {table number} in the restaurant&quot;

#### ReserveTable Command

##### Parameters

- ****** NumberOfPeople – int**

##### Functionality

Finds a table which is not reserved, and its capacity is enough for the number of people provided. If there is no such table returns:

&quot;No available table for {numberOfPeople} people&quot;

In the other case reserves the table and returns:

&quot;Table {table number} has been reserved for {numberOfPeople} people&quot;

#### OrderFood Command

##### Parameters

- ****** TableNumber - int**
- ****** FoodName - string**

##### Functionality

Finds the table with that number and the food with that name in the menu. If there is no such table returns:

&quot;Could not find table with {tableNumber}&quot;

If there is no such food returns:

&quot;No {foodName} in the menu&quot;

In other case orders the food for that table and returns:

&quot;Table {tableNumber} ordered {foodName}&quot;

#### OrderDrink Command

##### Parameters

- ****** TableNumber - int**
- ****** DrinkName – string**
- ****** DrinkBrand - string**

##### Functionality

Finds the table with that number and finds the drink with that name and brand. If there is no such table, it returns:

&quot;Could not find table with {tableNumber}&quot;

If there isn&#39;t such drink, it returns:

&quot;There is no {drinkName} {drinkBrand} available&quot;

In other case, it orders the drink for that table and returns:

**&quot;Table {tableNumber} ordered {drinkName} {drinkBrand}&quot;**

#### LeaveTable Command

##### Parameters

- ****** TableNumber - int**

##### Functionality

Finds the table with the same table number. Gets the bill for that table and clears it. Finally returns:

**&quot;Table: {tableNumber}&quot;**

**&quot;Bill: {**** table bill ****:f2}&quot;**

#### GetFreeTablesInfo Command

##### Functionality

Finds all not reserved tables and for each table returns the table info.

#### GetOccupiedTablesInfo Command

##### Functionality

Finds all reserved tables and for each table returns the table info.

#### GetSummary Command

Returns the total income for the restaurant for all orders.

&quot;Total income: {income:f2}lv&quot;

# Task 3: Input / Output

### Input

- You will receive commands **until you receive &quot;END&quot;** as a command.

Below, you can see the **format** in which **each command** will be given in the input:

- **** AddFood {type} {name} {price}
- **** AddDrink {type} {name} {servingSize} {brand}
- **** AddTable {type} {tableNumber} {capacity}
- **** ReserveTable {numberOfPeople}
- **** OrderFood {tableNumber} {foodName}
- **** OrderDrink {tableNumber} {drinkName} {drinkBrand}
- **** LeaveTable {tableNumber}
- **** GetFreeTablesInfo
- **** GetOccupiedTablesInfo

### Output

Print the output from each command when issued. When the END command is received, print the summary for the restaurant

### Constraints

- The commands will always be in the provided format.

### Examples

| **Input** |
| --- |
| AddFood Dessert Toffifee 2.90AddDrink Water Spring 500 DivnaAddTable Inside 1 10AddTable Outside 2 20ReserveTable 5OrderFood 1 ToffifeeOrderDrink 1 Spring DivnaGetOccupiedTablesInfo GetFreeTablesInfo LeaveTable 1END |
| **Output** |
| Added Toffifee (Dessert) with price 2.90 to the poolAdded Spring (Divna) to the drink poolAdded table number 1 in the restaurantAdded table number 2 in the restaurantTable 1 has been reserved for 5 peopleTable 1 ordered ToffifeeTable 1 ordered Spring DivnaTable: 1Type: InsideTableNumber of people: 5Food orders: 1Toffifee: 200g - 2.90Drink orders: 1Spring Divna - 500ml - 1.50lvTable: 2Type: OutsideTableCapacity: 20Price per Person: 3.50Table: 1Bill: 16.90Total income: 16.90lv |

| **Input** |
| --- |
| AddFood Dessert Toffifee 2.90AddFood Salad Shopska 12.90AddFood Soup Bob 12.90AddFood MainCourse Chushki -90AddDrink Water Spring -500 DivnaAddDrink Alcohol Rakia 200 YambolskaPerlaAddDrink FuzzyDrink PeachSchnapps 200 MoninAddTable Inside 1 10AddTable Inside 2 12AddTable Inside 3 11AddTable Outside 4 20AddTable Outside 5 -2AddTable Outside 6 10ReserveTable 5ReserveTable 1ReserveTable 2OrderFood 1 ToffifeeOrderFood 1 ShopskaOrderFood 2 BobOrderFood 3 BobOrderFood 4 BobOrderDrink 1 Spring DivnaOrderDrink 2 Spring DivnaOrderDrink 2 Spring YambolskaPerlaOrderDrink 3 Spring MoninGetOccupiedTablesInfo GetFreeTablesInfo LeaveTable 1LeaveTable 2END |
| **Output** |
| Added Toffifee (Dessert) with price 2.90 to the poolAdded Shopska (Salad) with price 12.90 to the poolAdded Bob (Soup) with price 12.90 to the poolPrice cannot be less or equal to zero!Serving size cannot be less or equal to zeroAdded Rakia (YambolskaPerla) to the drink poolAdded PeachSchnapps (Monin) to the drink poolAdded table number 1 in the restaurantAdded table number 2 in the restaurantAdded table number 3 in the restaurantAdded table number 4 in the restaurantCapacity has to be greater than 0Added table number 6 in the restaurantTable 1 has been reserved for 5 peopleTable 2 has been reserved for 1 peopleTable 3 has been reserved for 2 peopleTable 1 ordered ToffifeeTable 1 ordered ShopskaTable 2 ordered BobTable 3 ordered BobTable 4 ordered BobThere is no Spring Divna availableThere is no Spring Divna availableThere is no Spring YambolskaPerla availableThere is no Spring Monin availableTable: 1Type: InsideTableNumber of people: 5Food orders: 2Toffifee: 200g - 2.90Shopska: 300g - 12.90Drink orders: NoneTable: 2Type: InsideTableNumber of people: 1Food orders: 1Bob: 245g - 12.90Drink orders: NoneTable: 3Type: InsideTableNumber of people: 2Food orders: 1Bob: 245g - 12.90Drink orders: NoneTable: 4Type: OutsideTableCapacity: 20Price per Person: 3.50Table: 6Type: OutsideTableCapacity: 10Price per Person: 3.50Table: 1Bill: 28.30Table: 2Bill: 15.40Total income: 43.70lv |

# Task 4: Unit Testing (100 points)

You will receive a skeleton with one class inside. The class will have some methods, properties, fields and constructors. Cover the whole class with unit test to make sure that the class is working as intended.