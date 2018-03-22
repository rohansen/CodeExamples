--Remember to reverse the updates in the other Management studio window, to enforce deadlock
use CarBooking
BEGIN TRANSACTION
UPDATE Customer SET FirstName = 'Ajes',LastName = 'Barton' WHERE CustomerId = 1
WAITFOR DELAY '00:00:010'
UPDATE Customer SET FirstName = 'Rasmus',LastName = 'Lima' WHERE CustomerId = 2
Commit


select * from Customer