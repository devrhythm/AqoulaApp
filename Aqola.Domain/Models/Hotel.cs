namespace Aqola.Domain.Models
{
    public class Hotel
    {
        private readonly int _amountOfFloor = 0;
        private readonly int _amountOfRoomPerFloor = 0;

        public List<Floor> Floors { get; private set; } = new List<Floor>();
        public int TotalRoom { get; private set; } = 0;
        public List<Keycard> Keycards { get; private set; } = new List<Keycard>();

        public Hotel()
        {

        }

        public Hotel(int amountOfFloor, int amountOfRoomPerFloor)
        {
            _amountOfFloor = amountOfFloor;
            _amountOfRoomPerFloor = amountOfRoomPerFloor;
        }

        public void Create()
        {
            Floors = new List<Floor>();
            for (int floorNo = 1; floorNo <= _amountOfFloor; floorNo++)
            {
                var floor = new Floor(floorNo, _amountOfRoomPerFloor);
                List<Room> roomsOnFloor = floor.CreateRooms();
                Floors.Add(floor);
            }
            TotalRoom = _amountOfFloor * _amountOfRoomPerFloor;
            Keycards = Keycard.CreateKeycards(TotalRoom);
        }

        public List<Room> GetAllRooms()
        {
            var allRooms = new List<Room>();
            Floors.ForEach(floor =>
            {
                allRooms.AddRange(floor.Rooms);
            });
            return allRooms;
        }

        public Room? GetRoomByKeycard(int keycardNo)
        {
            List<Room> allRooms = GetAllRooms();
            return allRooms
                    .Where(room => room.KeycardNo == keycardNo)
                    .SingleOrDefault();
        }

        public List<Room> GetAvailableRooms()
        {
            List<Room> allRooms = GetAllRooms();
            return allRooms.Where(room => room.IsAvailable).ToList();
        }

        public Room GetRoom(string roomName)
        {
            List<Room> rooms = GetAllRooms();
            return rooms.Single(room => room.RoomName == roomName);
        }

        public Keycard RegisterKeycard(string roomName)
        {
            Keycard keycard = Keycards.OrderBy(keycard => keycard.KeycardNo)
                     .First(keycard => keycard.IsAvailable);
            return keycard.Register(roomName);
        }

        public List<Guest> GetGuestList()
        {
            List<Room> rooms = GetAllRooms();
            return rooms.Where(room => !room.IsAvailable)
                .OrderBy(room => room.CheckInDate)
                .Select(room => room.Guest)
                .ToList();
        }

        public Guest GetGuestInfoByRoom(string searchRoomName)
        {
            List<Guest> allGuest = GetGuestList();
            return allGuest.Single(guest => guest.BookedRoomName == searchRoomName);
        }

        public Room? GetGuestRoom(string guestName)
        {
            List<Room> rooms = GetAllRooms();
            return rooms.SingleOrDefault(room => room.Guest.Name == guestName);
        }

        public Keycard GetKeycard(int keycardNo)
        {
            return Keycards.Single(keycard => keycard.KeycardNo == keycardNo);
        }
    }
}
