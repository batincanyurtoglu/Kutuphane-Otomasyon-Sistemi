namespace KendinTasarla
{
    partial class OduncVerForm
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
            label1 = new Label();
            cmbKitap = new ComboBox();
            label2 = new Label();
            cmbUye = new ComboBox();
            label3 = new Label();
            nudGun = new NumericUpDown();
            lblTarih = new Label();
            btnVer = new Button();
            btnIptal = new Button();
            ((System.ComponentModel.ISupportInitialize)nudGun).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 19);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 0;
            label1.Text = "Kitap:";
            // 
            // cmbKitap
            // 
            cmbKitap.FormattingEnabled = true;
            cmbKitap.Location = new Point(111, 16);
            cmbKitap.Name = "cmbKitap";
            cmbKitap.Size = new Size(151, 28);
            cmbKitap.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 62);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 2;
            label2.Text = "Üye:";
            // 
            // cmbUye
            // 
            cmbUye.FormattingEnabled = true;
            cmbUye.Location = new Point(111, 60);
            cmbUye.Name = "cmbUye";
            cmbUye.Size = new Size(151, 28);
            cmbUye.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 105);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 4;
            label3.Text = "Süre (gün):";
            // 
            // nudGun
            // 
            nudGun.Location = new Point(111, 104);
            nudGun.Name = "nudGun";
            nudGun.Size = new Size(150, 27);
            nudGun.TabIndex = 5;
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Location = new Point(14, 148);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(54, 20);
            lblTarih.TabIndex = 6;
            lblTarih.Text = "Teslim:";
            // 
            // btnVer
            // 
            btnVer.Location = new Point(14, 200);
            btnVer.Name = "btnVer";
            btnVer.Size = new Size(94, 29);
            btnVer.TabIndex = 7;
            btnVer.Text = "Ödünç Ver";
            btnVer.UseVisualStyleBackColor = true;
            btnVer.Click += btnVer_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(167, 200);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(94, 29);
            btnIptal.TabIndex = 8;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // OduncVerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 244);
            Controls.Add(btnIptal);
            Controls.Add(btnVer);
            Controls.Add(lblTarih);
            Controls.Add(nudGun);
            Controls.Add(label3);
            Controls.Add(cmbUye);
            Controls.Add(label2);
            Controls.Add(cmbKitap);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            Name = "OduncVerForm";
            Text = "Ödünç Ver";
            ((System.ComponentModel.ISupportInitialize)nudGun).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbKitap;
        private Label label2;
        private ComboBox cmbUye;
        private Label label3;
        private NumericUpDown nudGun;
        private Label lblTarih;
        private Button btnVer;
        private Button btnIptal;
    }
}