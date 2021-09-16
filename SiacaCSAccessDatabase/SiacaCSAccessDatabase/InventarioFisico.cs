using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiacaCSAccessDatabase
{
	public class InventarioFisico
	{
		public double tipoInventario;
		public double id_almacen;
		public double id_productos;
		public double id_proveedor;
		public double cantidad;
		public double costo_unitario;
		public double ultimo_costo;
		public double subtotal;
		public double diferencia;
		public double existencias;
		public string clave_producto;


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

		
		public double SelectExistenceOfProduct() //devuelve si existe una clave_producto en la tabla CatProductos
		{

			OleDbConnection conn = null;
			OleDbDataReader reader = null;
			try
			{
				conn = new OleDbConnection(
					"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\jose romero\\Desktop\\MP\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
				conn.Open();

				OleDbCommand cmd =
					new OleDbCommand("SELECT CatProductos.ID_PRODUCTOS FROM CatProductos WHERE(((CatProductos.CLAVE_PRODUCTO) = @param)); ", conn);   ///insert un nievo inventarioFisico
				cmd.Parameters.AddWithValue("@param",this.clave_producto);
				//MessageBox.Show("QUERY: " + this.clave_producto);
				reader = cmd.ExecuteReader();
				



				if (reader.Read()) //se ejecuta si el query encuentra algo 
				{
					double x = Convert.ToDouble(reader["ID_PRODUCTOS"].ToString());
					this.id_productos = x;
					if (reader != null) reader.Close();
					if (conn != null) conn.Close();
					return x;

				}
				else
				{
					return 0;
				}

			}
			catch (Exception e)
			{
				Console.WriteLine("Hubo un error SelectExistenceOfProduct: " + e);
				return 0;
			}

			finally
			{
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();
			}
			
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
				MessageBox.Show("ID tope:" +this.id_productos);
				OleDbCommand cmd =
					new OleDbCommand("INSERT INTO InventarioFisico (TIPOINVENTARIO,ID_PRODUCTOS,CANTIDAD,COSTO_UNITARIO,ULTIMO_COSTO,SUB_TOTAL,DIFERENCIA,EXISTENCIAS) VALUES (@tipoInventario,@id_productos,@cantidad,@costo_unitario,@ultimo_costo,@subtotal,@diferencia,@existencias);", conn);   ///insert un nievo inventarioFisico
					//new OleDbCommand("INSERT INTO InventarioFisico (TIPOINVENTARIO,ID_PRODUCTOS,CANTIDAD,COSTO_UNITARIO,ULTIMO_COSTO,SUB_TOTAL,DIFERENCIA,EXISTENCIAS) VALUES (2,@id_productos,1,1,1,1,1,1);", conn);   ///insert un nievo inventarioFisico

				cmd.Parameters.AddWithValue("@tipoInventario", this.tipoInventario);
				cmd.Parameters.AddWithValue("@id_productos", this.id_productos);
				cmd.Parameters.AddWithValue("@cantidad", this.cantidad);
				cmd.Parameters.AddWithValue("@costo_unitario", this.costo_unitario);
				cmd.Parameters.AddWithValue("@ultimo_costo", this.ultimo_costo);
				cmd.Parameters.AddWithValue("@subtotal", this.subtotal);
				cmd.Parameters.AddWithValue("@diferencia", this.diferencia);
				cmd.Parameters.AddWithValue("@existencias", this.existencias);

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


		public int GetInventarioFisicoFromSQLServer()
		{
			int conToAPI=1;
			//connect to api
			if (conToAPI == 0)
			{
				//si la conexion falla retorna un -1

				//si no hay cambios nuevos retorna 0
				return 0;
			}

			//manejar el json de la api
			//asignar el json de a api a this

			//PLACEHOLDER:
			this.tipoInventario = 1;
			this.id_almacen = 1;
			this.id_productos = 1;
			this.id_proveedor = 1;
			this.cantidad =252;
			this.costo_unitario = 0;
			this.ultimo_costo = 0;
			this.subtotal = 0;
			this.diferencia = 0;
			this.existencias = 252;
			this.clave_producto = "123";

			return 1;
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
					new OleDbCommand("UPDATE InventarioFisico SET CANTIDAD=@cant, EXISTENCIAS=@existencias WHERE ID_PRODUCTOS=@id_prod; ", conn); //UPDATE un inventario fisico
				cmd.Parameters.AddWithValue("@cant",this.cantidad);
				cmd.Parameters.AddWithValue("@existencias", this.existencias);
				cmd.Parameters.AddWithValue("@id_prod",this.id_productos);
				

				//MessageBox.Show("cantidad " + this.cantidad + " idprod " + this.id_productos + " existencias " + this.existencias);

				var recordupdated = cmd.ExecuteNonQuery();
				//MessageBox.Show(""+ recordupdated);

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

		public double GetTopIdInventarioFisico()
		{
			
			OleDbConnection conn = null;
			OleDbDataReader reader = null;
			try
			{
				conn = new OleDbConnection(
					"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\jose romero\\Desktop\\MP\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
				conn.Open();

				OleDbCommand cmd =
					new OleDbCommand("SELECT TOP 1 ID_PRODUCTOS FROM InventarioFisico ORDER BY ID_PRODUCTOS DESC;", conn);   ///insert un nievo inventarioFisico
				
				reader = cmd.ExecuteReader();


			if (reader.Read()) //se ejecuta si el query encuentra algo 
			{
				double x = Convert.ToDouble(reader["ID_PRODUCTOS"].ToString()) +1;
					//MessageBox.Show("" + x);
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();
				return x;

			}
			else
			{
				return 0;
			}

			}
			catch (Exception e)
			{
					Console.WriteLine("Hubo un error GetTopIdInventarioFisico: " + e);
					return 0;
			}

			finally
			{
					if (reader != null) reader.Close();
					if (conn != null) conn.Close();
			}

			
		}

	}
}
