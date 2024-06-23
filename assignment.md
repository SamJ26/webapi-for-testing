# Assignment

Develop system tests for the web API. The requirements are as follows:

- **Happy Path Tests**: Ensure there is at least one test for each endpoint that covers the happy path scenario.
- **Exception Flow Tests for Payment Endpoint** (`POST /orders/:id/pay`):
    - Test that an order cannot be paid if its status is not `Completed`.
    - Test that an order cannot be paid twice if its status is already `Paid`.

## Useful information

- If anything is unclear, don't hesitate to ask for clarification.
- To understand the functionality, review the code (warning: there are basically no comments).
- Most tests will require setting up orders in the database, so be prepared to perform database seeding.
- You can find these kind of tests also called **integration tests**.
- You do not need to spin up a separate database for testing - use the existing one running in Docker.
- There's no need to clean the database after testing - in a real-world scenario, the database would be disposed after tests.

## Resources

- https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-8.0
