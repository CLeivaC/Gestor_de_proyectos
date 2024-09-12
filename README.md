# Sistema de Gestión de Proyectos

## Descripción

Este proyecto es una **aplicación de consola en C#** diseñada para gestionar proyectos y las tareas asociadas a estos proyectos, utilizando una base de datos en **SQL Server**. La aplicación permite realizar operaciones básicas como agregar, visualizar, actualizar y eliminar proyectos y tareas.

## Características

- **Agregar un Nuevo Proyecto**: Permite al usuario ingresar detalles sobre un nuevo proyecto, incluyendo:
  - Nombre
  - Fecha de inicio
  - Fecha de fin
  - Estado
- **Agregar una Nueva Tarea**: Permite al usuario seleccionar un proyecto existente e ingresar detalles sobre una nueva tarea, incluyendo:
  - Descripción
  - Fecha de creación
  - Fecha de entrega
  - Estado
- **Ver Proyectos y Tareas**: Muestra una lista de todos los proyectos junto con las tareas asociadas a cada proyecto.
- **Actualizar el Estado de una Tarea**: Permite al usuario buscar una tarea por su ID y actualizar su estado.
- **Eliminar una Tarea**: Permite al usuario eliminar una tarea por su ID.

## Estructura del Proyecto

El proyecto está organizado en varias capas para mantener una buena separación de responsabilidades:

- **Capa de Datos (`DATA`)**:
  - Maneja la conexión a la base de datos y las operaciones CRUD.
  - Incluye la clase `ConexionBD` para gestionar la conexión y los repositorios para las operaciones específicas de la base de datos.

- **Capa de Servicios (`SERVICES`)**:
  - Contiene la lógica de negocio.
  - Los servicios interactúan con los repositorios para ejecutar operaciones y manejar la lógica de la aplicación.

- **Capa de Modelos (`MODELS`)**:
  - Define las entidades del sistema, como `Proyecto` y `Tarea`.

- **Capa de Presentación (`VIEWS`)**:
  - Interfaz de usuario en la consola.
  - Es el punto de entrada de la aplicación (`Program.cs`) y maneja la interacción con el usuario.
