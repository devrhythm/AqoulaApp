namespace Aqola.Domain.Models
{
    public class Floor
    {
        public int FloorNo { get; private set; }
        public int AmountOfRoomPerFloor { get; private set; }

        public List<Room> Rooms { get; set; } = new List<Room>();

        public Floor(int floorNo, int amountRoomOfFloor)
        {
            this.FloorNo = floorNo;
            this.AmountOfRoomPerFloor = amountRoomOfFloor;
        }

        public List<Room> CreateRooms()
        {
            Rooms = new List<Room>();
            for (int roomNo = 1; roomNo <= AmountOfRoomPerFloor; roomNo++)
            {
                Rooms.Add(new Room(roomNo, this));
            }
            return Rooms;
        }

        public bool IsEmptyGuest()
        {
            return Rooms.TrueForAll(room => room.IsAvailable);
        }

        public bool IsAvailable()
        {
            return Rooms.TrueForAll(room => room.IsAvailable);
        }

        public List<Room> GetGuestRooms()
        {
            return Rooms.Where(room => !room.IsAvailable).ToList();
        }
    }
}
