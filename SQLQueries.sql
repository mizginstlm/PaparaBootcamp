// Yeni bir veritabanı oluşturma
CREATE DATABASE SalesDB;
GO

// Oluşturduğumuz veritabanını kullanma
USE SalesDB;
GO

// Ürünler tablosunu oluşturma
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    CategoryID INT,
    UnitPrice DECIMAL(10, 2),
    UnitsInStock INT
);
GO

// Kategoriler tablosunu oluşturma
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName NVARCHAR(50)
);
GO

// Satışlar tablosunu oluşturma
CREATE TABLE Sales (
    SaleID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    Quantity INT,
    SaleDate DATE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

// Kategori kayıtları ekleme
INSERT INTO Categories (CategoryID, CategoryName)
VALUES 
    (1, 'Electronics'),
    (2, 'Clothing'),
    (3, 'Books');

// Ürün kayıtları ekleme
INSERT INTO Products (ProductID, ProductName, CategoryID, UnitPrice, UnitsInStock)
VALUES 
    (101, 'Laptop', 1, 1200.00, 10),
    (102, 'T-shirt', 2, 20.00, 50),
    (103, 'Book: Introduction to SQL', 3, 35.00, 30);


// Satış kayıtları ekleme
INSERT INTO Sales (SaleID, CustomerID, ProductID, Quantity, SaleDate)
VALUES 
    (301, 201, 101, 2, '2023-01-05'),
    (302, 202, 102, 3, '2023-02-10');

// Belirli bir kategorideki ürünleri bulma sorgusu
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE CategoryID = 1;

// Belirli bir müşterinin yaptığı satışları bulma sorgusu
SELECT s.SaleID, p.ProductName, s.Quantity, s.SaleDate
FROM Sales s
INNER JOIN Products p ON s.ProductID = p.ProductID
WHERE s.CustomerID = 201;

// Belirli bir tarihte yapılan satışların toplam tutarını bulma sorgusu
SELECT SUM(p.UnitPrice * s.Quantity) AS TotalSales
FROM Sales s
INNER JOIN Products p ON s.ProductID = p.ProductID
WHERE s.SaleDate = '2023-01-05';

// Ürün stok durumu azalanları listeleme sorgusu
SELECT ProductID, ProductName, UnitsInStock
FROM Products
WHERE UnitsInStock < 20;

// En pahalı ürünü bulma sorgusu
SELECT TOP 1 ProductID, ProductName, UnitPrice
FROM Products
ORDER BY UnitPrice DESC;

// En çok satılan ürünlerin listesi sorgusu
SELECT TOP 3 p.ProductID, p.ProductName, SUM(s.Quantity) AS TotalQuantity
FROM Sales s
INNER JOIN Products p ON s.ProductID = p.ProductID
GROUP BY p.ProductID, p.ProductName
ORDER BY TotalQuantity DESC;

// Kategori bazında satışların toplamı bulma sorgusu
SELECT c.CategoryName, SUM(p.UnitPrice * s.Quantity) AS TotalSales
FROM Sales s
INNER JOIN Products p ON s.ProductID = p.ProductID
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY c.CategoryName;
 
// Ürün adı içinde geçenleri listeleme sorgusu
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE ProductName LIKE '%Book%';

// Ürün fiyatlarının ortalaması bulma sorgusu
SELECT AVG(UnitPrice) AS AveragePrice
FROM Products;

// Kategori bazında ortalama fiyat bulma sorgusu
SELECT c.CategoryName, AVG(p.UnitPrice) AS AveragePrice
FROM Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY c.CategoryName;

// Stokta bulunan ürünlerin toplam değeri bulma sorgusu
SELECT SUM(UnitPrice * UnitsInStock) AS TotalStockValue
FROM Products;

// En az ürün stokta olan kategori bulma sorgusu
SELECT TOP 1 c.CategoryName, SUM(p.UnitsInStock) AS TotalStock
FROM Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY c.CategoryName
ORDER BY TotalStock ASC;

// En fazla ürün stokta olan kategori bulma sorgusu
SELECT TOP 1 c.CategoryName, SUM(p.UnitsInStock) AS TotalStock
FROM Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY c.CategoryName
ORDER BY TotalStock DESC;

// Veritabanını silme
USE master;
GO
DROP DATABASE SalesDB;
