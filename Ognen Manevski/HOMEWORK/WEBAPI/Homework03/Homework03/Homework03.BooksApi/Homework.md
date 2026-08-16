Homework - Class 03
Objectives

In this homework, you'll build a simple Books API while practicing:

    Controllers
    Routing
    Query parameters
    Model Binding
    FromBody
    Testing endpoints with Postman and Swagger

Requirements

    Create a new .NET Web API project.

    Create a new BooksController.

    Create a Book model with the following properties:

public class Book
{
    public string Author { get; set; }
    public string Title { get; set; }
}

    Create a simple static database containing a list of Book objects.

    Implement a GET endpoint that returns all books.

    Implement a GET endpoint that returns a single book by its index using a query parameter.

Example:

GET /api/books?index=2

    Implement a GET endpoint that filters books by author and title using query parameters.

Example:

GET /api/books/search?author=Robert Martin&title=Clean Code

    Implement a POST endpoint that accepts a Book object from the request body using the [FromBody] attribute and adds it to the list.

    Test all endpoints using both:

    Swagger
    Postman

Bonus ⭐

Implement a POST endpoint that accepts a list of Book objects from the request body and returns only their titles as a List<string>.

Example request:

[
  {
    "author": "Robert Martin",
    "title": "Clean Code"
  },
  {
    "author": "Martin Fowler",
    "title": "Refactoring"
  }
]

Example response:

[
  "Clean Code",
  "Refactoring"
]

🤖 AI Guidelines

Use AI as a learning assistant—not as a code generator.

AI can help you:

    Understand model binding.
    Explain routing.
    Debug errors.
    Review your implementation.
    Suggest improvements after you've completed the homework.

Good prompts

Explain the difference between FromBody and FromQuery.

Review my BooksController and suggest improvements without rewriting the solution.

Why isn't my Book object being populated from the request body?

Explain how model binding works in .NET Web API.

Help me understand this compiler or runtime error without giving me the full solution.

How should I test this endpoint in Postman?

Avoid prompts like

Generate the entire homework solution.

Write the complete BooksController for me.

Implement all endpoints.

The goal is to understand how the solution works, not simply generate working code.