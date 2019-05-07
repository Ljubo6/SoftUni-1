# Exercises: Advanced Querying

# BookShop System

For the following tasks, use the [BookShop](http://svn.softuni.org/admin/svn/csharp-databases/2019-Jan/2.%20DB-Advanced-EF-Core/07.%20DB-Advanced-Advanced-Querying/BookShop.zip) database.

## 1.Age Restriction

**NOTE** : You will need method publicstaticstring **GetBooksByAgeRestriction** (BookShopContext context, string command) and publicStartUp class.

Return in a **single**** string **allbook** titles **, each on a** new line, **that have** age ****restriction** , equal to the **given**** command **. Order the titles** alphabetically**.

Read **input** from the console in your **main**** method **, and call your** method **with the** necessary ****arguments**. Print the **returned**** string **to the console.** Ignore** casing of the input.

### Example

| **Input** | **Output** |
| --- | --- |
| miNor | A Confederacy of DuncesA Farewell to ArmsA Handful of Dust… |
| teEN | A Passage to IndiaA Scanner DarklyA Swiftly Tilting Planet… |

## 2.Golden Books

**NOTE** : You will need method publicstaticstring **GetGoldenBooks** (BookShopContext context) and publicStartUp class.

Return in a **single** string **titles of the golden edition books** that have **less than 5000 copies** ,each on a **new line**. Order them by **book**** id** ascending.

Call the **GetGoldenBooks** (BookShopContext context) method in your **Main()**and print the returned string to the console.

### Example

| **Output** |
| --- |
| Lilies of the FieldLook HomewardThe Mirror Crack&#39;d from Side to Side… |

## 3.Books by Price

**NOTE** : You will need method publicstaticstring **GetBooksByPrice** (BookShopContext context) and publicStartUp class.

Return in a single string all **titles and prices**** of books **with** price higher than 40 **, each on a** new ****row** in the **format** given below. Order them by **price** descending.

### Example

| **Output** |
| --- |
| O Pioneers! - $49.90That Hideous Strength - $48.63A Handful of Dust - $48.63… |

## 4.Not Released In

**NOTE** : You will need method publicstaticstring **GetBooksNotReleasedIn** (BookShopContext context, int year) and publicStartUp class.

Return in a **single** string all **titles of books** that are **NOT released** on a given year. Order them by **book**** id** ascending.

### Example

| **Input** | **Output** |
| --- | --- |
| 2000 | AbsalomNectar in a SieveNine Coaches Waiting… |
| 1998 | The Needle&#39;s EyeNo Country for Old MenNo Highway… |

## 5.Book Titles by Category

**NOTE** : You will need method publicstaticstring **GetBooksByCategory** (BookShopContext context, string input) and publicStartUp class.

Returnin a single string the **titles of books** by a given **list of categories**. The list of **categories** will be given in a single line separated with one or more spaces. Ignore casing. Order by **title** alphabetically.

### Example

| **Input** | **Output** |
| --- | --- |
| horror mystery drama | A Fanatic HeartA Farewell to ArmsA Glass of Blessings… |

## 6.Released Before Date

**NOTE** : You will need method publicstaticstring **GetBooksReleasedBefore** (BookShopContext context, string date) and publicStartUp class.

Return **the title, edition type and price** of all books that are **released before a given date**. The date will be a string **in format**  **dd-MM-yyyy**.

Return all of the rows in a **single** string, ordered by **release**** date ****descending**.

### Example

| **Input** | **Output** |
| --- | --- |
| 12-04-1992 | If I Forget Thee Jerusalem - Gold - $33.21Oh! To be in England - Normal - $46.67The Monkey&#39;s Raincoat - Normal - $46.93… |
| 30-12-1989 | A Fanatic Heart - Normal - $9.41The Curious Incident of the Dog in the Night-Time - Normal - $23.41The Other Side of Silence - Gold - $46.26… |

## 7.Author Search

**NOTE** : You will need method publicstaticstring **GetAuthorNamesEndingIn** (BookShopContext context, string input) and publicStartUp class.

Return the **full**** names **of** authors **, whose** first ****name** ends with a **given**** string**.

Return all **names** in a **single**** string **, each on a** new ****row** , ordered alphabetically.

### Example

| **Input** | **Output** |
| --- | --- |
| e | George PowellJane Ortiz |
| dy | Randy Morales |

## 8.Book Search

**NOTE** : You will need method publicstaticstring **GetBookTitlesContaining** (BookShopContext context, string input) and publicStartUp class.

Return the **titles** of **book** , which contain a **given**** string**. Ignore casing.

Return all **titles** in a **single**** string **, each on a** new ****row** , ordered alphabetically.

### Example

| **Input** | **Output** |
| --- | --- |
| sK | A Catskill EagleThe Daffodil SkyThe Skull Beneath the Skin |
| WOR | Great Work of TimeTerrible Swift Sword |

## 9.Book Search by Author

**NOTE** : You will need method publicstaticstring **GetBooksByAuthor** (BookShopContext context, string input) and publicStartUp class.

Return **all titles of books and their authors&#39; names** for books, which are written by authors whose last names **start with the given string**.

Return a single string with each title on a new row. **Ignore** casing. Order by **book id** ascending.

### Example

| **Input** | **Output** |
| --- | --- |
| R | The Heart Is Deceitful Above All Things (Bozhidara Rysinova)His Dark Materials (Bozhidara Rysinova)The Heart Is a Lonely Hunter (Bozhidara Rysinova)… |
| po | Postern of Fate (Stanko Popov)Precious Bane (Stanko Popov)The Proper Study (Stanko Popov)… |

## 10.Count Books

**NOTE** : You will need method publicstaticint **CountBooks** (BookShopContext context, int lengthCheck) and publicStartUp class.

Return **the number of books,** which have a **title longer than the number** given as an input.

### Example

| **Input** | **Output** | **Comments** |
| --- | --- | --- |
| 12 | 169 | There are 169 books with longer title than 12 symbols |
| 40 | 2 | There are 2 books with longer title than 40 symbols |

## 11.Total Book Copies

**NOTE** : You will need method publicstaticstring **CountCopiesByAuthor** (BookShopContext context) and publicStartUp class.

Return the **total number of book copies** for each **author**. Order the results **descending by total book copies**.

Return all results in a **single string**, each on a **new line**.

### Example

| **Output** |
| --- |
| Stanko Popov - 117778
|Lyubov Ivanova - 107391
|Jane Ortiz – 103673
|… |

## 12.Profit by Category

**NOTE** : You will need method publicstaticstring **GetTotalProfitByCategory** (BookShopContext context) and publicStartUp class.

Return the **total profit of all books by category**. Profit for a book can be calculated by multiplying its **number of copies** by the **price per single book**. Order the results by **descending by total profit** for category and **ascending by category name**.

### Example

| **Output** |
| --- |
| Art $6428917.79
|Fantasy $5291439.71
|Adventure $5153920.77
|Children&#39;s $4809746.22
|… |

## 13.Most Recent Books

**NOTE** : You will need method publicstaticstring **GetMostRecentBooks** (BookShopContext context) and publicStartUp class.

Get the most recent books by categories. The **categories** should be ordered by **name alphabetically**. Only take the **top 3** most recent books from each category - ordered by **release date** (descending). **Select** and **print** the **category name** , and for each **book** – its **title** and **release year**.

### Example

| **Output** |
| --- |
| --ActionBrandy ofthe Damned (2015)
|Bonjour Tristesse (2013)
|By Grand Central Station I Sat Down and Wept (2010)
|--AdventureThe Cricket on the Hearth (2013)
|Dance Dance Dance (2002)
|Cover Her Face (2000)
|… |

## 14.Increase Prices

**NOTE** : You will need method publicstaticvoid **IncreasePrices** (BookShopContext context) and publicStartUp class.

**Increase the prices of all books released before 2010 by 5**.

## 15.Remove Books

**NOTE** : You will need method publicstaticint **RemoveBooks** (BookShopContext context) and publicStartUp class.

Removeall **books** , which have less than **4200 copies**. Return an **int** - the **number of books that were deleted** from the database.

### Example

| **Output** |
| --- |
| 34 |