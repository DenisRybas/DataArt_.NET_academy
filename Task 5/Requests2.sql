/*
Task1
����� ����, � �������� ������� ����������� �������� ���������, ������� ����� 
��� ������� �� ����� �� �������� � �������� ������,
� ��������� ��� ������� � ������ �� �������� ������.
*/
 SELECT DISTINCT GenreID, PlatformID, Name
 FROM Game, Game_Genre, Game_Platform
 WHERE Game_Genre.GenreID IN (2) 
 AND Game_Platform.PlatformID IN (0, 2) 
 AND Game.Name LIKE '%game%'

/*
Task2
������� ���������� ��� ��� ������ ��������� � ������ ���������� ���������.
*/
SELECT PlatformID, COUNT(ESRBRatingID) AS NumberOfgames, ESRBRatingID
FROM Game_Platform
JOIN Game
ON GAME.ID = Game_Platform.GameID
GROUP BY PlatformID, ESRBRatingID

/*
Task3
������� �������� ����������� ����, ����� ���, 
������� ��������� ������ � ������ �����.
(�������, � ��������� ����� ������� ������. 
� ����� ���� � ����������� ����������� ������,
� ������� ������ ���� ����)
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
������� ��� ������ ��������� �� ����� ������ ���� ������� �����, ���� ���� ����� ���� �� ������ ���������.
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
