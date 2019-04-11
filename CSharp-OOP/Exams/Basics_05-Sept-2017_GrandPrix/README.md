# OOP Basics Retake Exam – Grand Prix

It&#39;s racing time again! Welcome to Grand Prix de SoftUni!

### Overview

You should write a software which simulates a Formula 1 race under number of commands. Different number of **Drivers** can participate in each race and each driver … well, drives a **Car**. Drivers have different attitude on the track and cars have different specifications which makes the race that thrilling!

## Task 1: Structure

### Drivers

All drivers have a name, total time record and a car to drive:
**Name** – a **string**
**TotalTime** – a **floating-point number**
**Car -**  **parameter of type**  **Car**
**FuelConsumptionPerKm** – a **floating-point number**
**Speed** – a **floating-point number**

Driver&#39;s **Speed** is calculated throught the formula below. Keep in mind that Speed changes on each lap.
**Speed = &quot;(car&#39;s Hp + tyre&#39;s degradation) / car&#39;s fuelAmount&quot;**

#### AggressiveDriver
This type of drivers have **FuelConsumptionPerKm** equal to **2.7 liters**. Also aggressive driver&#39;s **Speed** is **multiplied by 1.3.**

#### EnduranceDriver
This type of drivers have **FuelConsumptionPerKm** equal to **1.5 liters**.

### Cars
Each car should keep its horsepower (Hp), fuel amount and the **type** of tyres fit at the moment

**Hp** –  an **integer**
**FuelAmount** – a **floating-point number**
**Tyre -**  **parameter of type**  **Tyre**

The fuel tank&#39;s **maximum capacity** of each car is **160 liters**. Fuel amount **cannot become bigger** than the tank&#39;s maximum capacity. If you are given **more fuel**** than **needed you should fill up the tank to the** maxiumum **and** nothing else happens**.

If **fuel amount** drops **below 0 liters** you should **throw an exception** and the **driver cannot continue** the race.

### Tyres
Every type of tyre has different hardness of the compound. It also has a degradation level, which is its lifetime:
**Name** – a **string**
**Hardness** –  a **floating-point number**
**Degradation** - **a** floating-point number

Every tyre **starts** with **100** points **degradation** and drops down **towards 0**. Upon each lap it&#39;s degradation is **reduced** by **the value of the** hardness. If a tyre&#39;s degradation drops below 0 points the tyre blows up and the **driver cannot continue the race**. If a tyre blows up you should **throw an exeption**.

#### UltrasoftTyre
Because it&#39;s ultra-soft this type of tyre has an additional property:
**Grip** –  a positive **floating-point number**
The name of this tyre is always &quot; **Ultrasoft**&quot;.

Upon **each lap** , it&#39;s **Degradation**  **drops down** by its **Hardness**  **summed** with its **Grip**. Also, the ultra-soft tyre **blows up** when tyre&#39;s **Degradation**  **drops below 30** points.

#### HardTyre
The name of this tyre is always &quot; **Hard**&quot;. Hard tyres have less grip and slow down the car but endure bigger distance.

## Task 2: Business Logic

_Overview: Each execution of the application simulates_ **only one** _race. In the beginning, you receive info about the track (laps / length) after which drivers are registered. The start of the race is marked by the first CompleteLaps command. The race finishes when all the laps are done by the drivers._

### The Controller Class
The business logic of the program should be concentrated around several commands. Implement a class called **RaceTower** , which will hold the **main functionality** , represented by these **public**** methods**:

| RaceTower.cs |
| --- |
| voidSetTrackInfo(int lapsNumber, int trackLength)|
{    //TODO: Add some logic here …}|
voidRegisterDriver(List\&lt;string\&gt; commandArgs)|
{     //TODO: Add some logic here …} |
voidDriverBoxes(List\&lt;string\&gt; commandArgs)|
{     //TODO: Add some logic here …} |
string CompleteLaps(List\&lt;string\&gt; commandArgs)|
{     //TODO: Add some logic here …} |
stringGetLeaderboard()|
{     //TODO: Add some logic here …} |
voidChangeWeather(List\&lt;string\&gt; commandArgs)|
{     //TODO: Add some logic here …} |

**NOTE: RaceTower class** methods are called from the outside so these methods **must NOT** receive the command parameter (the first argument from the input line) as part of the arguments!

Method **SetTrackInfo** ()should initialize track&#39;s total **laps number** and **length**.

### Commands

There are several commands that control the business logic of the application and you are supposed to build.
They are stated below.

#### RegisterDriver Command

Creates a **Driver** , and registers it into the race. Input data may **not** be **always** valid. If you can&#39;t create a Driver with the data provided upon this command just skip it . All **successfully registered** drivers should be **saved inside the Racetower class** in any type data structure provided by .NET Framework (no custom structures).

##### Parameters
- **type** – a **string** , equal to either &quot; **Aggressive**&quot;or &quot; **Endurance**&quot;
- **name** – a **string**
- **hp** – an **integer**
- **fuelAmount** – a **floating-point number**
- **tyreType** – a **string**
- **tyreHardness** – a **floating-point number**

If the type of tyre is **Ultrasoft** , you will receive **1 extra parameter** :
- **grip** –  a positive **floating-point number**

#### Leaderboard Command
On the first line print:
**_Lap {current lap}/{total laps number}_**

On the next lines, all drivers should be displayed in the order of their progress in the following format:
**_{Position number} {Driver&#39;s Name} {Total time / Failure reason}_**
Drivers are ordered by their TotalTime in acsending order.

#### CompleteLaps Command
Upon this command, **all drivers** progress the race with the **specified number** of laps.   **On each lap** , each driver&#39;s **TotalTime** should be increased with the result of the following formula:
**&quot;60 / (trackLength / driver&#39;s Speed)&quot;**

**After each** lap, you must do the **actions below** in the **exact same order** :

1. Reduce **FuelAmount** by: **&quot;trackLength \* driver&#39;s fuelConsumptionPerKm&quot;**.
2. Degradate tyre **according** to its **type**

If you are given **greater laps number** than the number of **laps left** in the race you should **throw an exception** with the **appropriate message** and **not increment** the **completed** laps number.

**After** increasing **the TotalTime** and decreasing driver&#39;s resources(reduce FuelAmount, degradate Tyre) you should **check for overtaking** opportunities. For more info read the **Additional Action >> Overtaking** section.

##### Parameters
- **numberOfLaps** – an **integer**

#### Box Command

Makes a driver to box at the current lap which **adds 20 seconds** to his **TotalTime** and either **changes** his **tyres** with **new ones** of the specified type **or refills** with **fuel**.

##### Parameters
- **reasonToBox** - a **string** , equal to either **ChangeTyres** or **Refuel**
- **driversName** - a **string** specifying which driver boxes
- **tyreType / fuelAmount** - a **string** specifying the type of the new tyre / a **floating-point** specifying how much fuel is refilled

If the reason is **ChangeTyres** , you will receive **extra parameters** :
- **tyreHardness** - a **floating-point** specifying the new tyres hardness (only for the **ChangeTyres** case)

If the type of tyre is **Ultrasoft** , you will receive **1 extra parameter** :
- **grip** –  a positive **floating-point number**

#### ChangeWeather Command

Changes the current weather. In the beginning, the weather is **Sunny** by default. Input parameter will **always** be **valid**!

##### Parameters

- **weather** – a **string** equal to one of the following: &quot; **Rainy**&quot;, &quot; **Foggy**&quot;, &quot; **Sunny**&quot;

### Additional Action

#### DNF

If a driver **stops** because of **some failure** he **doesn&#39;t**** progress **in the race anymore under the** CompleteLaps**command (his stats get frozen).Drivers that are not racing anymore** but still take part **at the bottom of the Leaderboard in the order of their failure occurrence** (the latest failed driver is at the very bottom).

- The message in case of a blown tyre should be - &quot; **Blown Tyre**&quot;
- The message in case of getting out of fuel should be - &quot; **Out of fuel**&quot;
- The message in case of a crash should be - &quot; **Crashed**&quot;

#### Overtaking

At **certain conditions** drivers overtake each other. Generally, if a driver is **2 seconds or less behind** another driver at the end of a lap, he **overtakes** the driver **ahead** which **reduces** his **TotalTime** with the same interval of 2 secondsand **increases** the drivers that **has been** ahead **TotalTime** again with **the same interval**. Although there are some special cases:

- **AggressiveDriver** on **UltrasoftTyre** has an overtake **interval** up to **3** seconds to the driver ahead and  **crashes in _Foggy_ weather**.
- **EnduranceDriver** on **HardTyre** has an overtake **interval** up to **3 seconds** to the driver ahead and **crashes** if **attempts** an overtake in _**Rainy**_ weather.

A driver is allowed to attempt an overtake **only once** in a **lap**. An overtaken driver is **not allowed** to **fight back** for his position in the same lap.

**Checking** for overtaking opportunities **must** happen from the **slowest** (last) driver to the **fastest** (first).

## Task 3: Input / Output

### Input
- On the **first line,** you will receive an **integer** representing the **number of laps** in the **race**
- On the **second** line **, you will receive an** integer **number representing the** length **of the** track
- On the **next** lines, you will receive **different** commands. You should **stop** reading the input when drivers complete **all** laps in the race

Below, you can see the **format** in which **each command** will be given in the input:
- _RegisterDriver {type} {name} {hp} {fuelAmount} { **tyreType** } {tyreHardness}_
- _RegisterDriver {type} {name} {hp} {fuelAmount} Ultrasoft {tyreHardness} { **grip** }_
- _Leaderboard_
- _CompleteLaps { **numberOfLaps** }_
- _Box **Refuel** { **driversName** } { **fuelAmount** }_
- _Box **ChangeTyres** { **driversName** } Hard { **tyreHardness** }_
- _Box **ChangeTyres** { **driversName** } **Ultrasoft** { **tyreHardness** } { **grip** }_
- _ChangeWeather {weather}_

### Output
Below you can see what output should be provided from the commands.

#### Leaderboard Command

Lap {current lap}/{total laps number}

On the next lines, all drivers should be displayed in the order of their progress in the following format:

{Position number} {Driver&#39;s Name} {Total time / Failure reason}

#### CompleteLaps Command
If you are given invalid number of laps print on the console:
&quot; **There is no time! On lap {current lap}.**&quot;

In case of a successful overtake you should print on the console:
&quot; **{Overtaking driver&#39;s name} has overtaken {Overtaken driver&#39;s name} on lap {Current lap number}.**&quot;

#### Finish

After all laps in the race are completed you should print the winner on the console in the following format:

**&quot;{Driver&#39;s name}**** wins the race for {TotalTime} seconds.&quot;
The **TotalTime** should be rounded to **three digits** after the **decimal** point.

### Constraints
- The **Driver&#39;s name** will be a string which may contain any ASCII character, except **space** (&#39; &#39;).
- The **names** of all drivers will always be **unique**.
- All drivers will be registered **before** the **race begins** (there won&#39;t be any **RegisterDriver** command after the first **CompleteLaps** command).
- A driver will **never** box twice in a lap.
- Each race **will have** a finishing driver.
- There will be **NO invalid** input data.

### Examples

| **Input** | **Output** |
| --- | --- |
| 32| Lap 17/32
3|1 ThirdDriver 2896.110
RegisterDriver Aggressive FirstDriver 650 140 Ultrasoft 0.2 3.8| 2 FirstDriver 6918.938
RegisterDriver Endurance SecondDriver 467 78.48 Hard 0.8| 3 SecondDriver 7209.032
RegisterDriver Endurance ThirdDriver 160 78.48 Ultrasoft 0.4 2.7 | SecondDriver wins the race for 9838.183 seconds.
CompleteLaps 17 |
LeaderboardBox |
Refuel SecondDriver 98.28 |
CompleteLaps 15 | 
   |
| 105RegisterDriver Aggressive FirstDriver 650 140 Ultrasoft 10.2 3.0RegisterDriver Aggressive SecondDriver 650 140 Hard 3.9RegisterDriver Endurance ThirdDriver 360 78.48 Ultrasoft 2.4 0.7CompleteLaps 14CompleteLaps 8LeaderboardBox ChangeTyres ThirdDriver Hard 0.3CompleteLaps 2 | There is no time! On lap 0.FirstDriver has overtaken SecondDriver on lap 1.Lap 8/101 ThirdDriver 931.5872 SecondDriver 1127.0983 FirstDriver Blown TyreThirdDriver wins the race for 1752.693 seconds. |
| 145RegisterDriver Endurance FirstDriver 650 140 Hard 0.2RegisterDriver Endurance SecondDriver 650 140 Ultrasoft 0.2 0.3RegisterDriver Aggressive ThirdDriver 350 100 Ultrasoft 0.2 0.3RegisterDriver Aggressive FourthDriver 450 60 Hard 1.2ChangeWeather RainyCompleteLaps 1LeaderboardBox Refuel FourthDriver 168CompleteLaps 6Box Refuel FourthDriver 2CompleteLaps 6LeaderboardCompleteLaps 1 | Lap 1/141 SecondDriver 64.2862 ThirdDriver 70.2003 FourthDriver 143.0004 FirstDriver CrashedLap 13/141 SecondDriver 1353.1242 FourthDriver 2122.9493 ThirdDriver Out of fuel4 FirstDriver CrashedSecondDriver wins the race for 1563.054 seconds. |