CREATE TABLE [dbo].[FoodPriceTable] (
    [Food_Type]  NVARCHAR (50) NOT NULL,
    [Food_Price] MONEY         NOT NULL,
    PRIMARY KEY CLUSTERED ([Food_Type] ASC)
);

