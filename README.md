# 🚗 Prueba Técnica — BrowserTravel  

**Autor:** Jorge Alejandro Vélez Quitián  
**GitHub:** [AlejandroVelez0222](https://github.com/AlejandroVelez0222/BrowserTravel)  
**LinkedIn:** [www.linkedin.com/in/ingeniero-sistemas-computacion-alejandro-velez](https://www.linkedin.com/in/ingeniero-sistemas-computacion-alejandro-velez)

---

## 📖 Descripción del Proyecto  

Este proyecto fue desarrollado como parte de una **prueba técnica** para BrowserTravel.  
Su objetivo es construir una **API REST en .NET 8** conectada a **MySQL**, que permita realizar búsquedas de vehículos disponibles según distintos tipos de criterios, aplicando una **arquitectura limpia (Clean Architecture)** y principios de **SOLID**.

La solución cuenta con separación por capas:
- **Core (Domain):** Entidades y reglas de negocio.
- **Application:** Casos de uso, servicios e interfaces.
- **Infrastructure:** Repositorios, configuración de EF Core y acceso a datos.
- **API:** Controladores y capa de presentación.

---

## 🧩 Arquitectura General  

```plaintext
BrowserTravel.sln
│
├── BrowserTravel.Core                → Entidades de dominio (Vehicle, Market, VehicleLocation)
├── BrowserTravel.Application         → Interfaces, DTOs, y lógica de aplicación (servicios)
├── BrowserTravel.Infrastructure      → Repositorios, contexto de base de datos, migraciones
└── PruebaTecnicaBrowserTravel.Api    → API principal (.NET 8) con controladores y Swagger
```

---

## ⚙️ Requisitos Previos  

Antes de ejecutar el proyecto, asegúrate de tener instalados los siguientes componentes:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/)

---

## 🗄️ Configuración de la Base de Datos  

1. Crea una base de datos vacía en MySQL (por ejemplo: `browsertraveldb`).  
2. En el archivo `appsettings.json` del proyecto **PruebaTecnicaBrowserTravel.Api**, actualiza tu cadena de conexión:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=browsertraveldb;User=root;Password=tu_contraseña;"
}
```

---

## 🧰 Comandos Útiles  

Ejecuta los siguientes comandos desde la raíz del proyecto (`PruebaTecnicaBrowserTravel`):

```bash
# 🧹 Eliminar base de datos existente (si necesitas reiniciar el entorno)
dotnet ef database drop --project .\BrowserTravel.Infrastructure\BrowserTravel.Infrastructure.csproj --startup-project .\PruebaTecnicaBrowserTravel\PruebaTecnicaBrowserTravel.Api.csproj -f

# 🏗️ Crear nueva migración
dotnet ef migrations add InitialCreate --project .\BrowserTravel.Infrastructure\BrowserTravel.Infrastructure.csproj --startup-project .\PruebaTecnicaBrowserTravel\PruebaTecnicaBrowserTravel.Api.csproj

# 💾 Aplicar migraciones a la base de datos
dotnet ef database update --project .\BrowserTravel.Infrastructure\BrowserTravel.Infrastructure.csproj --startup-project .\PruebaTecnicaBrowserTravel\PruebaTecnicaBrowserTravel.Api.csproj

# 🚀 Ejecutar el proyecto (API)
dotnet run --project .\PruebaTecnicaBrowserTravel\PruebaTecnicaBrowserTravel.Api.csproj
```

---

## 🌐 Ejecución del Proyecto  

Una vez ejecutado el último comando, el proyecto se levantará en los siguientes puertos:

```
HTTPS: https://localhost:7262
HTTP:  http://localhost:5137
```

Abre tu navegador en:

👉 **[https://localhost:7262/swagger](https://localhost:7262/swagger)**  

Allí podrás explorar y probar los endpoints disponibles del API.

---


## 🧩 Tecnologías Utilizadas  

| Capa | Tecnologías |
|------|--------------|
| Core | C#, .NET 8 |
| Infraestructura | EF Core 9, Pomelo MySQL Provider |
| Aplicación | DTOs, patrones Strategy y Repository |
| API | ASP.NET Core Web API + Swagger |

---

## 👨‍💻 Autor  

**Jorge Alejandro Vélez Quitián**  
📧 *Ingeniero de Sistemas y Computación*  
🔗 [LinkedIn](https://www.linkedin.com/in/ingeniero-sistemas-computacion-alejandro-velez)  
💻 [GitHub](https://github.com/AlejandroVelez0222/BrowserTravel)
