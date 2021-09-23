using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiacaCSSQLServerDB
{
	class Cambios
	{
		public double tipoInventario=1;
		public double id_almacen=1;
		public double id_productos=1;
		public double id_proveedor=1;
		public double cantidad=0;
		public double costo_unitario=0;
		public double ultimo_costo=0;
		public double subtotal=0;
		public double diferencia=0;
		public double existencias=0;
		public string clave_producto="";
		public string producto="";
		public string localizacion="";
		public DateTime fecha= DateTime.Today;
		public bool activo=true;
		

		public int SelectCantidadDeFacturas()
		{
			try
			{
				
				SqlConnection con = new SqlConnection();
				con.ConnectionString = "Data Source=PC-DE-ALEJANDRO;Initial Catalog=SIACA_2020;Integrated Security=True";
				//int Id = 2;

				var query = "SELECT COUNT(Factura.co_art) as Contador  FROM saFacturaCompraReng as Factura, saArticulo as Articulo WHERE (Factura.co_art = Articulo.co_art) AND(Articulo.tipo LIKE 'C') ;";
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



				Convert.ToDouble(newChanges);
				MessageBox.Show(""+Convert.ToDouble(newChanges));
				
				con.Close();
				return Convert.ToInt32(newChanges);
			}
			catch (Exception e)
			{
				return -1;
			}
			finally
			{

			}
			return 0;
		}


		public int BuscarCambioEnProfit(int cantidadCambios)
		{

			try
			{

				SqlConnection con = new SqlConnection();
				con.ConnectionString = "Data Source=PC-DE-ALEJANDRO;Initial Catalog=SIACA_2020;Integrated Security=True";
				//int Id = 2;

				var query = "SELECT TOP (1) * FROM (SELECT TOP(@cantidadCambios) Factura.co_art,Articulo.art_des,Stock.stock,Factura.co_uni,Factura.cost_unit,Articulo.campo1,Factura.fe_us_in  FROM saFacturaCompraReng as Factura, saArticulo as Articulo, saStockAlmacen as Stock WHERE (Factura.co_art = Articulo.co_art) AND(Articulo.tipo LIKE 'C') AND (Stock.co_art = Factura.co_art) AND (Stock.tipo like 'ACT') ORDER BY Factura.fe_us_in DESC) as X order by X.fe_us_in ;";
				String str = "";

				SqlCommand cmd = new SqlCommand(query, con);

				cmd.Parameters.Add(new SqlParameter("@cantidadCambios", cantidadCambios));
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				con.Open();
				//datareader quizas es una mejor forma de sacar valores
				da.Fill(dt);
				string newChanges = "";

				foreach (DataRow row in dt.Rows)
				{

					this.clave_producto = row["co_art"].ToString();
					this.producto = row["art_des"].ToString();
					this.cantidad = Convert.ToDouble( row["stock"].ToString());
					this.existencias = this.cantidad;
					string unidad = ( row["co_uni"].ToString());
					this.costo_unitario = Convert.ToDouble( row["cost_unit"].ToString());
					this.localizacion = row["campo1"].ToString();//localizacion
					this.fecha = Convert.ToDateTime( row["fe_us_in"].ToString());//fecha
					



				}


				MessageBox.Show("clave producto a enviar: " + clave_producto);
				con.Close();

				this.EnviarCambioToApi();

				

				return 1;
			}
			catch (Exception e)
			{
				return 0;
			}
			finally
			{

			}
			
			return 0;
		}

		public int EnviarCambioToApi()
		{
			return 0;
		}



	}
}
