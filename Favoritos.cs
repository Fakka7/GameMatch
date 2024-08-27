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
    public partial class Favoritos : Form
    {
        private MySqlConnection conexion;
        public Favoritos()
        {
            InitializeComponent();

            string cadenaConexion = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            conexion = new MySqlConnection(cadenaConexion);

            CargarDatos();

        }

        private void CargarDatos()
        {
            string usuario = buscarJugadorConectado();
            try
            {
                conexion.Open();
                string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
                string consulta = "SELECT jugadorseleccionado, discord, juego, horariodejuego FROM favoritos WHERE elegidopor = '" + usuario + "';";

                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();
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

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Amigos form2 = new Amigos();
            form2.Show();
        }
    }
}
