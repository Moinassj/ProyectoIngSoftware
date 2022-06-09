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

namespace IngeniriaProyceto
{
    public partial class Form2 : Form
    {
        //Conexion a la base de datos (Para poder utilizarlo en su pc cambio el server por el suyo de sql server)   
        SqlConnection conexion = new SqlConnection("server = localhost\\SQLEXPRESS; database=ProyectoVL; integrated security=true");
        public Form2()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtPasswordConfirmation.PasswordChar = '*';
        }

        private void Cerrar(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Agregar
            try
            {
                if(txtPassword.Text == txtPasswordConfirmation.Text)
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
                    MessageBox.Show("Contraseñas no concuerdan.......");
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
