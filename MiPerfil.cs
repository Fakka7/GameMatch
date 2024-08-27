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
    public partial class MiPerfil : Form
    {
        public MiPerfil()
        {
            InitializeComponent();
            string usuario = buscarJugadorConectado();
            textBox1.Text = usuario;
            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";

            using (MySqlConnection conexion1 = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion1.Open();

                    string consulta = "SELECT discord, juego, horariodejuego FROM jugadoresregistrados WHERE usuario = @usuario";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion1);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox2.Text = reader["discord"].ToString();
                            textBox4.Text = reader["juego"].ToString();
                            textBox3.Text = reader["horariodejuego"].ToString();
                           
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener datos: " + ex.Message);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            Amigos form2 = new Amigos(); 
            form2.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string usuario = buscarJugadorConectado();
            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            using (MySqlConnection conexion2 = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion2.Open();

                    string discord = textBox2.Text;
                    string juego = textBox4.Text;
                    string horariodejuego = textBox3.Text;

                    string consulta = "UPDATE jugadoresregistrados SET discord = @discord, juego = @juego, horariodejuego = @horariodejuego WHERE usuario = @usuario;";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion2);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@discord", discord);
                    comando.Parameters.AddWithValue("@juego", juego);
                    comando.Parameters.AddWithValue("@horariodejuego", horariodejuego);
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
    }
}
