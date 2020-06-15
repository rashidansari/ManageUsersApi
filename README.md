# ManageUsersApi

To run the API, execute the following command in root dir of the project in sequance.
docker-compose up -d


Sample URL to Test:
1. To list all Users [Get Method] : http://localhost:8000/api/users
2. To create new Users [Post Method]:http://localhost:8000/api/users<br/>
Sample Json format :
```json
{   
            "name": "Rashid Ansari",
            "emailAdress": "Rashid@gmail.com",
            "monthlySalary": 20000,
            "monthlyExpenes": 200     
}
```
3. To get single User  [Get Method]: http://localhost:8000/api/users/{id}
4. To create new account for a user [Post Method]: http://localhost:8000/api/users/{id}/accounts<br/>
Sample Json format (optional):
```json
{   
            "userId": 1,
            "accountType": "Premium"
}
```
