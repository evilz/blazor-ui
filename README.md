# Blazor UI Template

A modern Blazor .NET 9 project template inspired by [shadcn/ui dashboard](https://ui.shadcn.com/examples/dashboard), featuring components from [Sysinfocus Simple/UI](https://blazor.art/Tools/Simple-UI).

## Features

- 🎨 Modern dashboard layout with left sidebar and top header
- 📱 Responsive design that works on mobile and desktop
- 🎯 35+ demo pages showcasing different UI components
- ⚡ Built with Blazor .NET 9 and interactive server components
- 🎭 Clean and professional styling using Simple-UI components
- 🧩 Reusable component library with best practices
- 🔄 Service layer with dependency injection pattern
- 📊 Kanban board with drag-and-drop functionality
- 🚀 TailwindCSS v4 for utility-first styling

## Pages Included

### Main Application Pages
- **Dashboard** - Overview with statistics cards and recent activity
- **Analytics** - Performance metrics and data visualization
- **Kanban Board** ✨ - Task management with drag-and-drop columns
- **Orders** - Order management with status badges
- **Products** - Product catalog with pricing cards
- **Customers** - Customer list with avatars
- **Mail** - Email client interface with folders
- **Calendar** - Event calendar with month/week views
- **Documents** - Document viewer and management
- **Settings** - Application settings and preferences

### Example Pages
- **Counter** - Interactive counter example
- **Weather** - Weather forecast demo
- **Login** - Authentication page template
- **Profile** - User profile with cover image
- **And 20+ more...**

See [SOLUTION_ANALYSIS.md](SOLUTION_ANALYSIS.md) for complete list of pages and features.

## Reusable Components ✨

This template includes a library of reusable UI components following best practices:

- **LoadingSpinner** - Consistent loading states with customizable messages
- **EmptyState** - User-friendly display for empty data scenarios
- **ErrorDisplay** - Error handling with retry functionality
- **PageComponentBase** - Base class for common component patterns

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- Node.js (for TailwindCSS)

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
│   │   └── MainLayout.razor         # Main dashboard layout
│   ├── Pages/                       # 35+ page components
│   │   ├── Home.razor              # Dashboard
│   │   ├── Kanban.razor            # Kanban board ✨
│   │   ├── Analytics.razor         # Analytics
│   │   └── ...                     # Many more
│   ├── Shared/                     # Reusable components ✨
│   │   ├── LoadingSpinner.razor
│   │   ├── EmptyState.razor
│   │   ├── ErrorDisplay.razor
│   │   └── PageComponentBase.cs
│   └── ShowCase/                   # Component showcase
├── Models/                         # Data models (13 models)
├── Services/                       # Service layer ✨
│   ├── IKanbanService.cs          # Service interfaces
│   ├── MockKanbanService.cs       # Mock implementations
│   └── ...                        # More services
├── Styles/                        # TailwindCSS source
├── wwwroot/                       # Static assets
└── Program.cs                     # Application entry point
```

## Technology Stack

- **Framework**: Blazor .NET 9 with Interactive Server
- **UI Components**: [Sysinfocus Simple/UI](https://blazor.art/Tools/Simple-UI) v0.0.3.4
  - Card, Button, Input, Icon, Avatar, Badge
  - DataTable, Breadcrumb, Separator
  - Material Symbols icons
- **Styling**: TailwindCSS v4 + Custom CSS
- **Architecture**: Service layer with dependency injection
- **State Management**: Component-level state with base classes

## Best Practices

This template demonstrates modern Blazor development best practices:

- ✅ Service layer pattern with interfaces
- ✅ Dependency injection
- ✅ Reusable component library
- ✅ Consistent error handling and loading states
- ✅ Mock services for development
- ✅ XML documentation
- ✅ Responsive design
- ✅ Type safety

See [BEST_PRACTICES.md](BEST_PRACTICES.md) for detailed best practices guide.

## Documentation

- **[SOLUTION_ANALYSIS.md](SOLUTION_ANALYSIS.md)** - Complete analysis of the solution, missing features, and recommendations
- **[BEST_PRACTICES.md](BEST_PRACTICES.md)** - Comprehensive guide to best practices used in this template

## What's New ✨

### Recently Added
- **Kanban Board** - Full-featured task board with drag-and-drop
- **Reusable Components** - LoadingSpinner, EmptyState, ErrorDisplay
- **Service Layer** - IKanbanService with mock implementation
- **Best Practices Documentation** - Comprehensive guides and patterns
- **PageComponentBase** - Base class for common component patterns

## Future Enhancements

See [SOLUTION_ANALYSIS.md](SOLUTION_ANALYSIS.md) for recommended additions:
- Notifications Center
- Team Management
- File Manager
- Activity Timeline
- And more...

## Contributing

This is an open template. Feel free to use it as a starting point for your projects and extend it based on your needs.

## License

This template is open source and available for use in your projects.
