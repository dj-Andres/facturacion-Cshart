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
    public partial class frmReporteCliente : Form
    {
        OdbcConnection cnn;
        public frmReporteCliente()
        {
            InitializeComponent();
        }
        private void conexion()
        {
            cnn = new OdbcConnection("Driver={MySQL ODBC 5.2w Driver};server=localhost;uid=root;password=1234;database=facturacion2;port=3306");
            cnn.Open(); //abrimos nuestra coneccion
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            conexion();
            OdbcDataAdapter da = new OdbcDataAdapter("select c.cedula,c.nombre,c.apellido,c.direccion,c.telefono,c.fecha_ingreso,ci.ciudad from clientes c join ciudades ci on c.Idciudad=ci.Idciudad where estado='1'", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);

            ReporteCliente mi_reporte = new ReporteCliente();
            mi_reporte.SetDataSource(ds);

            crystalReportViewer1.ReportSource = mi_reporte;
        }
    }
}
