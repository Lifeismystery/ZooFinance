CREATE TABLE [dbo].[AnimalsTable] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Animal_Type] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AnimalsTable_AnimalTypeTable] FOREIGN KEY ([Animal_Type]) REFERENCES [dbo].[AnimalTypeTable] ([Animal Type])
);

