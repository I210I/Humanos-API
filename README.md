# Humanos API

Este proyecto es una API de gestión de Humanos desarrollada con .NET 7 y Entity Framework Core que permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre una base de datos de humanos.

## Despliegue

### Prerrequisitos

- .NET 7 SDK
- PostgreSQL
- Un cliente HTTP como Postman o cURL para probar la API

### Pasos de Despliegue

1. Clonar el repositorio:
git clone https://github.com/I210I/Humanos-API.git
cd Humanos-API


2. Restaurar los paquetes NuGet:
dotnet restore


3. Configurar la cadena de conexión de PostgreSQL en `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=apiHumano;Username=tu-usuario;Password=tu-contraseña;"
}

4. Aplicar las migraciones a la base de datos:
dotnet ef database update

en caso de no poder actualizar, entonces primero borrar el paquete Migrations y ejecutar:
dotnet ef migrations add InitialCreate

5. Ejecutar la API (en su defecto de no utilizar VS)
dotnet run

La API ahora estará escuchando en http://localhost:5000 y https://localhost:5001. o en el puerto 7095 con la autodocumentación de swagger.

# Uso
La API soporta las siguientes operaciones:

GET /Humano: Devuelve una lista de todos los humanos en la base de datos.
GET /Humano/{id}: Devuelve el humano con el ID especificado.
POST /Humano: Crea un nuevo humano.
PUT /Humano/{id}: Actualiza el humano con el ID especificado.
GET /Humano/Mock: Devuelve una lista estática de humanos para propósitos de prueba.

El MathController es un controlador API diseñado para realizar operaciones matemáticas básicas como sumar (+), restar (-), multiplicar (*) y dividir (/). Este controlador ofrece dos métodos principales: uno que acepta solicitudes POST y otro que acepta solicitudes GET.

## Endpoints

POST math/operacionmatematica
POST math/operacionmatematica

Descripción: Realiza una operación matemática especificada en el cuerpo de la solicitud.
Request Body:
OperacionRequest: Un objeto JSON que contiene dos enteros (A y B) y una cadena de texto (Operacion) que especifica la operación a realizar.
Ejemplo de Request Body:

{
  "A": 10,
  "B": 5,
  "Operacion": "+"
}



# Estructura del Proyecto
Api/Data/_DbContext.cs
Define el contexto de la base de datos utilizado por Entity Framework Core para interactuar con PostgreSQL.

Api/Models/Humanos.cs
Define el modelo de datos Humanos que representa la tabla de humanos en la base de datos.

Api/Controllers/HumanoController.cs
Contiene los endpoints de la API que manejan las solicitudes HTTP para operaciones CRUD sobre humanos.