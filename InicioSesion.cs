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
    public partial class InicioSesion : Form
    {
        private MySqlConnection conexion;
        int intentos = 0;
        public InicioSesion()
        {
            InitializeComponent();
            if (hayJugadoresConectados())
            {
                this.ingresoToolStripMenuItem.Enabled = false;
                this.ingresarToolStripMenuItem.Enabled = true;
                this.registroToolStripMenuItem.Enabled = true;
                this.cerrarSesionToolStripMenuItem.Enabled = false;
                this.debateToolStripMenuItem.Enabled = true;
                this.consejosToolStripMenuItem.Enabled = true;
                this.favoritosToolStripMenuItem.Enabled = false;
                this.amigosToolStripMenuItem.Enabled = false;
            }
            conexion = new MySqlConnection();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = textBox2.Text;
            string contraseña = textBox1.Text;
            bool aceptado = false;
            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
                try
                {
                    conexion.Open();

                    string consulta = "SELECT contraseña FROM jugadoresregistrados WHERE usuario = @usuario";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string contraseñasql = reader["contraseña"].ToString();
                            if (contraseña == contraseñasql)
                            {
                                aceptado = true;
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
            if (aceptado)
            {
                jugadorConectado(usuario);
                Amigos form2 = new Amigos();
                form2.Show();
                this.Hide();
            }
            else
            {
                intentos++;
                if(intentos >= 2)
                {
                    MessageBox.Show("Recuerda que puedes registarte si aun no lo has hecho");
                    intentos = 0;
                }
                else
                {
                    MessageBox.Show("Inicio de sesión fallido. Verifique sus credenciales");
                }
            }

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Registrarse form2 = new Registrarse();
            form2.Show();
            this.Hide();
        }

        private void consejosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consejos form2 = new Consejos();
            form2.Show();
            this.Hide();
        }

        private void debateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debate form2 = new Debate(); 
            form2.Show();
            this.Hide();
        }

        public void jugadorConectado(string usuario)
        {
            string connectionString = "Server=LocalHost;Database=gamematch;User ID=root;Password=admin;";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
                try
                {
                    conexion.Open();

                    string consulta = "UPDATE jugadoresregistrados SET conexion = 1 WHERE usuario = @usuario;";
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

        private void btnInvitado_Click(object sender, EventArgs e)
        {
            Consejos form2 = new Consejos();
            form2.Show();
            this.Hide();
        }

    }
}
