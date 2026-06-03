# Real Estate Agency App 🏠

A Windows desktop application for managing the core operations of a real estate agency — properties, clients, requests, and offers.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# (.NET Framework 4.8) |
| UI | Windows Forms |
| Database | SQL Server Express |
| Data access | ADO.NET |
| Architecture | Repository pattern |

---

## Features

**Properties** — Add, edit, delete properties. Filter by type (Apartment, House, Commercial Space). Each property has a type, address, city, area, price, transaction type (Sale/Rental) and status (Available, Sold, Rented).

**Clients** — Add, edit, delete clients with full name, phone and email validation.

**Requests** — Add, edit, delete client requests. Each request specifies the desired property type, transaction type, max budget, city and status. Filter by status (Active, Resolved, Cancelled). Client is selected via live search.

**Offers** — Add, edit, delete offers linking a client to a property. Filter by status (Proposed, Accepted, Rejected). When an offer is accepted, the property status is automatically updated (Sold/Rented) and the client's active requests are resolved.

---

## Getting Started

### Prerequisites

- [Visual Studio 2022+](https://visualstudio.microsoft.com/) with .NET desktop development workload
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository
   ```bash
   git clone https://github.com/tiberiucirstea/RealEstateAgency-App.git
   ```

2. Open `RealEstateAgency-App.sln` in Visual Studio

3. Set up the database — connect to SQL Server Express, create the database `RealEstateAgencyDB`, then run:

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

4. Build and run the project

---

## Project Structure

```
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
└── Program.cs
```
