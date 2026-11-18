
# Addis Eats API — Endpoint Design

API Version: v1  
Base URL: `/api/v1`

## Restaurants

| Method | Path | Purpose | Success | Failure |
|---|---|---|---|---|
| GET | /restaurants | Get restaurants with optional filters and pagination | 200 | 400 |
| GET | /restaurants/{id} | Get a restaurant by ID | 200 | 404 |
| POST | /restaurants | Create a restaurant | 201 | 400 |

## Menu Items

| Method | Path | Purpose | Success | Failure |
|---|---|---|---|---|
| GET | /restaurants/{id}/menu-items | Get restaurant menu items | 200 | 404 |
| GET | /menu-items/{id} | Get a menu item by ID | 200 | 404 |
| POST | /restaurants/{id}/menu-items | Add a menu item | 201 | 400 |
| PATCH | /menu-items/{id} | Update part of a menu item | 200 | 404 |
| DELETE | /menu-items/{id} | Delete a menu item | 204 | 404 |

## Orders

| Method | Path | Purpose | Success | Failure |
|---|---|---|---|---|
| POST | /orders | Create an order | 201 | 422 |
| GET | /orders | Get customer orders | 200 | 401 |
| GET | /orders/{id} | Get an order by ID | 200 | 404 |
| PATCH | /orders/{id}/status | Update order status | 200 | 409 |
| DELETE | /orders/{id} | Cancel an order | 204 | 409 |

## Payments

| Method | Path | Purpose | Success | Failure |
|---|---|---|---|---|
| POST | /payments | Initiate a payment | 201 | 503 |
| GET | /payments/{id} | Get payment information | 200 | 404 |

## Authentication

| Method | Path | Purpose | Success | Failure |
|---|---|---|---|---|
| POST | /auth/tokens | Authenticate and issue an access token | 201 | 401 |
| DELETE | /auth/tokens/current | Revoke current authentication session | 204 | 401 |
