
namespace MammaNatale
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ListaBambiniStato = new System.Windows.Forms.DataGridView();
            this.StatiDelFusoOrario = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.oraAttuale = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.DettagliStato = new System.Windows.Forms.GroupBox();
            this.UTC = new System.Windows.Forms.Label();
            this.DLatitudine = new System.Windows.Forms.Label();
            this.DCodice = new System.Windows.Forms.Label();
            this.DnomeStato = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ListaBambiniStato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatiDelFusoOrario)).BeginInit();
            this.DettagliStato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ListaBambiniStato
            // 
            this.ListaBambiniStato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaBambiniStato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaBambiniStato.Location = new System.Drawing.Point(677, 411);
            this.ListaBambiniStato.Margin = new System.Windows.Forms.Padding(2);
            this.ListaBambiniStato.Name = "ListaBambiniStato";
            this.ListaBambiniStato.RowHeadersVisible = false;
            this.ListaBambiniStato.RowHeadersWidth = 51;
            this.ListaBambiniStato.RowTemplate.Height = 24;
            this.ListaBambiniStato.RowTemplate.ReadOnly = true;
            this.ListaBambiniStato.Size = new System.Drawing.Size(516, 200);
            this.ListaBambiniStato.TabIndex = 0;
            // 
            // StatiDelFusoOrario
            // 
            this.StatiDelFusoOrario.AllowUserToAddRows = false;
            this.StatiDelFusoOrario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatiDelFusoOrario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.StatiDelFusoOrario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StatiDelFusoOrario.Location = new System.Drawing.Point(929, 32);
            this.StatiDelFusoOrario.Margin = new System.Windows.Forms.Padding(2);
            this.StatiDelFusoOrario.Name = "StatiDelFusoOrario";
            this.StatiDelFusoOrario.ReadOnly = true;
            this.StatiDelFusoOrario.RowHeadersVisible = false;
            this.StatiDelFusoOrario.RowHeadersWidth = 51;
            this.StatiDelFusoOrario.RowTemplate.Height = 24;
            this.StatiDelFusoOrario.RowTemplate.ReadOnly = true;
            this.StatiDelFusoOrario.Size = new System.Drawing.Size(264, 225);
            this.StatiDelFusoOrario.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // oraAttuale
            // 
            this.oraAttuale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.oraAttuale.AutoSize = true;
            this.oraAttuale.BackColor = System.Drawing.Color.Transparent;
            this.oraAttuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oraAttuale.Location = new System.Drawing.Point(583, 230);
            this.oraAttuale.Margin = new System.Windows.Forms.Padding(0);
            this.oraAttuale.Name = "oraAttuale";
            this.oraAttuale.Size = new System.Drawing.Size(103, 37);
            this.oraAttuale.TabIndex = 4;
            this.oraAttuale.Text = "00:00";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::MammaNatale.Properties.Resources.play_button;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(583, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 58);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DettagliStato
            // 
            this.DettagliStato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DettagliStato.BackColor = System.Drawing.Color.Transparent;
            this.DettagliStato.Controls.Add(this.UTC);
            this.DettagliStato.Controls.Add(this.DLatitudine);
            this.DettagliStato.Controls.Add(this.DCodice);
            this.DettagliStato.Controls.Add(this.DnomeStato);
            this.DettagliStato.Location = new System.Drawing.Point(12, 411);
            this.DettagliStato.Name = "DettagliStato";
            this.DettagliStato.Size = new System.Drawing.Size(390, 144);
            this.DettagliStato.TabIndex = 6;
            this.DettagliStato.TabStop = false;
            this.DettagliStato.Text = "DETTAGLI STATO";
            // 
            // UTC
            // 
            this.UTC.AutoSize = true;
            this.UTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UTC.Location = new System.Drawing.Point(14, 100);
            this.UTC.Name = "UTC";
            this.UTC.Size = new System.Drawing.Size(157, 24);
            this.UTC.TabIndex = 3;
            this.UTC.Text = "FUSO ORARIO:";
            // 
            // DLatitudine
            // 
            this.DLatitudine.AutoSize = true;
            this.DLatitudine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DLatitudine.Location = new System.Drawing.Point(14, 76);
            this.DLatitudine.Name = "DLatitudine";
            this.DLatitudine.Size = new System.Drawing.Size(134, 24);
            this.DLatitudine.TabIndex = 2;
            this.DLatitudine.Text = "LATITUDINE:";
            // 
            // DCodice
            // 
            this.DCodice.AutoSize = true;
            this.DCodice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DCodice.Location = new System.Drawing.Point(14, 52);
            this.DCodice.Name = "DCodice";
            this.DCodice.Size = new System.Drawing.Size(93, 24);
            this.DCodice.TabIndex = 1;
            this.DCodice.Text = "CODICE:";
            // 
            // DnomeStato
            // 
            this.DnomeStato.AutoSize = true;
            this.DnomeStato.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DnomeStato.Location = new System.Drawing.Point(14, 28);
            this.DnomeStato.Name = "DnomeStato";
            this.DnomeStato.Size = new System.Drawing.Size(91, 24);
            this.DnomeStato.TabIndex = 0;
            this.DnomeStato.Text = "STATO: ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(925, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "ORDINE DEI PAESI";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(673, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "LISTA DEI BAMBINI DEL SINGOLO STATO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(12, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(549, 344);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "CHRISTMAS NAVIGATOR";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(573, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "ORA LOCALE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MammaNatale.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(1204, 613);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DettagliStato);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.oraAttuale);
            this.Controls.Add(this.StatiDelFusoOrario);
            this.Controls.Add(this.ListaBambiniStato);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1220, 652);
            this.Name = "Form1";
            this.Text = "Babbo Natale";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListaBambiniStato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatiDelFusoOrario)).EndInit();
            this.DettagliStato.ResumeLayout(false);
            this.DettagliStato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ListaBambiniStato;
        private System.Windows.Forms.DataGridView StatiDelFusoOrario;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label oraAttuale;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox DettagliStato;
        private System.Windows.Forms.Label DLatitudine;
        private System.Windows.Forms.Label DCodice;
        private System.Windows.Forms.Label DnomeStato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UTC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

