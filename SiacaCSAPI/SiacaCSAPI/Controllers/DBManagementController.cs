using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiacaCSAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SiacaCSAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DBManagementController : ControllerBase
	{

	

		[Route("DeleteCambio")]
		[HttpPost]
		public string DeleteCambio(JObject jObject)
		{
			CambiosForm cambiosForm = new CambiosForm();
			try
			{
				Console.WriteLine("Jobject ID: " + jObject["id"]);
				SqlConnection con = new SqlConnection();
				con.ConnectionString = "Data Source=PC-DE-ALEJANDRO;Initial Catalog=SIACA_API;Integrated Security=True";
				int Id = 2;
		
				
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
				
				SqlConnection con = new SqlConnection();
				con.ConnectionString = "Data Source=PC-DE-ALEJANDRO;Initial Catalog=SIACA_API;Integrated Security=True";
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

		[Route("CambiosNuevos")]
		[HttpGet]
		public NewChangesForm NewChanges()
		{
			
			try
			{
				NewChangesForm newChangesForm = new NewChangesForm();
				SqlConnection con = new SqlConnection();
				con.ConnectionString = "Data Source=PC-DE-ALEJANDRO;Initial Catalog=SIACA_API;Integrated Security=True";
				//int Id = 2;

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
