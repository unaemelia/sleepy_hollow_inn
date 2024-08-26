using TheSleepyHollowInnDbClassLibrary;

namespace TheSleepyHollowInnDtoClassLibrary
{
    public class RoomDto
    {
        public string? Name { get; set; }
        public string? Availability { get; set; }
        public RoomDto() {}
        public RoomDto(Room room, DateOnly availabilityStartDate, DateOnly getFromDate)
        {
            if (String.IsNullOrEmpty(room.Availability))
                throw new ArgumentNullException(nameof(room.Availability));

            int startIndex =
                (int)(getFromDate.DayNumber - availabilityStartDate.DayNumber);
            if (startIndex > 365 - 30) startIndex = 365 - 30;
            if (startIndex < 0) startIndex = 0;
            this.Name = room.Name;
            this.Availability = room.Availability.Substring(startIndex, 30);
        }
    }
}
