## Información escencial del login

**Este tiene de manera estática el Username = admin y Password = password. Esto es como fin de mostrar el manejo de authentication y generar el Token para poder realizar la operación Crud. **



﻿# Prueba Técnica para BackendDeveloper

## Descripción General del proyecto

Este proyecto es un API RESTful, desarrollado en **.Net 8**. Utilizando arquitectura **ONION**. Este proyecto permite realizar las operaciones CRUD de la entidad Candidato y registrar métricas de consumo del API. Además, 
implementa los patrones de diseño **Unit of Work** y **CQRS** para mejorar la gestión de transacciones y la separación de responsabilidades entre operaciones de lectura y escritura. Manejo de errores de las peticiones Http. Tiene la configuración
de autenticación **JWT = JSON Web Tokens**. También consta de un proyecto de Test de las operaciones CRUD de los Handlers de Candidatos y 
las operaciones del UnitOfWork, las cuales pasan los 7 endpoints con éxito. Finalmente se publico el proyecto a un repositorio GitHub utilizado gitbash y manejos de vesiones **tags**

## Detalles de las tecnologías utilizadas

- **.Net 8**
- **C#**
- **Entity Framework Core**
- **SQL Server**
- **MediatR** para la implementación de CQRS
- **AutoMapper** para mapeo de DTOs
- **FluentValidation** para validaciones
- **Serilog** para el logging (No implementado completamente)
- **Swagger** para documentación y levantamiento de API
- **xUnit** y **Moq** para pruebas unitarias

## Arquitectura ONION

La arquitectura ONION nos brinda una separación clara de responsabilidades entre las distintas capas de la aplicación:


├── src
│   ├── Application ------------------------------------> La capa Application se encarga de definir la lógica de negocio específica de la aplicación. Gestiona los comandos y consultas. Coordina operaciones entre el dominio y la infraestructura. Utiliza DTOs para transferir datos.
│   
│   ├── Domain -----------------------------------------> La capa Domain se encarga de definir las entidades y objetos de valor. Contiene la lógica de negocio pura. Define reglas y comportamientos esenciales del sistema.
│     
│   ├── Infrastructure ---------------------------------> La capa Infrastructure se encarga de implementar las interfaces definidas en Application. Gestiona el acceso a datos, maneja servicios externos y detalles técnicos. Implementa el patrón Unit of Work.
│   
│   ├── API --------------------------------------------> La capa API se encarga de exponer endpoints RESTful. Gestiona las peticiones HTTP y respuestas. Implementa autenticación y autorización, maneja los errores y registra métricas.
│   
├── tests ----------------------------------------------> La capa UnitTests se ha creado con el propósito de verificar, a través de métodos de pruebas o tests, el correcto funcionamiento del CRUD de candidatos y el Unit of Work, los cuales pasaron con éxito 7/7.
│   ├── UnitTests
│
└── README.md

## Patrón Unit of Work
El patrón **Unit of Work** se utiliza para gestionar transacciones de manera centralizada, coordinando múltiples repositorios para asegurar que todas las operaciones dentro de una transacción se completen exitosamente o se deshagan en caso de error.

## Patrón CQRS
El patrón **CQRS (Command Query Responsibility Segregation)** separa las operaciones de lectura (Queries) de las operaciones de escritura (Commands), permitiendo una mejor organización y optimización de las mismas.


## Instalación y Ejecución
### Prerrequisitos

- **.NET 8 SDK**: [Descargar aquí](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- **SQL Server**: Puede ser SQL Server Express o LocalDB.
- **IDE**: Visual Studio 2022, Visual Studio Code o cualquier otro IDE compatible con .NET.

### Pasos 

1- **Clonar el Repositorio**

Utilizando  bash
 git clone https://github.com/BryantBeltre/PruebaTecnicaCandidatosApi.git

2- Una vez clonado abre el proyecto y Configura tu base dedatos en el  connectionStrings
  eje:
  {
  "ConnectionStrings": {
    "DefaultConnection": "Server=server;Database=Database;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
3- Abre el Package Manager Console y corre las migations en el proyecto Infrastrucuture
	Add-Migration <Nombre de la migración> (press enter)
	Update-Database (press enter)
4- Pon como proyecto de arranque el ApiRestFullPruebaTecnica.
   y utiliza el api en el Swagger.

	
	


