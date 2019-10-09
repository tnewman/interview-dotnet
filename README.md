# Tom's Notes
## Design Tradeoffs
- In a project with very complex business rules or multiple frontends (API and server-side rendered pages), 
  I would separate the business logic from the controller. Separating the code out later would not be difficult, and I believe the 
  reduction of implementation and maintenance effort is worth it.
- `database.json` was missing a date for the order, so I added it in there, so I could implement the requirement to retrieve orders 
  by date.

# Overview
This exercise is intentionally left open ended.  Within you will find a skeleton code base and a json file intended to simulate a database.

# Requirements
 - API listing all customers
 - API retrieving a customer
 - API listing all orders
 - API listing all orders for a given date
 - API retrieving an order
 - API listing products
 - API retrieving a product
 - API list a customer's orders
 - API saving a customer
 - API saving a product
 - Create Unit Tests to exercise the above

# Expectations
Implement the above listed requirements in a manner you see fitting.  Demonstrate design and implementation aspects you feel are important in a software project.
