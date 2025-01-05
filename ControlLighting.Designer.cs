namespace ControlSmartHome
{
    partial class ControlLighting
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlLighting));
            this.imageListPowerStatus = new System.Windows.Forms.ImageList(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.labelColor = new System.Windows.Forms.Label();
            this.buttonColor = new System.Windows.Forms.Button();
            this.buttonPower = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNameDevice = new System.Windows.Forms.TextBox();
            this.labelPowerStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.labelBrightness = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListPowerStatus
            // 
            this.imageListPowerStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPowerStatus.ImageStream")));
            this.imageListPowerStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPowerStatus.Images.SetKeyName(0, "PowerOff.png");
            this.imageListPowerStatus.Images.SetKeyName(1, "PowerOn.png");
            // 
            // labelColor
            // 
            this.labelColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColor.AutoSize = true;
            this.labelColor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelColor.Location = new System.Drawing.Point(87, 186);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(85, 17);
            this.labelColor.TabIndex = 12;
            this.labelColor.Text = "255, 255, 255";
            // 
            // buttonColor
            // 
            this.buttonColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonColor.BackColor = System.Drawing.Color.Bisque;
            this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor.Location = new System.Drawing.Point(180, 179);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(30, 30);
            this.buttonColor.TabIndex = 7;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonPower
            // 
            this.buttonPower.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonPower.AutoSize = true;
            this.buttonPower.FlatAppearance.BorderSize = 0;
            this.buttonPower.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonPower.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPower.ImageIndex = 0;
            this.buttonPower.ImageList = this.imageListPowerStatus;
            this.buttonPower.Location = new System.Drawing.Point(180, 89);
            this.buttonPower.Name = "buttonPower";
            this.buttonPower.Size = new System.Drawing.Size(55, 36);
            this.buttonPower.TabIndex = 11;
            this.buttonPower.UseVisualStyleBackColor = true;
            this.buttonPower.Click += new System.EventHandler(this.buttonPower_Click);
            // 
            // labelID
            // 
            this.labelID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelID.Location = new System.Drawing.Point(87, 13);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(28, 17);
            this.labelID.TabIndex = 8;
            this.labelID.Text = "----";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Яркость";
            // 
            // textBoxNameDevice
            // 
            this.textBoxNameDevice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxNameDevice, 2);
            this.textBoxNameDevice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameDevice.Location = new System.Drawing.Point(87, 52);
            this.textBoxNameDevice.Name = "textBoxNameDevice";
            this.textBoxNameDevice.Size = new System.Drawing.Size(209, 25);
            this.textBoxNameDevice.TabIndex = 3;
            // 
            // labelPowerStatus
            // 
            this.labelPowerStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPowerStatus.AutoSize = true;
            this.labelPowerStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPowerStatus.Location = new System.Drawing.Point(87, 99);
            this.labelPowerStatus.Name = "labelPowerStatus";
            this.labelPowerStatus.Size = new System.Drawing.Size(40, 17);
            this.labelPowerStatus.TabIndex = 9;
            this.labelPowerStatus.Text = "Выкл.";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Цвет";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Состояние";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя";
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.BackColor = System.Drawing.SystemColors.Control;
            this.trackBarBrightness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarBrightness.LargeChange = 1;
            this.trackBarBrightness.Location = new System.Drawing.Point(180, 132);
            this.trackBarBrightness.Maximum = 100;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(117, 37);
            this.trackBarBrightness.SmallChange = 5;
            this.trackBarBrightness.TabIndex = 5;
            this.trackBarBrightness.TickFrequency = 5;
            this.trackBarBrightness.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarBrightness.Scroll += new System.EventHandler(this.trackBarBrightness_Scroll);
            // 
            // labelBrightness
            // 
            this.labelBrightness.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBrightness.AutoSize = true;
            this.labelBrightness.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBrightness.Location = new System.Drawing.Point(87, 142);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(26, 17);
            this.labelBrightness.TabIndex = 10;
            this.labelBrightness.Text = "0%";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.51381F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.48619F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelBrightness, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBarBrightness, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelPowerStatus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNameDevice, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonPower, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonColor, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelColor, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(36, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 217);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // ControlLighting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ControlLighting";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ImageList imageListPowerStatus;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonPower;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNameDevice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelBrightness;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPowerStatus;
    }
}
