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
			LoggerAccessDB logger = new LoggerAccessDB();
			InventarioFisico inventarioFisico = new InventarioFisico();
			CatProducto catProducto = new CatProducto();

			int newChanges =  inventarioFisico.GetInventarioFisicoFromSQLServer();

			if (newChanges == 1) //edita o anade solo cuando la api le informa que hubieron cambios
			{
				
				double ExistenceOfProduct = inventarioFisico.SelectExistenceOfProduct();
				//MessageBox.Show("ID OF PROD: " + ExistenceOfProduct);


				if (ExistenceOfProduct != 0)//si el producto existe
				{
					//en este caso se debe editar inventarioFisico y catProductos, solo los atributos de existencias
					catProducto.clave_producto = inventarioFisico.clave_producto;
					catProducto.existencias = inventarioFisico.cantidad;
					catProducto.id_productos = ExistenceOfProduct;

					inventarioFisico.EditInventarioFisico();
					catProducto.EditCatProducto();
					logger.ProductoExistenteLogger(inventarioFisico);
				}
				else // si el producto no existe
				{

					//en este caso se debe insertar un inventarioFisico y un catProductos
					double topInventarioFisico = inventarioFisico.GetTopIdInventarioFisico();
					inventarioFisico.id_productos = topInventarioFisico;
					catProducto.id_productos = topInventarioFisico;
					catProducto.clave_producto = inventarioFisico.clave_producto;
					catProducto.existencias = inventarioFisico.cantidad;
					catProducto.producto = inventarioFisico.producto;
					catProducto.localizacion = inventarioFisico.localizacion;
					catProducto.fecha = inventarioFisico.fecha;
					catProducto.activo = inventarioFisico.activo;

					catProducto.AddCatProducto();
					inventarioFisico.AddInventarioFisico();

					logger.ProductoInexistenteLogger(inventarioFisico);
				}
				
			}
			//fill the log
			textBox1.Text = logger.GetAllFile();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
