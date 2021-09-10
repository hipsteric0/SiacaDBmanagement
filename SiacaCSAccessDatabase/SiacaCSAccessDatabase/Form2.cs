using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//POR HACER:
//editar tabla inventarioFisico
//Insertar en tabla CatProductos
//editar tabla catProductos
//consultar en sql server
//enviar desde sql server a access los datos a insertar/editar
//los vales (PREGUNTAR EN SIACA)
//obtener la BD de siaca de PROFIT (sqlserver)

namespace SiacaCSAccessDatabase
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the '_INV_13_11_19DataSet1.InventarioFisico' table. You can move, or remove it, as needed.
			this.inventarioFisicoTableAdapter.Fill(this._INV_13_11_19DataSet1.InventarioFisico);
			inventarioFisicoBindingSource.DataSource = this._INV_13_11_19DataSet1.InventarioFisico;

		}

		private void button1_Click(object sender, EventArgs e)
		{
			byte TIPOINVENTARIO = 1;
			int ID_ALMACEN = 1;
			int ID_PROVEEDOR = 1;
			float CANTIDAD = 1.1f;
			double COSTO_UNITARIO = 1.1;
			double ULTIMO_COSTO = 1.1;
			double SUB_TOTAL = 1.1;
			double DIFERENCIA = 1.1;
			double EXISTENCIAS = 1.1;

			this._INV_13_11_19DataSet1.CatProductos.FindByID_PRODUCTOS(1);

			this._INV_13_11_19DataSet1.InventarioFisico.AddInventarioFisicoRow(
				TIPOINVENTARIO,
				ID_ALMACEN,
				this._INV_13_11_19DataSet1.CatProductos.FindByID_PRODUCTOS(2),
				ID_PROVEEDOR,
				CANTIDAD,
				COSTO_UNITARIO,
				ULTIMO_COSTO,
				SUB_TOTAL,
				DIFERENCIA,
				EXISTENCIAS

				);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			{
				OleDbConnection conn = null;
				OleDbDataReader reader = null;
				try
				{
					conn = new OleDbConnection(
						"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\alero\\OneDrive\\Escritorio\\MP\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
					conn.Open();

					OleDbCommand cmd =
						//new OleDbCommand("INSERT INTO InventarioFisico (TIPOINVENTARIO,ID_ALMACEN,ID_PRODUCTOS,ID_PROVEEDOR,CANTIDAD,COSTO_UNITARIO,ULTIMO_COSTO,SUB_TOTAL,DIFERENCIA,EXISTENCIAS) VALUES (1,1,1,1,1,1,1,1,1,1)", conn);   ///insert un nievo inventarioFisico
						new OleDbCommand("UPDATE InventarioFisico SET ID_ALMACEN=1 where ID_PRODUCTOS=2 ", conn); //UPDATE un inventario fisico  

					reader = cmd.ExecuteReader();


					
					//datagrid.DataSource = reader;
					//datagrid.DataBind();
				}
				//        catch (Exception e)
				//        {
				//            Response.Write(e.Message);
				//            Response.End();
				//        }
				finally
				{
					if (reader != null) reader.Close();
					if (conn != null) conn.Close();
				}
			}
		}
	}
}
