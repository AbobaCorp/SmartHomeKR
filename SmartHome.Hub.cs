using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using SmartHome;

namespace SmartHome
{
    [Serializable]
    public class Hub
    {
        public int MaxDeviceIdIter { get; private set; }

        private TemperatureSensor _temperature;
        private PressureSensor _pressure;
        private HumiditySensor _humidity;
        private List<Room> _rooms;

        public string Name { get; private set; }
        public TemperatureSensor Temperature { get => _temperature; }
        public PressureSensor Pressure { get => _pressure; }
        public HumiditySensor Humidity { get => _humidity; }
        public SecuritySystem SecuritySystem { get; private set; }
        private DateTime _time;
        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
                _time = _time.AddMinutes(-(_time.Minute % 10));
            }
        }
        public int CountRoom { get => _rooms.Count; }
        public IEnumerable<Room> Rooms { get => _rooms; }

        public Hub(string name)
        {
            _temperature = new TemperatureSensor();
            _pressure = new PressureSensor();
            _humidity = new HumiditySensor();

            _rooms = new List<Room>();

            SecuritySystem = new SecuritySystem();
            _time = DateTime.Now;
            _time = _time.AddMinutes(-(_time.Minute % 10));
            Name = name;
        }

        //переименовать Hub
        public void Rename(string newName)
        {
            Name = newName;
        }

        //обновление метеоданных
        public void UpdateWeatherData()
        {
            _temperature.Update();
            _pressure.Update();
            _humidity.Update();
        }

        //обновление времени
        public void UpdateTime()
        {
            _time = _time.AddMinutes(5);
        }

        //обновление всех устройств
        public void UpdateAllDevices()
        {
            foreach (var i in Rooms)
            {
                foreach (var j in i.Devices)
                {
                    j.Update();
                    //DeviceChanged?.Invoke(i, j);
                }
            }
        }

        //оновление MaxDeviceIdIter
        public void UpdateMaxDeviceIdIter()
        {
            MaxDeviceIdIter = 0;
            foreach (var i in Rooms)
            {
                foreach (var j in i.Devices)
                {
                    if (MaxDeviceIdIter < j.ID.ID)
                    {
                        MaxDeviceIdIter = j.ID.ID;
                    }
                }
            }
        }

        //добавление комнаты
        public bool AddRoom(string nameRoom)
        {
            foreach (var item in _rooms)
            {
                if (item.Name == nameRoom)
                {
                    return false;
                }
            }

            Room newRoom = new Room(nameRoom);
            _rooms.Add(newRoom);
            RoomAdded?.Invoke(newRoom);
            return true;
        }

        //удаление комнаты
        public bool RemoveRoom(string nameRoom)
        {
            for (int i = 0; i < _rooms.Count; i++)
            {
                if (_rooms[i].Name == nameRoom)
                {
                    RoomRemoved?.Invoke(_rooms[i]);
                    _rooms.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public bool RemoveRoomAt(int index)
        {
            if (index >= 0 && index < _rooms.Count)
            {
                RoomRemoved?.Invoke(_rooms[index]);
                _rooms.RemoveAt(index);
                return true;
            }

            return false;
        }

        //добавление устройства в заданную комнату
        public bool AddDevice(string nameRoom, Device device)
        {
            foreach (var room in _rooms)
            {
                if (room.Name == nameRoom)
                {
                    room.Add(device);
                    DeviceAdded?.Invoke(room, device);
                    return true;
                }
            }

            return false;
        }

        //удаление устройства
        public bool RemoveDevice(string nameRoom, DeviceId id)
        {
            foreach (var i in _rooms)
            {
                if (i.Name == nameRoom)
                {
                    foreach (var j in i.Devices)
                    {
                        if (j.ID == id)
                        {
                            DeviceRemoved?.Invoke(i, j);
                            i.Remove(j);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool RemoveDevice(DeviceId id)
        {
            foreach (var i in _rooms)
            {
                foreach (var j in i.Devices)
                {
                    if (j.ID == id)
                    {
                        DeviceRemoved?.Invoke(i, j);
                        i.Remove(j);
                        return true;
                    }
                }
            }
            return false;
        }

        //получить комнату по имени
        public Room GetRoom(string nameRoom)
        {
            for (int i = 0; i < _rooms.Count; i++)
            {
                if (_rooms[i].Name == nameRoom)
                {
                    return _rooms[i];
                }
            }

            return null;
        }

        //получить комнату по адресу
        public Room GetRoomAt(int index)
        {
            if (index >= 0 && index < _rooms.Count)
            {
                return _rooms[index];
            }
            return null;
        }

        //Получить устройство по ID
        public Device GetDevice(DeviceId deviceId, bool isChange = false)
        {
            foreach (var room in _rooms)
            {
                foreach (var device in room.Devices)
                {
                    if (device.ID == deviceId)
                    {
                        if (isChange)
                        {
                            DeviceChanged?.Invoke(room, device);
                        }
                        return device;
                    }
                }
            }
            return null;
        }

        public Device GetDeviceAt(string nameRoom, int index, bool isChange = false)
        {
            for (int i = 0; i < _rooms.Count; i++)
            {
                if (_rooms[i].Name == nameRoom)
                {
                    Device device = _rooms[i].GetDevice(index);
                    if (isChange)
                    {
                        DeviceChanged?.Invoke(_rooms[i], device);
                    }
                    return device;
                }
            }

            return null;
        }

        //сохранение данных в файл
        public static void SaveHubToFile(Hub hub, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                formatter.Serialize(stream, hub);
            }
        }

        //загрузка данных из файла
        public static Hub LoadObjectFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return null;

            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream stream = File.OpenRead(filePath))
            {
                return (Hub)formatter.Deserialize(stream);
            }
        }

        //события
        public delegate void DeviceHandler(Room room, Device device);
        public event DeviceHandler DeviceAdded;
        public event DeviceHandler DeviceRemoved;
        public event DeviceHandler DeviceChanged;

        public delegate void RoomHandler(Room room);
        public event RoomHandler RoomAdded;
        public event RoomHandler RoomRemoved;
    }
}