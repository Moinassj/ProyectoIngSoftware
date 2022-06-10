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
    public partial class UCRefacciones : UserControl
    {
        //Conexion a la base de datos (Para poder utilizarlo en su pc cambio el server por el suyo de sql server)   
        SqlConnection conexion = new SqlConnection("server = localhost\\SQLEXPRESS; database=ProyectoVL; integrated security=true");
        int rowModifcar;
        public UCRefacciones()
        {
            InitializeComponent();
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
            string QueryMuestra = "Select * from Refacciones";
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
                string QueryMuestra = "SELECT * FROM Refacciones";
                SqlCommand cmd = new SqlCommand(QueryMuestra, conexion);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                return tabla;
            }
            else
            {
                string QueryMuestra = "SELECT * FROM Refacciones WHERE NombrePieza LIKE '" + txtBuscar.Text +"' ";
                SqlCommand cmd = new SqlCommand(QueryMuestra, conexion);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                return tabla;
            } 
        }

        public void Limpiar()
        {
            txtNombrePieza.Text = "";
            txtModelo.Text = ""; 
            txtYear.Text = ""; 
            txtNombreReceptor.Text = ""; 
            txtExistencia.Text = "";        
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if(rowModifcar != 0 )
                {
                    string QueryMod = "UPDATE Refacciones SET Id_Refacciones = @Id_Refacciones, NombrePieza = @NombrePieza, Modelo = @Modelo, YearPieza = @YearPieza, NombreReceptorPieza = @NombreReceptorPieza, Existencia = @Existencia WHERE Id_Refacciones = @Id_Refacciones";
                    conexion.Open();
                    SqlCommand comandoMod = new SqlCommand(QueryMod, conexion);
                    comandoMod.Parameters.AddWithValue("@NombrePieza", txtNombrePieza.Text);
                    comandoMod.Parameters.AddWithValue("@Modelo", txtModelo.Text);
                    comandoMod.Parameters.AddWithValue("@YearPieza", txtYear.Text);
                    comandoMod.Parameters.AddWithValue("@NombreReceptorPieza", txtNombreReceptor.Text);
                    comandoMod.Parameters.AddWithValue("@Existencia", txtExistencia.Text);
                    comandoMod.Parameters.AddWithValue("@Id_Refacciones", rowModifcar.ToString());
                    comandoMod.ExecuteNonQuery();
                    TablaDatos.DataSource = MuestraDatos();
                    MessageBox.Show("Modificado correctamente");
                    rowModifcar = 0;
                }
                else
                {
                    //Insertar en una tabla
                    string Query = "INSERT INTO Refacciones (NombrePieza, Modelo, YearPieza,NombreReceptorPieza,Existencia) VALUES (@NombrePieza, @Modelo, @YearPieza, @NombreReceptorPieza, @Existencia)";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(Query, conexion);
                    comando.Parameters.AddWithValue("@NombrePieza", txtNombrePieza.Text);
                    comando.Parameters.AddWithValue("@Modelo", txtModelo.Text);
                    comando.Parameters.AddWithValue("@YearPieza", txtYear.Text);
                    comando.Parameters.AddWithValue("@NombreReceptorPieza", txtNombreReceptor.Text);
                    comando.Parameters.AddWithValue("@Existencia", txtExistencia.Text);
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
            int Id_Refacciones = Convert.ToInt32(TablaDatos.CurrentRow.Cells[0].Value);

            try
            {
                string Query = "DELETE FROM Refacciones WHERE Id_Refacciones = '"+ Id_Refacciones +"'";
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
                txtNombrePieza.Text = TablaDatos.CurrentRow.Cells[1].Value.ToString();
                txtModelo.Text = TablaDatos.CurrentRow.Cells[2].Value.ToString();
                txtYear.Text = TablaDatos.CurrentRow.Cells[3].Value.ToString();
                txtNombreReceptor.Text = TablaDatos.CurrentRow.Cells[4].Value.ToString();
                txtExistencia.Text = TablaDatos.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                Limpiar();
            }
        }
    }
}
