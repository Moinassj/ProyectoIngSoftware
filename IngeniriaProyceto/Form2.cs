using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace IngeniriaProyceto
{
    public partial class Form2 : Form
    {
        //Conexion a la base de datos (Para poder utilizarlo en su pc cambio el server por el suyo de sql server)   
        SqlConnection conexion = new SqlConnection("server = localhost\\SQLEXPRESS; database=ProyectoVL; integrated security=true");
        string correo;
        public Form2()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtPasswordConfirmation.PasswordChar = '*';
        }
        static bool comparador(string texto, string id)
        {
            Regex regex = new Regex(id);
            MatchCollection match = regex.Matches(texto);
            bool coincidencia = false;
            if (match.Count > 0)
            {
                coincidencia = true;
            }
            return coincidencia;
        }

        private void Cerrar(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string correo = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            //Agregar
            try
            {
                bool correoElectronico = comparador(txtCorreo.Text,correo);
                if(txtPassword.Text == txtPasswordConfirmation.Text && correoElectronico == true)
                {
                    //Insertar en una tabla
                    string Query = "INSERT INTO Usuarios (Usuario, PasswordUser, Nombre) VALUES (@Usuario, @PasswordUser, @Nombre)";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(Query, conexion);
                    comando.Parameters.AddWithValue("@Usuario", txtCorreo.Text);
                    comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    comando.Parameters.AddWithValue("@PasswordUser", txtPasswordConfirmation.Text);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Usuario Creado....");
                    new Form1().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseñas no concuerdan o revisa el correo bien escrito.......");
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Datos incorrectos, revise sus datos....\n" + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Regresar
            new Form1().Show();
            this.Hide();
        }
    }
}
