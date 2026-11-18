Exercise 1: Explain what a server is
A server is a service that listens for requests from other applications and responds with the information or action they need. For example, when someone visits a website, their browser sends a request asking for a page. The server receives that request, processes it, and sends the page back. It can also store information, retrieve records, create accounts, and process orders. In simple terms, a server acts like a restaurant worker who receives customer orders, processes them, and delivers the requested service.

Completed
 Under 120 words, without using the two prohibited words.
Exercise 2: Inspect three HTTP requests
Example website: Wikipedia.

The following is an illustrative set of requests, not a live browser capture.
#	Method	Path	Status	Request body
1	GET	/	200 OK	No
2	GET	/portal/wikipedia.org/assets/img/Wikipedia-logo-v2.png	200 OK	No
3	GET	/portal/wikipedia.org/assets/img/Wikipedia-wordmark-en.svg	200 OK	No

Explanation:
- GET retrieves a resource.
- 200 means the request succeeded.
- These GET requests do not carry request bodies.
Exercise 3: Identify request and response headers
Using a representative HTTP request:

Request headers
Header	Purpose
Host	Identifies the destination server.
User-Agent	Identifies the client/browser.
Accept	Specifies acceptable response formats.
Accept-Language	Indicates the preferred language.

Response headers
Header	Purpose
Content-Type	Specifies the format of the response body.
Cache-Control	Defines caching rules.
Content-Length	Indicates the response body size in bytes.
Date	Indicates when the response was generated.

These are representative headers, not verified headers from a captured Wikipedia request.
Exercise 4: Write a complete HTTP request
Scenario: Create an order for two portions of menu item 7 at restaurant 14 in Bole, paid through TeleBirr.
POST /api/v1/orders HTTP/1.1
Host: api.addiseats.et
Content-Type: application/json
Accept: application/json
Authorization: Bearer <your_access_token>

{
    "restaurantId": 14,
    "area": "Bole",
    "items": [
        {
            "menuItemId": 7,
            "qty": 2
        }
    ],
    "paymentMethod": "TeleBirr"
}


Explanation:
- POST: Creates a new order.
- /api/v1/orders: Identifies the orders collection.
- Host: Identifies the API server.
- Content-Type: Specifies that the request body is JSON.
- Accept: Indicates that the client expects JSON.
- Authorization: Carries the authentication token.
- Body: Contains the restaurant, menu item, quantity, and payment method.
The token is a placeholder; a real request must use a valid token. The exact payment field is a proposed API design choice.
Exercise 5: Choose the correct HTTP status codes
This is an important exercise because status-code judgment is used again in later backend lessons.
Scenario	Correct status	Reason
A. A list of restaurants is returned	200 OK	The read operation succeeded.
B. An order is created	201 Created	A new resource was created.
C. An order is cancelled and nothing is returned	204 No Content	The operation succeeded without a response body.
D. The qty field arrives as "two"	400 Bad Request	The request contains malformed data.
E. The authentication token has expired	401 Unauthorized	The credentials are invalid.
F. A courier attempts to edit a menu	403 Forbidden	The courier is authenticated but lacks permission.
G. Someone requests order 99999, which doesn't exist	404 Not Found	The requested resource cannot be found.
H. Your code throws an unhandled exception	500 Internal Server Error	An unexpected backend error occurred.

Important distinctions:
- 401 = Authentication problem.
- 403 = Permission problem.
- 400 = Invalid request format or input.
- 422 = Valid format, but semantically invalid data.
- 500 = Unexpected backend failure.
Exercise 5 completed
Exercise 6: Investigate a public API
Example: JSONPlaceholder.

Website: JSONPlaceholder.

Three things its API contract promises:
1. Resource endpoints: It provides resources such as /posts, /users, /comments, and /todos.
2. HTTP methods: It supports methods such as GET, POST, PUT, PATCH, and DELETE for demonstrating REST operations.
3. JSON responses: It returns JSON-formatted data that applications can consume.
One thing I would want to know before depending on it:

- What are its availability guarantees and support arrangements? Can I rely on it for a production application, and what happens if the service becomes unavailable?

JSONPlaceholder is intended primarily for testing and prototyping, rather than as a production database.