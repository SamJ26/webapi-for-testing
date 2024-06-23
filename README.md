# Sample web API for testing purposes

## Domain overview

This application represents a simple web API for the e-shop. Imagine a simplified e-shop experience:

1. Upon opening the application, a new, empty order is automatically created.
2. Users can browse available items and add their selections to the order.
3. Once all desired items are added, the user must input a delivery address.
4. Clicking the submit button marks the order as complete and generates the necessary payment information.
5. The final step is for the user to complete the payment for their order.

For simplicity, step 2 is omitted (there is no endpoint for adding items to the order).

## Endpoints

- `POST /orders`
    - Description: Create an empty order
    - Prerequisities: None
- `PUT /orders/:id/address` 
    - Description: Add delivery address
    - Prerequisities: There is an existing order with status `InProgress` 
- `PUT /orders/:id/complete`
    - Description: Complete the order
    - Prerequisities: There is an existing order with status `InProgress`
- `POST /orders/:id/pay`
    - Description: Pay for the order
    - Prerequisities: There is an existing order with status `Completed`

## Setup

Required & recommended tools:

- **.NET 8**
- **Docker**
- MongoDB Compass

Setup instructions:

1. Start docker container with MongoDB database

    ```shell
    docker run -d -p 127.0.0.1:27017:27017 --name mongodb mongo:latest
    ```

2. Start the application

    ```shell
    cd src/SampleApi
    dotnet run
    ```

3. Open the web API documentation on URL http://localhost:5025/swagger/index.html
