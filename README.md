# MoviesLibrary

This repository contains a simple Movies Library management application built using .NET 8. The application consists of a Windows Forms frontend that communicates with a RESTful API.

## How to Run

Copy the repository to terminal:
```bash
git clone https://github.com/MikolajKocik/MoviesLibrary-REST-API.git
```
If you want to run the project in Visual Studio, use option 'Clone the repository' and then:
```bash
https://github.com/MikolajKocik/MoviesLibrary-REST-API.git
```

### API - backend and database using EF

1. **Open the API Project**
  - Open the API project in Visual Studio.
  - Open the NuGet Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) and run the following command:
   ```bash
   Update-Database
   ```   
To update the database, you can also simply run:
   ```bash
   dotnet ef database update
   ```
2. **Run the project**
   - Run the project in Visual Studio, you can press 'F5' or click on button
     
   Eventually:
   ```bash
   dotnet run
   ```
   and dont close it, go to the next step.

### WinForms - frontend

1. **Open the Frontend Project**
  - Open the Windows Forms project in Visual Studio.
    
2. **Run the project**
    - Run the project in Visual Studio, you can press 'F5' or click on button
  
   You can also run the project in console:
   ```bash
   dotnet run
   ```
  - The main form (Form1) displays a list of movies retrieved from the API.
  - **Add:** Click the "Add" button to open a modal dialog (FormMovie) for adding a new movie.
  - **Edit:** Each row in the DataGridView has an "Edit" button. Clicking it opens the modal dialog pre-filled with the movie data for editing.
  - **Delete:** Each row also has a "Delete" button that, after confirmation, removes the movie.

### Requirements:
- .NET 8 SDK
- Visual Studio 2022
- Web Application Development workload installed in VS
- Desktop Application Development workload installed in VS
