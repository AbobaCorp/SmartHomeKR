using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormSmartHome
{
    public partial class FormAddDevice : Form
    {
        private SmartHome.Hub hub;

        public FormAddDevice(SmartHome.Hub Hub)
        {
            InitializeComponent();

            this.hub = Hub;

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (textBoxNameRoom.Text == "")
                {
                    MessageBox.Show("Имя добовляемой комнаты не может быть пустой строчкой!", "SmartHome",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (hub.AddRoom(textBoxNameRoom.Text) == false)
                {
                    MessageBox.Show("Комната с таким именем уже существует!", "SmartHome",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (textBoxNameDevice.Text == "")
                {
                    MessageBox.Show("Имя добовляемого устройства не может быть пустой строчкой!", "SmartHome",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (listView1.SelectedIndices.Count > 0)
                {
                    string typeDevice = listView1.SelectedItems[0].ImageKey;
                    switch (typeDevice)
                    {
                        case "SmartHome.Lighting":
                            hub.AddDevice(comboBox1.SelectedItem.ToString(),
                                new SmartHome.Lighting(textBoxNameDevice.Text, 100, Color.White));
                            break;
                        case "SmartHome.Thermostat":
                            hub.AddDevice(comboBox1.SelectedItem.ToString(),
                                new SmartHome.Thermostat(textBoxNameDevice.Text, 26));
                            break;
                        case "SmartHome.WarmFloor":
                            hub.AddDevice(comboBox1.SelectedItem.ToString(),
                                new SmartHome.WarmFloor(textBoxNameDevice.Text, 26, (5, 5)));
                            break;
                        case "SmartHome.Camera":
                            hub.AddDevice(comboBox1.SelectedItem.ToString(),
                                new SmartHome.Camera(textBoxNameDevice.Text, (640, 480)));
                            break;
                        case "SmartHome.RobotVacuumCleaner":
                            hub.AddDevice(comboBox1.SelectedItem.ToString(),
                                new SmartHome.RobotVacuumCleaner(textBoxNameDevice.Text));
                            break;
                        case "SmartHome.SmartPlug":
                            hub.AddDevice(comboBox1.SelectedItem.ToString(),
                                new SmartHome.SmartPlug(textBoxNameDevice.Text, "unknown"));
                            break;
                        case "SmartHome.IRRemoteControl":
                            hub.AddDevice(comboBox1.SelectedItem.ToString(),
                                new SmartHome.IRRemoteControl(textBoxNameDevice.Text));
                            break;
                        case "SmartHome.AirConditioner":
                            hub.AddDevice(comboBox1.SelectedItem.ToString(),
                                new SmartHome.AirConditioner(textBoxNameDevice.Text, 16));
                            break;
                        case "SmartHome.Curtain":
                            hub.AddDevice(comboBox1.SelectedItem.ToString(),
                                new SmartHome.Curtain(textBoxNameDevice.Text));
                            break;
                        default:
                            return;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите тип добавляемого устройства!", "SmartHome",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxRoom.Enabled = checkBox1.Checked;
            groupBoxDevice.Enabled = !checkBox1.Checked;
        }

        private void FormAddDevice_Activated(object sender, EventArgs e)
        {
            textBoxNameRoom.Text = $"Комната{hub.CountRoom}";

            if (hub.CountRoom == 0)
            {
                groupBoxRoom.Enabled = true;
                groupBoxDevice.Enabled = false;
                checkBox1.Enabled = false;
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1_CheckedChanged(null, null);
                checkBox1.Enabled = true;
            }

            comboBox1.Items.Clear();
            foreach (var i in hub.Rooms)
            {
                comboBox1.Items.Add(i.Name);
            }
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                textBoxNameDevice.Text = listView1.SelectedItems[0].Text;
            }
        }
    }
}
