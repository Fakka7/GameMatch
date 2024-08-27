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
    public partial class Agregar_Debate : Form
    {
        public Agregar_Debate()
        {
            InitializeComponent();
        }

        private void btnagr_Click(object sender, EventArgs e)
        {
            string usuario;
            if (hayJugadoresConectados())
            {
                usuario = buscarJugadorConectado();
            }
            else
            {
                usuario = "I    nvitado";
            }
            string juego = comboBox1.Text.ToString(); 
            string texto = textBox2.Text;
            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            try
            {
                conexion.Open();
                string consulta2 = "INSERT INTO debates (Usuario, juego, texto) VALUES (@usuario, @juego, @texto)";
                MySqlCommand comando2 = new MySqlCommand(consulta2, conexion);
                comando2.Parameters.AddWithValue("@usuario", usuario);
                comando2.Parameters.AddWithValue("@juego", juego);
                comando2.Parameters.AddWithValue("@texto", texto);
                comando2.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            Debate form2 = new Debate(); 
            form2.Show(); 
        }
    }
}
