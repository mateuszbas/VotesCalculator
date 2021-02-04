CREATE TABLE [Voters] (
        [VoterId] [int] NOT NULL IDENTITY PRIMARY KEY,
        [FirstName] [nvarchar](max),
        [LastName] [nvarchar](max),
        [PersonalIdNumber] [nvarchar](11),
        [VoteInfo] [nvarchar](max)
    )

