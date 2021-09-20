using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
		[HttpGet]
		public IActionResult Get(JObject id)
		{
			try
			{
				SqlConnection con = new SqlConnection();
				con.ConnectionString = "Data Source=PC-DE-ALEJANDRO;Initial Catalog=Prueba;Integrated Security=True";
				int Id = 2;

				var query = "SELECT id,nombre,apellido,cedula FROM TablaDePrueba WHERE id = @ID;";
				String str = "";

				SqlCommand cmd = new SqlCommand(query, con);

				cmd.Parameters.Add(new SqlParameter("@ID",Convert.ToDouble( id["value"])));
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				con.Open();
				//datareader quizas es una mejor forma de sacar valores
				da.Fill(dt);

				foreach (DataRow row in dt.Rows)
				{

					String Name = row["Nombre"].ToString();
					String FamilyName = row["Apellido"].ToString();
					String ID = row["Cedula"].ToString();
					str = Name + " " + FamilyName + " " + ID;
				}

				// (using) is BS
				//make sure to check for null values when retrieving the data




				//MessageBox.Show(str);
				Console.WriteLine(str);
				return Ok(str);
			}
			catch(Exception e)
			{
				return BadRequest(e);
			}
			finally
			{

			}

			return Ok("no data");

		}


		[HttpPost]
		public IActionResult Post(JObject payload)
		{
			return Ok(payload);
		}
	}
	
}
