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
    public partial class UCRendimiento : UserControl
    {
        //Conexion a la base de datos (Para poder utilizarlo en su pc cambio el server por el suyo de sql server)   
        SqlConnection conexion = new SqlConnection("server = localhost\\SQLEXPRESS; database=ProyectoVL; integrated security=true");
        int rowModifcar;
        public UCRendimiento()
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
            string QueryMuestra = "Select * from Rendimiento";
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
                string QueryMuestra = "SELECT * FROM Rendimiento";
                SqlCommand cmd = new SqlCommand(QueryMuestra, conexion);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                return tabla;
            }
            else
            {
                string QueryMuestra = "SELECT * FROM Rendimiento WHERE NombreReceptor LIKE '" + textBox8.Text + "' ";
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
            textBox3.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
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
                    string QueryMod = "UPDATE Rendimiento SET Km_Recorridos = @Km_Recorridos, Litros = @Litros, Consumo_Promedio = @Consumo_Promedio, Precio = @Precio WHERE Id_Rendimiento = @Id_Rendimiento";
                    conexion.Open();
                    SqlCommand comandoMod = new SqlCommand(QueryMod, conexion);
                    comandoMod.Parameters.AddWithValue("@Km_Recorridos", textBox1.Text);
                    comandoMod.Parameters.AddWithValue("@Litros", textBox2.Text);
                    comandoMod.Parameters.AddWithValue("@Consumo_Promedio", textBox3.Text);
                    comandoMod.Parameters.AddWithValue("@Precio", textBox4.Text);
                    comandoMod.Parameters.AddWithValue("@Id_Rendimiento", rowModifcar.ToString());

                    comandoMod.ExecuteNonQuery();
                    dataGridView1.DataSource = MuestraDatos();
                    MessageBox.Show("Modificado correctamente");
                    rowModifcar = 0;
                }
                else
                {
                    //Insertar en una tabla
                    string Query = "INSERT INTO Rendimiento (Km_Recorridos, Litros, Consumo_Promedio, Precio) VALUES 	(@Km_Recorridos, @Litros, @Consumo_Promedio, @Precio)";
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(Query, conexion);
                    comando.Parameters.AddWithValue("@Km_Recorridos", textBox1.Text);
                    comando.Parameters.AddWithValue("@Litros", textBox2.Text);
                    comando.Parameters.AddWithValue("@Consumo_Promedio", textBox3.Text);
                    comando.Parameters.AddWithValue("@Precio", textBox4.Text);
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
            int Id_Rendimiento = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            try
            {
                string Query = "DELETE FROM Rendimiento WHERE Id_Rendimiento = '" + Id_Rendimiento + "'";
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
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            else
            {
                Limpiar();
            }
        }
    }
}
