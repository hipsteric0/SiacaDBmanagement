using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiacaCSAccessDatabase.Entities
{
	class CambiosForm
	{
		public double id = 0;
		public double tipo_inventario = 0;
		public double id_almacen = 0;
		public double id_productos = 0;
		public double id_proveedor = 0;
		public double cantidad = 0;
		public double costo_unitario = 0;
		public double ultimo_costo = 0;
		public double subtotal = 0;
		public double diferencia = 0;
		public double existencias = 0;
		public string clave_producto = "";
		public string producto = "";
		public string localizacion = "";
		public DateTime fecha = DateTime.Today;
		public bool activo = true;
	}
}
