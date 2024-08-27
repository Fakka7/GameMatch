using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameMatch
{
    public partial class Consejos : Form
    {
        public Consejos()
        {
            InitializeComponent();
            if (hayJugadoresConectados())
            {
                this.micuentaToolStripMenuItem.Enabled = true;
                this.cerrarSesionToolStripMenuItem.Enabled = true;
                this.debateToolStripMenuItem.Enabled = true;
                this.consejosToolStripMenuItem.Enabled = true;
                this.favoritosToolStripMenuItem.Enabled = true;
                this.amigosToolStripMenuItem.Enabled = true;
                this.iniciarSesionToolStripMenuItem.Enabled = false;
                this.verPerfilToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.micuentaToolStripMenuItem.Enabled = false;
                this.debateToolStripMenuItem.Enabled = true;
                this.consejosToolStripMenuItem.Enabled = true;
                this.iniciarSesionToolStripMenuItem.Enabled = true;
                this.verPerfilToolStripMenuItem.Enabled = false;
                this.button1.Enabled = false;
                this.eliminar.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void amigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Amigos form2 = new Amigos();
            form2.Show(); 
        }

        private void consejosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Consejos form2 = new Consejos(); 
            form2.Show(); 
        }

        private void debateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Debate form2 = new Debate(); 
            form2.Show(); 
        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            InicioSesion form2 = new InicioSesion(); 
            form2.Show(); 
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Registrarse form2 = new Registrarse(); 
            form2.Show();
        }
        private string buscarJugadorConectado()
        {
            string usuario = "";

            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
                try
                {
                    conexion.Open();
                    string consulta = "SELECT usuario FROM jugadoresregistrados WHERE conexion = 1;";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = reader["usuario"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conexion.Close();
                }

            return usuario;
        }
        private void jugadorDesconectado()
        {
            string usuario = buscarJugadorConectado();

            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
                try
                {
                    conexion.Open();

                    string consulta = "UPDATE jugadoresregistrados SET conexion = 0 WHERE usuario = @usuario;";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
        }
        private bool hayJugadoresConectados()
        {
            bool conectado = false;

            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
                try
                {
                    conexion.Open();

                    string consulta = "SELECT usuario FROM jugadoresregistrados WHERE conexion = 1";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string usuario = reader["usuario"].ToString();
                            if (usuario != null)
                            {
                                conectado = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conexion.Close();
                }

            return conectado;
        }
        private void refrescar_Click(object sender, EventArgs e)
        {
            this.eliminar.Enabled = false;
            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";

            string consulta = "SELECT Usuario, Juego, Texto FROM consejos";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        dataGridView1.DataSource = tabla;
                    }
                }
            }
        }
        private void btnAgregarConsejo_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Agregar_Consejo form2 = new Agregar_Consejo();
            form2.Show(); 
        }

        private void btnElimnarConsejo_Click_1(object sender, EventArgs e)
        {
            eliminarFilaSeleccionada();
        }
        private void eliminarFilaSeleccionada()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                dataGridView1.Rows.Remove(filaSeleccionada);
                string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
                string texto = "";
                using (MySqlConnection conexion2 = new MySqlConnection(connectionString))
                    try
                    {
                        conexion2.Open();

                        string consulta2 = "SELECT Texto FROM consejos WHERE Usuario = @Usuario;";
                        MySqlCommand comando3 = new MySqlCommand(consulta2, conexion2);

                        using (MySqlDataReader reader = comando3.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string usuariosql = reader["Texto"].ToString();
                                texto = usuariosql;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        conexion2.Close();
                    }
                MySqlConnection conexion = new MySqlConnection(connectionString);
                try
                {
                    conexion.Open();
                    string consulta = "DELETE FROM consejos WHERE Texto = @texto";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@texto", texto);
                    comando.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila para eliminar.");
            }
        }
        public string devolverUsuarioPorConexion()
        {
            string usuario = "";
            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
                try
                {
                    conexion.Open();

                    string consulta = "SELECT Usuario FROM jugadoresregistrados WHERE Conexion = 1";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string usuariosql = reader["Usuario"].ToString();
                            usuario = usuariosql;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
            return usuario;
        }

        private void btnMisConsejos(object sender, EventArgs e)
        {
            this.eliminar.Enabled = true;
            this.btnVerConsejo.Enabled = true;
            string usuario = "";
            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            try
            {
                conexion.Open();
                string consulta = "SELECT usuario FROM jugadoresregistrados WHERE conexion = 1";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string usuariosql = reader["Usuario"].ToString();
                        usuario = usuariosql;
                    }
                }
                cargarMisDebates(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        public void cargarMisDebates(string usuario)
        {
            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            try
            {
                string consulta = "SELECT Usuario, Juego, Texto FROM consejos WHERE usuario = @usuario";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        dataGridView1.DataSource = tabla;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void iniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            InicioSesion form2 = new InicioSesion(); 
            form2.Show();
        }

        private void favoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Favoritos form2 = new Favoritos();
            form2.Show(); 
        }

        private void verPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            MiPerfil form2 = new MiPerfil(); 
            form2.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jugadorDesconectado();
            this.Close();
            InicioSesion form2 = new InicioSesion();
            form2.Show();
        }

        private void btnVerConsejo_Click(object sender, EventArgs e)
        {
            string valorColumna = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                valorColumna = filaSeleccionada.Cells[2].Value.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila antes de presionar el botón.");
            }
            this.Close();
            VerConsejo form2 = new VerConsejo(valorColumna);
            form2.Show();
        }
    }
}

