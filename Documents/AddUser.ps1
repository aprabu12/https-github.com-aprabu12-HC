$params = '
{
  "userID": 14,
  "firstName": "dee",
  "lastName": "alston",
  "age": 32,
  "phone": "1231231234",
  "email": "",
  "hobbies": "",
  "isActive": true,
  "addressID": 2,
  "address": {
    "addressID": 2,
    "address1": "100 cumming drive",
    "address2": "",
    "city": "cumming",
    "state": "GA",
    "zip": "30000",
    "country": "USA"
  }
  }'



Invoke-RestMethod -Uri https://localhost:44340/api/users -Method POST -Body $params -ContentType "application/json"