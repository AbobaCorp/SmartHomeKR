using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlSmartHome
{
    public partial class ControlDevice : UserControl
    {
        public virtual string ID { get; set; }

        public ControlDevice()
        {
            InitializeComponent();

        }

        public virtual void Edit(bool isEdit) { }

        public virtual void UpdateControl(SmartHome.Device device) { }

        public virtual void UpdateDeviceFromControl(SmartHome.Device device) { }
    }
}
