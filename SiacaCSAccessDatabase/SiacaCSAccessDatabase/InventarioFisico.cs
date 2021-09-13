using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiacaCSAccessDatabase
{
	public class InventarioFisico
	{
		double tipoInventario;
		double id_almacen;
		double id_productos;
		double id_proveedor;
		double cantidad;
		double costo_unitario;
		double ultimo_costo;
		double subtotal;
		double diferencia;
		double existencias;

		public InventarioFisico(/*double tipoinventario, double id_almacen, double id_productos, double id_proveedor, double cantidad, double costo_unitario, double ultimo_costo, double subtotal, double diferencia, double existencias*/)
		{
			/*this.tipoInventario = tipoinventario;
			this.id_almacen = id_almacen;
			this.id_productos = id_productos;
			this.id_proveedor = id_proveedor;
			this.cantidad = cantidad;
			this.costo_unitario = costo_unitario;
			this.ultimo_costo = ultimo_costo;
			this.subtotal = subtotal;
			this.diferencia = diferencia;
			this.existencias = existencias;*/

		}

		public int SelectExistenceOfProduct()
		{

			OleDbConnection conn = null;
			OleDbDataReader reader = null;
			try
			{
				conn = new OleDbConnection(
					"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\jose romero\\Desktop\\MP\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
				conn.Open();

				OleDbCommand cmd =
					new OleDbCommand("SELECT CatProductos.CLAVE_PRODUCTO FROM CatProductos WHERE(((CatProductos.CLAVE_PRODUCTO) = '4290003')); ", conn);   ///insert un nievo inventarioFisico

				reader = cmd.ExecuteReader();
				

			}
			catch (Exception e)
			{
				Console.WriteLine("Hubo un error SelectExistenceOfProduct: " + e);
			}

			finally
			{
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();
			}
			return 1;
		}

		public int AddInventarioFisico()
		{
			OleDbConnection conn = null;
			OleDbDataReader reader = null;
			try
			{
				conn = new OleDbConnection(
					"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\jose romero\\Desktop\\MP\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
				conn.Open();

				OleDbCommand cmd =
					new OleDbCommand("INSERT INTO InventarioFisico (TIPOINVENTARIO,ID_ALMACEN,ID_PRODUCTOS,ID_PROVEEDOR,CANTIDAD,COSTO_UNITARIO,ULTIMO_COSTO,SUB_TOTAL,DIFERENCIA,EXISTENCIAS) VALUES (1,1,1,1,1,1,1,1,1,1)", conn);   ///insert un nievo inventarioFisico

				reader = cmd.ExecuteReader();


			}
			catch (Exception e)
			{
				return 0;
			}

			finally
			{
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();
			}
			return 1;
		}


		public InventarioFisico GetInventarioFisicoFromSQLServer()
		{
			int conToAPI=1;
			//connect to api
			if (conToAPI == 0)
			{
				//si la conexion falla retorna un -1

				//si no hay cambios nuevos retorna 0
				return null;
			}

			//manejar el json de la api
			//asignar el json de a api a this

			//PLACEHOLDER:
			this.tipoInventario = 1;
			this.id_almacen = 1;
			this.id_productos = 1;
			this.id_proveedor = 1;
			this.cantidad = 1;
			this.costo_unitario = 1;
			this.ultimo_costo = 1;
			this.subtotal = 1;
			this.diferencia = 1;
			this.existencias = 1;

			return this;
		}


		public int EditInventarioFisico()
		{
			OleDbConnection conn = null;
			OleDbDataReader reader = null;
			try
			{
				conn = new OleDbConnection(
					"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\jose romero\\Desktop\\MP\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
				conn.Open();

				OleDbCommand cmd =
					new OleDbCommand("UPDATE InventarioFisico SET ID_ALMACEN=5 where ID_PRODUCTOS=2 ", conn); //UPDATE un inventario fisico
				reader = cmd.ExecuteReader();

			}
			catch (Exception e)
			{
				return 0;
			}

			finally
			{
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();
			}
			return 1;
		}

	}
}
