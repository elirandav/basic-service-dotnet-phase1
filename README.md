
## Requirements

GET /users 

response: [{Id: 1, Name: 'Zehava Ben'},{Id: 2, Name: 'Billie Eilish'}]

## Assumptions 

GET http://external-service/records

response: 
[{Id: 1, FirstName: 'Zehava', LastName: 'Ben'},
{Id: 2, FirstName: 'Billie', LastName: 'Eilish'}]

## Plan 

1. Have a green test that calls your service "/users" and returns a successful HTTP status code. 
2. Have a green test that calls your service "/users" and returns a successful HTTP status code with the following response:

response: [{Id: 1, Name: 'Zehava Ben'},{Id: 2, Name: 'Billie Eilish'}]