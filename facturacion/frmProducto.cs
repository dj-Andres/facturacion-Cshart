using System;
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
    public partial class frmProducto : Form
    {
        OdbcConnection cnn;
        OdbcConnection cn;
        
        public frmProducto()
        {
            InitializeComponent();
        }
        private void conexion()
        {
            cnn = new OdbcConnection("Driver={MySQL ODBC 5.2w Driver};server=localhost;uid=root;password=1234;database=facturacion2;port=3306");
            cnn.Open(); 
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void cargar_comboPresentacion()
        {
         
        
            string sql;
           
            conexion();

            sql = "select Id_tpresentacion,presentacion from tipo_presentacion";

            OdbcDataAdapter da = new OdbcDataAdapter(sql, cnn);

            DataTable dt = new DataTable("tipo_presentacion");
            da.Fill(dt);
            this.cmbPresentacion.DataSource = dt;
            this.cmbPresentacion.DisplayMember = "presentacion";
            this.cmbPresentacion.ValueMember = "Id_tpresentacion";
            int n;
            n = Convert.ToInt16(cmbPresentacion.SelectedValue);

            DataRow dr = dt.NewRow();
            dr["presentacion"] = "Seleccionar";
            dr["Id_tpresentacion"] = 0;
            dt.Rows.InsertAt(dr, 0);
            cmbPresentacion.SelectedIndex = 0;
            cnn.Close();
        
        }
        private void cargar_comboMedida()
        {
            string sql;

            conexion();

            sql = "select Idunidad,medida from unidad_medida";

            OdbcDataAdapter da = new OdbcDataAdapter(sql, cnn);
            
            DataTable dt = new DataTable("unidad_medida");
            da.Fill(dt);
            this.cmbMedida.DataSource = dt;
            this.cmbMedida.DisplayMember = "medida";
            this.cmbMedida.ValueMember = "Idunidad";
            int n;
            n = Convert.ToInt16(cmbMedida.SelectedValue);

            DataRow dr = dt.NewRow();
            dr["medida"] = "Seleccionar";
            dr["Idunidad"] = 0;
            dt.Rows.InsertAt(dr, 0);
            cmbMedida.SelectedIndex = 0;
            cnn.Close();
        }
        
        private void frmProducto_Load(object sender, EventArgs e)
        {
            txtID.Visible = false;
            cofigurarGrid();
            cargar_tabla();
            cargar_comboPresentacion();
            cargar_comboMedida();
        }
        private void cofigurarGrid()
        {
            
            GProducto.Columns.Add("Presentacion", "Presentacion");
            GProducto.Columns.Add("Unidad_Medida", "Unidad_Medida");
            GProducto.Columns.Add("Cantidad", "Cantidad");
            GProducto.Columns.Add("Precio_Unitario", "Precio_Unitario");
            GProducto.Columns.Add("Precio_Venta", "Precio_Venta");
        }
        private void cargar_tabla()
        {
            conexion();
            OdbcDataAdapter da = new OdbcDataAdapter("select pp.Idpresentacion,pp.producto,t.presentacion,m.medida,pp.valor_unidad as cantidad,pp.costo_unitario as precio_unitario,pp.precio_unitario as precio_venta from  presentacion_producto pp  join tipo_presentacion t on t.Id_tpresentacion=pp.Id_tpresentacion join unidad_medida m on m.Idunidad=pp.Idunidad", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            cnn.Close();
        }
        private void cadena(string sql)
        {
            conexion();
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            cargar_tabla();
        }
        private void btnagegar_Click(object sender, EventArgs e)
        {
            //GProducto.Rows.Add(txtproducto.Text);   
        }

        private void btnagegar_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtproducto.Text)||string.IsNullOrWhiteSpace(cmbPresentacion.Text)||string.IsNullOrWhiteSpace(cmbMedida.Text)||string.IsNullOrWhiteSpace(txtcantidad.Text)||string.IsNullOrWhiteSpace(txtunitario.Text)||string.IsNullOrWhiteSpace(txtventa.Text))
            {
                MessageBox.Show( "Llenar todos los campos","Gestión de Productos",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {

                GProducto.Rows.Add(cmbPresentacion.SelectedIndex.ToString(), cmbMedida.SelectedIndex.ToString(), txtcantidad.Text, txtunitario.Text, txtventa.Text);
                
            }
            
        }

        private void btnpresentacion_Click(object sender, EventArgs e)
        {
            frmPresentacion presentacion = new frmPresentacion();
            presentacion.ShowDialog();
            cargar_comboPresentacion();
        }

        private void btnmedida_Click(object sender, EventArgs e)
        {
            frmMedida medida = new frmMedida();
            medida.ShowDialog();
            cargar_comboMedida();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            conexion();

            string sql;
            sql = "select * from presentacion_producto where producto='" + txtproducto.Text + "'";
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            cmd.ExecuteScalar();
            
            int n;
            n=Convert.ToInt16(cmd.ExecuteScalar());
            cnn.Close();
            if (n > 0)
            {
                MessageBox.Show("El producto ya se encuentra registrado");
            }
            else
            {
                //cadena("insert into productos (productos)values('"+txtproducto.Text.ToUpper()+"') ");
                //dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()
                cadena("insert into presentacion_producto (producto,Id_tpresentacion,Idunidad,valor_unidad,costo_unitario,precio_unitario)values('" + txtproducto.Text.ToUpper() + "','" + GProducto.Rows[GProducto.CurrentRow.Index].Cells[0].Value.ToString() + "','" + GProducto.Rows[GProducto.CurrentRow.Index].Cells[1].Value.ToString() + "','" + GProducto.Rows[GProducto.CurrentRow.Index].Cells[2].Value.ToString() + "','" + GProducto.Rows[GProducto.CurrentRow.Index].Cells[3].Value.ToString() + "','" + GProducto.Rows[GProducto.CurrentRow.Index].Cells[4].Value.ToString() + "')");
                MessageBox.Show("se registro");
            }
            

        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            cadena("update presentacion_producto set producto='" + txtproducto.Text.ToUpper() + "',Id_tpresentacion='"+cmbPresentacion.SelectedIndex.ToString()+"',Idunidad='"+cmbMedida.SelectedIndex.ToString()+"',valor_unidad='"+txtcantidad.Text+"',costo_unitario='"+txtunitario.Text+"',precio_unitario='"+txtventa.Text+"' where Idpresentacion='"+dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()+"'");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            txtproducto.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            cmbPresentacion.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            cmbMedida.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            txtcantidad.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            txtunitario.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            txtventa.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
        }
        
    }
}
