using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiacaCSAccessDatabase
{
	class CatProducto
	{
		public double id_productos;
		public string clave_fabricante;
		public string clave_producto;
		public string producto = "producto generico";
		//string especificaciones;
		public double id_unidades;
		public double nivel_maximo;
		public double nivel_minimo;
		public double existencias;
		public double precio;
		public string localizacion = "localizacion";
		public DateTime fecha;
		public bool activo;
		public bool serie;
		public double cantidad_pendiente;
		public double id_clasificaciones;
		public bool tiene_movimientos;
		//double id_imagen;
		public double dias_procuramiento;
		public double ultimo_proveedor;
		public DateTime ultima_fecha;
		public double costoTotalMovimiento;
		//string puntero_externo;
		public double optimo;
		public double costoExistencias;
		public double totalEntradas;
		public double totalSalidas;
		public double promedio;


		public CatProducto()
		{
			this.nivel_minimo = 0;
			this.nivel_maximo = 999999;
			this.fecha = DateTime.Now;
			this.activo = true;
			this.serie = false;
			this.cantidad_pendiente = 0;
			this.tiene_movimientos = false;
			this.dias_procuramiento = 0;
			this.ultimo_proveedor = 0;
			this.ultima_fecha = this.fecha;
			this.costoTotalMovimiento = 0;
			this.optimo = 0;
			this.costoExistencias = 0;
			this.totalEntradas = 0;
			this.totalSalidas = 0;
			this.promedio = 0;

		}

		public double EditCatProducto()
		{
			//solo se debe editar existencias
			OleDbConnection conn = null;
			OleDbDataReader reader = null;
			try
			{
				conn = new OleDbConnection(
					"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\jose romero\\Desktop\\MP\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
				conn.Open();
				//MessageBox.Show("EXISTENCIAS: " + this.existencias);
				//MessageBox.Show("clave: " + this.clave_producto);
				OleDbCommand cmd =
					new OleDbCommand("UPDATE Catproductos SET EXISTENCIAS=@existencias WHERE CLAVE_PRODUCTO=@id_prod;  ", conn); //UPDATE un inventario fisico
				
				cmd.Parameters.AddWithValue("@existencias", this.existencias);
				cmd.Parameters.AddWithValue("@id_prod", this.clave_producto);


				////MessageBox.Show("cantidad " + this.cantidad + " idprod " + this.id_productos + " existencias " + this.existencias);

				var recordupdated = cmd.ExecuteNonQuery();




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

		public int AddCatProducto()
		{
			OleDbConnection conn = null;
			OleDbDataReader reader = null;
			try
			{
				conn = new OleDbConnection(
					"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\jose romero\\Desktop\\MP\\INV_13-11-19.i01;Persist Security Info=True;Jet OLEDB:Database Password=*");
				conn.Open();
				
				OleDbCommand cmd =
					new OleDbCommand("INSERT INTO Catproductos (ID_PRODUCTOS,CLAVE_PRODUCTO,PRODUCTO,EXISTENCIAS,PROMEDIO,ID_UNIDADES,LOCALIZACION,FECHA,ACTIVO) VALUES (@id_productos,@clave_producto,@producto,@existencias,@promedio,@id_unidades,@localizacion,@fecha,@activo);", conn);   ///insert un nievo inventarioFisico
				//new OleDbCommand("INSERT INTO InventarioFisico (TIPOINVENTARIO,ID_PRODUCTOS,CANTIDAD,COSTO_UNITARIO,ULTIMO_COSTO,SUB_TOTAL,DIFERENCIA,EXISTENCIAS) VALUES (2,@id_productos,1,1,1,1,1,1);", conn);   ///insert un nievo inventarioFisico

				cmd.Parameters.AddWithValue("@id_productos", this.id_productos);
				cmd.Parameters.AddWithValue("@clave_producto", this.clave_producto);
				cmd.Parameters.AddWithValue("@producto", this.producto);
				cmd.Parameters.AddWithValue("@existencias", this.existencias);
				cmd.Parameters.AddWithValue("@promedio", 0);
				cmd.Parameters.AddWithValue("@id_unidades", 1);
				cmd.Parameters.AddWithValue("@localizacion", this.localizacion);
				cmd.Parameters.AddWithValue("@fecha", this.fecha);
				cmd.Parameters.AddWithValue("@activo", this.activo);


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

	}
}
