using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiacaCSSQLServerDB
{
	class LoggerSQLServer
	{
		public string filePath = @"C:\Users\jose romero\Desktop\log\LOGProfit.txt";


		public string GetAllFile()
		{
			
			try
			{
				string str = File.ReadAllText(filePath);
				return str;
			}
			catch
			{
				return "";
			}
					
			
		}


		public int InsercionCorrectaLogger(Cambios cambio)
		{
			try
			{
				StringChecker stringChecker = new StringChecker();
				cambio.clave_producto = stringChecker.TrimWhiteSpace(cambio.clave_producto);
				string str = "[ " + DateTime.Now.ToString() + " ] " + "Se ha enviado el cambio a la API correctamente para el producto [ " + cambio.producto + " ] " + "con el codigo [ " + cambio.clave_producto + " ], cantidad: [ " + cambio.cantidad + " ]";
				
				
				List<string> x = File.ReadAllLines(filePath).ToList<string>();
				x.Insert(0, "");
				x.Insert(0, str);

				string[] strArray = x.ToArray<string>();

				File.WriteAllLines(filePath, strArray);

				return 1;
			}
			catch(Exception e)
			{
				
				return 0;
			}
		}


		public int ApiCaidaLogger(Cambios cambio)
		{
			try
			{
				StringChecker stringChecker = new StringChecker();
				cambio.clave_producto = stringChecker.TrimWhiteSpace(cambio.clave_producto);
				string str = "[ " + DateTime.Now.ToString() + " ] " + "Ha fallado la conexión con la API, cuando se intento enviar el producto [ " + cambio.producto + " ] " + "con el codigo [ " + cambio.clave_producto + " ], cantidad: [ " + cambio.cantidad + " ]. Se intentará enviar el cambio de nuevo en unos minutos.";


				List<string> x = File.ReadAllLines(filePath).ToList<string>();
				x.Insert(0, "");
				x.Insert(0, str);

				string[] strArray = x.ToArray<string>();

				File.WriteAllLines(filePath, strArray);

				return 1;
			}
			catch (Exception e)
			{

				return 0;
			}
		}

		public int BDProfitCaidaLogger()
		{
			try
			{
				StringChecker stringChecker = new StringChecker();
				
				string str = "[ " + DateTime.Now.ToString() + " ] " + "Ha fallado la conexión con la Base de datos de PROFIT. Se intentará enviar el cambio de nuevo en unos minutos. De continuar el fallo favor chequear la Base de datos SIACA_2020 en SQLSERVER";


				List<string> x = File.ReadAllLines(filePath).ToList<string>();
				x.Insert(0, "");
				x.Insert(0, str);

				string[] strArray = x.ToArray<string>();

				File.WriteAllLines(filePath, strArray);

				return 1;
			}
			catch (Exception e)
			{

				return 0;
			}
		}


	}
}
