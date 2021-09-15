SELECT O.Name as [Owner Name], C.Name as [Cat Name]
FROM Owner as O
INNER JOIN Cats as C on OwnerId = O.Id