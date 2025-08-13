# DevFolio 🚀
DevFolio is a modern, professional backend solution designed to help developers quickly create and manage a personal portfolio website. Built with ASP.NET Core 8 and following Clean Architecture, it ensures maintainable, scalable, and secure development.

With DevFolio, you can manage your projects, skills, education, experiences, and social links through a RESTful API, all protected by JWT authentication for admins.

# 🌟 Key Highlights
-  Admin Authentication — Secure login with JWT. Multiple admins can be created, all sharing the same admin role.
-  Full Content Management — CRUD operations for projects, experiences, education, skills, social links, and site settings.
-  Clean & Extensible Architecture — Designed to be easily maintainable and extendable.
-  Swagger UI Integration — Explore and test all API endpoints interactively.
-  Security Best Practices — Password hashing, input validation, secure API patterns, and fully pentest verified.


# 🛠 Tech Stack
- Backend: ASP.NET Core 8 (C#)
- Database: Microsoft SQL Server
- ORM: Entity Framework Core 
- Authentication: JWT Bearer Token
- Documentation: Swagger 
- Architecture: Clean, layered (Application, Domain, Infrastructure, WebAPI)

# ⚡ Getting Started

1. Clone the repository
```bash
git clone https://github.com/username/DevFolio.git
```
2. Navigate to the project folder
```bash
cd DevFolio
```
3. Configure appsettings.json:
```bash
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DevFolioDb;User Id=sa;Password=YourPassword;"
},
"JwtSettings": {
    "SecretKey": "YOUR_JWT_SECRET_KEY"
}
```
> 🔑 Never commit real secrets or passwords.

4. Run EF Core migrations to create the database
```bash
dotnet ef database update
```
5. Start the API
```bash
dotnet run
```
6. Explore the API using Swagger UI:
```bash
https://localhost:5001/swagger
```

# 🔒 Security Notes
- Multiple admin accounts are supported, all sharing the same admin role.
- Full pentest has been conducted to verify security.
- Always use HTTPS and secure headers in production.
- Never commit secrets like JWT keys or database passwords.

# 🤝 Contributing
This project welcomes contributions! Feel free to:
- Submit issues
- Suggest improvements
- Open pull requests

# 📄 License
This project is licensed under the MIT License — free to use, modify, and share.

# 📌 Screenshots
<img width="2266" height="1318" alt="Annotation 2025-08-13 203743" src="https://github.com/user-attachments/assets/ea442ca9-34ac-41ca-8903-dfce8127cebd" />

---

<img width="2130" height="853" alt="Annotation 2025-08-13 204525" src="https://github.com/user-attachments/assets/426cb22f-01d1-43b7-a081-1730e1191fc0" />



