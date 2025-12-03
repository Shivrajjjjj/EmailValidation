# EmailValidation

EmailValidation is a Razor Pages application built with .NET 8.0. It provides functionality to validate emails, submit forms, and monitor blocked email attempts. The application includes a dashboard for managing submissions and blocked emails.

## Features

- **Email Validation**: Validate email addresses and block invalid ones.
- **Contact Form**: Submit contact details including phone number, email, and description.
- **Dashboard**: View statistics for total submissions, successful registrations, and blocked emails.
- **Blocked Emails**: Monitor and display blocked email addresses.
- **Dynamic Alerts**: Notify users with success or error messages using Bootstrap alerts.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (optional, for managing frontend dependencies)
- A modern web browser

## Getting Started


### 2. Restore Dependencies

Restore the required NuGet packages:


### 3. Build the Application

Build the project to ensure everything is set up correctly:


### 4. Run the Application

Run the application locally:


The application will start and bind to a random available port. Open your browser and navigate to the URL displayed in the terminal (e.g., `http://127.0.0.1:5000`).

### 5. Access the Application

- **Home Page**: `http://127.0.0.1:<port>/`
- **Contact Page**: `http://127.0.0.1:<port>/Contact/Index`
- **Dashboard**: `http://127.0.0.1:<port>/Contact/Dashboard`
- **Blocked Emails**: `http://127.0.0.1:<port>/Contact/BlockedEmail`

## Project Structure

- **Controllers**: Handles HTTP requests and responses.
- **Views**: Razor Pages for the user interface.
- **Models**: Contains data models like `ContactModel` and `DashboardViewModel`.
- **Services**: Includes the `EmailBlockService` for email validation logic.
- **wwwroot**: Static files such as CSS, JavaScript, and images.

## Key Files

- `Program.cs`: Configures the application and middleware.
- `Views/Shared/_Layout.cshtml`: Defines the layout for all pages.
- `wwwroot/js/alerts.js`: Handles dynamic alert notifications.
- `wwwroot/css/EmailValidation.styles.css`: Custom styles for the application.

## Dependencies

- **NuGet Packages**:
  - `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation`: Enables runtime compilation of Razor views.
- **Frontend Libraries**:
  - [Bootstrap](https://getbootstrap.com/): For responsive design and styling.
  - [jQuery Validation](https://jqueryvalidation.org/): For client-side form validation.

## License

This project is licensed under the MIT License. See the [LICENSE](wwwroot/lib/jquery-validation/LICENSE.md) file for details.

## Contributing

Contributions are welcome! Feel free to submit issues or pull requests to improve the project.

## Acknowledgments

- [jQuery Validation Plugin](https://jqueryvalidation.org/)
- [Bootstrap](https://getbootstrap.com/)

---

