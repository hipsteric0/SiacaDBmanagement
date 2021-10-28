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
		public string filePath = @"C:\Users\Administrador.SIACASERVICIOS\Desktop\Proyecto_Profit_MP\log\LOGProfit.txt";


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
				string str = "[ " + DateTime.Now.ToString() + " ] " + Environment.NewLine + "Se ha enviado el CAMBIO a la API correctamente. " + Environment.NewLine + "Producto: [ " + cambio.producto + " ]. " + Environment.NewLine + "Codigo de Producto: [ " + cambio.clave_producto + " ]" + Environment.NewLine + "Cantidad: [ " + cambio.cantidad + " ]";

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

		public int InsercionConsumoCorrectoLogger(Cambios cambio)
		{
			try
			{
				StringChecker stringChecker = new StringChecker();
				cambio.clave_producto = stringChecker.TrimWhiteSpace(cambio.clave_producto);
				string str = "[ " + DateTime.Now.ToString() + " ] " + Environment.NewLine + "Se ha enviado el CONSUMO a la API correctamente. " + Environment.NewLine + "Producto: [ " + cambio.producto + " ]. " + Environment.NewLine + "Codigo de Producto: [ " + cambio.clave_producto + " ]" + Environment.NewLine + "Cantidad: [ " + cambio.cantidad + " ]";
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

		public int ApiCaidaLogger(Cambios cambio)
		{
			try
			{
				StringChecker stringChecker = new StringChecker();
				cambio.clave_producto = stringChecker.TrimWhiteSpace(cambio.clave_producto);
				string str = "[ " + DateTime.Now.ToString() + " ] " + Environment.NewLine + "Ha FALLADO la CONEXIÓN con la API, cuando se intento enviar el producto." + Environment.NewLine + "Producto: [ " + cambio.producto + " ] " + Environment.NewLine + "Código [ " + cambio.clave_producto + " ]" + Environment.NewLine + "Cantidad: [ " + cambio.cantidad + " ]. Se intentará enviar el cambio de nuevo en unos minutos.";

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

				string str = "[ " + DateTime.Now.ToString() + " ] " + Environment.NewLine + "Ha fallado la conexión con la Base de datos de PROFIT. Se intentará enviar el cambio de nuevo en unos minutos." + Environment.NewLine + " De continuar el fallo favor chequear la Base de datos SIACA_2020 en SQLSERVER";

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
