
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
			this.button2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
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
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(21, 19);
			this.button2.Margin = new System.Windows.Forms.Padding(2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(56, 19);
			this.button2.TabIndex = 3;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(21, 43);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(557, 311);
			this.textBox1.TabIndex = 4;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 366);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button2);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form2";
			this.Text = "Form2";
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
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox1;
	}
}