# Homework - Class 09

## 🐛 The Bug Hunt

---

## 📕 The bug Fixes

### Debugging Approach:

#### Preparation

- First of all I read the entire solution to have an idea of what I'm working with.
- Transferred the requested endpoints in Postman as a collection (using AI to save on effort).
- Placed a debugger on each endpoint in `LibraryApi.Controllers`
- Connected the SSMS Server and ran a `Update-Database` command

#### Testing
- Ran the exact endpoints from the requirements in Postman using custom params or JSON in the body
- Compared the data in SSMS by querying directly:
```sql
USE LibraryDb;
GO

SELECT * FROM Author;
SELECT * FROM Book;
```

#### Finding
- Using the debugger: following the code execution path starting from the `Controllers` -> Service -> Mapper -> Repository (f5, f10, f11).
- Manually reviewing files and checking implementations (go to definition feature).


#### Verification
- Rerunning the problem endpoint
- Verifying with `GET /api/books`
- Verifying in SSMS
- Asking Copilot to review fixes for potential issues

---

### 🐞 Ticket #1 — "Every book in our library has zero pages"

> `GET /api/books` and `GET /api/books/1` both come back with `"pageCount": 0` for **every**
> book. I checked the `Book` table in SSMS — the page counts are really in there (1984 has 328).
> Nothing else in the response is wrong.

### Root Cause

`LibraryApi.Mappers/BookMapper.cs` -> `ToBookDto(...)` did not map the `PageCount` property from `Book` to `BookDto`.
As a result, `BookDto.PageCount` retained its default `int` value of `0`.

### Fix

Added the missing property mapping:
```csharp
PageCount = book.PageCount;
```
---

### 🐞 Ticket #2 — "The author's name disappears, but only on one screen"

> `GET /api/books/by-author/1` gives me three books and every one says
> `"authorFullName": "Unknown"`.
> But `GET /api/books` shows `"authorFullName": "George Orwell"` for those exact same books.
> Same books, same field, two different answers.

### Root Cause

`LibraryApi.DataAccess.Implementations/BookRepository.cs` -> `GetByAuthorIdAsync(...)` does not include the `Author`.
Especially compared to `GetAllAsync(...)`, which does include the `Author` and works properly on the endpoint `GET /api/books`.
As a result, in the mapper, `book.Author` is null (because Author wasn’t loaded), so the mapper returns `Author.FullName = "Unknown"`.

### Fix

Added the missing Author table join:
`.Include(book => book.Author)`
in `/BookRepository.cs` -> `GetByAuthorIdAsync(...)`

---

### 🐞 Ticket #3 — "New books are created with id 0"

> `POST /api/books` answers `201 Created` and gives me back the book I sent — except
> `"id": 0`, and the `Location` header says `/api/Books/0`.
> Then it gets weird: sometimes the book really is in `GET /api/books` afterwards,
> sometimes it isn't. Same request, different result.

### Root Cause

`LibraryApi.Services.Implementations/BookService.cs` -> `AddBookAsync(...)` on `step 3) Save`:
The `await` keyword was missing when calling `_bookRepository.AddAsync(newBook)`.
This was also highlighted in the IDE as a warning because the method is `async` and returns a `Task`, but the result was not awaited.
As a result, the method returned before the book was actually saved to the database, leading to `id` being `0`.
The different behavior pattern while testing matches the issue: sometimes it completed in time and sometimes it didn't.

### Fix

Added the missing `await` keyword:
```csharp
await _bookRepository.AddAsync(newBook)
```
---

### 🐞 Ticket #4 — "Editing a book silently does nothing"

> `PUT /api/books` with a changed title answers `204 No Content`, which means it worked.
> Then I `GET /api/books/1` and the title is exactly what it was before. Nothing changed.
> No error, no exception, no 500. The row in SSMS is untouched too.

### Root Cause

`LibraryApi.DataAccess.Implementations/BookRepository.cs` -> `GetByIdAsync(...)` is optimized to not track the entity for faster lookups (`.AsNoTracking()`).
As a result, the entity changes do not persist when being updated.

I devised two possible solutions:

### Fix #1 - Easy:
Comment out the `.AsNoTracking()` in `GetByIdAsync(...)` so that the entity is tracked and can be updated.
But this removes the lookup optimization, which is not ideal.


### Fix #2 - Medium:

Edit the `UpdateAsync(...)` method instead to reattach the untracked entity and mark it as modified.
As a precaution, I also made sure to preserve the original creation timestamp, which should not be changed when editing an entity.
```csharp
    public async Task UpdateAsync(Book entity)
    {        
        // Reattaching the untracked Book entity
        _context.Books.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        // Preserve original creation timestamp
        _context.Entry(entity).Property(book => book.CreatedDate).IsModified = false;        

        await _context.SaveChangesAsync();
    }
```

This is a better solution because it keeps the lookup optimization and still allows the entity to be updated.
But I decided to experiment a little and went forward with the third alternative:

### Fix #3 - Hard:
Add a new specialized method `GetByIdForUpdateAsync(...)` instead of modifying `GetByIdAsync(...)`.
The new method simply doesn't use `.AsNoTracking()` and is used only for the update scenario.
The `BookService` was updated to use the new method instead of the old one.
Consequently, the `IBookRepository` interface was also updated to include the new method.


---

### ⭐ Ticket #5 — "The year filter loses a book"

> `GET /api/books?minYear=1949` should give me every book published in 1949 **or later**.
> "1984" was published in 1949 and it is not in the list. Everything from 1950 on is fine.

### Root Cause

`LibraryApi.Services.Implementations/BookService.cs` -> `GetAllBooksAsync(...)` on `step 2) Filters`:
The filtering was done using greater than - `>` instead of greater or equals `>=`
```csharp
booksDb = booksDb.Where(book => book.Year > minYear.Value).ToList();
```

### Fix

Replaced `>` with `>=` in the filtering logic:
```csharp
booksDb = booksDb.Where(book => book.Year >= minYear.Value).ToList();
```

---