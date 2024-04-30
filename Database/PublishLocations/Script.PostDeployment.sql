IF NOT EXISTS (SELECT 1 FROM dbo.Product)
BEGIN
	INSERT INTO dbo.Product (Ean, Description, Price)
	VALUES
		('ASDF87', 'iPhone 14', 23500),
		('ASDF24', 'Samsung LED TV', 12000),
		('ASDF71', 'Lamp', 600)

	INSERT INTO dbo.Category (Name)
	VALUES
		('Computers and Laptops'), ('Gaming and Entertainment'), ('Phones, Smartwatches and Tablets'),
		('Major appliances'), ('Household'), ('Hobby and Garden'), ('Toys'), ('Drugstore'),
		('Beauty'), ('Sport and Outdoors'), ('Car and Moto'), ('Office supplies'), ('Books'),
		('Food and Alcohol'), ('Health')
END