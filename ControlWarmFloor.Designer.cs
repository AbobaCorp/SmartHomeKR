namespace ControlSmartHome
{
    partial class ControlWarmFloor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlWarmFloor));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPowerStatus = new System.Windows.Forms.Label();
            this.textBoxNameDevice = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.buttonPower = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCurrentTemperature = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelDesiredTemperature = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.labelCoveragArea = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.imageListPowerStatus = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.23729F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.76271F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPowerStatus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNameDevice, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonPower, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelCurrentTemperature, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelDesiredTemperature, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelCoveragArea, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(36, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(306, 206);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Состояние";
            // 
            // labelPowerStatus
            // 
            this.labelPowerStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPowerStatus.AutoSize = true;
            this.labelPowerStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPowerStatus.Location = new System.Drawing.Point(99, 54);
            this.labelPowerStatus.Name = "labelPowerStatus";
            this.labelPowerStatus.Size = new System.Drawing.Size(40, 17);
            this.labelPowerStatus.TabIndex = 9;
            this.labelPowerStatus.Text = "Выкл.";
            // 
            // textBoxNameDevice
            // 
            this.textBoxNameDevice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxNameDevice, 2);
            this.textBoxNameDevice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameDevice.Location = new System.Drawing.Point(99, 20);
            this.textBoxNameDevice.Name = "textBoxNameDevice";
            this.textBoxNameDevice.Size = new System.Drawing.Size(204, 25);
            this.textBoxNameDevice.TabIndex = 3;
            // 
            // labelID
            // 
            this.labelID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelID.Location = new System.Drawing.Point(99, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(28, 17);
            this.labelID.TabIndex = 8;
            this.labelID.Text = "----";
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
            this.buttonPower.Location = new System.Drawing.Point(180, 51);
            this.buttonPower.Name = "buttonPower";
            this.buttonPower.Size = new System.Drawing.Size(55, 23);
            this.buttonPower.TabIndex = 11;
            this.buttonPower.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 34);
            this.label4.TabIndex = 12;
            this.label4.Text = "Тек. температура";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCurrentTemperature
            // 
            this.labelCurrentTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCurrentTemperature.AutoSize = true;
            this.labelCurrentTemperature.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCurrentTemperature.Location = new System.Drawing.Point(99, 85);
            this.labelCurrentTemperature.Name = "labelCurrentTemperature";
            this.labelCurrentTemperature.Size = new System.Drawing.Size(26, 17);
            this.labelCurrentTemperature.TabIndex = 13;
            this.labelCurrentTemperature.Text = "--,-";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 34);
            this.label5.TabIndex = 14;
            this.label5.Text = "Заданная температура";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDesiredTemperature
            // 
            this.labelDesiredTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDesiredTemperature.AutoSize = true;
            this.labelDesiredTemperature.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDesiredTemperature.Location = new System.Drawing.Point(99, 119);
            this.labelDesiredTemperature.Name = "labelDesiredTemperature";
            this.labelDesiredTemperature.Size = new System.Drawing.Size(26, 17);
            this.labelDesiredTemperature.TabIndex = 15;
            this.labelDesiredTemperature.Text = "--,-";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Location = new System.Drawing.Point(180, 118);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown1.TabIndex = 16;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 34);
            this.label6.TabIndex = 17;
            this.label6.Text = "Площадь покрытия";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCoveragArea
            // 
            this.labelCoveragArea.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCoveragArea.AutoSize = true;
            this.labelCoveragArea.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCoveragArea.Location = new System.Drawing.Point(99, 167);
            this.labelCoveragArea.Name = "labelCoveragArea";
            this.labelCoveragArea.Size = new System.Drawing.Size(34, 17);
            this.labelCoveragArea.TabIndex = 18;
            this.labelCoveragArea.Text = "--x--";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.numericUpDownHeight);
            this.panel1.Controls.Add(this.numericUpDownWidth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(180, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 55);
            this.panel1.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(81, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "X";
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownHeight.DecimalPlaces = 2;
            this.numericUpDownHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownHeight.Location = new System.Drawing.Point(0, 28);
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownHeight.TabIndex = 21;
            this.numericUpDownHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.numericUpDownHeight_ValueChanged);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownWidth.DecimalPlaces = 2;
            this.numericUpDownWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownWidth.Location = new System.Drawing.Point(0, 2);
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownWidth.TabIndex = 20;
            this.numericUpDownWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // imageListPowerStatus
            // 
            this.imageListPowerStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPowerStatus.ImageStream")));
            this.imageListPowerStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPowerStatus.Images.SetKeyName(0, "PowerOff.png");
            this.imageListPowerStatus.Images.SetKeyName(1, "PowerOn.png");
            // 
            // ControlWarmFloor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ControlWarmFloor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPowerStatus;
        private System.Windows.Forms.TextBox textBoxNameDevice;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Button buttonPower;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCurrentTemperature;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelDesiredTemperature;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelCoveragArea;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.ImageList imageListPowerStatus;
    }
}
