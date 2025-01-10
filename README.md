# NewsAPI Documentation

## Base URL

Replace `<api-url>` with your API's base URL.

---

## Endpoints

| **Feature**                  | **HTTP Method** | **Endpoint**                                                                            | **Example**                                                                                   |
|------------------------------|-----------------|-----------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------|
| Search by Title              | `GET`           | `<api-url>/api/news/search`                                                             | `<api-url>/api/news/search?title=second`                                                      |
| Search by Category           | `GET`           | `<api-url>/api/news/searchByCategory`                                                   | `<api-url>/api/news/searchByCategory?category=Technology`                                     |
| Search by Date               | `GET`           | `<api-url>/api/news/searchByDate`                                                       | `<api-url>/api/news/searchByDate?date=2025-01-08`                                             |
| Search by Date and Category  | `GET`           | `<api-url>/api/news/searchByDateAndCategory`                                            | `<api-url>/api/news/searchByDateAndCategory?date=2024-02-01&category=Sports`                  |
| Search by Date and Title     | `GET`           | `<api-url>/api/news/searchByDateAndTitle`                                               | `<api-url>/api/news/searchByDateAndTitle?date=2025-01-08&title=Tech`                          |

---

## Notes

- Ensure the `<api-url>` is replaced with the appropriate base URL for your deployment.
- All endpoints support query parameters as shown in the examples.
- Results will be filtered based on the provided query criteria.

---

### Example Usage

#### Search by Title

```http
GET https://example.com/api/news/search?title=second
```
