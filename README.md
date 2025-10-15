# Blazor UI Template

A modern Blazor .NET 9 project template inspired by [shadcn/ui dashboard](https://ui.shadcn.com/examples/dashboard), featuring components from [Sysinfocus Simple/UI](https://blazor.art/Tools/Simple-UI).

## Features

- 🎨 Modern dashboard layout with left sidebar and top header
- 📱 Responsive design that works on mobile and desktop
- 🎯 Multiple demo pages showcasing different UI components
- ⚡ Built with Blazor .NET 9 and interactive server components
- 🎭 Clean and professional styling using Simple-UI components
- 🧩 Uses Card, Input, Button, and Icon components from Sysinfocus Simple/UI
- 🚀 No Bootstrap or Tailwind CSS dependencies

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

Navigate to `http://localhost:5005` in your browser.

## Project Structure

```
BlazorApp/
├── Components/
│   ├── Layout/
│   │   └── MainLayout.razor      # Main dashboard layout with integrated sidebar
│   └── Pages/
│       ├── Home.razor            # Dashboard page (Simple-UI Card)
│       ├── Analytics.razor       # Analytics page (Simple-UI Card)
│       ├── Orders.razor          # Orders page (Simple-UI Card, Button)
│       ├── Products.razor        # Products page (Simple-UI Card, Button)
│       ├── Customers.razor       # Customers page (Simple-UI Card, Button)
│       └── Settings.razor        # Settings page (Simple-UI Card, Input, Button)
├── wwwroot/                      # Static files
└── Program.cs                    # Application entry point
```

## Technology Stack

- **Framework**: Blazor .NET 9
- **Components**: [Sysinfocus Simple/UI](https://blazor.art/Tools/Simple-UI) v0.0.3.4
  - Card, CardHeader, CardContent, CardFooter
  - Button
  - Input
  - Icon (Material Symbols)
- **Styling**: Custom CSS with modern design principles
- **Icons**: Material Symbols Outlined for UI icons, Emoji icons for content

## License

This template is open source and available for use in your projects.
