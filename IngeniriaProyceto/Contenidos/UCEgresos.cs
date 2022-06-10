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
    public partial class UCEgresos : UserControl
    {
        
        //Conexion a la base de datos (Para poder utilizarlo en su pc cambio el server por el suyo de sql server)   
        SqlConnection conexion = new SqlConnection("server = localhost\\SQLEXPRESS; database=ProyectoVL; integrated security=true");
        int rowModifcar;
        public UCEgresos()
        {
            InitializeComponent();
            //Comprueba si la conexion fue exitosa
            try
            {
                conexion.Open();
                TablaDatos.DataSource = MuestraDatos();
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
            string QueryMuestra = "Select * from Egresos";
            SqlCommand cmd = new SqlCommand(QueryMuestra, conexion);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable BusquedaDatos()
        {
            if(txtBuscar.Text == "")
            {
                string QueryMuestra = "SELECT * FROM Egresos";
                SqlCommand cmd = new SqlCommand(QueryMuestra, conexion);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                return tabla;
            }
            else
            {
                string QueryMuestra = "SELECT * FROM Egresos WHERE NombreReceptor LIKE '" + txtBuscar.Text +"' ";
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
            txtNombreEmisor.Text = "";        
            txtSubtotal.Text = ""; 
            txtIva8.Text = ""; 
            txtIva16.Text = ""; 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             try
            {

                if(rowModifcar != 0 )
                {
                    string QueryMod = "UPDATE Egresos SET FolioFiscal_E = @FolioFiscal_E, Feche_E = @Feche_E, Folio_E = @Folio_E, NombreReceptor = @NombreReceptor, Subtotal_E = @Subtotal_E, Iva_Ocho_E = @Iva_Ocho_E WHERE Id_Egresos = @Id_Egresos";
                    conexion.Open();
                    SqlCommand comandoMod = new SqlCommand(QueryMod, conexion);
                    comandoMod.Parameters.AddWithValue("@FolioFiscal_E", txtFolioFiscal.Text);
                    comandoMod.Parameters.AddWithValue("@Feche_E", txtFecha.Text);
                    comandoMod.Parameters.AddWithValue("@Folio_E", txtFolio.Text);
                    comandoMod.Parameters.AddWithValue("@NombreReceptor", txtNombreEmisor.Text);
                    comandoMod.Parameters.AddWithValue("@Subtotal_E", txtSubtotal.Text);
                    comandoMod.Parameters.AddWithValue("@Iva_Ocho_E", txtIva8.Text);
                    comandoMod.Parameters.AddWithValue("@Id_Egresos", rowModifcar.ToString());
                    comandoMod.ExecuteNonQuery();
                    TablaDatos.DataSource = MuestraDatos();
                    MessageBox.Show("Modificado correctamente");
                    rowModifcar = 0;
                }
                else
                {
                    //Insertar en una tabla
                    string Query = "INSERT INTO Egresos (FolioFiscal_E, Feche_E, Folio_E, NombreReceptor, Subtotal_E, Iva_Ocho_E) VALUES (@FolioFiscal_I, @Feche_I, @Folio_I, @NombreReceptor, @Subtotal_I, @Iva_Ocho_E)";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(Query, conexion);
                    comando.Parameters.AddWithValue("@FolioFiscal_I", txtFolioFiscal.Text);
                    comando.Parameters.AddWithValue("@Feche_I", txtFecha.Text);
                    comando.Parameters.AddWithValue("@Folio_I", txtFolio.Text);
                    comando.Parameters.AddWithValue("@NombreReceptor", txtNombreEmisor.Text);
                    comando.Parameters.AddWithValue("@Subtotal_I", txtSubtotal.Text);
                    comando.Parameters.AddWithValue("@Iva_Ocho_E", txtIva8.Text);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEgreso = Convert.ToInt32(TablaDatos.CurrentRow.Cells[0].Value);

            try
            {
                string Query = "DELETE FROM Egresos WHERE Id_Egresos = '"+ idEgreso +"'";
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            TablaDatos.DataSource = BusquedaDatos();
        }

        private void TablaDatos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (TablaDatos.CurrentRow.Cells[0].Value != null)
            {
                rowModifcar = Convert.ToInt32(TablaDatos.CurrentRow.Cells[0].Value);
                txtFolioFiscal.Text = TablaDatos.CurrentRow.Cells[1].Value.ToString();
                txtFecha.Text = TablaDatos.CurrentRow.Cells[2].Value.ToString();
                txtFolio.Text = TablaDatos.CurrentRow.Cells[3].Value.ToString();
                txtNombreEmisor.Text = TablaDatos.CurrentRow.Cells[4].Value.ToString();
                txtSubtotal.Text = TablaDatos.CurrentRow.Cells[5].Value.ToString();
                txtIva8.Text = TablaDatos.CurrentRow.Cells[6].Value.ToString();
            }
            else
            {
                Limpiar();
            }
        }
    }
}
