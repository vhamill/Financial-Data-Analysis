USE [PzenaProject]
GO

/****** Object:  Table [dbo].[PRICES]    Script Date: 6/4/2024 10:53:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PRICES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ticker] [nvarchar](50) NOT NULL,
	[date] [date] NOT NULL,
	[open] [decimal](25, 10) NOT NULL,
	[high] [decimal](25, 10) NOT NULL,
	[low] [decimal](25, 10) NOT NULL,
	[close] [decimal](25, 10) NOT NULL,
	[volume] [decimal](32, 10) NULL,
	[closeadj] [decimal](25, 10) NOT NULL,
	[closeunadj] [decimal](25, 10) NOT NULL,
	[lastupdated] [date] NOT NULL,
 CONSTRAINT [PK__PRICES__3213E83F8EFE1005] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


