# Exercises: XML Processing

## Product Shop Database

A products shop holds **users** , **products** and **categories** for the products. Users can **sell** and **buy** products.

- Users have an **id** , **first name** (optional) and **last name** and **age** (optional).
- Products have an **id** , **name** , **price** , **buyerId** (optional) and **sellerId** as IDs of users.
- Categories have an **id** and **name**.
- Using Entity Framework Code First create a database following the above description.

- **Users** should have **many products sold** and **many products bought**.
- **Products** should have **many categories**
- **Categories** should have **many products**
- **CategoryProducts** should **map products** and **categories**

## 1.Import Data

### Query 1.Import Users

**NOTE** : You will need method publicstaticstring ImportUsers(ProductShopContext context, string inputXml) and publicStartUp class.

Import the users from the provided file **users.xml**.

Your method should return string with message $&quot;Successfully imported {Users.Count}&quot;;

### Query 2.Import Products

**NOTE** : You will need method publicstaticstring ImportProducts(ProductShopContext context, string inputXml) and publicStartUp class.

Import the products from the provided file **products.xml**.

Your method should return string with message $&quot;Successfully imported {Products.Count}&quot;;

### Query 3.Import Categories

**NOTE** : You will need method publicstaticstring ImportCategories(ProductShopContext context, string inputXml) and publicStartUp class.

Import the categories from the provided file **categories.xml**.

Some of the names will be null, so you don&#39;t have to add them in the database. Just skip the record and continue.

Your method should return string with message $&quot;Successfully imported {Categories.Count}&quot;;

### Query 4.Import Categories and Products

**NOTE** : You will need method publicstaticstring ImportCategoryProducts(ProductShopContext context, string inputXml) and publicStartUp class.

Import the categories and products ids from the provided file **categories-products.xml**. If provided category or product id, doesn&#39;t exists, skip the whole entry!

Your method should return string with message $&quot;Successfully imported {CategoryProducts.Count}&quot;;

## 2.Query and Export Data

Write the below described queries and **export** the returned data to the specified **format**. Make sure that Entity Framework generates only a **single query** for each task.

### Query 5.Products In Range

**NOTE** : You will need method publicstaticstring GetProductsInRange(ProductShopContext context) and publicStartUp class.

Get all products in a specified **price range** between 500 and 1000 (inclusive). Order them by price (from lowest to highest). Select only the **product name** , **price** and the **full name**** of the buyer **. Take top** 10** records.

**Return** the list of suppliers **to XML** in the format provided below.

### Query 6.Sold Products

**NOTE** : You will need method publicstaticstring GetSoldProducts(ProductShopContext context) and publicStartUp class.

Get all users who have **at least 1 sold item**. Order them by **last name** , then by **first name**. Select the person&#39;s **first** and **last name**. For each of the **sold products** , select the product&#39;s **name** and **price**. Take top **5** records.

**Return** the list of suppliers **to XML** in the format provided below.

### Query 7.Categories By Products Count

**NOTE** : You will need method publicstaticstring GetCategoriesByProductsCount(ProductShopContext context) and publicStartUp class.

Get **all**** categories **. For each category select its** name **, the** number of products **, the** average price of those products **and the** total revenue**(total price sum) of those products (regardless if they have a buyer or not). Order them by the**number of products**(**descending**) then by total revenue.

**Return** the list of suppliers **to XML** in the format provided below.

### Query 8.Users and Products

**NOTE** : You will need method publicstaticstring GetUsersWithProducts(ProductShopContext context) and publicStartUp class.

Select all users who have **at least 1 sold product**. Order them by the **number of sold products** (from highest to lowest). Select only their **first** and **last name** , **age, count** of sold products and for each product - **name** and **price** sorted by price (descending).

Follow the format below to better understand how to structure your data.

**Return** the list of suppliers **to XML** in the format provided below.