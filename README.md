# 🚗 Driving Licenses Management System

A **Windows Forms–based Driving License Management System** built in **C#** that manages driving license applicants, test administration, licensing services, renewals, and driver information.  
This project is intended for **educational purposes** and uses **Microsoft SQL Server** as its database.

---

## 🎯 Features

| Feature | Description |
|---------|-------------|
| 📝 Applicant Management | Register, update, and manage applicants |
| 🚦 Driving Test | Schedule and administer driving tests |
| 🪪 License Management | Issue and renew driving licenses |
| 📋 Driver Info | Manage driver personal and license information |
| 💻 User Interface | User-friendly Windows Forms interface |

---

## 🛠 Technologies Used

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D7?style=flat&logo=windows&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat&logo=microsoft-sql-server&logoColor=white)
![SSMS](https://img.shields.io/badge/SSMS-5C2D91?style=flat&logo=microsoft%20sql%20server&logoColor=white)

---

## 🗄 Database Setup

The project includes a SQL Server database script (`database.sql`) required to run the application.

### Prerequisites

- Microsoft SQL Server
- SQL Server Management Studio (SSMS) or `sqlcmd`
- .NET Framework compatible with the project

---

### Restore Database (Using SSMS)

1. Open **SQL Server Management Studio**.
2. Connect to your SQL Server instance.
3. Create a new database (e.g., `DVLD`).
4. Click **File → Open → File** and select the provided `DVLD_dataBase.sql`.
5. Select the created database.
6. Click **Execute** (`F5`).

---

### Restore Database (Using Command Line)

**Windows Authentication:**

```bash
sqlcmd -S localhost -d DVLD -E -i database.sql
```

## 🛠 Database Configuration

After restoring the database, you need to configure the connection string so the application can connect to SQL Server.

### Steps

1. Open the project folder: `DVLD_MainProject`.
2. Navigate to the `DVLD_WindowsForms` subfolder.
3. Open the solution file `DVLD_WindowsForms.sln` in **Visual Studio**.
4. In Solution Explorer, go to the **Data Access Layer** folder: `DVLD_data_AccessLayer`.
5. Open the **Database Settings** file (e.g., `DatabaseSettings.cs`).
6. Locate this line:

```csharp
public static string connectionString = "Server=.;Database=DVLD;User Id=xxx;Password=xxx;";
```
7. Replace the placeholders with your actual SQL Server credentials :
```text
Server → your SQL Server instance
         (e.g., . for local default instance or localhost\SQLEXPRESS for a named instance)
Database → the database you restored
         (e.g., DVLD)
User Id → your SQL Server username (only if using SQL Authentication)
Password → your SQL Server password (only if using SQL Authentication)
```
8. Save the `DatabaseSettings.cs` file after updating the connection string.
9. Rebuild the project in Visual Studio to ensure there are no errors.
10. Run the application. It should now connect successfully to the restored database.

## 📌 Credits & Attribution

- The **idea, icons, and database schema** used in this project are inspired by the **Programming Advices** website as part of their learning course.
- All code in this repository is written for **educational purposes**.




