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

		private void getInventarioFisicoData()
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{

			// se pregunta a la api si hay cambios nuevos
			//si no hay, return
			//else :

			InventarioFisico inventarioFisico = new InventarioFisico();
			
			int newChanges =  inventarioFisico.GetInventarioFisicoFromSQLServer();

			if (newChanges == 1) //edita o anade solo cuando la api le informa que hubieron cambios
			{
				double ExistenceOfProduct = inventarioFisico.SelectExistenceOfProduct("01110017");
				MessageBox.Show("EXISTENCE OF PROD: " + ExistenceOfProduct);


				if (ExistenceOfProduct != 0)
				{
					//en este caso se debe editar inventarioFisico y catProductos, solo los atributos de existencias
					
					MessageBox.Show(" return edit: " +inventarioFisico.EditInventarioFisico());
				}
				else
				{


					//en este caso se debe anadir un inventarioFisico y un catProductos
					inventarioFisico.AddInventarioFisico();

				}
				//fill the log
			}

		}
	}
}
