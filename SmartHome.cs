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

        //public void RemoveAt(int index)
        //{
        //    _devices.RemoveAt(index);
        //}

        //public void Clear()
        //{
        //    _devices.Clear();
        //}
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