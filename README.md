# CalendarWebApp
This application serves as a company employee management tool, as workers can log their free days, home office days etc.

## Basic data
- Language: Hungarian and English
- Framework: Blazor & .NET
- Type: Web Server

## Main functionalities
### Calendar
- Users have their own Scheduler type data grid, implemented via a Radzen Scheduler.
- They can add Appointments, which has a type, a date (day) and a description.
- Appointments are stored with the users User ID.
- Users can drag&drop their Appointments.
- Users can edit their Appointments.

#### Free Days
- Users have caluclated free days for each year depending on their age.
- They can only schedule free day type Appointments if they have enough remaining.

### Groups
- The company has Organisations and Groups within Organisations.
- There are hiearchical Groups (for ex. Web Development Group) and logical groups (for ex. Calendar Project Group).
- Users can be assigned to Groups then others can sort them by Groups and view their monthly schedule in a timetable.
- The application has a complex Group editing logic.

### Users
- Users have roles assigned to them, which can be God, Group_Leader and Employee.