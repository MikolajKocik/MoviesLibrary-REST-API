# MoviesLibrary

This repository contains a simple Movies Library management application built using .NET 8. The application consists of a Windows Forms frontend that communicates with a RESTful API.

## How to Run

First of all, use git clone to copy the repository:

```bash
https://github.com/MikolajKocik/MoviesLibrary-REST-API.git
```

### API - backend and database using EF

1. **Open the API Project**
  - Open the API project in Visual Studio.
  - Open the NuGet Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) and run the following command:
    ```bash
    Update-database
    ```   
To update the database, you can also simply run:
   ```bash
   dotnet ef database update
   ```
2. **Run a project**
   - Run the project in visual studio, you can press 'F5' or click on button
     
   Eventually:
   ```bash
   dotnet run
   ```
   and dont close, go to the next step.

### WinForms - frontend

1. **Open the Frontend Project**
  - Open the Windows Forms project in Visual Studio.
    
2. Build and Run
   Build and run the application.
   
   You can also run the project in console:
   ```bash
   dotnet run
   ```
  - The main form (Form1) displays a list of movies retrieved from the API.
  - **Add:** Click the "Add" button to open a modal dialog (FormMovie) for adding a new movie.
  - **Edit:** Each row in the DataGridView has an "Edit" button. Clicking it opens the modal dialog pre-filled with the movie data for editing.
  - **Delete:** Each row also has a "Delete" button that, after confirmation, removes the movie.
