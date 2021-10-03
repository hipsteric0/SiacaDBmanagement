using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiacaCSAccessDatabase
{
	class LoggerAccessDB
	{
		public string filePath = @"C:\Users\jose romero\Desktop\log\LOGMP.txt";


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


		


		public int ProductoExistenteLogger(InventarioFisico inventario)
		{
			try
			{
				
				string str = "[ " + DateTime.Now.ToString() + " ] " + "CAMBIO(S) DETECTADO(S) EN API. El producto [ "+inventario.producto +" ], de codigo [ "+inventario.clave_producto.Trim()+" ] existe en la Base de datos de MP, se procedera a Actualizar su inventario con la cantidad [ "+inventario.cantidad+" ].";


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

		public int ProductoInexistenteLogger(InventarioFisico inventario)
		{
			try
			{

				string str = "[ " + DateTime.Now.ToString() + " ] " + "CAMBIO(S) DETECTADO(S) EN API. El producto [ " + inventario.producto + " ], de codigo [ " + inventario.clave_producto.Trim() + " ] NO existe en la Base de datos de MP, se procedera a Crear su registro con la cantidad: [ " + inventario.cantidad + " ].";


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

		public int NoHayConexionAPI()
		{
			try
			{

				string str = "[ " + DateTime.Now.ToString() + " ] " + "NO HAY CONEXION A API. chequee su conexion a internet. Se volvera a intentar mas tarde.";


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
