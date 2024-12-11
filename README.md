# QuickProFixer

QuickProFixer is a platform that connects clients with skilled artisans, known as fixers, to get various jobs done efficiently. The platform supports functionalities like artisan and client registration, profile creation, fix request management, quotes, bookings, payments, and ratings.

## Features

- **User Registration**: Clients and artisans can register with their basic information and skills.
- **Profile Management**: Users can create and update detailed profiles.
- **Search and Filter**: Clients can search and filter artisans based on various criteria.
- **Fix Request**: Clients can send fix requests to one or multiple artisans.
- **Quotes and Communication**: Artisans can send quotes and communicate with clients.
- **Bookings**: Clients can book services from received quotes.
- **Job Execution**: Artisans can update job status, and clients can track progress.
- **Payment Processing**: Secure payments through multiple gateways.
- **Ratings and Reviews**: Clients and artisans can rate and review each other.
- **Dashboard and History**: Users can view their requests, quotes, bookings, and job statuses.
- **Dual Role Access**: Users can switch between client and fixer roles.

## Project Structure

quickprofixer/ ├── Controllers/ │ ├── AccountController.cs│ ├── ProfileController.cs│ ├── SearchController.cs│ ├── FixRequestController.cs│ ├── QuoteController.cs│ ├── BookingController.cs│ ├── ChatController.cs│ ├── DashboardController.cs│ ├── RoleController.cs│ └── AdminController.cs├── Models/ │ ├── Artisan.cs│ ├── Client.cs│ ├── FixRequest.cs│ ├── Quote.cs│ ├── Booking.cs│ ├── ChatMessage.cs│ ├── Rating.cs│ ├── Profile.cs│ └── Notification.cs├── Data/ │ ├── ApplicationDbContext.cs│ └── IRepository.cs├── Services/ │ ├── IAccountService.cs│ ├── IProfileService.cs│ ├── ISearchService.cs│ ├── IFixRequestService.cs│ ├── IQuoteService.cs│ ├── IBookingService.cs│ ├── IChatService.cs│ ├── IDashboardService.cs│ ├── IRoleService.cs│ └── IAdminService.cs├── DTOs/ │ ├── ArtisanDto.cs│ ├── ClientDto.cs│ ├── FixRequestDto.cs│ ├── QuoteDto.cs│ ├── BookingDto.cs│ ├── ChatMessageDto.cs│ ├── RatingDto.cs│ ├── ProfileDto.cs│ └── NotificationDto.cs├── Mappings/ │ └── AutoMapperProfile.cs├── Utilities/ │ ├── JwtHelper.cs│ └── EmailHelper.cs├── Program.cs├── Startup.cs├── quickprofixer.csproj└── appsettings.json

## Getting Started

### Prerequisites

- [.NET SDK 8](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) or any preferred IDE
- [Git](https://git-scm.com/)

### Installation

1. Clone the repository:

   ```sh
   git clone https://github.com/Sarerrdy/quickprofixer.git
   cd quickprofixer

   ```

2. Restore the .NET dependencies:
   dotnet restore

3. Update appsettings.json with your database connection string and other settings.

### Running the Application

1. Build and run the application:

- **dotnet run**

2. Open your browser and navigate to:

- **http://localhost:5000**
