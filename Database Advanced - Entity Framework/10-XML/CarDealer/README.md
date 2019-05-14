# Exercises: XML Processing
## Car Dealer Database
.
### Setup Database

A car dealer needs information about cars, their parts, parts suppliers, customers and sales.

- **Cars** have **make, model** , travelled distance in kilometers
- **Parts** have **name** , **price** and **quantity**
- Part **supplier** have **name** and info whether he **uses imported parts**
- **Customer** has **name** , **date of birth** and info whether he **is young driver**
- **Sale** has **car** , **customer** and **discount percentage**

A **price of a car** is formed by **total price of its parts**.

- A **car** has **many parts** and **one part** can be placed **in many cars**
- **One supplier** can supply **many parts** and each **part** can be delivered by **only one supplier**
- In **one sale** , only **one car** can be sold
- **Each sale** has **one customer** and **a customer** can buy **many cars**

### Import Data

Import data from the provided files ( **suppliers.xml, parts.xml, cars.xml, customers.xml** ).

### Query 1.Import Suppliers

**NOTE** : You will need method publicstaticstring ImportSuppliers(CarDealerContext context, string inputXml)and publicStartUp class.

Import the suppliers from the provided file **suppliers.xml**.

Your method should return string with message $&quot;Successfully imported {suppliers.Count}&quot;;

### Query 2.Import Parts

**NOTE** : You will need method publicstaticstring ImportParts(CarDealerContext context, string inputXml) and publicStartUp class.

Import the parts from the provided file **parts.xml**. If the supplierId doesn&#39;t exist, skip the record.

Your method should return string with message $&quot;Successfully imported {parts.Count}&quot;;

### Query 3.Import Cars

**NOTE** : You will need method publicstaticstring ImportCars(CarDealerContext context, string inputXml) and publicStartUp class.

Import the cars from the provided file **cars.xml**. Select unique car part ids. If the part id doesn&#39;t exist, skip the part record.

Your method should return string with message $&quot;Successfully imported {cars.Count}&quot;;

### Query 4.Import Customers

**NOTE** : You will need method publicstaticstring ImportCustomers(CarDealerContext context, string inputXml) and publicStartUp class.

Import the customers from the provided file **customers.xml**.

Your method should return string with message $&quot;Successfully imported {customers.Count}&quot;;

### Query 5.Import Sales

**NOTE** : You will need method publicstaticstring ImportSales(CarDealerContext context, string inputXml) and publicStartUp class.

Import the sales from the provided file **sales.xml**. If car doesn&#39;t exists, skip whole entity.

Your method should return string with message $&quot;Successfully imported {sales.Count}&quot;;

## Query and Export Data

Write the below described queries and **export** the returned data to the specified **format**. Make sure that Entity Framework generates only a **single query** for each task.

### Query 1.Cars With Distance

**NOTE** : You will need method publicstaticstring GetCarsWithDistance(CarDealerContext context) and publicStartUp class.

Get all **cars** with distance more than 2,000,000. Order them by make, then by model alphabetically. Take top 10 records.

**Return** the list of suppliers **to XML** in the format provided below.

### Query 6.Cars from make BMW

**NOTE** : You will need method publicstaticstring GetCarsFromMakeBmw(CarDealerContext context) and publicStartUp class.

Get all **cars** from make **BMW** and **order them by model alphabetically** and by **travelled distance descending**.

**Return** the list of suppliers **to XML** in the format provided below.

### Query 7.Local Suppliers

**NOTE** : You will need method publicstaticstring GetLocalSuppliers(CarDealerContext context) and publicStartUp class.

Get all **suppliers** that **do not import parts from abroad**. Get their **id** , **name** and **the number of parts they can offer to supply**.

**Return** the list of suppliers **to XML** in the format provided below.

### Query 8.Cars with Their List of Parts

**NOTE** : You will need method publicstaticstring GetCarsWithTheirListOfParts(CarDealerContext context) and publicStartUp class.

Get all **cars along with their list of parts**. For the **car** get only **make, model** and **travelled distance** and for the **parts** get only **name** and **price** and sort all pars by price (descending). Sort all cars by travelled distance ( **descending** ) then by model ( **ascending** ). Select top 5 records.

**Return** the list of suppliers **to XML** in the format provided below.

### Query 9.Total Sales by Customer

**NOTE** : You will need method publicstaticstring GetTotalSalesByCustomer(CarDealerContext context) and publicStartUp class.

Get all **customers** that have bought **at least 1 car** and get their **names, bought cars count** and **total spent money on cars**. **Order** the result list by **total spent money descending**.

**Return** the list of suppliers **to XML** in the format provided below.

### Query 10.Sales with Applied Discount

**NOTE** : You will need method publicstaticstring GetSalesWithAppliedDiscount(CarDealerContext context) and publicStartUp class.

Get all **sales** with information about the **car** , **customer** and **price** of the sale **with and without discount**.

**Return** the list of suppliers **to XML** in the format provided below.