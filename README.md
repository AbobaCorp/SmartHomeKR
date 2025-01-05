<img src=/img/smart-home.png width=128>

# SmartHomeKR
Исходный код приложения "Умный дом" для курсовой работы

## Исходный код
* Листинг 1 – файл SmartHome.cs
```cs
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SmartHome
{
    //комната с устройствами
    [Serializable]
    public class Room
    {
        private List<SmartHome.Device> _devices;

        public int CountDevice { get => _devices.Count; }
        public string Name { get; protected set; }
        public IEnumerable<Device> Devices { get => _devices; }

        public Room(string name)
        {
            Name = name;
            _devices = new List<SmartHome.Device>();
        }

        public void RenameRoom(string newName)
        {
            Name = newName;
        }

        public Device GetDevice(int index)
        {
            return _devices.ElementAt(index);
        }

        public void Add(SmartHome.Device device)
        {
            _devices.Add(device);
        }

        public bool Remove(SmartHome.Device device)
        {
            return _devices.Remove(device);
        }

        public bool Remove(SmartHome.DeviceId id)
        {
            foreach (SmartHome.Device device in _devices)
            {
                if (device.ID == id)
                {
                    Remove(device);
                    return true;
                }
            }
            return false;
        }
    }

    //id устройства
    [Serializable]
    public class DeviceId
    {
        private static int iter = 0;
        private int _id;

        public int ID { get => _id; }

        public DeviceId()
        {
            _id = iter;
            iter++;
        }

        private DeviceId(int id)
        {
            _id = id;
        }

        public static void IteratorRecovery(int iter)
        {
            DeviceId.iter = iter;
        }

        public static implicit operator DeviceId(string id)
        {
            return new DeviceId(Convert.ToInt32(id));
        }
        public static bool operator ==(DeviceId a, DeviceId b)
        {
            return a._id == b._id;
        }
        public static bool operator !=(DeviceId a, DeviceId b)
        {
            return a._id != b._id;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DeviceId))
            {
                return false;
            }

            return this == (DeviceId)obj;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"{_id:0000}";
        }
    }

    //устройство
    [Serializable]
    public abstract class Device
    {
        protected DeviceId _id;
        public string Name { get; protected set; }
        public bool Status { get; protected set; }
        public DeviceId ID { get => _id; }

        public Device()
        {
            _id = new DeviceId();
        }

        public virtual void TurnOn()
        {
            Status = true;
        }

        public virtual void TurnOff()
        {
            Status = false;
        }

        public void Rename(string newName)
        {
            Name = newName;
        }

        public virtual void Update() { }
    }

    //освещение
    [Serializable]
    public class Lighting : Device
    {
        public int Brightness { get; private set; }
        public Color Color { get; private set; }

        public Lighting(string name, int brightness, Color color) : base()
        {
            base.Name = name;
            Brightness = brightness;
            Color = color;

        }

        public void SetBrightness(int value)
        {
            Brightness = value;
        }
        public void SetColor(Color value)
        {
            Color = value;
        }
    }

    //термостат
    [Serializable]
    public class Thermostat : Device
    {
        private TemperatureSensor _curTemp;
        //текущая температупа
        public double CurrentTemperature { get => _curTemp.Temperature; }
        //желаемая температупа
        public double DesiredTemperature { get; protected set; }

        public Thermostat(string name, double DesiredTemperature) : base()
        {
            base.Name = name;
            this.DesiredTemperature = DesiredTemperature;
            _curTemp = new TemperatureSensor();
        }

        public virtual void SetTemperature(double value)
        {
            DesiredTemperature = value;
        }

        public override void Update()
        {
            _curTemp.Update();
        }
    }

    //теплый пол 
    [Serializable]
    public class WarmFloor : Thermostat
    {
        //площадь покрытия
        public (double, double) CoveragArea { get; set; }

        public WarmFloor(string name, double DesiredTemperature, (double, double) CoveragArea) : base(name, DesiredTemperature)
        {
            this.CoveragArea = CoveragArea;
        }
    }

    //камера
    [Serializable]
    public class Camera : Device
    {
        public (int, int) Resolution { get; private set; }
        public bool IsRecording { get; private set; }

        public Camera(string name, (int, int) resolution) : base()
        {
            base.Name = name;
            Resolution = resolution;
            IsRecording = false;
        }

        public void StartRecording()
        {
            IsRecording = true;
        }

        public void StopRecording()
        {
            IsRecording = false;
        }
    }

    //умный пылесос
    [Serializable]
    public class RobotVacuumCleaner : Device
    {
        private static Random random = new Random();
        public enum Tasks { cleans_up, charging, waiting }

        //заряд батареи %
        public int BatteryCharge { get; private set; }
        //ход работы %
        public int ProgressWork { get; private set; }
        //текущее задание
        public Tasks CurrentTask { get; private set; }

        public RobotVacuumCleaner(string name) : base()
        {
            base.Name = name;
            BatteryCharge = 100;
            ProgressWork = 0;
            CurrentTask = Tasks.waiting;
        }
        public override void Update()
        {
            BatteryCharge = random.Next(0, 4) == 0 ? random.Next(0, 16) : random.Next(0, 100);
            ProgressWork = random.Next(0, 4) == 0 ? 100 : random.Next(0, 100);

            if (ProgressWork == 100)
            {
                CurrentTask = Tasks.waiting;
            }
            else if (BatteryCharge <= 15)
            {
                CurrentTask = Tasks.charging;
            }
            else
            {
                CurrentTask = Tasks.cleans_up;
            }
        }
        public void SendCleanUp()
        {
            CurrentTask = Tasks.cleans_up;
        }
        public void SendCharging()
        {
            CurrentTask = Tasks.charging;
        }
        public void SendToBase()
        {
            CurrentTask = Tasks.waiting;
        }
    }

    //система безопасности
    [Serializable]
    public class SecuritySystem
    {
        public bool IsArmed { get; private set; }

        public SecuritySystem() => IsArmed = false;

        public void Arm()
        {
            IsArmed = true;
        }

        public void Disarm()
        {
            IsArmed = false;
        }
    }

    //датчик
    [Serializable]
    public abstract class Sensor
    {
        protected double value;
        protected static Random random = new Random();
        public abstract void Update();
    }

    //датчик температуры
    [Serializable]
    public class TemperatureSensor : Sensor
    {
        public double Temperature
        {
            get
            {
                return base.value;
            }
            private set
            {
                base.value = value;
            }
        }

        public TemperatureSensor()
        {
            Update();
        }

        public override void Update()
        {
            Temperature = Sensor.random.NextDouble() * 25 + 15;
        }

        public override string ToString()
        {
            return $"{Temperature:0.0} °C";
        }
    }

    //датчик давления
    [Serializable]
    public class PressureSensor : Sensor
    {
        public double Pressure
        {
            get
            {
                return base.value;
            }
            private set
            {
                base.value = value;
            }
        }

        public PressureSensor()
        {
            Update();
        }

        public override void Update()
        {
            Pressure = Sensor.random.Next(720, 780);
        }

        public override string ToString()
        {
            return $"{Pressure} мм рт. ст.";
        }
    }

    //датчик влажности
    [Serializable]
    public class HumiditySensor : Sensor
    {
        public double Humidity
        {
            get
            {
                return base.value;
            }
            private set
            {
                base.value = value;
            }
        }

        public HumiditySensor()
        {
            Update();
        }

        public override void Update()
        {
            Humidity = Sensor.random.Next(0, 101);
        }

        public override string ToString()
        {
            return $"{Humidity} %";
        }
    }

    //умная розетка
    [Serializable]
    public class SmartPlug : Device
    {
        //имя подключенного устройства
        public string NameConnectedDevice { get; private set; }

        public SmartPlug(string name, string nameConnectedDevice) : base()
        {
            base.Name = name;
            this.NameConnectedDevice = nameConnectedDevice;
        }
    }

    //ик-пульт
    [Serializable]
    public class IRRemoteControl : Device
    {
        private List<(DeviceId, string, bool)> _devices;

        public IEnumerable<(DeviceId, string, bool)> Devices { get => _devices; }

        public IRRemoteControl(string name) : base()
        {
            base.Name = name;
            base.Status = true;
            _devices = new List<(DeviceId, string, bool)>();
        }

        //добавить устройство
        public void Add(string nameDevice)
        {
            _devices.Add((new DeviceId(), nameDevice, false));
        }

        //удалить устройство по ID
        public bool Remove(DeviceId deviceId)
        {
            foreach (var device in _devices)
            {
                if (device.Item1 == deviceId)
                {
                    _devices.Remove(device);
                    return true;
                }
            }
            return false;
        }

        public void TurnOnDevice(DeviceId deviceId)
        {
            for (int i = 0; i < _devices.Count; i++)
            {
                if (_devices[i].Item1 == deviceId)
                {
                    _devices[i] = (_devices[i].Item1, _devices[i].Item2, true);
                }
            }
        }

        public void TurnOffDevice(DeviceId deviceId)
        {
            for (int i = 0; i < _devices.Count; i++)
            {
                if (_devices[i].Item1 == deviceId)
                {
                    _devices[i] = (_devices[i].Item1, _devices[i].Item2, false);
                }
            }
        }
    }

    //кондиционер
    [Serializable]
    public class AirConditioner : Thermostat
    {
        public AirConditioner(string name, double DesiredTemperature) : base(name, DesiredTemperature)
        {
        }
    }

    //штора
    [Serializable]
    public class Curtain : Device
    {
        public int Openness { get; private set; }

        public Curtain(string name) : base()
        {
            base.Name = name;
            base.Status = true;
            Openness = 0;
        }

        public bool Open(int percent)
        {
            if (percent > 0 && percent <= 100)
            {
                Openness = percent;
                return true;
            }
            return false;
        }

        public override void TurnOn()
        {
            Openness = 100;
        }
        public override void TurnOff()
        {
            Openness = 0;
        }
    }
}
```

* Листинг 2 – файл SmartHome.Hub.cs
```cs
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
```
## Примеры работы приложения
![](/examples/2.1.png)
![](/examples/2.2.png)
![](/examples/2.3.png)
![](/examples/2.4.png)
![](/examples/2.5.png)
![](/examples/2.6.png)
