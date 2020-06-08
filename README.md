# hostel-portal
A toy project to play with the basics of Redis, RabbitMQ and Docker

I'm learning the basics of Redis, RabbitMQ and Docker for building applications to be scalable.

I decided to create this to solve a problem in my school - 
The hostel portal always crashes when opened every year because of inefficiencies in the design. 
There are usually at least a few hundred simultaneous requests on the portal when the portal is opened 
because of limited space for thousands of applicants.
Before the crash, the response time degenerates to several minutes with a lot of failed requests.

The objective is to improve this performance such that the system never crashes under such load
and response times improved to less than a second.

The intended approach is to build a different front facing system that will efficiently use
a cache, a message queue and APIs provided by the original system.

The cache will be effective in reducing hits to the original system for the most frequently accessed data.
The queue will be used to handle long-running requests, so that the server is never held up too long.
A worker app will run threads to serve as consumers to read from the queue and
make requests to the original app.
The worker app will serve as the limiter to ensure that the original service never gets overloaded with requests.
The frontend to this app will be served from a CDN to remove the load of rendering the app from the server.

I am certain that this approach will be effective in reducing the response time and ensuring that the service never crashes.
