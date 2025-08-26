# Biblioteca API Localhost

Este proyecto consiste en una API de gestión de libros creada con ASP.NET y un frontend en jQuery para la interacción con la API. Este `README.md` proporciona las instrucciones necesarias para configurar y ejecutar el proyecto en tu entorno local.

## Contenido del Repositorio

- **Backup de la Base de Datos**: Un archivo de copia de seguridad de la base de datos SQL Server.
- **API (ASP.NET)**: La API que gestiona las operaciones CRUD para los libros.
- **Proyecto CRUD (jQuery)**: Interfaz de usuario para interactuar con la API.

## Requisitos Previos

Asegúrate de tener instalados los siguientes programas:

- **[SQL Server Express](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)**: Necesario para gestionar la base de datos.
- **[.NET SDK](https://dotnet.microsoft.com/download)**: Necesario para compilar y ejecutar la API.
- **[Visual Studio](https://visualstudio.microsoft.com/)**: Recomendado para el desarrollo de la API (también puedes usar otro IDE compatible con ASP.NET).
- **[Visual Studio Code](https://code.visualstudio.com/)**: Recomendado para editar el proyecto del CRUD en jQuery.

## Instrucciones para la Configuración

### 1. Restaurar la Base de Datos

1. Abre SQL Server Management Studio.
2. Conéctate a tu instancia de SQL Server (en mi caso era `LOCALMARIO\SQLEXPRESS`).
3. Haz clic derecho en "Bases de datos" y selecciona "Restaurar base de datos".
4. Selecciona el archivo de copia de seguridad (`Backup_BibliotecaLibrosAPI.bak`) que se encuentra en la carpeta del proyecto.
5. Sigue las instrucciones para completar la restauración.

### 2. Configurar la API

1. Abre la solución de la API en Visual Studio.
2. Asegúrate de que la cadena de conexión en `appsettings.json` esté configurada correctamente para tu instancia de SQL Server. Debe aparecer como sigue; asegúrate de cambiarla según tus necesidades:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=LOCALMARIO\\SQLEXPRESS;Database=BibliotecaLibrosAPI;Trusted_Connection=True;Encrypt=False;"
   }
3. Ejecuta la API desde Visual Studio (F5). Asegúrate de que esté funcionando en https://localhost:44372/, o en su defecto cambia la URL para que funcione.

### 3. Configurar el Proyecto CRUD

1. Abre el proyecto del CRUD en jQuery en tu editor de texto o IDE.
2. Asegúrate de que las URL en el código apunten a la API correcta. Por ejemplo: let urlLocalhost = "https://localhost:44372/";
3. Abre iniciobiblioteca.html haciendo clic derecho y seleccionando abrir con la extensión de VSCode 'Live Server'.

### Uso

- Accede a la interfaz de usuario del CRUD para agregar, editar o eliminar libros.
- La API responderá a las solicitudes y gestionará la base de datos de libros.

### Notas Adicionales

- Si encuentras problemas de acceso al dispositivo de copia de seguridad, asegúrate de que tu usuario tenga los permisos necesarios para escribir en la carpeta donde intentas guardar la copia de seguridad.
- Si ves un error sobre la compresión en SQL Server Express, asegúrate de no tener la opción de compresión activada en las configuraciones de respaldo.

### Contacto

- Si deseas más información sobre el proyecto, no dudes en contactarme por email: jimenezmarset@gmail.com.