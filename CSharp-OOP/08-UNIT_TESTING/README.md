# Exercises: Unit Testing

## Problem 1.Database

Create a simple class - **Database**. It should **store integers**. You should **set the initial integers by constructor**. Store them **in array**. Your Database should have a functionality to **add** , **remove** and **fetch all stored items**. Your task is to **test the class**. In other words, create the class and **write tests** , so you are sure its methods are working as intended.

### Constraints

- Storing array&#39;s **capacity** must be **exactly 16 integers**
  - If the size of the array is not 16 integers long, throw **InvalidOperationException**
- **Add** operation, should **add an element at the next free cell** (just like a stack)
  - If there are 16 elements in the Database and try to add 17, throw an **InvalidOperationException**
- **Remove** peration, should support only removing an element **at the last index** (just like a stack)
  - If you try to remove element from empty Database throw **InvalidOperationException**
- **Constructors** should take integers only, and store them in **array**
- **Fetch method** should return the elements as **array**

### Hint

Do not forget to **test the constructor(s)**. They are methods too!

## Problem 2.Extended Database

You already have a class - **Database**. Now your task is to modify and extend it. It should support, **adding, removing and finding People**. In other words, it should **store People**. There should be two types of finding methods - first: **FindById (long id)** and the second one: **FindByUsername (string username)**. As you may guess, each person should have its own **unique id** , and **unique username**. Your task is to implement these functions and test them.

### Constraints

Database should have methods:

- Add
  - If there are already users with this username, throw **InvalidOperationException**
  - If there are already users with this id, throw **InvalidOperationException**
- Remove
- FindByUsername
  - If no user is present by this username, throw **InvalidOperationException**
  - If username parameter is null, throw **ArgumentNullException**
  - Arguments are all **CaseSensitive**
- FindById
  - If no user is present by this id, throw **InvalidOperationException**
  - If negative ids are found, throw **ArgumentOutOfRangeException**

### Hint

Do not forget to test the constructor(s). They are methods too!

## Problem 3.Custom Linked List

Use the VS **solution**&quot; **CustomLinkedList**&quot;.

- Create new **Unit**** Test ****Project** and **add**** reference **to the &quot;** CustomLinkedList**&quot;.
- Create Test Methods for **all public members** that need testing.
- Create tests that ensure all methods, getters and setters **work correctly** (do not test auto-properties).
- Make sure that the methods throw the correct exceptions in case wrong input is entered.
- Give **meaningful**** assert ****messages** for failed tests.

## Problem 4.Storage Master

You are given a quite familiar with C# OOP Basic Exam  -  Storage Master. You have provided author solution, and your task is to create unit tests, for the skeleton structure and for business logic.

- Create two **Unit**** Test ****Projects** called **StorageMester.Tests.Structure** and **StorageMester. Tests.BusinessLogic**. **Add**** reference **to the &quot;** StorageMaster**&quot;.
- For the **StorageMester.Tests.Structure** you need to test if all fields, consts, propeties, constructorsand methods exists.
- For the **StorageMester.BusinessLogic.Tests** you need to test if all business methods are implemented properly.