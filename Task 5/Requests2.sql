/*
Task1
Найти игры, в названии которых встречается заданная подстрока, которые вышли 
как минимум на одной из платформ в заданном списке,
и относятся как минимум к одному из заданных жанров.
*/
 SELECT DISTINCT GenreID, PlatformID, Name
 FROM Game, Game_Genre, Game_Platform
 WHERE Game_Genre.GenreID IN (2) 
 AND Game_Platform.PlatformID IN (0, 2) 
 AND Game.Name LIKE '%game%'

/*
Task2
Вывести количество игр для каждой платформы в каждой возрастной категории.
*/
SELECT PlatformID, COUNT(ESRBRatingID) AS NumberOfgames, ESRBRatingID
FROM Game_Platform
JOIN Game
ON GAME.ID = Game_Platform.GameID
GROUP BY PlatformID, ESRBRatingID

/*
Task3
Выбрать наименее обсуждаемые игры, среди тех, 
которые относятся только к одному жанру.
(Надеюсь, я правильно понял условие задачи. 
Я вывел игры с минимальным количеством оценок,
у которых только один жанр)
*/
SELECT GameForCount.GameID, MIN(MarkCount) AS MinMarkCount
FROM (SELECT GameID, COUNT(MARK) MarkCount 
		FROM Game_User_Platform 
		GROUP BY GameID) GameForCount
JOIN Game_Genre
ON Game_Genre.GameID = GameForCount.GameID
GROUP BY GameForCount.GameID
HAVING COUNT(GenreID) = 1

/*
Task4
Выбрать для каждой платформы по одной лучшей игре каждого жанра, если игра жанра есть на данной платформе.
*/
SELECT Game_Platform.PlatformID, GenreID, MAX(AvgMark) AS BestMark
FROM (SELECT GameID, AVG(MARK) AvgMark
		FROM Game_User_Platform 
		GROUP BY GameID) GameMark
JOIN Game_Platform
ON Game_Platform.GameID = GameMark.GameID
JOIN Game_Genre
ON Game_Genre.GameID = GameMark.GameID
GROUP BY GenreID, Game_Platform.PlatformID
