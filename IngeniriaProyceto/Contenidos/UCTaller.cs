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
    public partial class UCTaller : UserControl
    {
         //Conexion a la base de datos (Para poder utilizarlo en su pc cambio el server por el suyo de sql server)   
        SqlConnection conexion = new SqlConnection("server = localhost\\SQLEXPRESS; database=ProyectoVL; integrated security=true");
        int rowModifcar;
        public UCTaller()
        {
            InitializeComponent();
            try
            {
                conexion.Open();
                dataGridView1.DataSource = MuestraDatos();
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
            string QueryMuestra = "Select * from Taller";
            SqlCommand cmd = new SqlCommand(QueryMuestra, conexion);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable BusquedaDatos()
        {
            if (textBox8.Text == "")
            {
                string QueryMuestra = "SELECT * FROM Taller";
                SqlCommand cmd = new SqlCommand(QueryMuestra, conexion);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                return tabla;
            }
            else
            {
                string QueryMuestra = "SELECT * FROM Taller WHERE Nombre LIKE '" + textBox8.Text + "' ";
                SqlCommand cmd = new SqlCommand(QueryMuestra, conexion);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                return tabla;
            }
        }

        public void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BusquedaDatos();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (rowModifcar != 0)
                {
                    string QueryMod = "UPDATE Taller SET Id_Taller = @Id_Taller, Nombre = @Nombre, Direccion = @Direccion, Cotizacion = @Cotizacion, Estatus = @Estatus, Fecha_Ingreso = @Fecha_Ingreso, Fecha_Salida = @Fecha_Salida WHERE Id_Taller = @Id_Taller";
                    conexion.Open();
                    SqlCommand comandoMod = new SqlCommand(QueryMod, conexion);
                    comandoMod.Parameters.AddWithValue("@Nombre", textBox1.Text);
                    comandoMod.Parameters.AddWithValue("@Direccion", textBox2.Text);
                    comandoMod.Parameters.AddWithValue("@Cotizacion", textBox4.Text);
                    comandoMod.Parameters.AddWithValue("@Estatus", textBox5.Text);
                    comandoMod.Parameters.AddWithValue("@Fecha_Ingreso", textBox6.Text);
                    comandoMod.Parameters.AddWithValue("@Fecha_Salida", textBox7.Text);
                    comandoMod.Parameters.AddWithValue("@Id_Taller", rowModifcar.ToString());

                    comandoMod.ExecuteNonQuery();
                    dataGridView1.DataSource = MuestraDatos();
                    MessageBox.Show("Modificado correctamente");
                    rowModifcar = 0;
                }
                else
                {
                    //Insertar en una tabla
                    string Query = "INSERT INTO Taller (Nombre, Direccion, Cotizacion, Estatus, Fecha_Ingreso, Fecha_Salida) VALUES 	(@Nombre, @Direccion, @Cotizacion, @Estatus, @Fecha_Ingreso, @Fecha_Salida)";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(Query, conexion);
                    comando.Parameters.AddWithValue("@Nombre", textBox1.Text);
                    comando.Parameters.AddWithValue("@Direccion", textBox2.Text);
                    comando.Parameters.AddWithValue("@Cotizacion", textBox4.Text);
                    comando.Parameters.AddWithValue("@Estatus", textBox5.Text);
                    comando.Parameters.AddWithValue("@Fecha_Ingreso", textBox6.Text);
                    comando.Parameters.AddWithValue("@Fecha_Salida", textBox7.Text);
                    comando.ExecuteNonQuery();
                    dataGridView1.DataSource = MuestraDatos();
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

        private void button3_Click(object sender, EventArgs e)
        {
            int Id_Taller = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            try
            {
                string Query = "DELETE FROM Taller WHERE Id_Taller = '" + Id_Taller + "'";
                conexion.Open();
                SqlCommand comando = new SqlCommand(Query, conexion);
                comando.ExecuteNonQuery();
                dataGridView1.DataSource = MuestraDatos();
                MessageBox.Show("Datos eliminados correctamente...");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos\n" + ex);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                rowModifcar = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            else
            {
                Limpiar();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (rowModifcar != 0)
                {
                    string QueryMod = "UPDATE Taller SET Id_Taller = @Id_Taller, Nombre = @Nombre, Direccion = @Direccion, Cotizacion = @Cotizacion, Estatus = @Estatus, Fecha_Ingreso = @Fecha_Ingreso, Fecha_Salida = @Fecha_Salida WHERE Id_Taller = @Id_Taller";
                    conexion.Open();
                    SqlCommand comandoMod = new SqlCommand(QueryMod, conexion);
                    comandoMod.Parameters.AddWithValue("@Nombre", textBox1.Text);
                    comandoMod.Parameters.AddWithValue("@Direccion", textBox2.Text);
                    comandoMod.Parameters.AddWithValue("@Cotizacion", textBox4.Text);
                    comandoMod.Parameters.AddWithValue("@Estatus", textBox5.Text);
                    comandoMod.Parameters.AddWithValue("@Fecha_Ingreso", textBox6.Text);
                    comandoMod.Parameters.AddWithValue("@Fecha_Salida", textBox7.Text);
                    comandoMod.Parameters.AddWithValue("@Id_Taller", rowModifcar.ToString());

                    comandoMod.ExecuteNonQuery();
                    dataGridView1.DataSource = MuestraDatos();
                    MessageBox.Show("Modificado correctamente");
                    rowModifcar = 0;
                }
                else
                {
                    //Insertar en una tabla
                    string Query = "INSERT INTO Taller (Nombre, Direccion, Cotizacion, Estatus, Fecha_Ingreso, Fecha_Salida) VALUES 	(@Nombre, @Direccion, @Cotizacion, @Estatus, @Fecha_Ingreso, @Fecha_Salida)";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(Query, conexion);
                    comando.Parameters.AddWithValue("@Nombre", textBox1.Text);
                    comando.Parameters.AddWithValue("@Direccion", textBox2.Text);
                    comando.Parameters.AddWithValue("@Cotizacion", textBox4.Text);
                    comando.Parameters.AddWithValue("@Estatus", textBox5.Text);
                    comando.Parameters.AddWithValue("@Fecha_Ingreso", textBox6.Text);
                    comando.Parameters.AddWithValue("@Fecha_Salida", textBox7.Text);
                    comando.ExecuteNonQuery();
                    dataGridView1.DataSource = MuestraDatos();
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            int Id_Taller = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            try
            {
                string Query = "DELETE FROM Taller WHERE Id_Taller = '" + Id_Taller + "'";
                conexion.Open();
                SqlCommand comando = new SqlCommand(Query, conexion);
                comando.ExecuteNonQuery();
                dataGridView1.DataSource = MuestraDatos();
                MessageBox.Show("Datos eliminados correctamente...");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos\n" + ex);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BusquedaDatos();
        }
    }
}
