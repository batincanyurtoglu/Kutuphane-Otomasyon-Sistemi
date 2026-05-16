namespace KendinTasarla
{
    partial class KitapEkleForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtISBN = new TextBox();
            txtBaslik = new TextBox();
            txtYazar = new TextBox();
            txtYayinevi = new TextBox();
            txtYil = new TextBox();
            txtKategori = new TextBox();
            txtAdet = new TextBox();
            btnKaydet = new Button();
            btnIptal = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 0;
            label1.Text = "ISBN:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 63);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "Başlık:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 107);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 2;
            label3.Text = "Yazar:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 151);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 3;
            label4.Text = "Yayınevi:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 195);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 4;
            label5.Text = "Yayın Yılı:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 239);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 5;
            label6.Text = "Kategori:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 283);
            label7.Name = "label7";
            label7.Size = new Size(44, 20);
            label7.TabIndex = 6;
            label7.Text = "Adet:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(111, 16);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(194, 27);
            txtISBN.TabIndex = 7;
            // 
            // txtBaslik
            // 
            txtBaslik.Location = new Point(111, 60);
            txtBaslik.Name = "txtBaslik";
            txtBaslik.Size = new Size(194, 27);
            txtBaslik.TabIndex = 8;
            // 
            // txtYazar
            // 
            txtYazar.Location = new Point(111, 104);
            txtYazar.Name = "txtYazar";
            txtYazar.Size = new Size(194, 27);
            txtYazar.TabIndex = 9;
            // 
            // txtYayinevi
            // 
            txtYayinevi.Location = new Point(111, 148);
            txtYayinevi.Name = "txtYayinevi";
            txtYayinevi.Size = new Size(194, 27);
            txtYayinevi.TabIndex = 10;
            // 
            // txtYil
            // 
            txtYil.Location = new Point(111, 192);
            txtYil.Name = "txtYil";
            txtYil.Size = new Size(194, 27);
            txtYil.TabIndex = 11;
            // 
            // txtKategori
            // 
            txtKategori.Location = new Point(111, 236);
            txtKategori.Name = "txtKategori";
            txtKategori.Size = new Size(194, 27);
            txtKategori.TabIndex = 12;
            // 
            // txtAdet
            // 
            txtAdet.Location = new Point(111, 280);
            txtAdet.Name = "txtAdet";
            txtAdet.Size = new Size(194, 27);
            txtAdet.TabIndex = 13;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(111, 331);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(94, 29);
            btnKaydet.TabIndex = 14;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(211, 331);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(94, 29);
            btnIptal.TabIndex = 15;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // KitapEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 372);
            Controls.Add(btnIptal);
            Controls.Add(btnKaydet);
            Controls.Add(txtAdet);
            Controls.Add(txtKategori);
            Controls.Add(txtYil);
            Controls.Add(txtYayinevi);
            Controls.Add(txtYazar);
            Controls.Add(txtBaslik);
            Controls.Add(txtISBN);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            Name = "KitapEkleForm";
            Text = "Yeni Kitap Ekle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtISBN;
        private TextBox txtBaslik;
        private TextBox txtYazar;
        private TextBox txtYayinevi;
        private TextBox txtYil;
        private TextBox txtKategori;
        private TextBox txtAdet;
        private Button btnKaydet;
        private Button btnIptal;
    }
}