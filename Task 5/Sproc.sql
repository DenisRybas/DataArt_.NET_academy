USE [GameWebsite]
GO
/****** Object:  StoredProcedure [dbo].[Age_to_ESRB]    Script Date: 15.03.2021 1:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Age_to_ESRB]
	@MinAge int,
	@MaxAge int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM ESRB_Rating
	WHERE (LowestAge between @MinAge and @MaxAge or LowestAge <= @MinAge) 
	AND (HighestAge between @MinAge and @MaxAge or HighestAge >= @MaxAge)
END
GO
