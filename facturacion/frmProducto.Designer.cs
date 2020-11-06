namespace facturacion
{
    partial class frmProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.GProducto = new System.Windows.Forms.DataGridView();
            this.btnmedida = new System.Windows.Forms.Button();
            this.btnpresentacion = new System.Windows.Forms.Button();
            this.btnagegar = new System.Windows.Forms.Button();
            this.txtventa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtunitario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMedida = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPresentacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtproducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GProducto)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.GProducto);
            this.panel1.Controls.Add(this.btnmedida);
            this.panel1.Controls.Add(this.btnpresentacion);
            this.panel1.Controls.Add(this.btnagegar);
            this.panel1.Controls.Add(this.txtventa);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtunitario);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtcantidad);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbMedida);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbPresentacion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtproducto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(23, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 263);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // GProducto
            // 
            this.GProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GProducto.Location = new System.Drawing.Point(34, 117);
            this.GProducto.Name = "GProducto";
            this.GProducto.Size = new System.Drawing.Size(484, 121);
            this.GProducto.TabIndex = 18;
            // 
            // btnmedida
            // 
            this.btnmedida.Location = new System.Drawing.Point(325, 74);
            this.btnmedida.Name = "btnmedida";
            this.btnmedida.Size = new System.Drawing.Size(39, 23);
            this.btnmedida.TabIndex = 17;
            this.btnmedida.Text = "agg";
            this.btnmedida.UseVisualStyleBackColor = true;
            this.btnmedida.Click += new System.EventHandler(this.btnmedida_Click);
            // 
            // btnpresentacion
            // 
            this.btnpresentacion.Location = new System.Drawing.Point(153, 76);
            this.btnpresentacion.Name = "btnpresentacion";
            this.btnpresentacion.Size = new System.Drawing.Size(39, 23);
            this.btnpresentacion.TabIndex = 16;
            this.btnpresentacion.Text = "agg";
            this.btnpresentacion.UseVisualStyleBackColor = true;
            this.btnpresentacion.Click += new System.EventHandler(this.btnpresentacion_Click);
            // 
            // btnagegar
            // 
            this.btnagegar.Location = new System.Drawing.Point(734, 28);
            this.btnagegar.Name = "btnagegar";
            this.btnagegar.Size = new System.Drawing.Size(75, 23);
            this.btnagegar.TabIndex = 15;
            this.btnagegar.Text = "Agregar";
            this.btnagegar.UseVisualStyleBackColor = true;
            this.btnagegar.Click += new System.EventHandler(this.btnagegar_Click_1);
            // 
            // txtventa
            // 
            this.txtventa.Location = new System.Drawing.Point(641, 77);
            this.txtventa.Name = "txtventa";
            this.txtventa.Size = new System.Drawing.Size(100, 20);
            this.txtventa.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(638, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Costo Venta";
            // 
            // txtunitario
            // 
            this.txtunitario.Location = new System.Drawing.Point(513, 77);
            this.txtunitario.Name = "txtunitario";
            this.txtunitario.Size = new System.Drawing.Size(100, 20);
            this.txtunitario.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Costo Unitario";
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(387, 76);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(100, 20);
            this.txtcantidad.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cantidad";
            // 
            // cmbMedida
            // 
            this.cmbMedida.FormattingEnabled = true;
            this.cmbMedida.Location = new System.Drawing.Point(198, 77);
            this.cmbMedida.Name = "cmbMedida";
            this.cmbMedida.Size = new System.Drawing.Size(121, 21);
            this.cmbMedida.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Unidad Medida";
            // 
            // cmbPresentacion
            // 
            this.cmbPresentacion.FormattingEnabled = true;
            this.cmbPresentacion.Location = new System.Drawing.Point(25, 77);
            this.cmbPresentacion.Name = "cmbPresentacion";
            this.cmbPresentacion.Size = new System.Drawing.Size(121, 21);
            this.cmbPresentacion.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Presentación";
            // 
            // txtproducto
            // 
            this.txtproducto.Location = new System.Drawing.Point(86, 14);
            this.txtproducto.Name = "txtproducto";
            this.txtproducto.Size = new System.Drawing.Size(251, 20);
            this.txtproducto.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Producto";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnmodificar);
            this.panel2.Controls.Add(this.btnguardar);
            this.panel2.Location = new System.Drawing.Point(887, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(117, 330);
            this.panel2.TabIndex = 1;
            // 
            // btnmodificar
            // 
            this.btnmodificar.Location = new System.Drawing.Point(20, 140);
            this.btnmodificar.Name = "btnmodificar";
            this.btnmodificar.Size = new System.Drawing.Size(75, 23);
            this.btnmodificar.TabIndex = 1;
            this.btnmodificar.Text = "Modificar";
            this.btnmodificar.UseVisualStyleBackColor = true;
            this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(20, 90);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(75, 23);
            this.btnguardar.TabIndex = 0;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(23, 282);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(817, 230);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(493, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(484, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Buscar";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(566, 195);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 19;
            // 
            // frmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 524);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmProducto";
            this.Load += new System.EventHandler(this.frmProducto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GProducto)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbMedida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPresentacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtproducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtventa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtunitario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnagegar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnpresentacion;
        private System.Windows.Forms.Button btnmedida;
        private System.Windows.Forms.DataGridView GProducto;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.TextBox txtID;
    }
}