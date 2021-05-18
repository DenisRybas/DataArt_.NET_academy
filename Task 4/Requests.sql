--TASK 3.1
SELECT Name
FROM Game
JOIN Game_User_Platform AS UserGP
ON UserGP.GameID = Game.ID
WHERE UserGP.UserNickname = 'Denis Rybas'

--TASK 3.2
SELECT gameWithName.Name, cast (AVG(DISTINCT gameWithMark.MARK) as decimal(10,1))as MARK, gameWithPlatform.ReleaseDate
FROM Game_User_Platform AS gameWithMark
JOIN Game AS gameWithName
ON gameWithMark.GameID = gameWithName.ID
JOIN Game_Platform AS gameWithPlatform
ON gameWithMark.GameID = gameWithPlatform.GameID
WHERE gameWithMark.PlatformID = 2 AND gameWithPlatform.ReleaseDate >= DATEADD(MONTH, -1, GETDATE())
GROUP BY gameWithName.Name, gameWithPlatform.ReleaseDate
ORDER BY MARK DESC;

--TASK 3.3
SELECT gameWithName.Name, COUNT(DISTINCT gameWithMark.MARK) as SumOfMarks
FROM Game_User_Platform AS gameWithMark
JOIN Game AS gameWithName
ON gameWithMark.GameID = gameWithName.ID
GROUP BY gameWithName.Name
ORDER BY SumOfMarks DESC;

--TASK 3.4
SELECT Developer.Name
FROM Game_Platform
JOIN Game AS Game
ON GameID = Game.ID
JOIN Developer AS Developer
ON DeveloperID = Developer.ID
GROUP BY Developer.Name
HAVING COUNT(PlatformID) > 2
