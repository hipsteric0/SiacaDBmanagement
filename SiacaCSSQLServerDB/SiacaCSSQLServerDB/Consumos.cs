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
	class Consumos
	{
		public List<string> listaCo_art = new List<string>();
		public List<string> listaTipo = new List<string>();
		public List<double> listaStock = new List<double>();


		public  Consumos()
		{
			try
			{

				SqlConnection con = new SqlConnection();
				con.ConnectionString = "Data Source=PC-DE-ALEJANDRO;Initial Catalog=SIACA_2020;Integrated Security=True";
				//int Id = 2;

				var query = "SELECT co_art,tipo,stock FROM saStockAlmacen ORDER BY co_art;";
				String str = "";

				SqlCommand cmd = new SqlCommand(query, con);

				//cmd.Parameters.Add(new SqlParameter("@ID", Convert.ToDouble(id["value"])));
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				con.Open();
				//datareader quizas es una mejor forma de sacar valores
				da.Fill(dt);
				string newChanges = "";
				int cont = -1;

				foreach (DataRow row in dt.Rows)
				{

					listaCo_art.Add( row["co_art"].ToString());
					listaTipo.Add(  row["tipo"].ToString());
					listaStock.Add( Convert.ToDouble(row["stock"].ToString() ));

					
				}

				// (using) is BS
				//make sure to check for null values when retrieving the data

				////MessageBox.Show("co_art: " + listaCo_art[cont] + " Tipo: " + listaTipo[cont] + " stock: " + listaStock[cont]);

				con.Close();
				
				
			}
			catch (Exception e)
			{
				//error de conexion con la bd de profit
				
			}
			finally
			{
				
			}
			
		}

		public int Compare(Consumos oldConsumos)
		{
			//MessageBox.Show("edita un valor");
			int result = 0;
			int diferencia = (this.listaCo_art.Count-oldConsumos.listaCo_art.Count);
			int j = 0;
			int i = 0;

			
			while ( i<oldConsumos.listaCo_art.Count)
			{
				////MessageBox.Show("j: " + j + "i: " + i);
				if (this.listaCo_art[j] == oldConsumos.listaCo_art[i])
				{

					////MessageBox.Show("OLD: " + oldConsumos.listaCo_art[i] + " "+oldConsumos.listaTipo[i] +" "+ oldConsumos.listaStock[i]+" "+
					//				"NEW: " + this.listaCo_art[j] + " " + this.listaTipo[j] + " " + this.listaStock[j] + " ");

					if ((this.listaTipo[j] == oldConsumos.listaTipo[i])&&(oldConsumos.listaTipo[i].Trim() == "ACT"))
					{
						if (this.listaStock[j] >= oldConsumos.listaStock[i])
						{
							//se registro una factura si es mayor, pero no hubieron cambios
							//si es igual no hubieron cambios ni registros de facturas
							i++;
							j++;
							////MessageBox.Show("entro por 1"); 


						}
						else if(this.listaStock[j] < oldConsumos.listaStock[i])
						{

							//se dio de baja a un producto, se debe mandar a la api el consumo
							//logger que se mando un cambio



							
							Cambios cambios = new Cambios();
							cambios.id_productos = -2;
							result = cambios.BuscarConsumoEnProfit(this.listaCo_art[j]);

							if (result == 1)
							{
								//MessageBox.Show("corrio bien");
								LoggerSQLServer logger = new LoggerSQLServer();
								logger.InsercionConsumoCorrectoLogger(cambios);
								//insercion correcta
							}
							else
							{
								//MessageBox.Show("corrio mal");
								LoggerSQLServer logger = new LoggerSQLServer();
								//logger.ApiCaidaLogger(cambios);
								return -1;
								//api caida
							}

							i++;
							j++;
							////MessageBox.Show("entro por 2");
							
						}

					}
					else if ((this.listaTipo[j] == oldConsumos.listaTipo[i]) && (oldConsumos.listaTipo[i].Trim() == "LLE"))
					{
						//ambos son tipo LLE, se ignora
						i++;
						j++;
						////MessageBox.Show("entro por 3");
					}
					else
					{
						//mismo cod_art, difernete tipo. Old sera lle, new sera act

						if (this.listaStock[j] == 0)
						{
							//Se registro una factura y se consumio antes que el programa se diera cuenta.
							//se dio de baja a un producto, se debe mandar a la api el consumo
							//logger que se mando un cambio
							//se desfasa new para que old lo alcance

							Cambios cambios = new Cambios();
							cambios.id_productos = -2;
							result = cambios.BuscarConsumoEnProfit(this.listaCo_art[j]);

							if (result == 1)
							{
								//MessageBox.Show("corrio bien");
								LoggerSQLServer logger = new LoggerSQLServer();
								logger.InsercionConsumoCorrectoLogger(cambios);
								//insercion correcta
							}
							else
							{
								//MessageBox.Show("corrio mal");
								LoggerSQLServer logger = new LoggerSQLServer();
								//logger.ApiCaidaLogger(cambios);
								return -1;
								//api caida
							}

							j++;
							//MessageBox.Show("entro por 4");
						}
						else if (this.listaStock[j] != 0)
						{

							//Se registro una factura, pero no se ha consumido. No hay que mandar nada a la api 
							//se desfasa new para que old lo alcance
							
							j++;
							//MessageBox.Show("entro por 5");
						}
					}
				}
				else
				{
					//como se anadio un valor a la tabla, los ids no concuerdan. si el nuevo id es 0 se consumio ese nuevo id

					if (this.listaStock[j] == 0)
					{
						//se registro un nuevo item al stock y se consumio
						//enviar a la api
						//logger
						//se desfasa new
						Cambios cambios = new Cambios();
						cambios.id_productos = -2;
						result = cambios.BuscarConsumoEnProfit(this.listaCo_art[j]);

						if (result == 1)
						{
							//MessageBox.Show("corrio bien");
							LoggerSQLServer logger = new LoggerSQLServer();
							logger.InsercionConsumoCorrectoLogger(cambios);
							//insercion correcta
						}
						else
						{
							//MessageBox.Show("corrio mal");
							LoggerSQLServer logger = new LoggerSQLServer();
							//logger.ApiCaidaLogger(cambios);
							return -1;
							//api caida
						}

						j++;
						//MessageBox.Show("entro por 6");
					}
					else
					{
						//se registro un nuevo item al stock, pero no se consumio
						//no se envia nada a la api
						//se desfasa new
						j++;
						//MessageBox.Show("entro por 7");
					}
				}
				
			}

			

			return 1;
		}

	}
}
