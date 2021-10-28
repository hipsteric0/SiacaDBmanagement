using Newtonsoft.Json;
using SiacaCSAccessDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// current API:
/// https://siacacsapi2021.azurewebsites.net/api/DBmanagement
/// </summary>

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
		public string producto;
		public string localizacion;
		public DateTime fecha;
		public bool activo;

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
					"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=S:\\SISTEMA\\mpsoftsv\\BasesMDB\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
				conn.Open();

				OleDbCommand cmd =
					new OleDbCommand("SELECT CatProductos.ID_PRODUCTOS FROM CatProductos WHERE(((CatProductos.CLAVE_PRODUCTO) = @param)); ", conn);   ///insert un nievo inventarioFisico
				cmd.Parameters.AddWithValue("@param",this.clave_producto);
				////MessageBox.Show("QUERY: " + this.clave_producto);
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
					if (reader != null) reader.Close();
					if (conn != null) conn.Close();
					return 0;
				}

			}
			catch (Exception e)
			{
				//no hay conexion con la BD de MP
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();
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
					"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=S:\\SISTEMA\\mpsoftsv\\BasesMDB\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
				conn.Open();
				//MessageBox.Show("ID tope:" +this.id_productos);
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
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();
				return 0;
			}

			finally
			{
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();
			}
			return 1;
		}

		public int DeleteCambioEnAPI(double idAEliminar)
		{
			try
			{
				var client = new WebClient();

				DeleteCambioForm deleteCambioForm = new DeleteCambioForm();
				deleteCambioForm.id = Convert.ToInt64(idAEliminar);
				string data = JsonConvert.SerializeObject(deleteCambioForm);
				//MessageBox.Show("LO QUE SE ENVIA A LA API ES: "+ data);
				client.Headers["Content-Type"] = "application/json";
				var result = client.UploadString("https://siacacsapi2021.azurewebsites.net/api/DBmanagement/DeleteCambio", data);//quizas aca es download en vez de upload
				client.Dispose();
				////MessageBox.Show("el resultado es:" + result);
			}
			catch (Exception e)
			{
				return -1; //aca pudiera ser return -1 para saber que hubo un error
			}
			return 0;
		}

		public int CantidadDeCambiosEnAPI()
		{
			

			try{
				var client = new WebClient();
				string responseString = client.DownloadString("https://siacacsapi2021.azurewebsites.net/api/DBmanagement/CambiosNuevos");
				//HAY QUE REVISAR EL TIMEOUT
				
				NewChangesForm newChangesForm = JsonConvert.DeserializeObject<NewChangesForm>(responseString);

				//MessageBox.Show("cantidad de cambios en api: "+ newChangesForm.cantidadDeCambios.ToString());


				client.Dispose();
				return newChangesForm.cantidadDeCambios;

			}
			catch (Exception e)
			{
				return -1; //aca pudiera ser return -1 para saber que hubo un error
			}

			

			
		}

		public double GetCambioFromAPI()
		{


			try
			{
				var client = new WebClient();

				string responseString = client.DownloadString("https://siacacsapi2021.azurewebsites.net/api/DBmanagement/consultarUnCambioNuevo");
				//HAY QUE REVISAR EL TIMEOUT

				CambiosForm cambiosForm = JsonConvert.DeserializeObject<CambiosForm>(responseString);

				this.tipoInventario = cambiosForm.tipo_inventario;
				this.id_almacen = cambiosForm.id_almacen;
				this.id_productos = cambiosForm.id_productos;
				this.id_proveedor = cambiosForm.id_proveedor;
				this.cantidad = cambiosForm.cantidad;
				this.costo_unitario = cambiosForm.costo_unitario;
				this.ultimo_costo = cambiosForm.ultimo_costo;
				this.subtotal = cambiosForm.subtotal;
				this.diferencia = cambiosForm.diferencia;
				this.existencias = cambiosForm.existencias;
				this.clave_producto = cambiosForm.clave_producto;
				this.producto = cambiosForm.producto;
				this.localizacion = cambiosForm.localizacion;
				this.fecha = cambiosForm.fecha;
				this.activo = cambiosForm.activo;


				//BORRAR DE LA BD DE LA API EL CAMBIO REALIZADO
				int y = DeleteCambioEnAPI(cambiosForm.id);

				//MessageBox.Show("return delete: " + y);
				client.Dispose();
				return cambiosForm.id;

			}
			catch (Exception e)
			{
				return 0; //aca pudiera ser return -1 para saber que hubo un error
			}




		}

		public int GetInventarioFisicoFromSQLServer()
		{
			int conToAPI= CantidadDeCambiosEnAPI();


			if (conToAPI == 0)
			{
				//no existen cambios nuevos
				//MessageBox.Show("NO HAY CAMBIOS NUEVOS");
				return 0;
			}

			if (conToAPI == -1)
			{
				// hubo un error de conexion
				//escribir en el log que no pudo realizar la conexion
				LoggerAccessDB logger = new LoggerAccessDB();
				logger.NoHayConexionAPI();
				return 0;
			}

			//Si entra aca es por que hay cambios nuevos
			//se debe pedir a la api el cambio de menor id, pues es el mas antiguo

			Double ApiIdToDelete =  GetCambioFromAPI();


			//PLACEHOLDER:
			/*this.tipoInventario = 1;
			this.id_almacen = 1;
			this.id_productos = 1;
			this.id_proveedor = 1;
			this.cantidad =252;
			this.costo_unitario = 0;
			this.ultimo_costo = 0;
			this.subtotal = 0;
			this.diferencia = 0;
			this.existencias = 252;
			this.clave_producto = "321";
			this.producto = "producto generico 2";
			this.localizacion = "A1-01";
			this.fecha = DateTime.Today;
			this.activo = true;*/

			return 1;
		}


		public int EditInventarioFisico()
		{
			OleDbConnection conn = null;
			OleDbDataReader reader = null;
			try
			{
				conn = new OleDbConnection(
					"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=S:\\SISTEMA\\mpsoftsv\\BasesMDB\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
				conn.Open();

				OleDbCommand cmd =
					new OleDbCommand("UPDATE InventarioFisico SET CANTIDAD=@cant, EXISTENCIAS=@existencias WHERE ID_PRODUCTOS=@id_prod; ", conn); //UPDATE un inventario fisico
				cmd.Parameters.AddWithValue("@cant",this.cantidad);
				cmd.Parameters.AddWithValue("@existencias", this.existencias);
				cmd.Parameters.AddWithValue("@id_prod",this.id_productos);
				

				////MessageBox.Show("cantidad " + this.cantidad + " idprod " + this.id_productos + " existencias " + this.existencias);

				var recordupdated = cmd.ExecuteNonQuery();
				////MessageBox.Show(""+ recordupdated);
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();

			}
			catch (Exception e)
			{
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();
				return 0;
			}

			finally
			{
				
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
					"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=S:\\SISTEMA\\mpsoftsv\\BasesMDB\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
				conn.Open();

				OleDbCommand cmd =
					new OleDbCommand("SELECT TOP 1 ID_PRODUCTOS FROM InventarioFisico ORDER BY ID_PRODUCTOS DESC;", conn);   ///insert un nievo inventarioFisico
				
				reader = cmd.ExecuteReader();


			if (reader.Read()) //se ejecuta si el query encuentra algo 
			{
				double x = Convert.ToDouble(reader["ID_PRODUCTOS"].ToString()) +1;
					////MessageBox.Show("" + x);
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();
				return x;

			}
			else
			{
					if (reader != null) reader.Close();
					if (conn != null) conn.Close();
					return 0;
			}

			}
			catch (Exception e)
			{
					Console.WriteLine("Hubo un error GetTopIdInventarioFisico: " + e);
				if (reader != null) reader.Close();
				if (conn != null) conn.Close();
				return 0;
			}

			finally
			{
					
			}

			
		}

	}
}
