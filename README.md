Hi and welcome to my solution to the Tiny Ledger home assignment - written in C#

Here are some assumptions I made along the way, if they were wrong please tell me as I can always just change what I have

## Assumptions

- I interpreted from what was said in the PDF that nothing was to be persisted, as such, I did not create a DBContext and care about a database. I've kept all data in-memory so it lasts only during runtime
- In the PDF it is said that you expect "a set of APIs", I interpreted that as a set of API endpoints as it seemed to me like an overkill to have 2+ API applications communicating with each other for this use case
- The previous assumption goes along with the request that we should not need to install any optional software, meaning that RabbitMQ and Kafka are not an option so I could only see some kind of synchronous http messaging as a choice, which could get messy
- Given this I assumed that a single web application was requested with perhaps 1-2 controllers and 3 endpoints based on the features
- I also assumed that unit testing and acceptance testing was not required

## Remarks

- It might have been overkill but I organized the code following something similar to a CQRS pattern, so that it could be potentially scalable
- Added validations as decorators to prevent wrong input
- I considered adding some exception handling middleware to return specific exceptions back to the user but it was requested to keep things simple

## Installation

To build and run this you have two options, to use docker or just commands from the command line. For either of these choices make sure you start at the root directory.

#### Commands

If you want to run this simply via commands you'll need to download and install the .NET 8.0 SDK first

Then, open the command line in the folder LedgerAPI, where the .csproj is, and run the following commands in order:

`dotnet restore`,
`dotnet build`,
`dotnet run`

This should run your project and it should be listening on port 5015

#### Docker

To run this on Docker, you'll first need to install Docker on your PC. For Windows, you can install Docker Desktop first.

Then, at the root-directory, open the command line and simply write `docker-compose up --build`

This should build and run the API for you, it will then be listening on port 8080.

## Usage

As requested, we have three main features set up as endpoints - to check the balance, to deposit/withdraw and to check transaction history.

Assuming that the port it is running on is 8080 then these are the endpoints:

http://localhost:8080/api/balance
http://localhost:8080/api/transactions

## Examples

To get your current balance, simply send a GET request to the Balance endpoint.
To view the transaction history, send a GET to the Transactions endpoint.

To create a transaction, send a POST request to the Transactions endpoint and in the body you should send a json dto in this format:
`{
	value: X,
	type: Y
}`

X in this case is a decimal, so you could send for example 5.5. Y is an enum that accepts the values: "Deposit" or "Withdrawal".

There are some validations at play, namely you can't make a deposit or withdrawal of 0 or less. You also can't withdraw more money than you currently possess in the balance.

Here are some concrete examples:
`{
	value: 5,
	type: "Deposit"
}`

`{
	value: 1000.5,
	type: "Withdrawal"
}`

Therefore some practical examples of requests could be

GET http://localhost:8080/api/transactions
GET http://localhost:8080/api/balance
POST http://localhost:8080/api/transactions with one of these json aforementioned