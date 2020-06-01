CREATE TABLE [dbo].[AnimalTypeTable] (
    [Animal_Type]       NVARCHAR (50) NOT NULL,
    [Food_Type]         NVARCHAR (50) NOT NULL,
    [Food_Rate_Per_Day] FLOAT (53)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Animal_Type] ASC),
    CONSTRAINT [FK_AnimalTypeTable_FoodPriceTable1] FOREIGN KEY ([Food_Type]) REFERENCES [dbo].[FoodPriceTable] ([Food_Type])
);

