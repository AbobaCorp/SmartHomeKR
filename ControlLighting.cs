using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlSmartHome
{
    public partial class ControlLighting : ControlSmartHome.ControlDevice
    {
        public override string ID
        {
            get => labelID.Text;
            set => labelID.Text = value;
        }
        //public string NameDevice
        //{
        //    get => textBoxNameDevice.Text;
        //    set => textBoxNameDevice.Text = value;
        //}
        //public bool PowerStatus
        //{
        //    get => buttonPower.ImageIndex == 1 ? true : false;
        //    set => buttonPower.ImageIndex = value ? 1 : 0;
        //}
        //public int Brightness
        //{
        //    get => trackBarBrightness.Value;
        //    set
        //    {
        //        trackBarBrightness.Value = value;
        //        labelBrightness.Text = $"{trackBarBrightness.Value}%";
        //    }
        //}
        //public Color GlowColor
        //{
        //    get => buttonColor.BackColor;
        //    set
        //    {
        //        buttonColor.BackColor = value;
        //        labelColor.Text = value.IsKnownColor ?
        //            value.Name : $"{value.R}, {value.G}, {value.B}";
        //    }
        //}

        public ControlLighting()
        {
            InitializeComponent();
            Edit(false);
        }

        public override void Edit(bool isEdit)
        {
            if (isEdit)
            {
                textBoxNameDevice.Enabled = true;
                buttonPower.Enabled = true;
                trackBarBrightness.Enabled = true;
                buttonColor.Enabled = true;
            }
            else
            {
                textBoxNameDevice.Enabled = false;
                buttonPower.Enabled = false;
                trackBarBrightness.Enabled = false;
                buttonColor.Enabled = false;
            }
        }

        public override void UpdateControl(SmartHome.Device device)
        {
            if (device is SmartHome.Lighting)
            {
                SmartHome.Lighting d = (SmartHome.Lighting)device;

                labelID.Text = d.ID.ToString();

                textBoxNameDevice.Text = d.Name;

                buttonPower.ImageIndex = d.Status ? 1 : 0;
                labelPowerStatus.Text = d.Status ? "Вкл." : "Выкл.";

                trackBarBrightness.Value = d.Brightness;
                labelBrightness.Text = $"{d.Brightness}%";

                buttonColor.BackColor = d.Color;
                labelColor.Text = d.Color.IsKnownColor ?
                    d.Color.Name : $"{d.Color.R}, {d.Color.G}, {d.Color.B}";
            }
        }

        public override void UpdateDeviceFromControl(SmartHome.Device device)
        {
            if (device is SmartHome.Lighting)
            {
                SmartHome.Lighting d = (SmartHome.Lighting)device;

                d.Rename(textBoxNameDevice.Text);

                if(buttonPower.ImageIndex == 1)
                {
                    d.TurnOn();
                }
                else d.TurnOff();

                d.SetBrightness(trackBarBrightness.Value);

                d.SetColor(buttonColor.BackColor);
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                //GlowColor = colorDialog1.Color;
                Color color = colorDialog1.Color;

                buttonColor.BackColor = color;
                labelColor.Text = color.IsKnownColor ?
                    color.Name : $"{color.R}, {color.G}, {color.B}";
            }
        }

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            labelBrightness.Text = $"{trackBarBrightness.Value}%";
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            buttonPower.ImageIndex = buttonPower.ImageIndex == 1 ? 0 : 1;
            labelPowerStatus.Text = buttonPower.ImageIndex == 1 ? "Вкл." : "Выкл.";
        }
    }
}
