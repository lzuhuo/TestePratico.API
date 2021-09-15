SELECT O.Name, Count(P.[Animals Count]) [Animals Count]
FROM Owner as O
LEFT JOIN (
    SELECT OwnerId, COUNT( OwnerId) AS [Animals Count] FROM Dogs
    GROUP BY OwnerId
    UNION ALL
    SELECT OwnerId, COUNT( OwnerId) AS [Animals Count] FROM Cats
    GROUP BY OwnerId
) P
ON P.OwnerId = O.Id
GROUP BY O.Name