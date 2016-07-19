CREATE TABLE [dbo].[MC_Countdown] (
    [ID]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserID]       INT            NOT NULL,
    [Title]        NVARCHAR (150) NULL,
    [EndTime]      DATETIME       NOT NULL,
    [CreateTime]   DATETIME       NOT NULL,
    [UpdateTime]   DATETIME       NOT NULL,
    [IsInProgress] BIT            NOT NULL,
    [IsDeleted]    BIT            NOT NULL,
    CONSTRAINT [PK_MC_Countdown] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_MC_Countdown_MC_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[MC_User] ([ID])
);

