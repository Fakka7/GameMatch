using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace GameMatch
{
    public partial class Amigos : Form
    {
        private System.Windows.Forms.Timer temporizador;
        private MySqlConnection conexion;

        public Amigos()
        {
            InitializeComponent();

            string cadenaConexion = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            conexion = new MySqlConnection(cadenaConexion);

            temporizador = new System.Windows.Forms.Timer();
            temporizador.Interval = 5000; 
            temporizador.Tick += Temporizador_Tick;

            temporizador.Start();

            CargarDatos();

            if (hayJugadoresConectados())
            {
                this.MiCuentaToolStripMenuItem.Enabled = true;
                this.cerrarSesionToolStripMenuItem.Enabled = true;
                this.debateToolStripMenuItem.Enabled = true;
                this.consejosToolStripMenuItem.Enabled = true;
                this.favoritosToolStripMenuItem.Enabled = true;
                this.amigosToolStripMenuItem.Enabled = true;
                this.verPerfilToolStripMenuItem.Enabled = true;
            }
        }
        private void Temporizador_Tick(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            try
            { 
                conexion.Open();
             
                string consulta = "SELECT usuario, discord, juego, horariodejuego FROM jugadoresregistrados;";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
              
                DataSet dataSet = new DataSet();
                
                adaptador.Fill(dataSet, "dataGridView1");

             
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dataSet.Tables["dataGridView1"];

                DataGridViewTextBoxColumn columnaUsuario = new DataGridViewTextBoxColumn();
                columnaUsuario.DataPropertyName = "usuario";
                columnaUsuario.HeaderText = "Usuario";
                dataGridView1.Columns.Add(columnaUsuario);

                DataGridViewTextBoxColumn columnaDiscord = new DataGridViewTextBoxColumn();
                columnaDiscord.DataPropertyName = "discord";
                columnaDiscord.HeaderText = "Discord";
                dataGridView1.Columns.Add(columnaDiscord);

                DataGridViewTextBoxColumn columnaJuego = new DataGridViewTextBoxColumn();
                columnaJuego.DataPropertyName = "juego";
                columnaJuego.HeaderText = "Juego";
                dataGridView1.Columns.Add(columnaJuego);

                DataGridViewTextBoxColumn columnaHorario = new DataGridViewTextBoxColumn();
                columnaHorario.DataPropertyName = "horariodejuego";
                columnaHorario.HeaderText = "Horario de Juego";
                dataGridView1.Columns.Add(columnaHorario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
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

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jugadorDesconectado();
            this.Close();
            InicioSesion form2 = new InicioSesion(); 
            form2.Show(); 
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

        private void btnfav_Click(object sender, EventArgs e)
        {
            string usuario = buscarJugadorConectado();
            string valorPrimeraColumnaSeleccionada = string.Empty;
            string discord = "";
            string juego = "";
            string horariodejuego = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                valorPrimeraColumnaSeleccionada = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                    try
                    {
                        conexion.Open();

                        string consulta = "SELECT discord, juego, horariodejuego FROM jugadoresregistrados WHERE usuario = @valorPrimeraColumnaSeleccionada;";
                        MySqlCommand comando = new MySqlCommand(consulta, conexion);
                        comando.Parameters.AddWithValue("@valorPrimeraColumnaSeleccionada", valorPrimeraColumnaSeleccionada);
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                discord = reader["discord"].ToString();
                                juego = reader["juego"].ToString();
                                horariodejuego = reader["horariodejuego"].ToString();
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

            if (usuario != valorPrimeraColumnaSeleccionada)
            {
                string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
                MySqlConnection conexion = new MySqlConnection(connectionString);

                try
                {
                    conexion.Open();

                    string consulta2 = "INSERT INTO favoritos (elegidopor, jugadorseleccionado, discord, juego, horariodejuego) VALUES (@elegidopor, @jugadorseleccionado, @discord, @juego, @horariodejuego)";
                    MySqlCommand comando2 = new MySqlCommand(consulta2, conexion);
                    comando2.Parameters.AddWithValue("@elegidopor", usuario);
                    comando2.Parameters.AddWithValue("@jugadorseleccionado", valorPrimeraColumnaSeleccionada);
                    comando2.Parameters.AddWithValue("@discord", discord);
                    comando2.Parameters.AddWithValue("@juego", juego);
                    comando2.Parameters.AddWithValue("@horariodejuego", horariodejuego);
                    comando2.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conexion.Close();
                    MessageBox.Show("Añadido a favoritos");
                }
            }

        }

        private void favoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Favoritos form2 = new Favoritos();
            form2.Show(); 
        }

        private void verPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MiPerfil form2 = new MiPerfil(); 
            form2.Show(); 
        }
    }
}
