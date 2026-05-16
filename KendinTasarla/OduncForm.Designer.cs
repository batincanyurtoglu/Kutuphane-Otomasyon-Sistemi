namespace KendinTasarla
{
    partial class OduncForm
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
            grid = new DataGridView();
            panel1 = new Panel();
            btnYenile = new Button();
            btnIadeAl = new Button();
            btnOduncVer = new Button();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Red;
            label1.Dock = DockStyle.Top;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(317, 20);
            label1.TabIndex = 0;
            label1.Text = "⚠ Kırmızı satırlar: teslim tarihi geçmiş kayıtlar";
            // 
            // grid
            // 
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(0, 20);
            grid.Name = "grid";
            grid.RowHeadersWidth = 51;
            grid.Size = new Size(800, 430);
            grid.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnYenile);
            panel1.Controls.Add(btnIadeAl);
            panel1.Controls.Add(btnOduncVer);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 400);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 50);
            panel1.TabIndex = 2;
            // 
            // btnYenile
            // 
            btnYenile.Location = new Point(234, 9);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(94, 29);
            btnYenile.TabIndex = 2;
            btnYenile.Text = "Yenile";
            btnYenile.UseVisualStyleBackColor = true;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnIadeAl
            // 
            btnIadeAl.Location = new Point(123, 9);
            btnIadeAl.Name = "btnIadeAl";
            btnIadeAl.Size = new Size(94, 29);
            btnIadeAl.TabIndex = 1;
            btnIadeAl.Text = "İade Al";
            btnIadeAl.UseVisualStyleBackColor = true;
            btnIadeAl.Click += btnIadeAl_Click;
            // 
            // btnOduncVer
            // 
            btnOduncVer.Location = new Point(12, 9);
            btnOduncVer.Name = "btnOduncVer";
            btnOduncVer.Size = new Size(94, 29);
            btnOduncVer.TabIndex = 0;
            btnOduncVer.Text = "Ödünç Ver";
            btnOduncVer.UseVisualStyleBackColor = true;
            btnOduncVer.Click += btnOduncVer_Click;
            // 
            // OduncForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(grid);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "OduncForm";
            Text = "Ödünç Sistemi";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView grid;
        private Panel panel1;
        private Button btnYenile;
        private Button btnIadeAl;
        private Button btnOduncVer;
    }
}