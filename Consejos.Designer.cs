
using System.Windows.Forms;

namespace GameMatch
{
    partial class Consejos
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
            this.favoritosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.micuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.agregar = new System.Windows.Forms.Button();
            this.eliminar = new System.Windows.Forms.Button();
            this.refrescar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnVerConsejo = new System.Windows.Forms.Button();
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
            this.favoritosToolStripMenuItem,
            this.micuentaToolStripMenuItem,
            this.iniciarSesionToolStripMenuItem});
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
            // favoritosToolStripMenuItem
            // 
            this.favoritosToolStripMenuItem.Enabled = false;
            this.favoritosToolStripMenuItem.Name = "favoritosToolStripMenuItem";
            this.favoritosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.favoritosToolStripMenuItem.Text = "Favoritos";
            this.favoritosToolStripMenuItem.Click += new System.EventHandler(this.favoritosToolStripMenuItem_Click);
            // 
            // micuentaToolStripMenuItem
            // 
            this.micuentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verPerfilToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.micuentaToolStripMenuItem.Enabled = false;
            this.micuentaToolStripMenuItem.Name = "micuentaToolStripMenuItem";
            this.micuentaToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.micuentaToolStripMenuItem.Text = "Mi Cuenta";
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
            // iniciarSesionToolStripMenuItem
            // 
            this.iniciarSesionToolStripMenuItem.Enabled = false;
            this.iniciarSesionToolStripMenuItem.Name = "iniciarSesionToolStripMenuItem";
            this.iniciarSesionToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.iniciarSesionToolStripMenuItem.Text = "Iniciar Sesion";
            this.iniciarSesionToolStripMenuItem.Click += new System.EventHandler(this.iniciarSesionToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.YellowGreen;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1081, 460);
            this.dataGridView1.TabIndex = 7;
            // 
            // agregar
            // 
            this.agregar.Location = new System.Drawing.Point(74, 539);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(136, 31);
            this.agregar.TabIndex = 8;
            this.agregar.Text = "Agregar Consejo";
            this.agregar.UseVisualStyleBackColor = true;
            this.agregar.Click += new System.EventHandler(this.btnAgregarConsejo_Click_1);
            // 
            // eliminar
            // 
            this.eliminar.Enabled = false;
            this.eliminar.Location = new System.Drawing.Point(481, 539);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(149, 31);
            this.eliminar.TabIndex = 9;
            this.eliminar.Text = "Eliminar Consejo";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.btnElimnarConsejo_Click_1);
            // 
            // refrescar
            // 
            this.refrescar.Location = new System.Drawing.Point(875, 493);
            this.refrescar.Name = "refrescar";
            this.refrescar.Size = new System.Drawing.Size(147, 31);
            this.refrescar.TabIndex = 10;
            this.refrescar.Text = "Refrescar Tabla";
            this.refrescar.UseVisualStyleBackColor = true;
            this.refrescar.Click += new System.EventHandler(this.refrescar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(481, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 31);
            this.button1.TabIndex = 11;
            this.button1.Text = "Mis consejos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnMisConsejos);
            // 
            // btnVerConsejo
            // 
            this.btnVerConsejo.Enabled = false;
            this.btnVerConsejo.Location = new System.Drawing.Point(875, 539);
            this.btnVerConsejo.Name = "btnVerConsejo";
            this.btnVerConsejo.Size = new System.Drawing.Size(147, 31);
            this.btnVerConsejo.TabIndex = 12;
            this.btnVerConsejo.Text = "Ver Consejo";
            this.btnVerConsejo.UseVisualStyleBackColor = true;
            this.btnVerConsejo.Click += new System.EventHandler(this.btnVerConsejo_Click);
            // 
            // Consejos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(1105, 626);
            this.Controls.Add(this.btnVerConsejo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.refrescar);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.agregar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Consejos";
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
        private System.Windows.Forms.ToolStripMenuItem micuentaToolStripMenuItem;
        private DataGridView dataGridView1;
        private Button agregar;
        private Button eliminar;
        private Button refrescar;
        private Button button1;
        private ToolStripMenuItem favoritosToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem iniciarSesionToolStripMenuItem;
        private ToolStripMenuItem verPerfilToolStripMenuItem;
        private Button btnVerConsejo;
    }
}
