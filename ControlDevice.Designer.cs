namespace ControlSmartHome
{
    partial class ControlDevice
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDevice));
            this.imageListPowerStatus = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageListPowerStatus
            // 
            this.imageListPowerStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPowerStatus.ImageStream")));
            this.imageListPowerStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPowerStatus.Images.SetKeyName(0, "PowerOff.png");
            this.imageListPowerStatus.Images.SetKeyName(1, "PowerOn.png");
            // 
            // ControlDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ControlDevice";
            this.Size = new System.Drawing.Size(375, 278);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageListPowerStatus;
    }
}
