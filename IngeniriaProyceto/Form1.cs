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
    public partial class Form1 : Form
    {
        //Conexion a la base de datos (Para poder utilizarlo en su pc cambio el server por el suyo de sql server)   
        SqlConnection conexion = new SqlConnection("server = localhost\\SQLEXPRESS; database=ProyectoVL; integrated security=true");
       
        public Form1()
        {
            InitializeComponent();
            //Comprueba si la conexion fue exitosa
            try
            {
                conexion.Open();
                MessageBox.Show("Conexion exitosa a la Base de Datos");
            }
            catch
            {
                MessageBox.Show("Error en la base de datos");
            }
            finally
            {
                conexion.Close();
            }
            txtPassword.PasswordChar = '*';       
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string cm = ("SELECT Usuario, PasswordUser FROM  Usuarios WHERE Usuario='"+ txtUsuario.Text+"' AND PasswordUser='"+txtPassword.Text+"'");
                 SqlCommand comando = new SqlCommand(cm, conexion);
                SqlDataReader dr = comando.ExecuteReader();
                if(dr.Read())
                {
                    new Egre().Show();
                    this.Hide();
                    MessageBox.Show("Bienvenido....");
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado o contraseña incorrecta....");
                }

            }
            catch(SqlException ex)
            {
                MessageBox.Show("No se encontro el usuario en el sistema....\n"+ ex);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Ponte en contacto con el administrador de la aplicacion","Soporte tecnico");
        }
    }
}
