using TheSleepyHollowInnDbClassLibrary;
using TheSleepyHollowInnDtoClassLibrary;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Db>();
var app = builder.Build();

app.MapGet("/calendar/{date?}", (DateOnly? date, Db db) =>
{
    date = date ?? DateOnly.FromDateTime(DateTime.Now);

    var cal = new CalendarDto
    {
        AvailabilityStartDateData = (DateOnly)date,
        RoomList = new List<RoomDto>()
    };

    foreach (var room in db.RoomList)
    {
        cal.RoomList.Add(new RoomDto
            (room, db.AvailabilityStartDateData, (DateOnly)date));
    }

    return cal;
});

app.MapGet("/", () => "Welcome to Sleepy Hollow Inn! Go to /calendar to see room availability.");

app.Run();
