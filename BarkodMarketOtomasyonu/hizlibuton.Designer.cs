
namespace BarkodMarketOtomasyonu
{
    partial class hizlibuton
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LbutonId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chTumu = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tUrunAra = new System.Windows.Forms.TextBox();
            this.girdUrunler = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.girdUrunler)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LbutonId);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.chTumu);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.tUrunAra);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.girdUrunler);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // LbutonId
            // 
            this.LbutonId.AutoSize = true;
            this.LbutonId.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LbutonId.Location = new System.Drawing.Point(308, 44);
            this.LbutonId.Name = "LbutonId";
            this.LbutonId.Size = new System.Drawing.Size(93, 18);
            this.LbutonId.TabIndex = 8;
            this.LbutonId.Text = "BUTON NO ";
            this.LbutonId.Click += new System.EventHandler(this.LbutonId_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(118, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "BARKOD NUMARASI ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // chTumu
            // 
            this.chTumu.AutoSize = true;
            this.chTumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chTumu.Location = new System.Drawing.Point(262, 81);
            this.chTumu.Name = "chTumu";
            this.chTumu.Size = new System.Drawing.Size(139, 24);
            this.chTumu.TabIndex = 6;
            this.chTumu.Text = "Tümünü Göster";
            this.chTumu.UseVisualStyleBackColor = true;
            this.chTumu.CheckedChanged += new System.EventHandler(this.chTumu_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(18, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "URUN ARA";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tUrunAra
            // 
            this.tUrunAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tUrunAra.Location = new System.Drawing.Point(12, 72);
            this.tUrunAra.Name = "tUrunAra";
            this.tUrunAra.Size = new System.Drawing.Size(232, 26);
            this.tUrunAra.TabIndex = 4;
            this.tUrunAra.TextChanged += new System.EventHandler(this.tUrunAra_TextChanged);
            // 
            // girdUrunler
            // 
            this.girdUrunler.AllowUserToAddRows = false;
            this.girdUrunler.AllowUserToDeleteRows = false;
            this.girdUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.girdUrunler.BackgroundColor = System.Drawing.Color.Azure;
            this.girdUrunler.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.girdUrunler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.girdUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.girdUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.girdUrunler.EnableHeadersVisualStyles = false;
            this.girdUrunler.Location = new System.Drawing.Point(0, 0);
            this.girdUrunler.Margin = new System.Windows.Forms.Padding(1);
            this.girdUrunler.Name = "girdUrunler";
            this.girdUrunler.ReadOnly = true;
            this.girdUrunler.RowHeadersVisible = false;
            this.girdUrunler.RowHeadersWidth = 45;
            this.girdUrunler.RowTemplate.Height = 32;
            this.girdUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.girdUrunler.Size = new System.Drawing.Size(800, 306);
            this.girdUrunler.TabIndex = 2;
            this.girdUrunler.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.girdUrunler_CellContentDoubleClick);
            // 
            // hizlibuton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "hizlibuton";
            this.Text = "hizlibuton";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.girdUrunler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Label LbutonId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chTumu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tUrunAra;
        private System.Windows.Forms.DataGridView girdUrunler;
    }
}