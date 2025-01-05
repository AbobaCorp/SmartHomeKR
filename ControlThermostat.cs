using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlSmartHome
{
    public partial class ControlThermostat : ControlSmartHome.ControlDevice
    {
        public override string ID
        {
            get => labelID.Text;
            set => labelID.Text = value;
        }

        public ControlThermostat()
        {
            InitializeComponent();
        }

        public override void Edit(bool isEdit)
        {
            if (isEdit)
            {
                textBoxNameDevice.Enabled = true;
                buttonPower.Enabled = true;
                numericUpDown1.Enabled = true;
            }
            else
            {
                textBoxNameDevice.Enabled = false;
                buttonPower.Enabled = false;
                numericUpDown1.Enabled = false;
            }
        }

        public override void UpdateControl(SmartHome.Device device)
        {
            if (device is SmartHome.Thermostat)
            {
                SmartHome.Thermostat d = (SmartHome.Thermostat)device;

                labelID.Text = d.ID.ToString();

                textBoxNameDevice.Text = d.Name;

                buttonPower.ImageIndex = d.Status ? 1 : 0;
                labelPowerStatus.Text = d.Status ? "Вкл." : "Выкл.";

                labelCurrentTemperature.Text = $"{d.CurrentTemperature:0.0} °C";

                labelDesiredTemperature.Text = $"{d.DesiredTemperature:0.0} °C";
                numericUpDown1.Value = (decimal)d.DesiredTemperature;
            }
        }

        public override void UpdateDeviceFromControl(SmartHome.Device device)
        {
            if (device is SmartHome.Thermostat)
            {
                SmartHome.Thermostat d = (SmartHome.Thermostat)device;

                d.Rename(textBoxNameDevice.Text);

                if (buttonPower.ImageIndex == 1)
                {
                    d.TurnOn();
                }
                else d.TurnOff();

                d.SetTemperature((double)numericUpDown1.Value);
            }
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            buttonPower.ImageIndex = buttonPower.ImageIndex == 1 ? 0 : 1;
            labelPowerStatus.Text = buttonPower.ImageIndex == 1 ? "Вкл." : "Выкл.";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            labelDesiredTemperature.Text = $"{numericUpDown1.Value:0.0} °C";
        }
    }
}
