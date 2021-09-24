using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiacaCSSQLServerDB
{
	public partial class Form1 : Form
	{
		Cambios cambios = new Cambios();
		int oldCantidadDeFacturas = 0;//la primera vez que se inicia el programa se debe hacer esto

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			if (oldCantidadDeFacturas == 0)
			{
				oldCantidadDeFacturas = cambios.SelectCantidadDeFacturas();
				oldCantidadDeFacturas = 655; //BORRAR, SOLO PARA PRUEBAS
			}

			int newCantidadDeFacturas = cambios.SelectCantidadDeFacturas();

			if (oldCantidadDeFacturas== newCantidadDeFacturas)
			{
				// no hay facturas nuevas, 
				int sleepQuantity = 5; // se debera dormir 5 minutos si no hay cambiuos nuevos
			}
			else if ((newCantidadDeFacturas == -1) || (oldCantidadDeFacturas== -1) )// en este caso no hay conexion a la bd de sqlserver local
			{
				//escribir en el LOG que no hay conexion a la BD 
				int sleepQuantity = 5; // se debera dormir 5 minutos si no hay conexion
			}
			else
			{
				//si hay cambios, se deben procesar
				int cantidadCambios = newCantidadDeFacturas - oldCantidadDeFacturas;
				int cambioInsertado = cambios.BuscarCambioEnProfit(cantidadCambios);


				if (cambioInsertado == 1) //si el cambio se inserto, se escribe en el log
				{
					//escribir en el log cambio correctamente insertado y anadir uno a la cantidad de facturas viejas
					oldCantidadDeFacturas++;
					//si quedan cambios sleep de 20 segundos, sino sleep de 5 mins
				}
				else //el cambio no se envio, se volvera a intentar
				{
					//sleep de un minuto
				}
			}

			//sleep(sleepQuantity)
			//aca se duerme la cantidad que se determino

		}
	}
}
