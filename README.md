# Real Estate Agency App 🏠

A Windows desktop application for managing the core operations of a real estate agency — properties, clients, requests, and offers.

> 🚧 Work in progress

---

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# (.NET Framework 4.8) |
| UI | Windows Forms |
| Database | SQL Server Express |
| Data access | ADO.NET |
| Architecture | Repository pattern (separate repository class per entity) |

---

## Project Structure

```
RealEstate-App/
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
├── Enums.cs               # PropertyType, TransactionType, RequestStatus, OfferStatus, PropertyStatus
└── Program.cs             # Entry point
```

---

## Database Setup

Connect to SQL Server Express, create the database `RealEstateAppDB`, then run:

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

## Data Models

| Model | Key Fields |
|---|---|
| `Client` | LastName, FirstName, Phone, Email |
| `Property` | Type, Address, City, Area (sqm), Price, TransactionType, Status |
| `Request` | Client, PropertyType, TransactionType, MaxBudget, City, Status, RequestDate |
| `Offer` | Client, Property, OfferDate, Status |
