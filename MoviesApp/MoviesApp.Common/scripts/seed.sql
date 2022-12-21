USE [MovieDB]
GO

/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21.12.2022. 22:07:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[CrewMember]    Script Date: 21.12.2022. 22:07:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CrewMember](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TmdbId] [int] NOT NULL,
 CONSTRAINT [PK_CrewMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[CrewMembereMovieCredit]    Script Date: 21.12.2022. 22:07:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CrewMembereMovieCredit](
	[Id] [uniqueidentifier] NOT NULL,
	[CrewMemberId] [uniqueidentifier] NOT NULL,
	[MovieCreditId] [uniqueidentifier] NOT NULL,
	[MovieId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CrewMembereMovieCredit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Genre]    Script Date: 21.12.2022. 22:07:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Genre](
	[Id] [uniqueidentifier] NOT NULL,
	[TmdbId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Movie]    Script Date: 21.12.2022. 22:07:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movie](
	[Id] [uniqueidentifier] NOT NULL,
	[TmbdId] [int] NOT NULL,
	[OriginalTitle] [nvarchar](max) NOT NULL,
	[Popularity] [float] NOT NULL,
	[ReleaseDate] [datetime2](7) NULL,
	[DateCreated] [datetime2](7) NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[MovieCredit]    Script Date: 21.12.2022. 22:07:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MovieCredit](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MovieCredit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[MovieGenre]    Script Date: 21.12.2022. 22:07:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MovieGenre](
	[Id] [uniqueidentifier] NOT NULL,
	[MovieId] [uniqueidentifier] NOT NULL,
	[GenreId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_MovieGenre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CrewMembereMovieCredit]  WITH CHECK ADD  CONSTRAINT [FK_CrewMembereMovieCredit_CrewMember_CrewMemberId] FOREIGN KEY([CrewMemberId])
REFERENCES [dbo].[CrewMember] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CrewMembereMovieCredit] CHECK CONSTRAINT [FK_CrewMembereMovieCredit_CrewMember_CrewMemberId]
GO

ALTER TABLE [dbo].[CrewMembereMovieCredit]  WITH CHECK ADD  CONSTRAINT [FK_CrewMembereMovieCredit_Movie_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CrewMembereMovieCredit] CHECK CONSTRAINT [FK_CrewMembereMovieCredit_Movie_MovieId]
GO

ALTER TABLE [dbo].[CrewMembereMovieCredit]  WITH CHECK ADD  CONSTRAINT [FK_CrewMembereMovieCredit_MovieCredit_MovieCreditId] FOREIGN KEY([MovieCreditId])
REFERENCES [dbo].[MovieCredit] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CrewMembereMovieCredit] CHECK CONSTRAINT [FK_CrewMembereMovieCredit_MovieCredit_MovieCreditId]
GO

ALTER TABLE [dbo].[MovieGenre]  WITH CHECK ADD  CONSTRAINT [FK_MovieGenre_Genre_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[MovieGenre] CHECK CONSTRAINT [FK_MovieGenre_Genre_GenreId]
GO

ALTER TABLE [dbo].[MovieGenre]  WITH CHECK ADD  CONSTRAINT [FK_MovieGenre_Movie_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[MovieGenre] CHECK CONSTRAINT [FK_MovieGenre_Movie_MovieId]
GO

