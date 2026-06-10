# MultiDraw Socket Client

A real-time multi-user collaborative drawing application built in C# using raw TCP sockets. Multiple clients can connect to a server and share drawing data in real time.

## Tech Stack

- C# / .NET
- TCP Sockets (custom `AbSoc` socket abstraction layer)
- Windows Forms (WinForms)
- Multi-threading

## Features

- Real-time drawing synchronization across connected clients
- Custom socket communication layer (`AbSoc`) for reliable data transmission
- Multi-threaded server/client architecture
- Interactive drawing canvas with live updates

## Project Structure

```
multidraw-socket-client/
└── MDClient_AbSoc/
    ├── AbSoc_AlhashemiM/        # Custom socket abstraction library
    ├── MDClient_AlhashemiM/     # Drawing client application
    ├── ConnectDlg_Solution/     # Connection dialog
    └── MDClient_AbSoc.sln
```

## Getting Started

### Prerequisites

- Visual Studio 2022
- .NET 8 SDK

### Run

1. Open `MDClient_AbSoc/MDClient_AbSoc.sln` in Visual Studio
2. Build the solution
3. Start the server, then launch one or more clients
4. Connect clients to the server address and start drawing
