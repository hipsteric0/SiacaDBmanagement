using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiacaCSSQLServerDB
{
	public partial class Form1 : Form
	{
		Cambios cambios = new Cambios();
		int oldCantidadDeFacturas = 0;//la primera vez que se inicia el programa se debe hacer esto
		Consumos Oldconsumos = new Consumos();
		

		public Form1()
		{
			InitializeComponent();
			this.button1_Click(null, null);
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			LoggerSQLServer logger = new LoggerSQLServer();


			while (true)
			{
				


				if (oldCantidadDeFacturas == 0)
				{
					//oldCantidadDeFacturas = cambios.SelectCantidadDeFacturas();  // Esto es si el programa funcionara con la cantidad de registros en saFacturaCompra
					oldCantidadDeFacturas = cambios.SelectCantidadDeNotasRecepcionCompra();    // Esto es si el programa funcionara con la cantidad de registros en saNotaRecepcionCompraReng
					oldCantidadDeFacturas = 643; //BORRAR, SOLO PARA PRUEBAS error ñs 644, los acentos tambien dan error 649
				}

				//int newCantidadDeFacturas = cambios.SelectCantidadDeFacturas();  // Esto es si el programa funcionara con la cantidad de registros en saFacturaCompra			
				int newCantidadDeFacturas = cambios.SelectCantidadDeNotasRecepcionCompra();    // Esto es si el programa funcionara con la cantidad de registros en saNotaRecepcionCompraReng

				if (oldCantidadDeFacturas == newCantidadDeFacturas)
				{
					// no hay facturas nuevas, 
					int sleepQuantity = 5; // se debera dormir 5 minutos si no hay cambiuos nuevos
				}
				else if ((newCantidadDeFacturas == -1) || (oldCantidadDeFacturas == -1))// en este caso no hay conexion a la bd de sqlserver local
				{
					//escribir en el LOG que no hay conexion a la BD 
					logger.BDProfitCaidaLogger();
					int sleepQuantity = 5; // se debera dormir 5 minutos si no hay conexion
				}
				else
				{
					//si hay cambios, se deben procesar
					int cantidadCambios = newCantidadDeFacturas - oldCantidadDeFacturas;
					//int cambioInsertado = cambios.BuscarCambioEnProfit(cantidadCambios);// Esto es si el programa funcionara con la cantidad de registros en saFacturaCompra
					int cambioInsertado = cambios.BuscarCambioEnProfitNotaCompra(cantidadCambios);// Esto es si el programa funcionara con la cantidad de registros en saNotaRecepcionCompraReng


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

				textBox1.Text = logger.GetAllFile();

				//ahora se verificara si hay consumos

				Consumos Newconsumos = new Consumos();

				int resultado = Newconsumos.Compare(Oldconsumos); //intentara buscar consumos, y si los hay, los enviara a la api

				if (resultado != -1)
				{
					Oldconsumos = Newconsumos; // si la api no esta activa no se actualiza la tabla, cuando este activa se actualizara
				}



				textBox1.Text = logger.GetAllFile();

				//sleep(sleepQuantity)
				await Task.Delay(300000); //tiempo en milisegundos
				//aca se duerme la cantidad que se determino
			}

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
