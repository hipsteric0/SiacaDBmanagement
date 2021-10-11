using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SiacaCSAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


//https://siacacsapi2021.azurewebsites.net/api/DBmanagement

namespace SiacaCSAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DBManagementController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		public DBManagementController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[Route("InsertCambio")]
		[HttpPost]
		public string InsertCambio(JObject jObject)
		{
			CambiosForm cambiosForm = new CambiosForm();
			try
			{
				string connectionString = _configuration.GetConnectionString("DEPLOYSiacaAPI");
				SqlConnection con = new SqlConnection();
				con.ConnectionString = connectionString;


				var query = "INSERT INTO Cambios VALUES(@id,@tipo_inventario,@id_almacen,@id_productos,@id_proveedor,@cantidad,@costo_unitario,@ultimo_costo,@subtotal,@diferencia,@existencias,@clave_producto,@producto,@localizacion,@fecha,@activo);";
				SqlCommand cmd2 = new SqlCommand(query, con);

				cmd2.Parameters.Add(new SqlParameter("@id", Convert.ToDouble(jObject["id"])));
				cmd2.Parameters.Add(new SqlParameter("@tipo_inventario", Convert.ToDouble(jObject["tipo_inventario"])));
				cmd2.Parameters.Add(new SqlParameter("@id_almacen", Convert.ToDouble(jObject["id_almacen"])));
				cmd2.Parameters.Add(new SqlParameter("@id_productos", Convert.ToDouble(jObject["id_productos"])));
				cmd2.Parameters.Add(new SqlParameter("@id_proveedor", Convert.ToDouble(jObject["id_proveedor"])));
				cmd2.Parameters.Add(new SqlParameter("@cantidad", Convert.ToDouble(jObject["cantidad"])));
				cmd2.Parameters.Add(new SqlParameter("@costo_unitario", Convert.ToDouble(jObject["costo_unitario"])));
				cmd2.Parameters.Add(new SqlParameter("@ultimo_costo", Convert.ToDouble(jObject["ultimo_costo"])));
				cmd2.Parameters.Add(new SqlParameter("@subtotal", Convert.ToDouble(jObject["subtotal"])));
				cmd2.Parameters.Add(new SqlParameter("@diferencia", Convert.ToDouble(jObject["diferencia"])));
				cmd2.Parameters.Add(new SqlParameter("@existencias", Convert.ToDouble(jObject["existencias"])));
				cmd2.Parameters.Add(new SqlParameter("@clave_producto", (jObject["clave_producto"]).ToString()));
				cmd2.Parameters.Add(new SqlParameter("@producto", (jObject["producto"]).ToString()));
				cmd2.Parameters.Add(new SqlParameter("@localizacion", (jObject["localizacion"]).ToString()));
				cmd2.Parameters.Add(new SqlParameter("@fecha", Convert.ToDateTime(jObject["fecha"])));
				cmd2.Parameters.Add(new SqlParameter("@activo", true));

				con.Open();
				cmd2.ExecuteNonQuery();


				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd2);

				//datareader quizas es una mejor forma de sacar valores
				//Console.WriteLine("EMPRIMIO");
				con.Close();

				return ("corrio bien");
			}
			catch (Exception e)
			{
				return "corrio mal";
			}
			finally
			{

			}

			return null;

		}


		[Route("DeleteCambio")]
		[HttpPost]
		public string DeleteCambio(JObject jObject)
		{
			CambiosForm cambiosForm = new CambiosForm();
			try
			{
				string connectionString = _configuration.GetConnectionString("DEPLOYSiacaAPI");
				SqlConnection con = new SqlConnection();
				con.ConnectionString = connectionString;


				var query = "DELETE FROM Cambios WHERE Id=@id;";
				SqlCommand cmd = new SqlCommand(query, con);
				cmd.Parameters.Add(new SqlParameter("@id", Convert.ToDouble(jObject["id"])));
				con.Open();
				cmd.ExecuteNonQuery();

				
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);

				//datareader quizas es una mejor forma de sacar valores
				//Console.WriteLine("EMPRIMIO");
				con.Close();

				return ("corrio bien");
			}
			catch (Exception e)
			{
				return "corrio mal";
			}
			finally
			{

			}

			return null;

		}

		[Route("ConsultarUnCambioNuevo")]
		[HttpGet]
		public CambiosForm GetCambios()
		{
			CambiosForm cambiosForm = new CambiosForm();
			try
			{
				string connectionString = _configuration.GetConnectionString("DEPLOYSiacaAPI");
				SqlConnection con = new SqlConnection();
				con.ConnectionString = connectionString;
				int Id = 2;

				var query = "SELECT TOP (1) * FROM Cambios ORDER BY Id ASC;";
				String str = "";

				SqlCommand cmd = new SqlCommand(query, con);

				//cmd.Parameters.Add(new SqlParameter("@ID",Convert.ToDouble(id["value"])));
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				con.Open();
				//datareader quizas es una mejor forma de sacar valores
				da.Fill(dt);

				foreach (DataRow row in dt.Rows)
				{

					/*String Name = row["Nombre"].ToString();
					String FamilyName = row["Apellido"].ToString();
					String ID = row["Cedula"].ToString();*/

					cambiosForm.id= Convert.ToDouble(row["Id"].ToString());
					cambiosForm.tipo_inventario = Convert.ToDouble(row["Tipo_Inventario"].ToString());
					cambiosForm.id_almacen = Convert.ToDouble(row["Id_Almacen"].ToString());
					cambiosForm.id_productos = Convert.ToDouble(row["Id_Productos"].ToString());
					cambiosForm.id_proveedor = Convert.ToDouble(row["Id_Proveedor"].ToString());
					cambiosForm.cantidad = Convert.ToDouble(row["Cantidad"].ToString());
					cambiosForm.costo_unitario = Convert.ToDouble(row["Costo_Unitario"].ToString());
					cambiosForm.ultimo_costo = Convert.ToDouble(row["Ultimo_Costo"].ToString());
					cambiosForm.subtotal = Convert.ToDouble(row["Subtotal"].ToString());
					cambiosForm.diferencia = Convert.ToDouble(row["Diferencia"].ToString());
					cambiosForm.existencias = Convert.ToDouble(row["Existencias"].ToString());
					cambiosForm.clave_producto = row["Clave_Producto"].ToString();
					cambiosForm.producto = row["Producto"].ToString();
					cambiosForm.localizacion = row["Localizacion"].ToString();
					cambiosForm.fecha = Convert.ToDateTime( row["Fecha"].ToString());
					cambiosForm.activo = Convert.ToBoolean( row["Activo"].ToString());
				}

				// (using) is BS
				//make sure to check for null values when retrieving the data




				
				return cambiosForm;
			}
			catch(Exception e)
			{
				return cambiosForm;
			}
			finally
			{

			}

			return null;

		}


		[Route("GetTopCambioID")]
		[HttpGet]
		public TopIdForm GetTopCambioID()
		{

			try
			{
				TopIdForm topIdForm = new TopIdForm();
				string connectionString = _configuration.GetConnectionString("DEPLOYSiacaAPI");
				SqlConnection con = new SqlConnection();
				con.ConnectionString = connectionString;

				var query = "SELECT TOP(1) Id FROM Cambios ORDER BY ID DESC;";
				String str = "";

				SqlCommand cmd = new SqlCommand(query, con);

				//cmd.Parameters.Add(new SqlParameter("@ID", Convert.ToDouble(id["value"])));
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				con.Open();
				//datareader quizas es una mejor forma de sacar valores
				da.Fill(dt);
				string newChanges = "";

				foreach (DataRow row in dt.Rows)
				{

					newChanges = row["Id"].ToString();
					//String FamilyName = row["Apellido"].ToString();
					//String ID = row["Cedula"].ToString();
					//str = Name + " " + FamilyName + " " + ID;
				}

				// (using) is BS
				//make sure to check for null values when retrieving the data



				topIdForm.topId = Convert.ToInt32(newChanges);
				//MessageBox.Show(str);
				Console.WriteLine(str);
				return topIdForm;
			}
			catch (Exception e)
			{
				return null;
			}
			finally
			{

			}

			//return Ok("no data");

		}


		[Route("CambiosNuevos")]
		[HttpGet]
		public NewChangesForm NewChanges()
		{
			
			try
			{
				NewChangesForm newChangesForm = new NewChangesForm();
				string connectionString = _configuration.GetConnectionString("DEPLOYSiacaAPI");
				SqlConnection con = new SqlConnection();
				con.ConnectionString = connectionString;

				var query = "SELECT COUNT (id) AS Contador FROM Cambios;";
				String str = "";

				SqlCommand cmd = new SqlCommand(query, con);

				//cmd.Parameters.Add(new SqlParameter("@ID", Convert.ToDouble(id["value"])));
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				con.Open();
				//datareader quizas es una mejor forma de sacar valores
				da.Fill(dt);
				string newChanges = "";

				foreach (DataRow row in dt.Rows)
				{

					newChanges = row["Contador"].ToString();
					//String FamilyName = row["Apellido"].ToString();
					//String ID = row["Cedula"].ToString();
					//str = Name + " " + FamilyName + " " + ID;
				}

				// (using) is BS
				//make sure to check for null values when retrieving the data



				newChangesForm.cantidadDeCambios = Convert.ToInt32(newChanges);
				//MessageBox.Show(str);
				Console.WriteLine(str);
				return newChangesForm;
			}
			catch (Exception e)
			{
				return null;
			}
			finally
			{

			}

			//return Ok("no data");

		}


		[HttpPost]
		public IActionResult Post(JObject payload)
		{
			return Ok(payload);
		}
	}
	
}
