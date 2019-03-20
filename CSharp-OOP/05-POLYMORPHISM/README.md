# Exercises : Polymorphism

Problems for exercises and homework for the [&quot;C# OOP&quot; course @ SoftUni&quot;](https://softuni.bg/trainings/2244/csharp-oop-february-2019).

You can check your solutions here: [h](https://judge.softuni.bg/Contests/1504/Polymorphism-Exercise)[ttps://judge.softuni.bg/Contests/1504/Polymorphism-Exercise](https://judge.softuni.bg/Contests/1504/Polymorphism-Exercise)

##Problem 1.Vehicles

Write a program that models 2 vehicles (a **Car** and a **Truck** ) and simulates **driving** and **refueling** them. **Car** and **truck** both have **fuel quantity** , **fuel consumption**** in liters ****per km** and can be **driven a given distance** and **refueled with a given amount of fuel.** It&#39;s summer, so both vehicles use air conditioners and their **fuel consumption** per km is **increased** by **0.9** liters for the **car** and with **1.6** liters for the **truck**. Also, the **truck** has a tiny hole in its tank and when its **refueled** it keeps only **95%** of the given **fuel**. The **car** has no problems and adds **all the given fuel to its tank.** If a vehicle cannot travel the given distance, its fuel does not change.

### Input

- On the **first**** line ****–** information about the **car** inthe **format:****&quot;Car {fuel quantity} {liters per km}&quot;**
- On the **second**** line **– info about the truck inthe** format: ****&quot;Truck {fuel quantity} {liters per km}&quot;**
- Onthe **third**** line ****–** the **number** of **commands** N that will be given on the next N **lines**
- On the next N lines – commands in **the** format **:**

- **&quot;Drive Car {distance}&quot;**
- **&quot;Drive Truck {distance}&quot;**
- **&quot;Refuel Car {liters}&quot;**
- **&quot;Refuel Truck {liters}&quot;**

### Output

- **After each** Drivecommand **, if there was** enough **fuel,** print **on the console a** message **in the format:**

- **&quot;Car/Truck travelled {distance} km&quot;**

- Iftherewas **not enough fuel** ,print **:**  **&quot;Car/Truck needs refueling&quot;**

- After the End command, print the remaining fuel for both the car and the truck, **rounded** to **2 digits** after the floating point in the format:

- **&quot;Car: {liters}&quot;**
- **&quot;Truck: {liters}&quot;**

### Examples

| **Input** | **Output** |
| --- | --- |
| Car 15 0.3Truck 100 0.94Drive Car 9Drive Car 30Refuel Car 50Drive Truck 10 | Car travelled 9 kmCar needs refuelingTruck travelled 10 kmCar: 54.20Truck: 75.00 |
| Car 30.4 0.4Truck 99.34 0.95Drive Car 500Drive Car 13.5Refuel Truck 10.300Drive Truck 56.2Refuel Car 100.2 | Car needs refuelingCar travelled 13.5 kmTruck needs refuelingCar: 113.05Truck: 109.13 |

##Problem 2.Vehicles Extension

Use your solution of the **previous** task for the starting point and add more functionality. Add a new vehicle – **Bus**. Add to every **vehicle** a new property – **tank**** capacity **. A vehicle cannot** start ****with** or **refuel**** above **its** tank ****capacity**.

If you **try to put more fuel** in the tank than the **available space,** print on the console **&quot;**** Cannot fit {fuel amount} fuel in the tank ****&quot;** and **do not add any fuel** in the vehicle&#39;s tank. If you try to **create** a vehicle with **more**** fuel **than its** tank ****capacity** , **create** it but start with an **empty**** tank**.

Add a **new command** for the bus. You can **drive** the **bus**** with or without people **.** With people **, the** air-conditioner ****is turned on** and its **fuel consumption** per kilometer is **increased by 1.4 liters**. If there are **no people in the bus** , the air-conditioner is **turned off** and **does not increase** the fuel consumption.

Finally, add a **validation** for the **amount** of **fuel** given to the **Refuel**** command **– if it is 0 or negative, print**&quot; ****Fuel must be a positive number****&quot;**.

### Input

- On the **first**** three ****lines** you will receive information about the vehicles in the format:

- **&quot;**** Vehicle {initial fuel quantity} {liters per km} {tank capacity} ****&quot;**

- On the **fourth**** line **– the number of** commands ****N** that will be given on the next N lines
- On the **next**** N ****lines** – commands in format:

- **&quot;**** Drive Car {distance} ****&quot;**
- **&quot;**** Drive Truck {distance} ****&quot;**
- **&quot;**** Drive Bus {distance} ****&quot;**
- **&quot;**** DriveEmpty Bus {distance} ****&quot;**
- **&quot;**** Refuel Car {liters} ****&quot;**
- **&quot;**** Refuel Truck {liters} ****&quot;**
- **&quot;**** Refuel Bus {liters} ****&quot;**

### Output

- **After each** Drivecommand **, if there was** enough **fuel,** print **on the console a** message **in the format:**

- **&quot;Car/Truck travelled {distance} km&quot;**

- Iftherewas **not enough fuel** ,print **:**

- **&quot;Car/Truck needs refueling&quot;**

- If you try to **refuel** with an **amount**  **≤ 0** print:

- **&quot;Fuel must be a positive number&quot;**

- If the given **fuel**** cannot **fit in the** tank**, print:

- **&quot;Cannot fit {fuel amount} fuel in the tank&quot;**

- After the End command, print the remaining fuel for all vehicles, **rounded** to **2 digits** after the floating point in the format:

- **&quot;Car: {liters}&quot;**
- **&quot;Truck: {liters}&quot;**
- **&quot;Bus: {liters}&quot;**

### Example

| **Input** | **Output** |
| --- | --- |
| Car 30 0.04 70Truck 100 0.5 300Bus 40 0.3 1508Refuel Car -10Refuel Truck 0Refuel Car 10Refuel Car 300Drive Bus 10Refuel Bus 1000DriveEmpty Bus 100Refuel Truck 1000   | Fuel must be a positive numberFuel must be a positive numberCannot fit 300 fuel in the tankBus travelled 10 kmCannot fit 1000 fuel in the tankBus needs refuelingCannot fit 1000 fuel in the tankCar: 40.00Truck: 100.00Bus: 23.00 |

##Problem 3.Wild Farm

Your task is to create a **class**** hierarchy **like the** described ****below**. The **Animal** , **Bird** , **Mammal** , **Feline** and **Food** classes should be **abstract**. Override the method **ToString()**.

- **Food – int Quantity;**
  - **Vegetable;**
  - **Fruit;**
  - **Meat;**
  - **Seeds;**
- **Animal – string Name, double Weight, int FoodEaten;**
  - **Bird – double WingSize;**
    - **Owl;**
    - **Hen;**
  - **Mammal – string LivingRegion;**
    - **Mouse;**
    - **Dog;**
    - **Feline – string Breed;**
      - **Cat;**
      - **Tiger;**

All **animals** should also have the **ability** to ask for food by **producing** a **sound**.

- **Owl – &quot;Hoot Hoot&quot;;**
- **Hen – &quot;Cluck&quot;;**
- **Mouse – &quot;Squeak&quot;;**
- **Dog – &quot;Woof!&quot;;**
- **Cat – &quot;Meow&quot;;**
- **Tiger – &quot;ROAR!!!&quot;;**

Now use the **classes that** you have created to **instantiate** some **animals** and **feed**** them**.
Input should be read from the console. Every **even** line (starting from 0) will **contain**** information **about an** animal** in the following format:

- **Felines - &quot;**** {Type} {Name} {Weight} {LivingRegion} {Breed} ****&quot;;**
- **Birds - &quot;**** {Type} {Name} {Weight} {WingSize} ****&quot;;**
- **Mice and Dogs - &quot;**** {Type} {Name} {Weight} {LivingRegion} ****&quot;;**

On the **odd** lines, you will receive **information** about a piece of **food** that you should **give** to that **animal**. The line will consist of a **FoodType** and **quantity** , separated by a whitespace.

Animals will only eat a certain type of food, as follows:

- **Hens** eat **everything** ;
- **Mice** eat **vegetables** and **fruits** ;
- **Cats** eat **vegetables** and **meat** ;
- **Tigers** , **Dogs** and **Owls** eat **only**** meat**;

If you try to give an animal a different type of food, it will not eat it and you should print:

- **&quot;**** {AnimalType} does not eat {FoodType}! ****&quot;**

The **weight** of an **animal** will **increase** with **every**** piece **of** food **it** eats**, as follows:

- **Hen – 0.35;**
- **Owl – 0.25;**
- **Mouse – 0.10;**
- **Cat – 0.30;**
- **Dog – 0.40;**
- **Tiger – 1.00;**

Override the **ToString()** method to print the information about an animal in the formats:

- **Birds**  **–****&quot;****{AnimalType} [{AnimalName}, {WingSize}, {AnimalWeight}, {FoodEaten}]****&quot;**
- **Felines –**  **&quot;**** {AnimalType} [{AnimalName}, {Breed}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}] ****&quot;**
- **Mice and Dogs –****&quot;****{AnimalType} [{AnimalName}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]****&quot;**

After you have read the **information** about the **animal** and the **food** , the **animal** will **produce a**** sound**(**print **it on the** console**). Next, you should**try **to** feed **it. After receiving the &quot;** End **&quot; command,** print **information about** every ****animal** in **order** of **input**.

| **Input** | **Output** |
| --- | --- |
| Cat Pesho 1.1 Home PersianVegetable 4End | MeowCat [Pesho, Persian, 2.3, Home, 4] |
| Tiger Typcho 167.7 Asia BengalVegetable 1Dog Doncho 500 Street Vegetable 150End | ROAR!!!Tiger does not eat Vegetable!Woof!Dog does not eat Vegetable!Tiger [Typcho, Bengal, 167.7, Asia, 0]Dog [Doncho, 500, Street, 0] |
| Mouse Jerry 0.5 AnywhereFruit 1000Owl Toncho 2.5 30Meat 5End | SqueakHoot HootMouse [Jerry, 100.5, Anywhere, 1000]Owl [Toncho, 30, 3.75, 5] |