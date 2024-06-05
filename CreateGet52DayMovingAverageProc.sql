USE [PzenaProject]
GO

/****** Object:  StoredProcedure [dbo].[Get52DayMovingAveragePrice]    Script Date: 6/4/2024 10:56:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get52DayMovingAveragePrice]
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
		   AVG([close]) as [52DayMovingAverage]
	FROM dbo.PRICES p
	WHERE [date] <= @AsOfDate and [date] >= DATEADD(DAY, -52, @AsOfDate) and [Ticker] = @Ticker
	GROUP BY [Ticker]
END
GO


