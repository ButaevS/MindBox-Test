SELECT Name From Customers
WHERE CustomerId IN 
(	SELECT DISTINCT CustomerId FROM Orders
	WHERE ProductName == 'Молоко'
	EXCEPT
	SELECT CustomerId FROM Orders
	WHERE ProductName == 'Сметана' AND PurchaiseDatetime >= DATEADD(MONTH, -1, GETDATE())
)