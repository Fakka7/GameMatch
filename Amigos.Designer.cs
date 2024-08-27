
namespace GameMatch
{
    partial class Amigos
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.amigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consejosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnfav = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Peru;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.amigosToolStripMenuItem,
            this.consejosToolStripMenuItem,
            this.debateToolStripMenuItem,
            this.MiCuentaToolStripMenuItem,
            this.favoritosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // amigosToolStripMenuItem
            // 
            this.amigosToolStripMenuItem.Enabled = false;
            this.amigosToolStripMenuItem.Name = "amigosToolStripMenuItem";
            this.amigosToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.amigosToolStripMenuItem.Text = "Amigos";
            this.amigosToolStripMenuItem.Click += new System.EventHandler(this.amigosToolStripMenuItem_Click);
            // 
            // consejosToolStripMenuItem
            // 
            this.consejosToolStripMenuItem.Enabled = false;
            this.consejosToolStripMenuItem.Name = "consejosToolStripMenuItem";
            this.consejosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.consejosToolStripMenuItem.Text = "Consejos";
            this.consejosToolStripMenuItem.Click += new System.EventHandler(this.consejosToolStripMenuItem_Click);
            // 
            // debateToolStripMenuItem
            // 
            this.debateToolStripMenuItem.Enabled = false;
            this.debateToolStripMenuItem.Name = "debateToolStripMenuItem";
            this.debateToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.debateToolStripMenuItem.Text = "Debate";
            this.debateToolStripMenuItem.Click += new System.EventHandler(this.debateToolStripMenuItem_Click);
            // 
            // MiCuentaToolStripMenuItem
            // 
            this.MiCuentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verPerfilToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.MiCuentaToolStripMenuItem.Enabled = false;
            this.MiCuentaToolStripMenuItem.Name = "MiCuentaToolStripMenuItem";
            this.MiCuentaToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.MiCuentaToolStripMenuItem.Text = "Mi Cuenta";
            // 
            // verPerfilToolStripMenuItem
            // 
            this.verPerfilToolStripMenuItem.Enabled = false;
            this.verPerfilToolStripMenuItem.Name = "verPerfilToolStripMenuItem";
            this.verPerfilToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.verPerfilToolStripMenuItem.Text = "Ver Perfil";
            this.verPerfilToolStripMenuItem.Click += new System.EventHandler(this.verPerfilToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Enabled = false;
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // favoritosToolStripMenuItem
            // 
            this.favoritosToolStripMenuItem.Enabled = false;
            this.favoritosToolStripMenuItem.Name = "favoritosToolStripMenuItem";
            this.favoritosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.favoritosToolStripMenuItem.Text = "Favoritos";
            this.favoritosToolStripMenuItem.Click += new System.EventHandler(this.favoritosToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "League of Legends",
            "Valorant",
            "Counter Strike Global Offensive"});
            this.comboBox1.Location = new System.Drawing.Point(327, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(443, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.YellowGreen;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(327, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(443, 378);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnfav
            // 
            this.btnfav.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfav.Location = new System.Drawing.Point(662, 534);
            this.btnfav.Name = "btnfav";
            this.btnfav.Size = new System.Drawing.Size(108, 36);
            this.btnfav.TabIndex = 12;
            this.btnfav.Text = "Favorito";
            this.btnfav.UseVisualStyleBackColor = true;
            this.btnfav.Click += new System.EventHandler(this.btnfav_Click);
            // 
            // Amigos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(1105, 626);
            this.Controls.Add(this.btnfav);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Amigos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem amigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consejosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MiCuentaToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnfav;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favoritosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPerfilToolStripMenuItem;
    }
}