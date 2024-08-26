# Sleepy Hollow Inn Room Availability API

This project is a simple web API for checking room availability at the Sleepy Hollow Inn. It is built with C# and .NET, providing endpoints to fetch the room availability data.

## Features

- **Room Availability Calendar**: Check the availability of rooms for a given date.
- **JSON Output**: The API returns room availability in JSON format, making it easy to integrate with other applications.

## Project Structure

### `program.cs`
The entry point for the API:
- Sets up the web server and defines routes.
- Includes a default route (`/`) that returns a welcome message.
- Provides a `/calendar/{date?}` route to check room availability.

### `RoomDto.cs`
Defines the `RoomDto` class, which represents the room availability for a specific date range:
- **Properties**:
  - `Name`: Name of the room.
  - `Availability`: A string showing the availability of the room for the next 30 days from the specified date.
- **Constructor**:
  - Takes a `Room` object, a start date, and a date from which availability is requested.
  - Calculates a substring of 30 days availability starting from the requested date.

### `CalendarDto.cs`
Defines the `CalendarDto` class, which represents the list of available rooms and the start date of the availability period:
- **Properties**:
  - `RoomList`: List of `RoomDto` objects representing available rooms.
  - `AvailabilityStartDateData`: The start date from which the availability is calculated.

### `Room.cs`
Defines the `Room` class, representing a room and its full-year availability:
- **Properties**:
  - `Name`: Name of the room.
  - `Availability`: A string representing a full year of availability (365 days).

### `Db.cs`
Simulates a database holding room availability data:
- **Properties**:
  - `RoomList`: A list of `Room` objects.
  - `AvailabilityStartDateData`: The date from which the availability data starts.
- **Constructor**:
  - Initializes the `RoomList` with some predefined rooms and their availability data.

## API Endpoints

### `GET /calendar/{date?}`
- **Description**: Returns room availability starting from the specified date. If no date is provided, it defaults to the current date.
- **Response**: A `CalendarDto` object in JSON format containing:
  - `AvailabilityStartDateData`: The date from which availability is calculated.
  - `RoomList`: A list of rooms with their 30-day availability.

### `GET /`
- **Description**: Returns a welcome message.
- **Response**: `"Welcome to Sleepy Hollow Inn! Go to /calendar to see room availability."`

## How to Run

1. Clone the repository.
2. Open the project in your preferred IDE (e.g., Visual Studio).
3. Build the project to restore dependencies.
4. Run the project. The API will be available at `http://localhost:{port}`.
5. Use an API client like Postman or a web browser to access the endpoints.

## Example Response

```bash
GET /calendar/2024-09-01

## Example response
{
  "availabilityStartDateData": "2024-09-01",
  "roomList": [
    {
      "name": "Room 1 - Double",
      "availability": "110011111111111111111111111111"
    },
    {
      "name": "Room 2 - Double",
      "availability": "111111111111111111111111111111"
    },
    {
      "name": "Room 3 - Executive",
      "availability": "111111111111111111111111111111"
    },
    {
      "name": "Room 4 - Single",
      "availability": "111111111111111111111111111111"
    }
  ]
}
