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

namespace IngeniriaProyceto.Contenidos
{
    public partial class UCIngresos : UserControl
    {
        //Conexion a la base de datos (Para poder utilizarlo en su pc cambio el server por el suyo de sql server)
        
        SqlConnection conexion = new SqlConnection("server = localhost\\SQLEXPRESS; database=ProyectoVL; integrated security=true");
        int rowModifcar;
        public UCIngresos()
        {
            InitializeComponent();
            //Comprueba si la conexion fue exitosa
            try
            {
                conexion.Open();
                TablaDatos.DataSource = MuestraDatos();
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
        }
        
        public DataTable MuestraDatos()
        {
            string QueryMuestra = "Select * from Ingresos";
            SqlCommand cmd = new SqlCommand(QueryMuestra, conexion);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable BusquedaDatos()
        {
            if(txtBusqueda.Text == "")
            {
                string QueryMuestra = "SELECT * FROM Ingresos";
                SqlCommand cmd = new SqlCommand(QueryMuestra, conexion);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                return tabla;
            }
            else
            {
                string QueryMuestra = "SELECT * FROM Ingresos WHERE NombreReceptor LIKE '" + txtBusqueda.Text +"' ";
                SqlCommand cmd = new SqlCommand(QueryMuestra, conexion);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                return tabla;
            } 
        }

        public void Limpiar()
        {
            txtFolioFiscal.Text = "";
            txtFecha.Text = ""; 
            txtFolio.Text = ""; 
            txtNombreEmisores.Text = "";        
            txtSubtotal.Text = ""; 
            txtIva8.Text = ""; 
            txtIva16.Text = ""; 
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UCIngresos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if(rowModifcar != 0 )
                {
                    string QueryMod = "UPDATE Ingresos SET FolioFiscal_I = @FolioFiscal_I, Feche_I = @Feche_I, Folio_I = @Folio_I, NombreReceptor = @NombreReceptor, Subtotal_I = @Subtotal_I, Iva_Ocho_E = @Iva_Ocho_E, Iva_Dieciseis_E = @Iva_Dieciseis_E WHERE Id_Ingresos = @Id_Ingresos";
                    conexion.Open();
                    SqlCommand comandoMod = new SqlCommand(QueryMod, conexion);
                    comandoMod.Parameters.AddWithValue("@FolioFiscal_I", txtFolioFiscal.Text);
                    comandoMod.Parameters.AddWithValue("@Feche_I", txtFecha.Text);
                    comandoMod.Parameters.AddWithValue("@Folio_I", txtFolio.Text);
                    comandoMod.Parameters.AddWithValue("@NombreReceptor", txtNombreEmisores.Text);
                    comandoMod.Parameters.AddWithValue("@Subtotal_I", txtSubtotal.Text);
                    comandoMod.Parameters.AddWithValue("@Iva_Ocho_E", txtIva8.Text);
                    comandoMod.Parameters.AddWithValue("@Iva_Dieciseis_E", txtIva16.Text);
                    comandoMod.Parameters.AddWithValue("@Id_Ingresos", rowModifcar.ToString());
                    comandoMod.ExecuteNonQuery();
                    TablaDatos.DataSource = MuestraDatos();
                    MessageBox.Show("Modificado correctamente");
                    rowModifcar = 0;
                }
                else
                {
                    //Insertar en una tabla
                    string Query = "INSERT INTO Ingresos (FolioFiscal_I, Feche_I, Folio_I, NombreReceptor, Subtotal_I, Iva_Ocho_E, Iva_Dieciseis_E) VALUES 	(@FolioFiscal_I, @Feche_I, @Folio_I, @NombreReceptor, @Subtotal_I, @Iva_Ocho_E, @Iva_Dieciseis_E)";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(Query, conexion);
                    comando.Parameters.AddWithValue("@FolioFiscal_I", txtFolioFiscal.Text);
                    comando.Parameters.AddWithValue("@Feche_I", txtFecha.Text);
                    comando.Parameters.AddWithValue("@Folio_I", txtFolio.Text);
                    comando.Parameters.AddWithValue("@NombreReceptor", txtNombreEmisores.Text);
                    comando.Parameters.AddWithValue("@Subtotal_I", txtSubtotal.Text);
                    comando.Parameters.AddWithValue("@Iva_Ocho_E", txtIva8.Text);
                    comando.Parameters.AddWithValue("@Iva_Dieciseis_E", txtIva16.Text);
                    comando.ExecuteNonQuery();
                    TablaDatos.DataSource = MuestraDatos();
                    MessageBox.Show("Ingresado correctamente");
                } 
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos\n" + ex);
            }
            finally
            {
                conexion.Close();
                Limpiar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TablaDatos.DataSource = BusquedaDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idIngreso = Convert.ToInt32(TablaDatos.CurrentRow.Cells[0].Value);

            try
            {
                string Query = "DELETE FROM Ingresos WHERE Id_Ingresos = '"+ idIngreso +"'";
                conexion.Open();
                SqlCommand comando = new SqlCommand(Query, conexion);
                comando.ExecuteNonQuery();
                TablaDatos.DataSource = MuestraDatos();
                MessageBox.Show("Datos eliminados correctamente...");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos\n" + ex);
            }
        }

        private void TablaDatos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (TablaDatos.CurrentRow.Cells[0].Value != null)
            {
                rowModifcar = Convert.ToInt32(TablaDatos.CurrentRow.Cells[0].Value);
                txtFolioFiscal.Text = TablaDatos.CurrentRow.Cells[1].Value.ToString();
                txtFecha.Text = TablaDatos.CurrentRow.Cells[2].Value.ToString();
                txtFolio.Text = TablaDatos.CurrentRow.Cells[3].Value.ToString();
                txtNombreEmisores.Text = TablaDatos.CurrentRow.Cells[4].Value.ToString();
                txtSubtotal.Text = TablaDatos.CurrentRow.Cells[5].Value.ToString();
                txtIva8.Text = TablaDatos.CurrentRow.Cells[6].Value.ToString();
                txtIva16.Text = TablaDatos.CurrentRow.Cells[7].Value.ToString();
            }
            else
            {
                Limpiar();
            }
        }
    }
}
