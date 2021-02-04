CREATE TABLE [Voters] (
        [VoteId] [int] NOT NULL IDENTITY PRIMARY KEY,
        [FirstName] [nvarchar](max) NOT NULL,
        [LastName] [nvarchar](max) NOT NULL,
        [PersonalIdNumber] [nvarchar](11) NOT NULL,
        [VoteName] [nvarchar](max) NOT NULL,
        [VoteParty] [nvarchar](max) NOT NULL
    )

