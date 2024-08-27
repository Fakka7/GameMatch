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
    public partial class VerConsejo : Form
    {
        string texto = "";
        public VerConsejo(string texto)
        {
            this.texto = texto;
            InitializeComponent();
            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";

            using (MySqlConnection conexion1 = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion1.Open();

                    string consulta = "SELECT Juego, Texto FROM consejos WHERE Texto = @texto";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion1);
                    comando.Parameters.AddWithValue("@texto", texto);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox1.Text = reader["Juego"].ToString();
                            textBox2.Text = reader["Texto"].ToString();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener datos: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Consejos form2 = new Consejos(); 
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string usuario = "";
            if (hayJugadoresConectados())
            {
                usuario = buscarJugadorConectado();
            }
            else
            {
                usuario = "invitado";
            }


            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            using (MySqlConnection conexion2 = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion2.Open();

                    string juego = textBox1.Text;
                    string textomod = textBox2.Text;

                    string consulta = "UPDATE consejos SET juego = @juego, Texto = @textomod WHERE Texto = @texto;";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion2);
                    comando.Parameters.AddWithValue("@juego", juego);
                    comando.Parameters.AddWithValue("@textomod", textomod);
                    comando.Parameters.AddWithValue("@texto", texto);
                    comando.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar datos: " + ex.Message);
                }

                this.Close();
                Amigos form2 = new Amigos(); 
                form2.Show(); 
            }
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
    }
}
