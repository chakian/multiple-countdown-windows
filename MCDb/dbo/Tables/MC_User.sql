CREATE TABLE [dbo].[MC_User] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50)  NOT NULL,
    [Password] NVARCHAR (50)  NOT NULL,
    [Email]    NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_MC_User] PRIMARY KEY CLUSTERED ([ID] ASC)
);

