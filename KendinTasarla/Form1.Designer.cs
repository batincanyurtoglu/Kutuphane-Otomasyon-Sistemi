namespace KendinTasarla
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnKitap = new Button();
            btnUye = new Button();
            btnOdunc = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(43, 19);
            label1.Name = "label1";
            label1.Size = new Size(217, 31);
            label1.TabIndex = 0;
            label1.Text = "Kütüphane Sistemi";
            // 
            // btnKitap
            // 
            btnKitap.Location = new Point(59, 94);
            btnKitap.Name = "btnKitap";
            btnKitap.Size = new Size(184, 47);
            btnKitap.TabIndex = 1;
            btnKitap.Text = "Kitapları Listele";
            btnKitap.UseVisualStyleBackColor = true;
            btnKitap.Click += btnKitap_Click;
            // 
            // btnUye
            // 
            btnUye.Location = new Point(59, 185);
            btnUye.Name = "btnUye";
            btnUye.Size = new Size(184, 47);
            btnUye.TabIndex = 2;
            btnUye.Text = "Üye Listesi";
            btnUye.UseVisualStyleBackColor = true;
            btnUye.Click += btnUye_Click;
            // 
            // btnOdunc
            // 
            btnOdunc.Location = new Point(59, 276);
            btnOdunc.Name = "btnOdunc";
            btnOdunc.Size = new Size(184, 47);
            btnOdunc.TabIndex = 3;
            btnOdunc.Text = "Ödünç Sistemi";
            btnOdunc.UseVisualStyleBackColor = true;
            btnOdunc.Click += btnOdunc_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 353);
            Controls.Add(btnOdunc);
            Controls.Add(btnUye);
            Controls.Add(btnKitap);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Kütüphane Yönetim Sistemi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnKitap;
        private Button btnUye;
        private Button btnOdunc;
    }
}
