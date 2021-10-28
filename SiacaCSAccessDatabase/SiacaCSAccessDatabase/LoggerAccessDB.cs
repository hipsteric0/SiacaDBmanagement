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
		public string filePath = @"D:\Users\Administrador\Desktop\PROYECTO_MP_PROFIT\log\LOGMP.txt";


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
				
				string str = "[ " + DateTime.Now.ToString() + " ] " + "CAMBIO(S) DETECTADO(S) EN API." + Environment.NewLine + "El producto: [ " + inventario.producto +" ]" + Environment.NewLine + "Codigo: [ " + inventario.clave_producto.Trim()+" ] " + Environment.NewLine + "Cantidad: [" + inventario.cantidad+"]" + Environment.NewLine + "EXISTE en la Base de datos de MP, se procedera a ACTUALIZAR su inventario.";


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

				string str = "[ " + DateTime.Now.ToString() + " ] " + "CAMBIO(S) DETECTADO(S) EN API." + Environment.NewLine + "El producto: [ " + inventario.producto + " ]" + Environment.NewLine + "Codigo: [ " + inventario.clave_producto.Trim() + " ] " + Environment.NewLine + "Cantidad: [" + inventario.cantidad + "]" + Environment.NewLine + "NO EXISTE en la Base de datos de MP, se procedera a CREAR su inventario.";


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

				string str = "[ " + DateTime.Now.ToString() + " ] " + Environment.NewLine + "NO HAY CONEXION A API." + Environment.NewLine + "Chequee su conexion a internet. Se volvera a intentar mas tarde.";


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
