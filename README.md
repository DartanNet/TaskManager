# TaskManager (.NET)

**TaskManager** is a simple web application built with ASP.NET Core MVC that allows users to create, view, edit, and delete tasks. Data is stored locally using SQLite and managed through Entity Framework Core.

---

## 📦 Technologies

- ASP.NET Core MVC
- C#
- Entity Framework Core (SQLite)
- Razor Views
- Dependency Injection & ILogger

---

## 📁 Project Structure

- `Models/TaskItem.cs` – Data model representing a task
- `Controllers/TasksController.cs` – Handles all task-related actions (CRUD)
- `Data/AppDbContext.cs` – Entity Framework context and SQLite config
- `Program.cs` – Application setup and route configuration

---

## 🧪 Features

- [x] Create a task
- [x] Edit a task
- [x] Delete a task
- [x] Display task list (ordered by newest)
- [x] Title validation (`[Required]` attribute)
- [x] Logging with `ILogger`

---

## ⚙️ Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/DartanNet/TaskManager.git
   cd TaskManager
Run the project:

Using Visual Studio: F5

Or via CLI:

bash

dotnet run
Open your browser at:

arduino
Kopiuj
Edytuj
http://localhost:5000
💾 Database
This app uses a local SQLite database (tasks.db).

To set up the database manually:

bash

dotnet ef migrations add InitialCreate
dotnet ef database update
Make sure Entity Framework CLI tools are installed:
dotnet tool install --global dotnet-ef

🔁 Routing
The app uses conventional routing and defaults to:

csharp
Kopiuj
Edytuj
pattern: "{controller=Tasks}/{action=Index}/{id?}"
🧼 .gitignore Recommendation
gitignore
Kopiuj
Edytuj
bin/
obj/
*.db
*.suo
*.user
.vs/
✅ Project Status
This is a functional CRUD MVP. It can be extended with:

Task categories or tags

Status indicators (priority, deadline)

User authentication

REST API (e.g., [ApiController])

Frontend SPA (React / Angular / Blazor)

📄 License
MIT – free to use and modify.

