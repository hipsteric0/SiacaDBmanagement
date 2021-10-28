
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
			this._INV_13_11_19DataSet1 = new SiacaCSAccessDatabase._INV_13_11_19DataSet();
			this.inventarioFisicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.iNV131119DataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.inventarioFisicoTableAdapter = new SiacaCSAccessDatabase._INV_13_11_19DataSetTableAdapters.InventarioFisicoTableAdapter();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this._INV_13_11_19DataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.inventarioFisicoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.iNV131119DataSet1BindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// _INV_13_11_19DataSet1
			// 
			this._INV_13_11_19DataSet1.DataSetName = "_INV_13_11_19DataSet";
			this._INV_13_11_19DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// inventarioFisicoBindingSource
			// 
			this.inventarioFisicoBindingSource.DataMember = "InventarioFisico";
			this.inventarioFisicoBindingSource.DataSource = this.iNV131119DataSet1BindingSource;
			// 
			// iNV131119DataSet1BindingSource
			// 
			this.iNV131119DataSet1BindingSource.DataSource = this._INV_13_11_19DataSet1;
			this.iNV131119DataSet1BindingSource.Position = 0;
			// 
			// inventarioFisicoTableAdapter
			// 
			this.inventarioFisicoTableAdapter.ClearBeforeFill = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(28, 81);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(851, 330);
			this.textBox1.TabIndex = 4;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.SystemColors.Control;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(28, 15);
			this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(852, 36);
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "PRECAUCIÓN! El programa solo sincronizará los cambios en la base de datos de MP u" +
    "na vez este corriendo.   Se recomienda no cerrar en ningún momento a excepción d" +
    "e un fallo.";
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.SystemColors.Control;
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox3.Location = new System.Drawing.Point(28, 58);
			this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(133, 15);
			this.textBox3.TabIndex = 6;
			this.textBox3.Text = "LOGGER:";
			// 
			// textBox4
			// 
			this.textBox4.BackColor = System.Drawing.SystemColors.Control;
			this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox4.Location = new System.Drawing.Point(28, 421);
			this.textBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(851, 15);
			this.textBox4.TabIndex = 7;
			this.textBox4.Text = "Ubicación: D:\\Users\\Administrador\\Desktop\\PROYECTO_MP_PROFIT\\log\\LOGMP.txt";
			this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(896, 450);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form2";
			this.Text = "SIACA MP Database Synchronizer";
			this.Load += new System.EventHandler(this.Form2_Load);
			((System.ComponentModel.ISupportInitialize)(this._INV_13_11_19DataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.inventarioFisicoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.iNV131119DataSet1BindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private _INV_13_11_19DataSet _INV_13_11_19DataSet1;
		private System.Windows.Forms.BindingSource iNV131119DataSet1BindingSource;
		private System.Windows.Forms.BindingSource inventarioFisicoBindingSource;
		private _INV_13_11_19DataSetTableAdapters.InventarioFisicoTableAdapter inventarioFisicoTableAdapter;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
	}
}