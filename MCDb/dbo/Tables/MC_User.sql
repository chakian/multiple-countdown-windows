CREATE TABLE [dbo].[MC_User] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50)  NOT NULL,
    [Password] NVARCHAR (50)  NOT NULL,
    [Email]    NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_MC_User] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MC_User_1]
    ON [dbo].[MC_User]([Email] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MC_User]
    ON [dbo].[MC_User]([Username] ASC);

