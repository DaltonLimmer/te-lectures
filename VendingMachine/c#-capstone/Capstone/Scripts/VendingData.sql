USE [VendingMachine]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([Id], [Name], [Noise]) VALUES (2, N'Beverage', N'Glug, Glug, Yum!')
GO
INSERT [dbo].[Category] ([Id], [Name], [Noise]) VALUES (3, N'Candy', N'Munch, Munch, Yum!')
GO
INSERT [dbo].[Category] ([Id], [Name], [Noise]) VALUES (4, N'Chips', N'Crunch, Crunch, Yum!')
GO
INSERT [dbo].[Category] ([Id], [Name], [Noise]) VALUES (5, N'Gum', N'Chew, Chew, Yum!')
GO
INSERT [dbo].[Category] ([Id], [Name], [Noise]) VALUES (6, N'Nuts', N'Nibble, Nibble, Yum!')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (1, N'Sea Salt Kettle Style Potato Chips', 0.75, 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (2, N'Jalepeno Kettle Stlye Potato Chips', 0.75, 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (3, N'Nacho Cheesiest Tortilla Chips', 0.6, 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (4, N'Cloud Popcorn', 0.85, 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (5, N'Moonpie', 1.2, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (6, N'Peanut Carmel Nouget Bar', 0.9, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (7, N'Wonka Bar', 0.95, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (8, N'One Hundred Million Bar', 1, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (9, N'Roasted Salted Almonds', 1.25, 6)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (10, N'Mr. Forest''s Chocolate Chip Cookies', 1.5, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (11, N'Honey Mustard Pretzels', 0.65, 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (12, N'Raisin Chocolate Goodness', 1.1, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (13, N'Cinnamon Hots Gum', 0.75, 5)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (14, N'Little League Chew', 0.75, 5)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (15, N'Sugarless Fruit Gum', 0.75, 5)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (16, N'Triplemint', 0.75, 5)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (17, N'Chillin'' Cola', 0.5, 2)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (18, N'Dr. Salt', 0.5, 2)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (19, N'Mountain Melter', 0.5, 2)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (20, N'Surge', 0.5, 2)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (2, 5, 1, 1, 1)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (3, 5, 1, 2, 2)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (4, 5, 1, 3, 3)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (5, 5, 1, 4, 4)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (6, 5, 2, 1, 5)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (7, 5, 2, 2, 6)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (8, 5, 2, 3, 7)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (9, 5, 2, 4, 8)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (10, 5, 3, 1, 9)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (11, 5, 3, 2, 10)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (12, 5, 3, 3, 11)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (13, 5, 3, 4, 12)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (14, 5, 4, 1, 13)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (15, 5, 4, 2, 14)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (16, 5, 4, 3, 15)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (17, 5, 4, 4, 16)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (18, 5, 5, 1, 17)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (19, 5, 5, 2, 18)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (20, 5, 5, 3, 19)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (21, 5, 5, 4, 20)
GO
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
