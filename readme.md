## [FR](lisezmoi.md)

# Candy Store Inventory Management API
## Lab: Development of an Inventory Management System for an Online Store with a REST API

## Objective

The goal of this lab is to design an inventory management system for an online store. This system should allow managing the store's products, orders, and users.

## Required Technologies

*   ASP.NET Web API for creating the REST API
*   ADO.NET for data manipulation in the database
*   LINQ for querying collections and entities
*   JWT for user authentication and authorization

## System Description

The system should allow store administrators to add new products, update information for existing products, manage orders placed by users, and track stock levels. Products will be categorized (e.g., Fresh, Fruits & Vegetables, Electronics, Toys, ...) and therefore filterable by category on demand.

## Expected Features

### 1. Product Management:

*   Endpoint to add a new product with its details (name, description, price, stock quantity, etc.).
*   Endpoint to retrieve the list of all available products.
*   Endpoint to retrieve the complete product sheet (category, price excl. VAT + incl. VAT, ...).
*   Endpoint to update the information of an existing product.
*   Endpoint to delete a product from the catalog.

### 2. Order Management:

*   Endpoint to place a new order with product and user details.
*   Endpoint to retrieve the list of placed orders.
*   Endpoint to mark an order as processed or cancelled.

### 3. User Management:

*   Endpoint for new user registration.
*   Endpoint for user login, generating and returning a valid JWT token upon success.
*   Endpoint to retrieve information about the logged-in user.
*   Endpoint to update the user profile.
*   Endpoint providing a user's order history.

## Tasks to Perform

1.  Set up the ASP.NET Web API project.
2.  Database configuration:
    *   Create a database to store information about products, orders, and users.
    *   Design tables for each entity with appropriate fields.
3.  Implement the API endpoints for the functionalities described above.
4.  Use ADO.NET for data manipulation in the database.
5.  Use LINQ to perform query and filtering operations on the data.
6.  Implement authentication and authorization with JWT to secure access to administrative functionalities.

## Expected Deliverables

*   Source code of the ASP.NET Web API project.
*   Documentation describing the API endpoints, the implemented methods, as well as instructions for testing the API.
*   Report detailing the different development steps, the problems encountered, and the solutions adopted.

## Note

It is recommended to use good development practices such as input data validation, error handling, data security, etc.