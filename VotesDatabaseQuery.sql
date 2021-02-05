
CREATE TABLE [Candidates] (
        [CandidateId] [int] NOT NULL IDENTITY PRIMARY KEY,
        [Name] [nvarchar](max) NOT NULL,
        [Party] [nvarchar](max) NOT NULL
    );


CREATE TABLE [Voters] (
        [VoteId] [int] NOT NULL IDENTITY PRIMARY KEY,
        [FirstName] [nvarchar](max) NOT NULL,
        [LastName] [nvarchar](max) NOT NULL,
        [PersonalIdNumber] [nvarchar](max) NOT NULL,
        [CandidateId] [int],
        CONSTRAINT [CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates]([CandidateId])
    );


CREATE TABLE [Statistics] (
        [StatisticId] [int] NOT NULL IDENTITY PRIMARY KEY,
        [DisallowedTries] [int] NOT NULL 
    );

INSERT INTO [Statistics] ([DisallowedTries])
VALUES (0);





