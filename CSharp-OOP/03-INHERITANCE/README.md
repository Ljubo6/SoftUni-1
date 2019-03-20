# Exercises : Inheritance

This document defines the **exercise assignments** for the [&quot;C# OOP Basics&quot; course @ Software University](https://softuni.bg/trainings/2084/csharp-oop-basics-october-2018).

Please submit your solutions (source code) of all below described problems in [Judge](https://judge.softuni.bg/Contests/239/Inheritance-Exercise).

##Problem 1.Person

You are asked to model an application for storing data about people. You should be able to have a person and a child. The child derives from the person. Your task is to model the application. The only constraints are:

- **--** People should **not** be able to have a **negative age**
- **--** Children should **not** be able to have an age **more than 15**.

- **Person** – represents the base class by which all of the others are implemented

- ****** Child **- represents a class, which derives from** Person.**

### Note

Your class&#39;s names **MUST** be the same as the names shown above!!!

| **Sample Main()** |
| --- |
| staticvoid Main(){    string name = Console.ReadLine();    int age = int.Parse(Console.ReadLine());    try    {        Child child = newChild(name, age);        Console.WriteLine(child);    }    catch (ArgumentException ae)    {        Console.WriteLine(ae.Message);    }} |

Create a new empty class and name it **Person**. Set its access modifier to **public** so it can be instantiated from any project. Every person has a name, and an age.

| **Sample Code** |
| --- |
| publicclassPerson{   // 1. Add Fields   // 2. Add Constructor   // 3. Add Properties   // 4. Add Methods} |

### Step 2 – Define the fields

Define a **field** for each property the class should have (e.g. **Name** , **Age** )

### Step 3 - Define the Properties of a Person

Define the **Name** and **Age** properties of a Person. Ensure that **the class can only be changed by itself or its descendants** (pick the most appropriate access modifier).

| **Sample Code** |
| --- |
| publicvirtualstring Name{    get    {        //TODO    }    set    {        //TODO    }}publicvirtualint Age{    get    {        //TODO    }    set    {        //TODO    }} |

### Step 4 - Define a Constructor

Define a constructor that accepts **name and age**.

| **Sample Code** |
| --- |
| public Person(string name, int age){    this.Name = name;    this.Age = age;} |

### Step 5 - Perform Validations

After you have created a **field** for each property (e.g. **Name** and **Age** ), the next step is to **perform validations** for each one. The **getter should return the corresponding field&#39;s value** and the **setter should validate** the input data before setting it. Do this for each property.

| **Sample Code** |
| --- |
| publicvirtualint Age{    get    {         returnthis.age;    }    set    {        if (value \&lt; 0)        {            thrownewArgumentException(&quot;Age must be positive!&quot;);        }        //TODO set field age with value    }} |

### Constraints

- If the age of a person is negative – exception&#39;s message is: **&quot;Age must be positive!&quot;**
- If the age of a child is bigger than 15 – exception&#39;s message is: **&quot;**** Child&#39;s age must be less than 15! ****&quot;**
- If the name of a child or a person is no longer than three symbols – exception&#39;s message is: **&quot;**** Name&#39;s length should not be less than 3 symbols! ****&quot;**

### Step 6 - Override ToString()

As you probably already know, all classes in C# inherit the **Object** class and therefore have all its **public** members ( **T**** oString() **,** E****quals()** and **G**** etHashCode()**methods).**T****oString()** serves to return information about an instance as string. Let&#39;s **override** (change) its behavior for our **Person** class.

| **Sample Code** |
| --- |
| publicoverridestring ToString(){    StringBuilder stringBuilder = newStringBuilder();    stringBuilder.Append(String.Format(&quot;Name: {0}, Age: {1}&quot;,                         this.Name,                         this.Age));    return stringBuilder.ToString();} |

And voila! If everything is correct, we can now create **Person objects** and display information about them.

### Step 7 – Create a Child

Create a **Child** class that inherits **Person** and has the same constructor definition. However, do not copy the code from the Person class - **reuse the Person class&#39;s constructor**.

| **Sample Code** |
| --- |
| public Child(string name, int age)    : base(name, age){} |

There is **no need** to rewrite the Name and Age properties since **Child** inherits **Person** and by default has them.

### Step 8 – Validate the Child&#39;s setter

| **Sample Code** |
| --- |
| publicoverrideint Age{    get    {        returnbase.Age;    }    set    {        //TODO validate childs age        base.Age = value;    }} |

##Problem 2.Book Shop

You are working in a library. You are sick of writing descriptions for books by hand, so you wish to use the computer to speed up the process. The task is simple - your program should have two classes – one for the ordinary books – **Book** , and another for the special ones – **GoldenEditionBook**. So let&#39;s get started! We need two classes:

- ****** Book **- represents a book that holds** title **,** author **and** price **. A book should offer** information** about itself in the format shown in the output below.
- ****** GoldenEditionBook **- represents a special book that holds the same properties as any** Book **, but its** price **is always** 30% higher**.

### Constraints

- If the author&#39;s second name is starting with a digit –  the exception&#39;s message is: **&quot;**** Author not valid! ****&quot;**
- If the title&#39;s length is less than 3 symbols –  the exception&#39;s message is: **&quot;**** Title not valid!&quot;**
- If the price is zero or it is negative – the exception&#39;s message is: **&quot;**** Price not valid! ****&quot;**
- Price must be formatted to **two** symbols after the decimal separator



| **Sample Main()** |
| --- |
| staticvoid Main(){    try    {        string author = Console.ReadLine();        string title = Console.ReadLine();        decimal price = decimal.Parse(Console.ReadLine());        Book book = newBook(author, title, price);        GoldenEditionBook goldenEditionBook = newGoldenEditionBook(author, title, price);        Console.WriteLine(book + Environment.NewLine);        Console.WriteLine(goldenEditionBook);    }    catch (ArgumentException ae)    {        Console.WriteLine(ae.Message);    }} |

### Examples

| **Input** | **Output** |
| --- | --- |
| Ivo 4ndonovUnder Cover9999999999999999999 | Author not valid! |
| Petur IvanovLife of Pesho20 | Type: BookTitle: Life of PeshoAuthor: Petur IvanovPrice: 20.00Type: GoldenEditionBookTitle: Life of PeshoAuthor: Petur IvanovPrice: 26.00 |

### Step 1 - Create a Book Class

Create a new empty class and name it **Book**. Set its access modifier to **public** so it can be instantiated from any project.

| **Sample Code** |
| --- |
| publicclassBook{    //1. Add Fields    //2. Add Constructors    //3. Add Properties    //4. Add Methods} |

### Step 2 - Define the Properties of a Book

Define the **Title** , **Author** and **Price** properties of a Book. Ensure that they can only be **changed by the class itself or its descendants** (pick the most appropriate access modifier).

### Step 3 - Define a Constructor

Define a constructor that accepts **author, title** and **price** arguments.

| **Sample Code** |
| --- |
| public Book(string author, string title, decimal price){    this.Author = author;    this.Title = title;    this.Price = price;} |

### Step 4 - Perform Validations

Create a **field** for each property ( **Price** , **Title** and **Author** ) and **perform validations** for each one. The **getter should return the corresponding field** and the **setter should validate** the input data before setting it. Do this for every property.





| **Sample Code** |
| --- |
| publicstring Author{    get    {        returnthis.author;    }    set    {        //TODO validate value        this.author = value;    }}publicstring Title{    get    {        returnthis.title;    }    set    {        //TODO validate value        this.title = value;    }}public virtualdecimal Price{    get    {        returnthis.price;    }    set    {        //TODO validate value        this.price = value;    }} |

### Step 5 - Override ToString()

We have already mentioned that all of the classes in C# inherit the **System.Object** class and therefore have all its **public** members. Let&#39;s **override** (change)  the **ToString()** method&#39;s behavior again according to our **Book** class&#39;s data.



| **Sample Code** |
| --- |
| publicoverridestring ToString(){    var resultBuilder = new StringBuilder();    resultBuilder.AppendLine($&quot;Type: {this.GetType().Name}&quot;)        .AppendLine($&quot;Title: {this.Title}&quot;)        .AppendLine($&quot;Author: {this.Author}&quot;)        .AppendLine($&quot;Price: {this.Price:f2}&quot;);     string result = resultBuilder.ToString().TrimEnd();    return result;} |

And voila! If everything is correct, we can now create **Book objects** and display information about them.

### Step 6 – Create a GoldenEditionBook

Create a **GoldenEditionBook** class that inherits **Book** and has the same constructor definition. However, do not copy the code from the Book class - **reuse the Book class constructor**.

| **Sample Code** |
| --- |
| public GoldenEditionBook(string author, string title, decimal price)     : base(author, title, price){ } |

There is **no need** to rewrite the Price, Title and Author properties since **GoldenEditionBook** inherits **Book** and by default has them.

### Step 7 - Override the Price Property

Golden edition books should return a **30%** higher **price** than the original price. In order for the getter to return a different value, we need to override the Price property.

Back to the **GoldenEditionBook** class, let&#39;s override the Price property and change the getter body

| **Sample Code** |
| --- |
| publicoverridedecimal Price{    get    {        returnbase.Price \* 1.3;    }} |

##Problem 3.Mankind

Your task is to model an application. It is very simple. The mandatory models of our application are 3:   **Human** , **Worker** and **Student**.

The parent class – Human should have **first name** and **last name**. Every student has a **faculty number**. Every worker has a **week salary** and **work hours per day**. It should be able to calculate the money he earns by an hour. You can see the constraints below.

### Input

On the first input line, you will be given info about a single student - a name and faculty number.

On the second input line, you will be given info about a single worker - first name, last name, salary and working hours.

### Output

You should print the info about the student first, followed by a single blank line and after that the info about the worker in the given formats:

- Print the student info in the following format:

  **First Name: {student&#39;s first name}**

**        Last Name: {student&#39;s last name}**

**        Faculty number: {student&#39;s faculty number}**

- Print the worker info in the following format:

**        First Name: {worker&#39;s first name}**

**Last Name: {worker&#39;s second name}**

**Week Salary: {worker&#39;s salary}**

**Hours per day: {worker&#39;s working hours}**

**Salary per hour: {worker&#39;s salary per hour}**

Print exactly two digits after every double value&#39;s decimal separator (e.g. 10.00). Consider the workweek from Monday to Friday. A faculty number should be consisted only of digits and letters.

### Constraints

| **Parameter** | **Constraint** | **Exception Message** |
| --- | --- | --- |
| Human first name | Should start with a capital letter | &quot;Expected upper case letter! Argument: firstName&quot; |
| Human first name | Should be more than 3 symbols | &quot;Expected length at least 4 symbols! Argument: firstName&quot; |
| Human last name | Should start with a capital letter | &quot;Expected upper case letter! Argument: lastName&quot; |
| Human last name | Should be more than 2 symbols | &quot;Expected length at least 3 symbols! Argument: lastName &quot; |
| Faculty number | Should be in range [5..10] symbols | &quot;Invalid faculty number!&quot; |
| Week salary | Should be more than 10 | &quot;Expected value mismatch! Argument: weekSalary&quot; |
| Working hours | Should be in the range [1..12] | &quot;Expected value mismatch! Argument: workHoursPerDay&quot; |

### Example

| **Input** | **Output** |
| --- | --- |
| Ivan Ivanov 08Pesho Kirov 1590 10 | Invalid faculty number! |
| Stefo Mk321 0812111Ivcho Ivancov 1590 10 | First Name: StefoLast Name: Mk321Faculty number: 0812111First Name: IvchoLast Name: IvancovWeek Salary: 1590.00Hours per day: 10.00Salary per hour: 31.80 |

##Problem 4.Online Radio Database

Create an online radio station database. It should keep information about all of the added songs. On the first line you are going to get the number of songs you are going to try to add. On the next lines you will get the songs to be added in the format **\&lt;artist name\&gt;;\&lt;song name\&gt;;\&lt;minutes:seconds\&gt;**. To be valid, every song should have an artist name, a song name and a length.

Design a custom exception hierarchy for invalid songs:

- InvalidSongException
  - InvalidArtistNameException
  - InvalidSongNameException
  - InvalidSongLengthException
    - InvalidSongMinutesException
    - InvalidSongSecondsException

### Validation

- Artist name should be between 3 and 20 symbols.
- Song name should be between 3 and 30 symbols.
- Song length should be between 0 second and 14 minutes and 59 seconds.
- Song minutes should be between 0 and 14.
- Song seconds should be between 0 and 59.

### Exception Messages

| **Exception** | **Message** |
| --- | --- |
| InvalidSongException | &quot;Invalid song.&quot; |
| InvalidArtistNameException | &quot;Artist name should be between 3 and 20 symbols.&quot; |
| InvalidSongNameException | &quot;Song name should be between 3 and 30 symbols.&quot; |
| InvalidSongLengthException | &quot;Invalid song length.&quot; |
| InvalidSongMinutesException | &quot;Song minutes should be between 0 and 14.&quot; |
| InvalidSongSecondsException | &quot;Song seconds should be between 0 and 59.&quot; |

**Note** : Check validity in the order **artist name** -\&gt; **song name** -\&gt; **song length**

### Output

If the song is added, print &quot; **Song added.**&quot;. If you **can&#39;t add a song** , print an **appropriate exception message**. On the last two lines print the **number of songs added** and the **total length of the playlist** in format **{Playlist length: 0h 7m 47s}.**

### Examples

| **Exception** | **Message** |
| --- | --- |
| 3ABBA;Mamma Mia;3:35Nasko Mentata;Shopskata salata;4:123Nasko Mentata;Shopskata salata;4:12 | Song added.Song seconds should be between 0 and 59.Song added.Songs added: 2Playlist length: 0h 7m 47s |
| 5Nasko Mentata;Shopskata salata;14:59Nasko Mentata;Shopskata salata;14:59Nasko Mentata;Shopskata salata;14:59Nasko Mentata;Shopskata salata;14:59Nasko Mentata;Shopskata salata;0:5 | Song added.Song added.Song added.Song added.Song added.Songs added: 5Playlist length: 1h 0m 1s |

##Problem 5.\*Mordor&#39;s Cruel Plan

Gandalf the Gray is a great wizard but he also loves to eat and the food makes him loose his capability of fighting the dark. The Mordor&#39;s orcs have asked you to design them a program that calculates Gandalf&#39;s mood, so they can predict the battles between them and try to beat The Gray Wizard.  When Gandalf is hungry, he gets angry and he cannot fight well. The orcs&#39; spy has revealed to them the foods that Gandalf is eating and the result on his mood after he had eaten each of them. Here is the list:

- **Cram** : 2 points of happiness;
- **Lembas** : 3 points of happiness;
- **Apple** : 1 point of happiness;
- **Melon** : 1 point of happiness;
- **HoneyCake** : 5 points of happiness;
- **Mushrooms** : -10 points of happiness;
- **Everything else** : -1 point of happiness;

Gandalf&#39;s moods are:

- **Angry** - below -5 points of happiness;
- **Sad** - from -5 to 0 points of happiness;
- **Happy** - from 1 to 15 points of happiness;
- **JavaScript** - when happiness points are more than 15;

The task is simple. Model an application that calculates the happiness points Gandalf has after eating all the food passed in the input. After you are done, print on the first line – total happiness points Gandalf had collected. On the second line – print the **Mood&#39;s** name, which corresponds to the points.

### Input

The input comes from the console. It will hold a single line: all of the foods Gandalf has eaten separated by a whitespace.

### Output

Print on the console Gandalf`s happiness points and the **Mood&#39;s** name which is corresponding to the points.

### Constraints

- The characters in the input string will be no more than: **1000.**
- The food count would be in the range **[1…100]**.
- Time limit: 0.3 sec. Memory limit: 16 MB.

### Note

Try to implement a factory pattern. You should have two factory classes – **FoodFactory** and **MoodFactory**. And their task is to produce objects (e.g. **FoodFactory** , produces – **Food** and the **MoodFactory** - **Mood** ). Try to implement abstract classes (e.g. classes which can&#39;t be instantiated directly)

### Examples

| **Input** | **Output** |
| --- | --- |
| Cram melon honeyCake Cake | 7Happy |
| gosho, pesho, meze, Melon, HoneyCake@; | -5Sad |

##Problem 6.Animals

Create a hierarchy of **Animals**. Your program should have three different animals – **Dog** , **Frog** and **Cat**. Deeper in the hierarchy you should have two additional classes – **Kitten** and **Tomcat**. **Kittens are female and Tomcats are male!**

All types of animals should be able to produce some kind of sound (**ProduceSound()**). For example, the dog should be able to bark.

Your task is to model the hierarchy and test its functionality. Create an animal of each kind and make them all produce sound.

You will be given some lines of input. Each two lines will represent an animal. On the first line will be the type of animal and on the second – the name, the age and the gender. When the command &quot; **Beast!**&quot; is given, stop the input and print all the animals in the format shown below.

### Output

- Print the information for each animal on three lines. On the first line, print: &quot;\&lt; **AnimalType** \&gt;&quot;
- On the second line print: &quot;\&lt; **Name** \&gt; \&lt; **Age** \&gt; \&lt; **Gender** \&gt;&quot;
- On the third line print the sounds it produces: &quot;\&lt;**ProduceSound()**\&gt;&quot;

### Constraints

- **** Each **Animal** should have a **name** , an **age** and a **gender**
- ****** All **input values should** not be blank** (e.g. name, age and so on…)
- **** If you receive an input for the **gender** of a **Tomcat** or a **Kitten** , ignore it but **create** the animal
- **** If the input is invalid for one of the properties, throw an exception with message: &quot;I **nvalid input!**&quot;
- **** Each animal should have the functionality to **ProduceSound()**
- **** Here is the type of sound each animal should produce:
  - **oo**** Dog: &quot;Woof!&quot;**
  - **oo**** Cat: &quot;Meow meow&quot;**
  - **oo**** Frog: &quot;Ribbit&quot;**
  - **oo**** Kittens: &quot;Meow&quot;**
  - **oo**** Tomcat: &quot;MEOW&quot;**

### Examples

| **Input** | **Output** |
| --- | --- |
| CatTom 12 MaleDogSharo 132 MaleBeast! | Cat Tom 12 MaleMeow meowDog Sharo 132 MaleWoof! |
| FrogKermit 12 MaleBeast! | Frog Kermit 12 MaleRibbit |
| FrogSashko -2 MaleFrogSashko 2 MaleBeast! | Invalid input!FrogSashko 2 MaleRibbit |

### **Bonus**

Create an interface **ISoundProducable** and implement it in the **Animal** class.