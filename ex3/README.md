# Class 3

An ASP.NET API for a toy IAM application implementing password hashing and salting with the MD5 (not recommended) and PBKDF2 algorithms.
Supported actions:

- Registering a new user account (`POST /register, /register_legacy`)
- Logging in to receive a JWT token (`POST /login`)
- Changing one's password (`PUT /password`)
- Deleting one's account (`DELETE /deleteAccount`)
- Checking one's info (`GET /whoami`)
- Viewing a list of all registered users (`GET /users`)