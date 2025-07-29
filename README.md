# KantarBooks

This repository contains the implementation for the coding challenge asked for Kantar's interview process, a library system management application.

# Installation
* Clone repository or download .zip
* Navigate to **KantarBooks.sln** directory
* Run docker compose up
* Open brower on [**localhost:5173**](http://localhost:5173)

Docker compose will build and instantiate three containers, running a SqlServer Database, the DataServer, and the WebUI.
The database is populated using .sql scripts contained in the Scripts folder and Docker's command line capabilities.

# Features
The application provides the following features:
* List all Books
* Filter by Title, Author
* Add a new Book
* Update a Book - not allowed if the book is borrowed
* Delete a Book - not allowed if the book is borrowed
* Borrow a Book
* Deliver a Book

# Ports
The system uses the following ports:
* **Database** - 1433
* **DataServer** - 5000
* **WebUi** - 5173

If any other process is using one of these ports, Docker will not be able to initialize the containers.

# Stack
The application uses the following stack:
* **Database** - SqlServer
* **DataServer** - .net9
* **WebUI** - React
* **Other** - Swagger, Docker

# Tests
The project includes unit tests for the following modules:
* BookRepository
* BookService
* AgentService
* TypeConverter
* BookController
* AgentController

The testing framework used was MSTest, with Moq for mocking interfaces when needed.
The test suit for BookRepository uses a local sqlite3 database. This was done to facilitate ORM testing. The suite resets the database to test default each time the suite is run.

To run the tests, navigate to the solution folder and run `dotnet test`
