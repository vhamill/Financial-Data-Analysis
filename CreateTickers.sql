USE [PzenaProject]
GO

/****** Object:  Table [dbo].[TICKERS]    Script Date: 6/4/2024 10:54:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TICKERS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[table] [nvarchar](50) NOT NULL,
	[permaticker] [int] NOT NULL,
	[ticker] [nvarchar](50) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[exchange] [nvarchar](50) NOT NULL,
	[isdelisted] [nvarchar](15) NOT NULL,
	[category] [nvarchar](50) NOT NULL,
	[cusips] [nvarchar](300) NULL,
	[siccode] [int] NULL,
	[sicsector] [nvarchar](100) NULL,
	[sicindustry] [nvarchar](100) NULL,
	[famasector] [nvarchar](15) NULL,
	[famaindustry] [nvarchar](50) NULL,
	[sector] [nvarchar](50) NULL,
	[industry] [nvarchar](50) NULL,
	[scalemarketcap] [nvarchar](50) NULL,
	[scalerevenue] [nvarchar](50) NULL,
	[relatedtickers] [nvarchar](300) NULL,
	[currency] [nvarchar](50) NOT NULL,
	[location] [nvarchar](50) NULL,
	[lastupdated] [date] NOT NULL,
	[firstadded] [date] NOT NULL,
	[firstpricedate] [date] NOT NULL,
	[lastpricedate] [date] NOT NULL,
	[firstquarter] [date] NULL,
	[lastquarter] [date] NULL,
	[secfilings] [nvarchar](100) NULL,
	[companysite] [nvarchar](150) NULL,
 CONSTRAINT [PK__TICKERS__3213E83FE488F885] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


