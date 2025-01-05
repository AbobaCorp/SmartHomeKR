namespace FormSmartHome
{
    partial class FormAddDevice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Освещение", "SmartHome.Lighting");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Термостат", "SmartHome.Thermostat");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Теплый пол", "SmartHome.WarmFloor");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Камера", "SmartHome.Camera");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Робот пылесос", "SmartHome.RobotVacuumCleaner");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Умная розетка", "SmartHome.SmartPlug");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Умный пульт", "SmartHome.IRRemoteControl");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Кондиционер", "SmartHome.AirConditioner");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Умная штора", "SmartHome.Curtain");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddDevice));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxDevice = new System.Windows.Forms.GroupBox();
            this.textBoxNameDevice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageListDevices = new System.Windows.Forms.ImageList(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxRoom = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNameRoom = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxDevice.SuspendLayout();
            this.groupBoxRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(180, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ок";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(261, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonOk);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 358);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(339, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkBox1.Location = new System.Drawing.Point(0, 332);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.checkBox1.Size = new System.Drawing.Size(339, 26);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Добавить только комнату";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.groupBoxDevice);
            this.panel1.Controls.Add(this.groupBoxRoom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 332);
            this.panel1.TabIndex = 4;
            // 
            // groupBoxDevice
            // 
            this.groupBoxDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDevice.Controls.Add(this.textBoxNameDevice);
            this.groupBoxDevice.Controls.Add(this.label3);
            this.groupBoxDevice.Controls.Add(this.listView1);
            this.groupBoxDevice.Controls.Add(this.comboBox1);
            this.groupBoxDevice.Controls.Add(this.label2);
            this.groupBoxDevice.Location = new System.Drawing.Point(3, 116);
            this.groupBoxDevice.Name = "groupBoxDevice";
            this.groupBoxDevice.Size = new System.Drawing.Size(333, 212);
            this.groupBoxDevice.TabIndex = 1;
            this.groupBoxDevice.TabStop = false;
            this.groupBoxDevice.Text = "Устройство";
            // 
            // textBoxNameDevice
            // 
            this.textBoxNameDevice.Location = new System.Drawing.Point(147, 62);
            this.textBoxNameDevice.Name = "textBoxNameDevice";
            this.textBoxNameDevice.Size = new System.Drawing.Size(175, 20);
            this.textBoxNameDevice.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Имя нового устройства";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.listView1.LargeImageList = this.imageListDevices;
            this.listView1.Location = new System.Drawing.Point(9, 86);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(313, 120);
            this.listView1.SmallImageList = this.imageListDevices;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // imageListDevices
            // 
            this.imageListDevices.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDevices.ImageStream")));
            this.imageListDevices.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDevices.Images.SetKeyName(0, "SmartHome.Lighting");
            this.imageListDevices.Images.SetKeyName(1, "SmartHome.Thermostat");
            this.imageListDevices.Images.SetKeyName(2, "SmartHome.WarmFloor");
            this.imageListDevices.Images.SetKeyName(3, "SmartHome.Camera");
            this.imageListDevices.Images.SetKeyName(4, "SmartHome.RobotVacuumCleaner");
            this.imageListDevices.Images.SetKeyName(5, "SmartHome.SmartPlug");
            this.imageListDevices.Images.SetKeyName(6, "SmartHome.IRRemoteControl");
            this.imageListDevices.Images.SetKeyName(7, "SmartHome.AirConditioner");
            this.imageListDevices.Images.SetKeyName(8, "SmartHome.Curtain");
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(147, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Выбор комнаты";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxRoom
            // 
            this.groupBoxRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRoom.Controls.Add(this.label1);
            this.groupBoxRoom.Controls.Add(this.textBoxNameRoom);
            this.groupBoxRoom.Enabled = false;
            this.groupBoxRoom.Location = new System.Drawing.Point(3, 10);
            this.groupBoxRoom.Name = "groupBoxRoom";
            this.groupBoxRoom.Size = new System.Drawing.Size(333, 100);
            this.groupBoxRoom.TabIndex = 0;
            this.groupBoxRoom.TabStop = false;
            this.groupBoxRoom.Text = "Комната";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя новой комнаты";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNameRoom
            // 
            this.textBoxNameRoom.Location = new System.Drawing.Point(147, 40);
            this.textBoxNameRoom.Name = "textBoxNameRoom";
            this.textBoxNameRoom.Size = new System.Drawing.Size(175, 20);
            this.textBoxNameRoom.TabIndex = 0;
            // 
            // FormAddDevice
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 388);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormAddDevice";
            this.Text = "Добавить";
            this.Activated += new System.EventHandler(this.FormAddDevice_Activated);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBoxDevice.ResumeLayout(false);
            this.groupBoxDevice.PerformLayout();
            this.groupBoxRoom.ResumeLayout(false);
            this.groupBoxRoom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxRoom;
        private System.Windows.Forms.GroupBox groupBoxDevice;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNameRoom;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageListDevices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNameDevice;
    }
}