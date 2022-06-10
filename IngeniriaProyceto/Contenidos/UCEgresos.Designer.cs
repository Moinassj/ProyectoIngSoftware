namespace IngeniriaProyceto
{
    partial class UCEgresos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TablaDatos = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.txtIva8 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombreEmisor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFolioFiscal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIva16 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaDatos
            // 
            this.TablaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaDatos.Location = new System.Drawing.Point(33, 297);
            this.TablaDatos.Name = "TablaDatos";
            this.TablaDatos.ReadOnly = true;
            this.TablaDatos.RowHeadersWidth = 51;
            this.TablaDatos.RowTemplate.Height = 24;
            this.TablaDatos.Size = new System.Drawing.Size(734, 180);
            this.TablaDatos.TabIndex = 39;
            this.TablaDatos.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TablaDatos_RowHeaderMouseClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(692, 200);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 38;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(593, 200);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 37;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(502, 268);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(33, 269);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(450, 22);
            this.txtBuscar.TabIndex = 35;
            // 
            // txtIva8
            // 
            this.txtIva8.Location = new System.Drawing.Point(611, 161);
            this.txtIva8.Name = "txtIva8";
            this.txtIva8.Size = new System.Drawing.Size(156, 22);
            this.txtIva8.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(606, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 25);
            this.label7.TabIndex = 31;
            this.label7.Text = "IVA 8%:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(395, 161);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(156, 22);
            this.txtSubtotal.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(390, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 25);
            this.label6.TabIndex = 29;
            this.label6.Text = "Subtotal:";
            // 
            // txtNombreEmisor
            // 
            this.txtNombreEmisor.Location = new System.Drawing.Point(33, 161);
            this.txtNombreEmisor.Name = "txtNombreEmisor";
            this.txtNombreEmisor.Size = new System.Drawing.Size(339, 22);
            this.txtNombreEmisor.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Nombre de los emisores";
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(611, 95);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(156, 22);
            this.txtFolio.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(606, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "Folio:";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(395, 95);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(156, 22);
            this.txtFecha.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(390, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Fecha:";
            // 
            // txtFolioFiscal
            // 
            this.txtFolioFiscal.Location = new System.Drawing.Point(33, 95);
            this.txtFolioFiscal.Name = "txtFolioFiscal";
            this.txtFolioFiscal.Size = new System.Drawing.Size(339, 22);
            this.txtFolioFiscal.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Folio Fiscal:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bodoni MT", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(351, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 47);
            this.label1.TabIndex = 20;
            this.label1.Text = "Egresos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 25);
            this.label8.TabIndex = 33;
            this.label8.Text = "IVA 16%:";
            this.label8.Visible = false;
            // 
            // txtIva16
            // 
            this.txtIva16.Location = new System.Drawing.Point(33, 225);
            this.txtIva16.Name = "txtIva16";
            this.txtIva16.Size = new System.Drawing.Size(156, 22);
            this.txtIva16.TabIndex = 34;
            this.txtIva16.Visible = false;
            // 
            // UCEgresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TablaDatos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.txtIva16);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIva8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNombreEmisor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFolioFiscal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCEgresos";
            this.Size = new System.Drawing.Size(835, 495);
            ((System.ComponentModel.ISupportInitialize)(this.TablaDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaDatos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TextBox txtIva8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombreEmisor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFolioFiscal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIva16;
    }
}
