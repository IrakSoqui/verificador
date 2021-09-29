using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeReader
{
    public partial class Form1 : Form
    {
        char x;
        String ca = "";
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            x = e.KeyChar;
            ca = ca + x;

            //label3.Text = ca;

            /*if (ca.Length == 4)
            {
                label3.Text = ca;
                ca = "";
            }*/

            if (e.KeyChar == (char)Keys.Enter)
            {
                ejecutarConsulta(ca);
            }
            if (e.KeyChar == (char)Keys.End)
            {
                ca = "";
            }

        }

        public void ejecutarConsulta(String codigo)
        {
            String x = "", img="";
            string cadenaConexion = "server=127.0.0.1; user=root; database=productos; SSL Mode=None;";

            MySqlConnection servidor = new MySqlConnection(cadenaConexion);
            try
            {
                servidor.Open();

                string cons = "SELECT producto_nombre, producto_precio, producto_stock, producto_imagen FROM productos WHERE producto_codigo =" + codigo + ";";
                

                MySqlCommand consulta = new MySqlCommand(cons, servidor);

                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.HasRows)
                {
                    //MessageBox.Show("Jala");
                    resultado.Read();
                    x = "Nombre: " + resultado.GetString(0) + Environment.NewLine + "Precio: " + resultado.GetString(1)+Environment.NewLine + "Cantidad: " + resultado.GetString(2);
                    img = resultado.GetString(3);
                    ventanaDatos(x, img);
                }
                else
                {
                    //MessageBox.Show("Error, solicite apoyo del personal encargado");
                    ventanaError();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "e", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        public void ventanaDatos(string info, string img)
        {
            Form2 v2 = new Form2(info, img);
            v2.Show();
            this.Hide();
        }
        public void ventanaError() {

            Form v3 = new Form3();
            v3.Show();
            
            this.Hide();

        }

        

    }
}
