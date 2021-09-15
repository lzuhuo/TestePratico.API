SELECT OwnerId, MAX(Age) as [Age]
FROM Dogs
GROUP BY OwnerId