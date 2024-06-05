USE [PzenaProject]
GO

/****** Object:  StoredProcedure [dbo].[Get52DayHighPrice]    Script Date: 6/4/2024 10:55:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get52DayHighPrice]
	-- Add the parameters for the stored procedure here
	@AsOfDate DATETIME,
	@Ticker VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @AsOfDate as AsOfDate,
		   @Ticker as Ticker,
		   MAX([close]) as [52DayHighPrice]
	FROM dbo.PRICES p
	WHERE [date] <= @AsOfDate and [date] >= DATEADD(DAY, -52, @AsOfDate) and [Ticker] = @Ticker
	GROUP BY [Ticker]
END
GO


