using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlSmartHome
{
    public partial class ControlWarmFloor : ControlSmartHome.ControlDevice
    {
        public override string ID
        {
            get => labelID.Text;
            set => labelID.Text = value;
        }

        public ControlWarmFloor()
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
                numericUpDownWidth.Enabled = true;
                numericUpDownHeight.Enabled = true;
            }
            else
            {
                textBoxNameDevice.Enabled = false;
                buttonPower.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDownWidth.Enabled = false;
                numericUpDownHeight.Enabled = false;
            }
        }

        public override void UpdateControl(SmartHome.Device device)
        {
            if (device is SmartHome.WarmFloor)
            {
                SmartHome.WarmFloor d = (SmartHome.WarmFloor)device;

                labelID.Text = d.ID.ToString();

                textBoxNameDevice.Text = d.Name;

                buttonPower.ImageIndex = d.Status ? 1 : 0;
                labelPowerStatus.Text = d.Status ? "Вкл." : "Выкл.";

                labelCurrentTemperature.Text = $"{d.CurrentTemperature:0.0} °C";

                labelDesiredTemperature.Text = $"{d.DesiredTemperature:0.0} °C";
                numericUpDown1.Value = (decimal)d.DesiredTemperature;

                labelCoveragArea.Text = $"{d.CoveragArea.Item1:0.00}" +
                    $" x {d.CoveragArea.Item2:0.00}";
                numericUpDownWidth.Value = (decimal)d.CoveragArea.Item1;
                numericUpDownHeight.Value = (decimal)d.CoveragArea.Item2;

            }
        }

        public override void UpdateDeviceFromControl(SmartHome.Device device)
        {
            if (device is SmartHome.WarmFloor)
            {
                SmartHome.WarmFloor d = (SmartHome.WarmFloor)device;

                d.Rename(textBoxNameDevice.Text);

                if (buttonPower.ImageIndex == 1)
                {
                    d.TurnOn();
                }
                else d.TurnOff();

                d.SetTemperature((double)numericUpDown1.Value);

                d.CoveragArea = ((double)numericUpDownWidth.Value, (double)numericUpDownHeight.Value);
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

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            labelCoveragArea.Text = $"{numericUpDownWidth.Value:0.00}" +
                    $" x {numericUpDownHeight.Value:0.00}";
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            labelCoveragArea.Text = $"{numericUpDownWidth.Value:0.00}" +
                    $" x {numericUpDownHeight.Value:0.00}";
        }
    }
}
