using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameMatch
{
    public partial class Registrarse : Form
    {
        private SqlConnection conexion;
        private string cadenaConexion = "Data Source=DESKTOP-IU1TQ9B;Initial Catalog=gamematch;User ID=root;Password=admin";
        public Registrarse()
        {
            InitializeComponent();
            conexion = new SqlConnection(cadenaConexion);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void btnFinalizarRegistro_Click_1(object sender, EventArgs e)
        {
            string usuario = textBox2.Text;
            string contraseña = textBox1.Text;
            string discord = textBox3.Text;
            string horariodejuego = textBox5.Text;
            string juego = textBox4.Text;
            int conexionn = 0;
            if (jugadorExistente(usuario))
            {
                MessageBox.Show("Usuario existente");
            }
            else
            {
                string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
                MySqlConnection conexion = new MySqlConnection(connectionString);
                try
                {
                    conexion.Open();
                    string consulta2 = "INSERT INTO jugadoresregistrados (Usuario, Contraseña, discord, juego, horariodejuego, Conexion) VALUES (@usuario, @contraseña, @discord, @juego, @horariodejuego, @conexion)";
                    MySqlCommand comando2 = new MySqlCommand(consulta2, conexion);
                    comando2.Parameters.AddWithValue("@usuario", usuario);
                    comando2.Parameters.AddWithValue("@contraseña", contraseña);
                    comando2.Parameters.AddWithValue("@discord", discord);
                    comando2.Parameters.AddWithValue("@juego", juego);
                    comando2.Parameters.AddWithValue("@horariodejuego", horariodejuego);
                    comando2.Parameters.AddWithValue("@conexion", conexionn);
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
                InicioSesion form2 = new InicioSesion();
                form2.Show();
            }
        }

        private void btnvol_Click(object sender, EventArgs e)
        {
            this.Close();
            InicioSesion form2 = new InicioSesion(); 
            form2.Show();
        }

        public bool jugadorExistente(string usuario)
        { 
            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
                try
                {
                    conexion.Open();

                    string consulta = "SELECT usuario FROM jugadoresregistrados WHERE usuario = @usuario";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string usuariosql = reader["usuario"].ToString();
                            if (usuario == "" & usuario == null)
                            {
                                return false;
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
            return true ;
        }
    }
}
