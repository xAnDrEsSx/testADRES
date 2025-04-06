# TestADRES API - Initial Migration and Database Setup

Este repositorio contiene la implementación de la **API de TestADRES**, que gestiona los requisitos de adquisiciones, incluyendo los detalles de proveedores, unidades de negocio, tipos de productos, etc. La API se conecta a una base de datos SQL Server y utiliza migraciones de Entity Framework Core para gestionar las estructuras de la base de datos.

## Requisitos previos

Para ejecutar este proyecto, necesitas tener instalado lo siguiente:

- **.NET 8.0** (o versión más reciente)
- **SQL Server** (o una instancia de SQL Server accesible)
- **Visual Studio** o cualquier editor de código compatible con .NET
- **SQL Server Management Studio (SSMS)** o herramientas similares para verificar la base de datos

## Estructura del Proyecto

El proyecto está dividido en las siguientes partes:

1. **TestADRES.Application**: Contiene la lógica de la aplicación.
2. **TestADRES.Infrastructure**: Contiene la infraestructura, incluyendo el acceso a la base de datos y repositorios.
3. **TestADRES.API**: La API web que sirve como punto de entrada para los servicios.

## Pasos para ejecutar el proyecto


### Comandos Para Ejecutar Migracion - ejecutar migracion en curso
 1. cd TestADRES.Infrastructure
 2. dotnet ef database update --startup-project ../TestADRES.API



### 1. Clonar el repositorio

Clona el repositorio a tu máquina local:

```bash
git clone https://github.com/yourusername/TestADRES.git


