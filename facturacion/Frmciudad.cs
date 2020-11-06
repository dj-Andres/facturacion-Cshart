﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace facturacion
{
    public partial class Frmciudad : Form
    {
        OdbcConnection cnn;
        private void conexion()
        {
            cnn = new OdbcConnection("Driver={MySQL ODBC 5.2w Driver};server=localhost;uid=root;password=1234;database=facturacion2;port=3306");
            cnn.Open();
        }
        private void cadena(string sql)
        {
            conexion();
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            cargar_tabla();
        }
        private void cargar_tabla()
        {
            conexion();
            OdbcDataAdapter da = new OdbcDataAdapter("select * from ciudades", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            cnn.Close();
        }
        public Frmciudad()
        {
            InitializeComponent();
        }

        private void Frmciudad_Load(object sender, EventArgs e)
        {
            cargar_tabla();
            txtciudad.Focus();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtciudad.Text))
            {
                MessageBox.Show("Ingresar el campo");
            }
            else
            {
                cnn = new OdbcConnection("Driver={MySQL ODBC 5.2w Driver};server=localhost;uid=root;password=1234;database=facturacion2;port=3306");
                cnn.Open();
                string query;
                query = "select * from ciudades where  ciudad='" + txtciudad.Text + "'";
                OdbcCommand cmd = new OdbcCommand(query, cnn);
                cmd.ExecuteScalar();
                int n;
                n = Convert.ToInt16(cmd.ExecuteScalar());
                cnn.Close();
                if (n > 0)
                {
                    MessageBox.Show("La ciudad ya esta registrada");
                }
                else
                {
                    cadena("insert into ciudades (ciudad)values('" + txtciudad.Text.ToUpper() + "') ");
                    MessageBox.Show("La ciudad se registro correctamente");
                    txtciudad.Text = "";
                }
            }
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            //frmClientes bc = new frmClientes();
            //bc.Show();
            this.Close();
        }
    }
}
