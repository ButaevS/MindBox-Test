SELECT Name From Customers
WHERE CustomerId IN 
(	SELECT DISTINCT CustomerId FROM Orders
	WHERE ProductName == '������'
	EXCEPT
	SELECT CustomerId FROM Orders
	WHERE ProductName == '�������' AND PurchaiseDatetime >= DATEADD(MONTH, -1, GETDATE())
)