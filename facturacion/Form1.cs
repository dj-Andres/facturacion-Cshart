using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace facturacion
{
    public partial class frmClientes : Form
    {
        private Boolean editar = false;
        OdbcConnection cnn;
        public frmClientes()
        {
            InitializeComponent();
        }
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
        private void buscar(string sql)
        {
            conexion();

            OdbcDataAdapter da = new OdbcDataAdapter(sql, cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            cnn.Close();
        }
        private void limpiar()
        {
            txtcedula.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            fecha.Text = null;
            cmbsexo.Text="";
            cmbciudad.Text = "";
            txturl.Text = "";
            pfoto.Image = null;
        }

        private void cargarcombo()
        {
            string sql;
           
            conexion();

            sql = "select Idciudad,ciudad from ciudades";

            OdbcDataAdapter da = new OdbcDataAdapter(sql, cnn);

            DataTable dt = new DataTable("ciudades");
            da.Fill(dt);
            this.cmbciudad.DataSource = dt;
            this.cmbciudad.DisplayMember = "ciudad";
            this.cmbciudad.ValueMember = "Idciudad";
            int n;
            n = Convert.ToInt16(cmbciudad.SelectedValue);

            DataRow dr = dt.NewRow();
            dr["ciudad"] = "Seleccionar";
            dr["Idciudad"] = 0;
            dt.Rows.InsertAt(dr, 0);
            cmbciudad.SelectedIndex = 0;
            //cmbciudad.SelectedItem = "Idciudad";
            cnn.Close();
        }
        private void cargar_imagen()
        {
            string sql;
            conexion();
            sql = "select foto from clientes where cedula='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'";
            OdbcDataAdapter da = new OdbcDataAdapter(sql, cnn);
            DataSet ds = new DataSet("clientes");
            da.Fill(ds, "clientes");
            byte[] datos = new byte[0];

            DataRow dr = ds.Tables["clientes"].Rows[0];
            datos = (byte[])dr["foto"];
            //MemoryStream  ms = new MemoryStream(datos);
            //pfoto.Image = Image.FromStream(ms);
            //pfoto.Image = byteArrayTolImage(datos);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(datos);
            this.pfoto.Image = System.Drawing.Bitmap.FromStream(ms);

        }
        private void cargar_tabla()
        {
            conexion();
            OdbcDataAdapter da = new OdbcDataAdapter("select c.cedula,c.nombre,c.apellido,c.direccion,c.telefono,c.sexo,c.fecha_ingreso,ci.ciudad from clientes c join ciudades ci on ci.Idciudad=c.Idciudad ", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            cnn.Close();
        }
        private void cargar_activos()
        {
            conexion();
            OdbcDataAdapter da = new OdbcDataAdapter("select c.cedula,c.nombre,c.apellido,c.direccion,c.telefono,c.sexo,c.fecha_ingreso,ci.ciudad from clientes c join ciudades ci on ci.Idciudad=c.Idciudad where estado='1' ", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            cnn.Close();
        }
        private void cargar_desabilitado()
        {
            conexion();
            OdbcDataAdapter da = new OdbcDataAdapter("select c.cedula,c.nombre,c.apellido,c.direccion,c.telefono,c.sexo,c.fecha_ingreso,ci.ciudad from clientes c join ciudades ci on ci.Idciudad=c.Idciudad where estado='0'", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            cnn.Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cargar_tabla();
            cancelado();
            rdtodos.Checked = true;
            cargarcombo();
            txturl.Visible = false;
        }
        private void cancelado()
        {
            txtcedula.Enabled = false;
            txtnombre.Enabled = false;
            txtapellido.Enabled = false;
            txtdireccion.Enabled = false;
            txttelefono.Enabled = false;
            fecha.Enabled = false;
            cmbsexo.Enabled = false;
            cmbciudad.Enabled = false;
            btnsubirFOTO.Enabled = false;
            btnciudad.Enabled = false;
            btnnuevo.Enabled = true;
            btnmodificar.Enabled = false;
            btnestado.Enabled = false;
            btnguardar.Enabled = false;
            btncancelar.Enabled = false;
        }
        private void nuevo()
        {
            txtcedula.Enabled = true;
            txtnombre.Enabled = true;
            txtapellido.Enabled = true;
            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
            fecha.Enabled = true;
            cmbsexo.Enabled = true;
            cmbciudad.Enabled = true;
            btnsubirFOTO.Enabled = true;
            btnciudad.Enabled = true;
            btnnuevo.Enabled = false;
            btnmodificar.Enabled = false;
            btnestado.Enabled = false;
            btnguardar.Enabled = true;
            btncancelar.Enabled = true;
        }
        private void modificar()
        {
            txtcedula.Enabled = true;
            txtnombre.Enabled = true;
            txtapellido.Enabled = true;
            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
            fecha.Enabled = true;
            cmbsexo.Enabled = true;
            cmbciudad.Enabled = true;
            btnsubirFOTO.Enabled = true;
            btnciudad.Enabled = true;
            btnnuevo.Enabled = false;
            btnmodificar.Enabled = true;
            btnestado.Enabled = false;
            btnguardar.Enabled = false;
            btncancelar.Enabled = true;
        }
        private void estado()
        {
            txtcedula.Enabled = true;
            txtnombre.Enabled = true;
            txtapellido.Enabled = true;
            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
            fecha.Enabled = true;
            cmbsexo.Enabled = true;
            cmbciudad.Enabled = true;
            btnsubirFOTO.Enabled = true;
            btnciudad.Enabled = true;
            btnnuevo.Enabled = false;
            btnmodificar.Enabled = false;
            btnestado.Enabled = true;
            btnguardar.Enabled = false;
            btncancelar.Enabled = true;
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string cedula;
            int total;
            int tamañocedula;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int numeroProvincia, Provincia, digitoTres, DigitoVerificadorRecibido, Valor, DigitoVerficadorObtenido;
            int tercerDigito;
            int numeric;

            cedula = txtcedula.Text;
            total = 0;
            tamañocedula = 10;
            numeroProvincia = 24;
            tercerDigito = 6;
            if (int.TryParse(cedula, out numeric) && cedula.Length == tamañocedula)
            {
                Provincia = Convert.ToInt32(string.Concat(cedula[0], cedula[1], string.Empty));
                digitoTres = Convert.ToInt32(cedula[2] + string.Empty);
                if ((Provincia > 0 && Provincia <= numeroProvincia) && digitoTres < tercerDigito)
                {
                    DigitoVerificadorRecibido = Convert.ToInt32(cedula[9] + string.Empty);
                    for (int k = 0; k < coeficientes.Length; k++)
                    {
                        Valor = Convert.ToInt32(coeficientes[k] + string.Empty) * Convert.ToInt32(cedula[k] + string.Empty);
                        total = Valor >= 10 ? total + (Valor - 9) : total + Valor;
                    }
                    DigitoVerficadorObtenido = total >= 10 ? (total % 10) != 0 ? 10 - (total % 10) : (total % 10) : total;
                    //DigitoVerficadorObtenido = DigitoVerificadorRecibido;
                    if (DigitoVerficadorObtenido == DigitoVerificadorRecibido)
                    {
                        //MessageBox.Show ("cedula valida");

                        if (string.IsNullOrEmpty(txturl.Text) || string.IsNullOrEmpty(txtcedula.Text) || string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtapellido.Text) || string.IsNullOrEmpty(txtdireccion.Text) || string.IsNullOrEmpty(txttelefono.Text) || string.IsNullOrEmpty(fecha.Text) || string.IsNullOrEmpty(cmbsexo.Text) || string.IsNullOrEmpty(cmbciudad.Text))
                        {
                            MessageBox.Show( "Llenar todos los campos","Gestión Clientes",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            conexion();
                            string query;
                            query = "select * from clientes where cedula='" + txtcedula.Text + "'";
                            OdbcCommand cmd = new OdbcCommand(query, cnn);
                            cmd.ExecuteScalar();

                            int n;
                            n = Convert.ToInt16(cmd.ExecuteScalar());
                            cnn.Close();

                            if (n > 0)
                            {
                                MessageBox.Show ( "El  Usuario ya esta ingresado");
                            }
                            else
                            {
                                string sexo;
                                if (cmbsexo.Text == "FEMENINO")
                                {
                                    sexo = "FEMENINO";
                                    cmbsexo.Text = sexo;
                                }
                                else if (cmbsexo.Text == "MASCULINO")
                                {
                                    sexo = "MASCULINO";
                                    cmbsexo.Text = sexo;
                                }
                                    cadena("insert into clientes(cedula,nombre,apellido,direccion,telefono,sexo,fecha_ingreso,estado,foto,Idciudad)values('" + txtcedula.Text + "','" + txtnombre.Text.ToUpper() + "','" + txtapellido.Text.ToUpper() + "','" + txtdireccion.Text.ToUpper() + "','" + txttelefono.Text + "','" + cmbsexo.Text + "','" + fecha.Text + "','1','" + txturl.Text + "','" + cmbciudad.SelectedIndex.ToString() + "')");
                                    //cadena("insert into clientes(cedula,nombre,apellido,direccion,telefono,sexo,fecha_ingreso,estado,Idciudad)values('" + txtcedula.Text + "','" + txtnombre.Text.ToUpper() + "','" + txtapellido.Text.ToUpper() + "','" + txtdireccion.Text.ToUpper() + "','" + txttelefono.Text + "','" + cmbsexo.Text + "','" + fecha.Text + "','D','" + cmbciudad.SelectedText + "')");
                                    //cadena("insert into clientes(cedula,nombre,apellido,direccion,telefono,sexo,fecha_ingreso,estado,Idciudad)values('" + txtcedula.Text + "','" + txtnombre.Text.ToUpper() + "','" + txtapellido.Text.ToUpper() + "','" + txtdireccion.Text.ToUpper() + "','" + txttelefono.Text + "','" + cmbsexo.Text + "','" + fecha.Text + "','D','" + cmbciudad.SelectedItem+ "')");
                                    MessageBox.Show("Datos correctamente ingresados","Gestión Clientes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    //cadena("insert into productos (nombre_producto) values('" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString() + "')");
                                    limpiar();
                                    cancelado();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("cedula invalida", "Gestión Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else { MessageBox.Show("Numero de provincia incorrecto", "Gestión Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            else { MessageBox.Show("Ingrese un nuemro de cedula", "Gestión Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rdtodos.Checked==true)
            {
                editar = true;
                
                modificar();
                txtcedula.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtnombre.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                txtapellido.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                txtdireccion.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                txttelefono.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                cmbsexo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
                fecha.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
                cmbciudad.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
                cargar_imagen();
            }
            else
            {
                if (rdDesabilitar.Checked == true || rdhablitar.Checked == true)
                    
                    editar = false;

                    estado();
                    txtcedula.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                    txtnombre.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                    txtapellido.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                    txtdireccion.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    txttelefono.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                    cmbsexo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
                    fecha.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
                    cmbciudad.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
            }
        }

        private void btnciudad_Click(object sender, EventArgs e)
        {
            Frmciudad bc = new Frmciudad();
            bc.ShowDialog();
            cargarcombo();
        }
        private void btnsubirFOTO_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "Archivo JPEG(*.JPG)|*.JPG|BMP(*.BMP)|*.BMP";

            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                pfoto.Image = Image.FromFile(BuscarImagen.FileName);
            }
            txturl.Text = BuscarImagen.FileName;
        }

        private void rdDesabilitar_CheckedChanged(object sender, EventArgs e)
        {
            cargar_desabilitado();
            btnestado.Text = "Hablitar";
        }

        private void rdtodos_CheckedChanged(object sender, EventArgs e)
        {
            cargar_tabla();   
        }

        private void rdhablitar_CheckedChanged(object sender, EventArgs e)
        {
            cargar_activos();
            btnestado.Text = "Desabilitar";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //modificar();
            cadena("update clientes set cedula='" + txtcedula.Text + "',nombre='" + txtnombre.Text.ToUpper() + "',apellido='" + txtapellido.Text.ToUpper() + "',direccion='" + txtdireccion.Text.ToUpper() + "',telefono='" + txttelefono.Text + "',sexo='" + cmbsexo.Text + "',fecha_ingreso='" + fecha.Text + "',foto='" + txturl.Text + "',Idciudad='" + cmbciudad.SelectedIndex.ToString() + "' where cedula='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'");
            MessageBox.Show("Datos correctamente actualizados","Gestión Clientes",MessageBoxButtons.OK,MessageBoxIcon.Information);
            limpiar();
        }

        private void btnestado_Click(object sender, EventArgs e)
        {
            
            string cedula;
            cedula = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            if (rdhablitar.Checked==true)
            {
                
                if (MessageBox.Show("Desea desahabilitar el cliente", "Gestión de Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1)==DialogResult.Yes)
                {
                    //estado();
                    cadena("update clientes set estado='0' where cedula='" + cedula + "'");
                    cargar_activos();
                    limpiar();
                    rdtodos.Checked = true;
                }
            }
            else
            {
                if (rdDesabilitar.Checked==true)
                {
                    if (MessageBox.Show("Desea habilitar el cliente", "Gestión de Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //estado();
                        cadena("update clientes set estado='1' where cedula='" + cedula + "'");
                        cargar_desabilitado();
                        limpiar();
                        rdtodos.Checked = true;
                    }   
                }
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (rdhablitar.Checked==true)
            {
                buscar("select c.cedula,c.nombre,c.apellido,c.direccion,c.telefono,c.sexo,c.fecha_ingreso,ci.ciudad from clientes c join ciudades ci on ci.Idciudad=c.Idciudad where cedula like'" + txtbuscar.Text + "%' or nombre like'" + txtbuscar.Text + "%' or apellido like'" + txtbuscar.Text + "%' and estado='1'");
            }
            if (rdDesabilitar.Checked==true)
            {
                buscar("select c.cedula,c.nombre,c.apellido,c.direccion,c.telefono,c.sexo,c.fecha_ingreso,ci.ciudad from clientes c join ciudades ci on ci.Idciudad=c.Idciudad where cedula like'" + txtbuscar.Text + "%' or nombre like'" + txtbuscar.Text + "%' or apellido like'" + txtbuscar.Text + "%' and estado='0'");
            }
            if (rdtodos.Checked==true)
            {
                buscar("select c.cedula,c.nombre,c.apellido,c.direccion,c.telefono,c.sexo,c.fecha_ingreso,ci.ciudad from clientes c join ciudades ci on ci.Idciudad=c.Idciudad where cedula like'" + txtbuscar.Text + "%' or nombre like'" + txtbuscar.Text + "%' or apellido like'" + txtbuscar.Text + "%'");
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            cancelado();
            limpiar();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Modificar el cliente", "Gestión de Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                txtcedula.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtnombre.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                txtapellido.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                txtdireccion.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                txttelefono.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                cmbsexo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
                fecha.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
                cmbciudad.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
                modificar();
            }
        }

        private void btnreporte_Click(object sender, EventArgs e)
        {
            frmReporteCliente reporte = new frmReporteCliente();
            reporte.Show();
        }
        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                 else
                  {
                      e.Handled = true;
                  }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
        }

        private void txtapellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtdireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = String.Format("{0:HH:mm:ss}", DateTime.Now);
        }

    }
}
