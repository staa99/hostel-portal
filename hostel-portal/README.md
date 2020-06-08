# FUNAAB Hostel Management System
The objective of this project is simply to improve the performance of the hostel portal.

Currently, the system crashes after a few thousand requests as a result of inefficiencies in the design.
This system seeks to improve it by providing a new frontend that handles the requests and designates the actual app to handle tasks such as actually allocating hostels and more. The system is created as a way to explore caches and queue systems.






Desired flow:
Login with matric number and portal password
Validate login with remote service
If login validated, return user information to cache on client side
Otherwise, return suitable response
Load available hostels, together with the prices and number of rooms available
Initiate payment for application
Once payment validated, allow hostel bidding
Load hostel bidding results