using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SmartHome;
using ControlSmartHome;

namespace FormSmartHome
{
    public partial class FormHub : Form
    {
        private Hub hub;
        private Thread threadUpdate;
        private bool flagDeleteDevice;
        private FormAddDevice addDeviceDialog;

        public FormHub()
        {
            InitializeComponent();

            flagDeleteDevice = false;

            //hub = new Hub("SmartHomeHub");
            hub = Hub.LoadObjectFromFile("SmartHomeDataBase.bin");
            if (hub == null)
            {
                hub = new Hub("SmartHomeHub");
                MessageBox.Show("База данных устройств не найдена!", "SmartHome",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                hub.UpdateMaxDeviceIdIter();
                DeviceId.IteratorRecovery(hub.MaxDeviceIdIter + 1);
                hub.Time = DateTime.Now;
            }

            labelHubName.Text = hub.Name;

            labelSecuritySystem.Text = hub.SecuritySystem.IsArmed ? "Вкл." : "Выкл.";
            labelSecuritySystem.ForeColor = hub.SecuritySystem.IsArmed ? Color.Green : Color.OrangeRed;
            buttonSecuritySystem.ImageIndex = hub.SecuritySystem.IsArmed ? 1 : 0;

            hub.DeviceAdded += tabControl1_AddDevice;
            hub.RoomAdded += tabControl1_AddRoom;
            hub.DeviceRemoved += tabControl1_RemoveDevice;
            hub.RoomRemoved += tabControl1_RemoveRoom;
            hub.DeviceChanged += tabControl1_DeviceChanged;
            hub.DeviceChanged += panelDeviceProperties_DeviceChanged;

            foreach (var i in hub.Rooms)
            {
                tabControl1_AddRoom(i);
                foreach (var j in i.Devices)
                {
                    tabControl1_AddDevice(i, j);
                }
            }
            //hub.AddRoom("Кухня");
            //hub.AddDevice("Кухня", new SmartHome.Lighting("ЛампаЗал", 100, Color.OldLace));
            //hub.AddDevice("Кухня", new SmartHome.Thermostat("Термостат", 27));
            //hub.AddDevice("Кухня", new SmartHome.SmartPlug("Розетка1", "Вентилятор"));
            //hub.AddDevice("Кухня", new SmartHome.IRRemoteControl("Пульт"));
            //hub.AddDevice("Кухня", new SmartHome.Curtain("Лев. Штора"));
            //hub.AddDevice("Кухня", new SmartHome.Curtain("Прав. Штора"));

            //hub.AddRoom("Коридор");
            //hub.AddDevice("Коридор", new SmartHome.Lighting("Лампа3", 100, Color.White));
            //hub.AddDevice("Коридор", new SmartHome.Lighting("Люстра4", 100, Color.White));
            //hub.AddDevice("Коридор", new SmartHome.Lighting("Лампа5", 100, Color.White));
            //hub.AddDevice("Коридор", new SmartHome.Camera("Камера", (100, 100)));

            //hub.AddRoom("Зал");
            //hub.AddDevice("Зал", new SmartHome.RobotVacuumCleaner("Доби"));
            //hub.AddDevice("Зал", new SmartHome.AirConditioner("Ветродуйка", 18));

            //hub.AddRoom("Балкон");
            //hub.AddDevice("Балкон", new SmartHome.Lighting("Лампа1", 100, Color.White));
            //hub.AddDevice("Балкон", new SmartHome.Lighting("Лампа2", 100, Color.White));
            //hub.AddDevice("Балкон", new SmartHome.WarmFloor("Теплый Пол", 23, (50.0, 100.0)));

            threadUpdate = new Thread(DataHubUpdate);
            threadUpdate.Start();

            addDeviceDialog = new FormAddDevice(hub);

            panelDeviceProperties.Controls.Add(new ControlSmartHome.ControlLighting()
            {
                Name = "SmartHome.Lighting",
                Dock = DockStyle.Fill,
                Visible = false
            });
            panelDeviceProperties.Controls.Add(new ControlSmartHome.ControlThermostat()
            {
                Name = "SmartHome.Thermostat",
                Dock = DockStyle.Fill,
                Visible = false
            });
            panelDeviceProperties.Controls.Add(new ControlSmartHome.ControlWarmFloor()
            {
                Name = "SmartHome.WarmFloor",
                Dock = DockStyle.Fill,
                Visible = false
            });
        }

        private void tabControl1_AddDevice(Room room, Device device)
        {
            foreach (TabPage i in tabControl1.TabPages)
            {
                if (i.Name == room.Name)
                {
                    Button button = new Button()
                    {
                        Name = device.ID.ToString(),
                        FlatStyle = FlatStyle.Flat,
                        Text = $"{device.Name}\n{(device.Status ? "Вкл." : "Выкл.")}",
                        TextAlign = ContentAlignment.BottomLeft,
                        BackColor = device.Status ? Color.LightCyan : Color.Transparent,
                        Size = new Size(100, 100),
                        Font = new Font("Segoe UI Semibold", 9.75F),
                        ImageList = imageListDevices,
                        ImageKey = device.GetType().ToString(),
                        ImageAlign = ContentAlignment.TopLeft
                    };
                    button.Click += buttonDevice_Click;
                    i.Controls[1].Controls.Add(button);

                    //Button buttonPower = new Button()
                    //{
                    //    Name = device.ID.ToString(),
                    //    BackColor = Color.Transparent,
                    //    Size = new Size(imageListPowerStatus.ImageSize.Width + 10,
                    //                    imageListPowerStatus.ImageSize.Height),
                    //    FlatStyle = FlatStyle.Flat,
                    //    ImageList = imageListPowerStatus,
                    //    ImageIndex = device.Status ? 1 : 0
                    //};
                    //if (device is SmartHome.Curtain ||
                    //    device is SmartHome.RobotVacuumCleaner ||
                    //    device is SmartHome.IRRemoteControl ||
                    //    device is SmartHome.Camera)
                    //{
                    //    buttonPower.Enabled = false;
                    //}
                    //buttonPower.Location = new Point(button.Size.Width - buttonPower.Size.Width, 0);
                    //buttonPower.FlatAppearance.BorderSize = 0;
                    //buttonPower.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    //buttonPower.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    //buttonPower.Click += buttonDevicePower_Click;
                    //button.Controls.Add(buttonPower);



                    button = new Button()
                    {
                        Name = device.ID.ToString(),
                        FlatStyle = FlatStyle.Flat,
                        Text = $"{device.Name}\n{(device.Status ? "Вкл." : "Выкл.")}",
                        TextAlign = ContentAlignment.BottomLeft,
                        BackColor = device.Status ? Color.LightCyan : Color.Transparent,
                        Size = new Size(100, 100),
                        Font = new Font("Segoe UI Semibold", 9.75F),
                        ImageList = imageListDevices,
                        ImageKey = device.GetType().ToString(),
                        ImageAlign = ContentAlignment.TopLeft
                    };
                    //button.FlatAppearance.MouseOverBackColor = Color.Azure;
                    //button.FlatAppearance.MouseDownBackColor = Color.LightCyan;
                    button.Click += buttonDevice_Click;
                    tabControl1.TabPages[0].Controls[1].Controls.Add(button);

                    //buttonPower = new Button()
                    //{
                    //    Name = device.ID.ToString(),
                    //    BackColor = Color.Transparent,
                    //    Size = new Size(imageListPowerStatus.ImageSize.Width + 10,
                    //                    imageListPowerStatus.ImageSize.Height),
                    //    FlatStyle = FlatStyle.Flat,
                    //    ImageList = imageListPowerStatus,
                    //    ImageIndex = device.Status ? 1 : 0
                    //};
                    //if (device is SmartHome.Curtain ||
                    //    device is SmartHome.RobotVacuumCleaner ||
                    //    device is SmartHome.IRRemoteControl ||
                    //    device is SmartHome.Camera)
                    //{
                    //    buttonPower.Enabled = false;
                    //}
                    //buttonPower.Location = new Point(button.Size.Width - buttonPower.Size.Width, 0);
                    //buttonPower.FlatAppearance.BorderSize = 0;
                    //buttonPower.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    //buttonPower.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    //buttonPower.Click += buttonDevicePower_Click;
                    //button.Controls.Add(buttonPower);

                    if (i.Controls[1].Controls.Count != 0)
                    {
                        i.Controls[0].Visible = false;
                        tabControl1.TabPages[0].Controls[0].Visible = false;
                    }

                    return;
                }
            }
        }

        private void tabControl1_AddRoom(Room room)
        {
            tabControl1.TabPages.Add(room.Name, room.Name);
            int indexPage = tabControl1.TabPages.IndexOfKey(room.Name);
            tabControl1.TabPages[indexPage].Padding = new Padding(3, 3, 3, 3);

            tabControl1.TabPages[indexPage].Controls.Add(new Label()
            {
                Text = "Здесь пока ничего нет",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false
            });

            tabControl1.TabPages[indexPage].Controls.Add(new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            });
        }

        private void tabControl1_RemoveDevice(Room room, Device device)
        {
            foreach (TabPage i in tabControl1.TabPages)
            {
                if (i.Name == room.Name)
                {
                    i.Controls[1].Controls.RemoveByKey(device.ID.ToString());
                    tabControl1.TabPages[0].Controls[1].Controls.RemoveByKey(device.ID.ToString());

                    if (i.Controls[1].Controls.Count == 0)
                    {
                        i.Controls[0].Visible = true;
                    }
                    if (tabControl1.TabPages[0].Controls[1].Controls.Count == 0)
                    {
                        tabControl1.TabPages[0].Controls[0].Visible = true;
                    }

                    return;
                }
            }
        }

        private void tabControl1_RemoveRoom(Room room)
        {
            foreach (var i in hub.GetRoom(room.Name).Devices)
            {
                tabControl1.TabPages[0].Controls[1].Controls.RemoveByKey(i.ID.ToString());
            }

            tabControl1.TabPages.RemoveByKey(room.Name);

            if (tabControl1.TabPages[0].Controls[1].Controls.Count == 0)
            {
                tabControl1.TabPages[0].Controls[0].Visible = true;
            }
        }

        private void tabControl1_DeviceChanged(Room room, Device device)
        {
            foreach (TabPage i in tabControl1.TabPages)
            {
                foreach (Button j in i.Controls[1].Controls)
                {
                    if (j.Name == device.ID)
                    {
                        j.Text = $"{device.Name}\n" +
                            $"{(device.Status ? "Вкл." : "Выкл.")}";
                        j.BackColor = device.Status ? Color.LightCyan : Color.Transparent;
                        //(j.Controls[0] as Button).ImageIndex = device.Status ? 1 : 0;
                    }
                }
            }
        }

        private void panelDeviceProperties_DeviceChanged(Room room, Device device)
        {
            foreach (ControlSmartHome.ControlDevice i in panelDeviceProperties.Controls)
            {
                if (i.Visible)
                {
                    //if (device is Lighting)
                    //{
                    //    Lighting deviceLighting = (Lighting)device;

                    //    ControlLighting controlLighting = i as ControlLighting;
                    //    controlLighting.UpdateDeviceFromControl(device);
                    //    //controlLighting.ID = deviceLighting.ID.ToString();
                    //    //controlLighting.NameDevice = deviceLighting.Name;
                    //    //controlLighting.PowerStatus = deviceLighting.Status;
                    //    //controlLighting.Brightness = deviceLighting.Brightness;
                    //    //controlLighting.GlowColor = deviceLighting.Color;
                    //}

                    if (i.Name == device.GetType().ToString())
                    {
                        if (buttonEdit.Visible)
                        {
                            i.UpdateControl(device);
                        }
                    }
                    return;
                }
            }
        }

        private void DataHubUpdate()
        {
            while (true)
            {
                Thread.Sleep(2500);

                tableLayoutPanel1.BeginInvoke((MethodInvoker)(() =>
                {
                    labelTemperature.Text = hub.Temperature.ToString();
                    labelPressure.Text = hub.Pressure.ToString();
                    labelHumidity.Text = hub.Humidity.ToString();

                    labelDateTime.Text = $"{hub.Time.ToShortTimeString()}\n{hub.Time.ToShortDateString()}";

                    foreach (ControlSmartHome.ControlDevice i in panelDeviceProperties.Controls)
                    {
                        if (i.Visible)
                        {
                            hub.GetDevice(i.ID, true);

                            return;
                        }
                    }
                }));

                hub.UpdateWeatherData();
                hub.UpdateTime();
                hub.UpdateAllDevices();
            }
        }

        private void FormHub_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadUpdate.Abort();
            hub.DeviceAdded -= tabControl1_AddDevice;
            hub.RoomAdded -= tabControl1_AddRoom;
            hub.DeviceRemoved -= tabControl1_RemoveDevice;
            hub.RoomRemoved -= tabControl1_RemoveRoom;
            hub.DeviceChanged -= tabControl1_DeviceChanged;
            hub.DeviceChanged -= panelDeviceProperties_DeviceChanged;
            Hub.SaveHubToFile(hub, "SmartHomeDataBase.bin");
        }

        private void buttonRenameHub_Click(object sender, EventArgs e)
        {

            string res = Microsoft.VisualBasic.Interaction.InputBox("Введите текст:", "Переименовать", "Контроллер");
            if (res != "")
            {
                hub.Rename(res);
                labelHubName.Text = hub.Name;
            }
        }

        private void buttonSecuritySystem_Click(object sender, EventArgs e)
        {
            if (hub.SecuritySystem.IsArmed)
            {
                hub.SecuritySystem.Disarm();
                buttonSecuritySystem.ImageIndex = 0;
            }
            else
            {
                hub.SecuritySystem.Arm();
                buttonSecuritySystem.ImageIndex = 1;
            }

            labelSecuritySystem.Text = hub.SecuritySystem.IsArmed ? "Вкл." : "Выкл.";
            labelSecuritySystem.ForeColor = hub.SecuritySystem.IsArmed ? Color.Green : Color.OrangeRed;
        }

        private void buttonDevice_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (flagDeleteDevice)
                {
                    hub.RemoveDevice(button.Name);
                    return;
                }

                Device device = hub.GetDevice(button.Name);
                if (device != null)
                {
                    //groupBoxDeviceProperties.Controls[0].Text =
                    //    $"ID: {device.ID}\n" +
                    //    $"Name: {device.Name}\n" +
                    //    $"Status: {device.Status}\n" +
                    //    $"Type Device: {device.GetType()}";

                    flowLayoutPanel2.Visible = false;
                    buttonApply.Visible = false;
                    buttonCancel.Visible = false;
                    buttonEdit.Visible = true;
                    label2.Visible = true;
                    foreach (ControlSmartHome.ControlDevice i in panelDeviceProperties.Controls)
                    {
                        if (i.Name == device.GetType().ToString())
                        {
                            i.Visible = true;
                            i.Edit(false);

                            flowLayoutPanel2.Visible = true;
                            label2.Visible = false;
                        }
                        else
                        {
                            i.Visible = false;
                        }
                    }
                    panelDeviceProperties_DeviceChanged(null, device);
                }
            }
        }

        private void buttonDevicePower_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Device device = hub.GetDevice(button.Name);
            if (button.ImageIndex == 1)
            {
                device.TurnOff();
            }
            else
            {
                device.TurnOn();
            }

            hub.GetDevice(button.Name, true);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Visible = false;
            label2.Visible = true;
            foreach (Control i in panelDeviceProperties.Controls)
            {
                i.Visible = false;
            }

            flagDeleteDevice = !flagDeleteDevice;

            buttonDelete.BackColor = flagDeleteDevice ? Color.FromArgb(255, 219, 216) : Color.Transparent;

            foreach (TabPage i in tabControl1.TabPages)
            {
                foreach (Button j in i.Controls[1].Controls)
                {
                    if (flagDeleteDevice)
                    {
                        j.BackColor = Color.FromArgb(255, 219, 216);
                    }
                    else hub.GetDevice(j.Name, true);
                    //j.BackColor = flagDeleteDevice ? Color.FromArgb(255, 219, 216) : Color.Transparent;
                }
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            string name = toolStripComboBox1.SelectedItem.ToString();

            DialogResult result = MessageBox.Show($"Удалить комнату \"{name}\"?", "SmartHome",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                hub.RemoveRoom(name);
            }

            flowLayoutPanel2.Visible = false;
            label2.Visible = true;
        }

        private void contextMenuStripDelete_Opening(object sender, CancelEventArgs e)
        {
            if (flagDeleteDevice) buttonDelete_Click(sender, e);

            if (hub.CountRoom > 0)
            {
                toolStripMenuItem2.Enabled = true;
                toolStripComboBox1.Items.Clear();

                foreach (var i in hub.Rooms)
                {
                    toolStripComboBox1.Items.Add(i.Name);
                }
                toolStripComboBox1.SelectedIndex = 0;
            }
            else
            {
                toolStripMenuItem2.Enabled = false;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addDeviceDialog.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            foreach (ControlSmartHome.ControlDevice i in panelDeviceProperties.Controls)
            {
                if (i.Visible)
                {
                    i.Edit(true);
                }
            }
            buttonEdit.Visible = false;
            buttonApply.Visible = true;
            buttonCancel.Visible = true;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            foreach (ControlSmartHome.ControlDevice i in panelDeviceProperties.Controls)
            {
                if (i.Visible)
                {
                    i.Edit(false);
                    buttonEdit.Visible = true;
                    buttonApply.Visible = false;
                    buttonCancel.Visible = false;
                    i.UpdateDeviceFromControl(hub.GetDevice(i.ID));
                    hub.GetDevice(i.ID, true);
                    return;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

            foreach (ControlSmartHome.ControlDevice i in panelDeviceProperties.Controls)
            {
                if (i.Visible)
                {
                    i.Edit(false);
                    buttonEdit.Visible = true;
                    buttonApply.Visible = false;
                    buttonCancel.Visible = false;
                    hub.GetDevice(i.ID, true);

                    return;
                }
            }
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            new ControlSmartHome.AboutBox().ShowDialog();
        }
    }
}
