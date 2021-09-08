
namespace SiacaCSAccessDatabase
{
	partial class Form2
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
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this._INV_13_11_19DataSet1 = new SiacaCSAccessDatabase._INV_13_11_19DataSet();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.iNV131119DataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.inventarioFisicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.inventarioFisicoTableAdapter = new SiacaCSAccessDatabase._INV_13_11_19DataSetTableAdapters.InventarioFisicoTableAdapter();
			this.tIPOINVENTARIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iDALMACENDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iDPRODUCTOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iDPROVEEDORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cANTIDADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cOSTOUNITARIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uLTIMOCOSTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sUBTOTALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dIFERENCIADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.eXISTENCIASDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this._INV_13_11_19DataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.iNV131119DataSet1BindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.inventarioFisicoBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 23);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// _INV_13_11_19DataSet1
			// 
			this._INV_13_11_19DataSet1.DataSetName = "_INV_13_11_19DataSet";
			this._INV_13_11_19DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tIPOINVENTARIODataGridViewTextBoxColumn,
            this.iDALMACENDataGridViewTextBoxColumn,
            this.iDPRODUCTOSDataGridViewTextBoxColumn,
            this.iDPROVEEDORDataGridViewTextBoxColumn,
            this.cANTIDADDataGridViewTextBoxColumn,
            this.cOSTOUNITARIODataGridViewTextBoxColumn,
            this.uLTIMOCOSTODataGridViewTextBoxColumn,
            this.sUBTOTALDataGridViewTextBoxColumn,
            this.dIFERENCIADataGridViewTextBoxColumn,
            this.eXISTENCIASDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.inventarioFisicoBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 77);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(763, 301);
			this.dataGridView1.TabIndex = 2;
			// 
			// iNV131119DataSet1BindingSource
			// 
			this.iNV131119DataSet1BindingSource.DataSource = this._INV_13_11_19DataSet1;
			this.iNV131119DataSet1BindingSource.Position = 0;
			// 
			// inventarioFisicoBindingSource
			// 
			this.inventarioFisicoBindingSource.DataMember = "InventarioFisico";
			this.inventarioFisicoBindingSource.DataSource = this.iNV131119DataSet1BindingSource;
			// 
			// inventarioFisicoTableAdapter
			// 
			this.inventarioFisicoTableAdapter.ClearBeforeFill = true;
			// 
			// tIPOINVENTARIODataGridViewTextBoxColumn
			// 
			this.tIPOINVENTARIODataGridViewTextBoxColumn.DataPropertyName = "TIPOINVENTARIO";
			this.tIPOINVENTARIODataGridViewTextBoxColumn.HeaderText = "TIPOINVENTARIO";
			this.tIPOINVENTARIODataGridViewTextBoxColumn.MinimumWidth = 6;
			this.tIPOINVENTARIODataGridViewTextBoxColumn.Name = "tIPOINVENTARIODataGridViewTextBoxColumn";
			this.tIPOINVENTARIODataGridViewTextBoxColumn.Width = 125;
			// 
			// iDALMACENDataGridViewTextBoxColumn
			// 
			this.iDALMACENDataGridViewTextBoxColumn.DataPropertyName = "ID_ALMACEN";
			this.iDALMACENDataGridViewTextBoxColumn.HeaderText = "ID_ALMACEN";
			this.iDALMACENDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iDALMACENDataGridViewTextBoxColumn.Name = "iDALMACENDataGridViewTextBoxColumn";
			this.iDALMACENDataGridViewTextBoxColumn.Width = 125;
			// 
			// iDPRODUCTOSDataGridViewTextBoxColumn
			// 
			this.iDPRODUCTOSDataGridViewTextBoxColumn.DataPropertyName = "ID_PRODUCTOS";
			this.iDPRODUCTOSDataGridViewTextBoxColumn.HeaderText = "ID_PRODUCTOS";
			this.iDPRODUCTOSDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iDPRODUCTOSDataGridViewTextBoxColumn.Name = "iDPRODUCTOSDataGridViewTextBoxColumn";
			this.iDPRODUCTOSDataGridViewTextBoxColumn.Width = 125;
			// 
			// iDPROVEEDORDataGridViewTextBoxColumn
			// 
			this.iDPROVEEDORDataGridViewTextBoxColumn.DataPropertyName = "ID_PROVEEDOR";
			this.iDPROVEEDORDataGridViewTextBoxColumn.HeaderText = "ID_PROVEEDOR";
			this.iDPROVEEDORDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iDPROVEEDORDataGridViewTextBoxColumn.Name = "iDPROVEEDORDataGridViewTextBoxColumn";
			this.iDPROVEEDORDataGridViewTextBoxColumn.Width = 125;
			// 
			// cANTIDADDataGridViewTextBoxColumn
			// 
			this.cANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD";
			this.cANTIDADDataGridViewTextBoxColumn.HeaderText = "CANTIDAD";
			this.cANTIDADDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.cANTIDADDataGridViewTextBoxColumn.Name = "cANTIDADDataGridViewTextBoxColumn";
			this.cANTIDADDataGridViewTextBoxColumn.Width = 125;
			// 
			// cOSTOUNITARIODataGridViewTextBoxColumn
			// 
			this.cOSTOUNITARIODataGridViewTextBoxColumn.DataPropertyName = "COSTO_UNITARIO";
			this.cOSTOUNITARIODataGridViewTextBoxColumn.HeaderText = "COSTO_UNITARIO";
			this.cOSTOUNITARIODataGridViewTextBoxColumn.MinimumWidth = 6;
			this.cOSTOUNITARIODataGridViewTextBoxColumn.Name = "cOSTOUNITARIODataGridViewTextBoxColumn";
			this.cOSTOUNITARIODataGridViewTextBoxColumn.Width = 125;
			// 
			// uLTIMOCOSTODataGridViewTextBoxColumn
			// 
			this.uLTIMOCOSTODataGridViewTextBoxColumn.DataPropertyName = "ULTIMO_COSTO";
			this.uLTIMOCOSTODataGridViewTextBoxColumn.HeaderText = "ULTIMO_COSTO";
			this.uLTIMOCOSTODataGridViewTextBoxColumn.MinimumWidth = 6;
			this.uLTIMOCOSTODataGridViewTextBoxColumn.Name = "uLTIMOCOSTODataGridViewTextBoxColumn";
			this.uLTIMOCOSTODataGridViewTextBoxColumn.Width = 125;
			// 
			// sUBTOTALDataGridViewTextBoxColumn
			// 
			this.sUBTOTALDataGridViewTextBoxColumn.DataPropertyName = "SUB_TOTAL";
			this.sUBTOTALDataGridViewTextBoxColumn.HeaderText = "SUB_TOTAL";
			this.sUBTOTALDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.sUBTOTALDataGridViewTextBoxColumn.Name = "sUBTOTALDataGridViewTextBoxColumn";
			this.sUBTOTALDataGridViewTextBoxColumn.Width = 125;
			// 
			// dIFERENCIADataGridViewTextBoxColumn
			// 
			this.dIFERENCIADataGridViewTextBoxColumn.DataPropertyName = "DIFERENCIA";
			this.dIFERENCIADataGridViewTextBoxColumn.HeaderText = "DIFERENCIA";
			this.dIFERENCIADataGridViewTextBoxColumn.MinimumWidth = 6;
			this.dIFERENCIADataGridViewTextBoxColumn.Name = "dIFERENCIADataGridViewTextBoxColumn";
			this.dIFERENCIADataGridViewTextBoxColumn.Width = 125;
			// 
			// eXISTENCIASDataGridViewTextBoxColumn
			// 
			this.eXISTENCIASDataGridViewTextBoxColumn.DataPropertyName = "EXISTENCIAS";
			this.eXISTENCIASDataGridViewTextBoxColumn.HeaderText = "EXISTENCIAS";
			this.eXISTENCIASDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.eXISTENCIASDataGridViewTextBoxColumn.Name = "eXISTENCIASDataGridViewTextBoxColumn";
			this.eXISTENCIASDataGridViewTextBoxColumn.Width = 125;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(636, 23);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button1);
			this.Name = "Form2";
			this.Text = "Form2";
			this.Load += new System.EventHandler(this.Form2_Load);
			((System.ComponentModel.ISupportInitialize)(this._INV_13_11_19DataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.iNV131119DataSet1BindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.inventarioFisicoBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private _INV_13_11_19DataSet _INV_13_11_19DataSet1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource iNV131119DataSet1BindingSource;
		private System.Windows.Forms.BindingSource inventarioFisicoBindingSource;
		private _INV_13_11_19DataSetTableAdapters.InventarioFisicoTableAdapter inventarioFisicoTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn tIPOINVENTARIODataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDALMACENDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDPRODUCTOSDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDPROVEEDORDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cANTIDADDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cOSTOUNITARIODataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn uLTIMOCOSTODataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn sUBTOTALDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dIFERENCIADataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn eXISTENCIASDataGridViewTextBoxColumn;
		private System.Windows.Forms.Button button2;
	}
}