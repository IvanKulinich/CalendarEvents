# CalendarEvents
```
Technologies: C#, Asp NET Core, Postgres
Implement a REST API with similar functions:

1) For a certain date, save a list of events 
Request: 
{
  date: "2023-12-12",
  events : [
    {title: "event1"},
    {title: "event1"}
    ...
  ]
}
Response : 201 Created

2) For a certain month and year, get all days of the month with events
Request: 
query param:
year: 2023
month: January
Response : 200 Ok
{
  [
    {
      date: "2023-12-12",
      events : [
         {title: "event1"},
         {title: "event1"}
      ]
    }
  ]
}
```
