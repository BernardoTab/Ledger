Hi and welcome to my solution to the Tiny Ledger home assignment - written in C#

Here are some assumptions I made along the way, if they were wrong please tell me as I can always just change what I have

### Assumptions

- I interpreted from what was said in the PDF that nothing was to be persisted, as such, I did not create a DBContext and care about a database. I've kept all data in-memory so it lasts only during runtime
- In the PDF it is said that you expect "a set of APIs", I interpreted that as a set of API endpoints as it seemed to me like an overkill to have 2+ API applications communicating with each other for this use case
- The previous assumption goes along with the request that we should not need to install any optional software, meaning that RabbitMQ and Kafka are not an option so I could only see some kind of synchronous http messaging as a choice, which could get messy
- Given this I assumed that a single web application was requested with perhaps 1-2 controllers and 3 endpoints based on the features
- I also assumed that unit testing and acceptance testing was not required

### Remarks

- It might have been overkill but I organized the code following something similar to a CQRS pattern, so that it could be potentially scalable
- Added validations as decorators to prevent wrong input
- I considered adding some exception handling middleware to return specific exceptions back to the user but it was requested to keep things simple

### Installation

To build and run this you have two options, to use docker or just commands from the command line

## Commands

To run the project