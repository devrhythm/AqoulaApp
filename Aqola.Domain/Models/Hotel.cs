namespace Aqola.Domain.Models
{
    public class Hotel
    {
        private readonly int _amountOfFloor = 0;
        private readonly int _amountOfRoomPerFloor = 0;

        public List<Floor> Floors { get; private set; } = new List<Floor>();
        public int TotalRoom { get; private set; } = 0;

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
    }
}
