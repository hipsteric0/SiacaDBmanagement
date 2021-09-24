using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiacaCSSQLServerDB.Entities
{
	class CambioForm
    {
        public long id = 1;
        public double tipo_inventario = 1;
        public double id_almacen = 1;
        public double id_productos=-1;
        public double id_proveedor= 1;
        public double cantidad = 0;
        public double costo_unitario = 0;
        public double ultimo_costo = 0;
        public double subtotal = 0;
        public double diferencia = 0;
        public double existencias = 0;
        public string clave_producto= "No definido";
        public string producto = "No definido";
        public string localizacion = "No definido";
        public DateTime fecha = DateTime.Today;
        public bool activo = true;
	}
}
