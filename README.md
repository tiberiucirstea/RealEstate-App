# Real Estate Agency App

A Windows desktop application for managing the core operations of a real estate agency: properties, clients, client requests, and offers.

The application is built with C# and Windows Forms, uses SQL Server Express for persistence, and accesses the database through ADO.NET repositories.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# (.NET Framework 4.8) |
| UI | Windows Forms |
| Database | SQL Server Express |
| Data access | ADO.NET / SqlClient |
| Architecture | Models + Repositories + WinForms UI |

---

## Features

### Properties

- Add, edit, delete, and list real estate properties.
- Filter properties by type: `Apartment`, `House`, or `CommercialSpace`.
- Each property stores:
  - type
  - address
  - city
  - area
  - price
  - transaction type: `Sale` or `Rental`
  - status: `Available`, `Sold`, or `Rented`
- New properties are created as `Available`.
- Property status is managed automatically when offers are accepted, changed, or deleted.
- Deleting a property also deletes its related offers in a database transaction.

### Clients

- Add, edit, delete, and list clients.
- Each client stores:
  - last name
  - first name
  - phone
  - email
- The application performs basic phone/email validation.
- The application checks for duplicate email or phone before saving a client.
- Deleting a client also deletes related requests and offers in a database transaction.
- If the deleted client had accepted offers, the related properties are made `Available` again.

### Requests

- Add, edit, delete, and list client requests.
- Filter requests by status: `Active`, `Resolved`, or `Cancelled`.
- A request stores:
  - client
  - desired property type
  - transaction type
  - maximum budget
  - city
  - status
  - request date
- The client is selected through a searchable list.

### Offers

- Add, edit, delete, and list offers.
- Filter offers by status: `Proposed`, `Accepted`, or `Rejected`.
- An offer links one client to one property.
- When creating a new offer, only `Available` properties are listed.
- An accepted offer marks the property as:
  - `Sold` for sale properties
  - `Rented` for rental properties
- If an accepted offer is changed to another status or deleted, the property is returned to `Available`.
- Saving an already accepted offer does not re-run the accepted-offer side effects.
- When an offer is accepted, only matching active requests are resolved.

---

## Business Rules

The main business rules implemented by the application are:

- A property can be sold or rented only through an accepted offer.
- A new offer can be created only for an `Available` property.
- Accepting an offer updates the property's status based on its transaction type.
- Changing or deleting an accepted offer releases the property back to `Available`.
- Accepting an offer resolves only the active requests that match:
  - same client
  - same city
  - same property type
  - same transaction type
  - request budget greater than or equal to the property price
- Deleting a client removes that client's offers and requests together.
- Deleting a property removes that property's offers together.
- Client/property cascaded deletes are wrapped in database transactions to avoid partially deleted data.

---

## Getting Started

### Prerequisites

- Visual Studio 2022 or newer
- `.NET desktop development` workload installed in Visual Studio
- SQL Server Express
- SQL Server Management Studio or another SQL client

### Clone the Repository

```bash
git clone https://github.com/tiberiucirstea/RealEstateAgency-App.git
```

Open `RealEstateAgency-App.sln` in Visual Studio.

---

## Database Setup

The application expects a SQL Server database named `RealEstateAgencyDB`.

The connection string is configured in `App.config`:

```xml
<add name="RealEstateAgencyDB"
     connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=RealEstateAgencyDB;Integrated Security=True"
     providerName="System.Data.SqlClient" />
```

If your SQL Server instance has a different name, update `Data Source` accordingly.

Create the database, then run the following SQL script:

```sql
CREATE TABLE [dbo].[Clients] (
    [Id]        UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [LastName]  NVARCHAR(100) NOT NULL,
    [FirstName] NVARCHAR(100) NOT NULL,
    [Phone]     NVARCHAR(20) NOT NULL,
    [Email]     NVARCHAR(150) NOT NULL
);

CREATE TABLE [dbo].[Properties] (
    [Id]              UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [Type]            NVARCHAR(50) NOT NULL,
    [Address]         NVARCHAR(200) NOT NULL,
    [City]            NVARCHAR(100) NOT NULL,
    [Area]            FLOAT NOT NULL,
    [Price]           DECIMAL(18,2) NOT NULL,
    [TransactionType] NVARCHAR(50) NOT NULL,
    [Status]          NVARCHAR(50) NOT NULL DEFAULT 'Available'
);

CREATE TABLE [dbo].[Requests] (
    [Id]              UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [ClientId]        UNIQUEIDENTIFIER NOT NULL REFERENCES Clients(Id),
    [PropertyType]    NVARCHAR(50) NOT NULL,
    [TransactionType] NVARCHAR(50) NOT NULL,
    [MaxBudget]       DECIMAL(18,2) NOT NULL,
    [City]            NVARCHAR(100) NOT NULL,
    [Status]          NVARCHAR(50) NOT NULL DEFAULT 'Active',
    [RequestDate]     DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [dbo].[Offers] (
    [Id]         UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [ClientId]   UNIQUEIDENTIFIER NOT NULL REFERENCES Clients(Id),
    [PropertyId] UNIQUEIDENTIFIER NOT NULL REFERENCES Properties(Id),
    [OfferDate]  DATETIME NOT NULL DEFAULT GETDATE(),
    [Status]     NVARCHAR(50) NOT NULL DEFAULT 'Proposed'
);
```

---

## Run the Application

1. Open the solution in Visual Studio.
2. Make sure SQL Server Express is running.
3. Make sure `RealEstateAgencyDB` exists and contains the required tables.
4. Build the solution.
5. Run the application from Visual Studio.

If the database cannot be reached when the application starts, the application displays a database error message instead of closing immediately.

---

## Manual Test Checklist

Use these scenarios to verify the most important behavior:

1. Create a property, client, and matching active request.
2. Create an accepted offer for that client and property.
3. Confirm that the property becomes `Sold` or `Rented`.
4. Confirm that only matching active requests become `Resolved`.
5. Edit the accepted offer and change it to `Rejected` or `Proposed`.
6. Confirm that the property returns to `Available`.
7. Create another accepted offer, then delete it.
8. Confirm that the property returns to `Available`.
9. Try to create a new offer for a sold/rented property.
10. Confirm that unavailable properties are not listed for new offers.
11. Delete a client with related offers and requests.
12. Confirm that related data is removed and accepted-offer properties become `Available`.
13. Delete a property with related offers.
14. Confirm that the property and its offers are removed together.

---

## Project Structure

```text
RealEstateAgency-App/
├── Models/
│   ├── Client.cs
│   ├── Property.cs
│   ├── Request.cs
│   └── Offer.cs
├── Repositories/
│   ├── ClientRepository.cs
│   ├── PropertyRepository.cs
│   ├── RequestRepository.cs
│   └── OfferRepository.cs
├── Enums.cs
├── MainForm.cs
├── MainForm.Designer.cs
├── Program.cs
├── App.config
└── RealEstateAgency-App.sln
```

---

## Notes

- The database schema is created manually; the application does not run migrations.
- SQL queries are parameterized through ADO.NET commands.
- Cascaded deletes are handled in application code.
- The project is intended as a personal/educational Windows Forms application, not as a production-ready system.
