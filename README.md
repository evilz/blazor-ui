# Blazor UI Template

A modern Blazor .NET 9 project template inspired by [shadcn/ui dashboard](https://ui.shadcn.com/examples/dashboard), featuring components from [Sysinfocus Simple/UI](https://blazor.art/Tools/Simple-UI).

## Features

- 🎨 Modern dashboard layout with left sidebar and top header
- 📱 Responsive design that works on mobile and desktop
- 🎯 Multiple demo pages showcasing different UI components
- ⚡ Built with Blazor .NET 9 and interactive server components
- 🎭 Clean and professional styling inspired by shadcn/ui

## Pages Included

- **Dashboard** - Overview with statistics cards and recent activity
- **Analytics** - Performance metrics and data visualization
- **Orders** - Order management with status badges
- **Products** - Product catalog with pricing cards
- **Customers** - Customer list with avatars
- **Settings** - Application settings and preferences
- **Counter** - Interactive counter example
- **Weather** - Weather forecast demo

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later

### Running the Application

```bash
cd BlazorApp
dotnet run
```

Navigate to `http://localhost:5000` in your browser.

## Project Structure

```
BlazorApp/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor      # Main dashboard layout
│   │   └── NavMenu.razor         # Sidebar navigation
│   └── Pages/
│       ├── Home.razor            # Dashboard page
│       ├── Analytics.razor       # Analytics page
│       ├── Orders.razor          # Orders page
│       ├── Products.razor        # Products page
│       ├── Customers.razor       # Customers page
│       └── Settings.razor        # Settings page
├── wwwroot/                      # Static files
└── Program.cs                    # Application entry point
```

## Technology Stack

- **Framework**: Blazor .NET 9
- **Components**: Sysinfocus Simple/UI
- **Styling**: Custom CSS with modern design principles
- **Icons**: Emoji icons for simplicity

## License

This template is open source and available for use in your projects.
