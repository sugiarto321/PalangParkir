namespace PalangParkir.View
{
    partial class SettingView
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
            this.cmbPortController = new System.Windows.Forms.ComboBox();
            this.cmbBaudRateController = new System.Windows.Forms.ComboBox();
            this.txtIpCamera1 = new System.Windows.Forms.TextBox();
            this.txtIpCamera2 = new System.Windows.Forms.TextBox();
            this.cmbPortPrinter = new System.Windows.Forms.ComboBox();
            this.cmbBaudRatePrinter = new System.Windows.Forms.ComboBox();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.btnSetPrinter = new System.Windows.Forms.Button();
            this.btnSetGate = new System.Windows.Forms.Button();
            this.btnSetController = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bntGateIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPortController
            // 
            this.cmbPortController.FormattingEnabled = true;
            this.cmbPortController.Location = new System.Drawing.Point(664, 34);
            this.cmbPortController.Name = "cmbPortController";
            this.cmbPortController.Size = new System.Drawing.Size(121, 21);
            this.cmbPortController.TabIndex = 1;
            // 
            // cmbBaudRateController
            // 
            this.cmbBaudRateController.FormattingEnabled = true;
            this.cmbBaudRateController.Location = new System.Drawing.Point(664, 73);
            this.cmbBaudRateController.Name = "cmbBaudRateController";
            this.cmbBaudRateController.Size = new System.Drawing.Size(121, 21);
            this.cmbBaudRateController.TabIndex = 2;
            // 
            // txtIpCamera1
            // 
            this.txtIpCamera1.Location = new System.Drawing.Point(121, 35);
            this.txtIpCamera1.Name = "txtIpCamera1";
            this.txtIpCamera1.Size = new System.Drawing.Size(100, 20);
            this.txtIpCamera1.TabIndex = 3;
            // 
            // txtIpCamera2
            // 
            this.txtIpCamera2.Location = new System.Drawing.Point(121, 70);
            this.txtIpCamera2.Name = "txtIpCamera2";
            this.txtIpCamera2.Size = new System.Drawing.Size(100, 20);
            this.txtIpCamera2.TabIndex = 4;
            // 
            // cmbPortPrinter
            // 
            this.cmbPortPrinter.FormattingEnabled = true;
            this.cmbPortPrinter.Location = new System.Drawing.Point(403, 34);
            this.cmbPortPrinter.Name = "cmbPortPrinter";
            this.cmbPortPrinter.Size = new System.Drawing.Size(121, 21);
            this.cmbPortPrinter.TabIndex = 5;
            // 
            // cmbBaudRatePrinter
            // 
            this.cmbBaudRatePrinter.FormattingEnabled = true;
            this.cmbBaudRatePrinter.Location = new System.Drawing.Point(403, 73);
            this.cmbBaudRatePrinter.Name = "cmbBaudRatePrinter";
            this.cmbBaudRatePrinter.Size = new System.Drawing.Size(121, 21);
            this.cmbBaudRatePrinter.TabIndex = 6;
            // 
            // btnPrinter
            // 
            this.btnPrinter.Location = new System.Drawing.Point(373, 108);
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.Size = new System.Drawing.Size(75, 23);
            this.btnPrinter.TabIndex = 7;
            this.btnPrinter.Text = "SetPrinter";
            this.btnPrinter.UseVisualStyleBackColor = true;
            this.btnPrinter.Click += new System.EventHandler(this.btnPrinter_Click);
            // 
            // btnSetPrinter
            // 
            this.btnSetPrinter.Location = new System.Drawing.Point(373, 137);
            this.btnSetPrinter.Name = "btnSetPrinter";
            this.btnSetPrinter.Size = new System.Drawing.Size(75, 23);
            this.btnSetPrinter.TabIndex = 8;
            this.btnSetPrinter.Text = "TesPrint";
            this.btnSetPrinter.UseVisualStyleBackColor = true;
            this.btnSetPrinter.Click += new System.EventHandler(this.btnSetPrinter_Click);
            // 
            // btnSetGate
            // 
            this.btnSetGate.Location = new System.Drawing.Point(664, 137);
            this.btnSetGate.Name = "btnSetGate";
            this.btnSetGate.Size = new System.Drawing.Size(75, 23);
            this.btnSetGate.TabIndex = 9;
            this.btnSetGate.Text = "TestGate";
            this.btnSetGate.UseVisualStyleBackColor = true;
            this.btnSetGate.Click += new System.EventHandler(this.btnSetGate_Click);
            // 
            // btnSetController
            // 
            this.btnSetController.Location = new System.Drawing.Point(642, 108);
            this.btnSetController.Name = "btnSetController";
            this.btnSetController.Size = new System.Drawing.Size(156, 23);
            this.btnSetController.TabIndex = 10;
            this.btnSetController.Text = "Setting Controller";
            this.btnSetController.UseVisualStyleBackColor = true;
            this.btnSetController.Click += new System.EventHandler(this.btnSetController_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "IP Camera 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "IP Camera 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Port Printer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "BaudRate Printer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(585, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Port Controller";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(556, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "BaudRate Controller";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Set Camera 1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(53, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Set Camera 2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // bntGateIn
            // 
            this.bntGateIn.Location = new System.Drawing.Point(53, 221);
            this.bntGateIn.Name = "bntGateIn";
            this.bntGateIn.Size = new System.Drawing.Size(75, 23);
            this.bntGateIn.TabIndex = 19;
            this.bntGateIn.Text = "Gate IN";
            this.bntGateIn.UseVisualStyleBackColor = true;
            this.bntGateIn.Click += new System.EventHandler(this.bntGateIn_Click);
            // 
            // SettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 269);
            this.Controls.Add(this.bntGateIn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetController);
            this.Controls.Add(this.btnSetGate);
            this.Controls.Add(this.btnSetPrinter);
            this.Controls.Add(this.btnPrinter);
            this.Controls.Add(this.cmbBaudRatePrinter);
            this.Controls.Add(this.cmbPortPrinter);
            this.Controls.Add(this.txtIpCamera2);
            this.Controls.Add(this.txtIpCamera1);
            this.Controls.Add(this.cmbBaudRateController);
            this.Controls.Add(this.cmbPortController);
            this.Name = "SettingView";
            this.Text = "SettingView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIpCamera1;
        private System.Windows.Forms.TextBox txtIpCamera2;
        private System.Windows.Forms.Button btnPrinter;
        private System.Windows.Forms.Button btnSetGate;
        private System.Windows.Forms.Button btnSetController;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSetPrinter;
        public System.Windows.Forms.ComboBox cmbPortController;
        public System.Windows.Forms.ComboBox cmbBaudRateController;
        private System.Windows.Forms.Button bntGateIn;
        public System.Windows.Forms.ComboBox cmbPortPrinter;
        public System.Windows.Forms.ComboBox cmbBaudRatePrinter;
    }
}