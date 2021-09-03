using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiacaCSAccessDatabase
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void consumoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			this.Validate();
			this.consumoBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this._MP_13_11_19DataSet);

		}

        private int GetLastConsumoID()
		{
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["SiacaCSAccessDatabase.Properties.Settings.MP_13_11_19ConnectionString"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 Consumo.Id_Consumo FROM Consumo ORDER BY Consumo.Id_Consumo DESC; ", con );

            /*cmd.Connection = con;
            return cmd.ExecuteNonQuery();*/

            OleDbDataReader reader;
            reader = cmd.ExecuteReader();

			if (reader.Read())
			{
                String str = reader["Id_Consumo"].ToString();
                 return int.Parse(str);

			}

            return 0;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the '_MP_13_11_19DataSet.Consumo' table. You can move, or remove it, as needed.
			this.consumoTableAdapter.Fill(this._MP_13_11_19DataSet.Consumo);
			consumoBindingSource.DataSource = this._MP_13_11_19DataSet.Consumo;
            
		}

		private void button1_Click(object sender, EventArgs e)
		{
            int Id_Consumo = this.GetLastConsumoID()+1;
            Console.WriteLine(Id_Consumo);
            string Desc_TypeResource = "A";
            int Id_ResourceKey = 1;
            int Id_OTMaster = 1;
            int Id_History_EquipBuilding = 1;
            int Id_TypeResource = 1;
            string Desc_Resource = "B";
            string PartNo = "A1";
            double Quantity = 1;
            System.DateTime Duration = System.DateTime.Now;
            string Unit_Resource = "a";
            System.DateTime CreatedDate = System.DateTime.Now;
            decimal Cost = 1;
            decimal Total = 1;
            int Id_OTType = 1;
            bool Catalogado = false;
            string CostCenter = "a";
            int Id_Vale_Detail = 1;
            bool Automatico = true;
            bool IsOverTime = false;
            string MD = "a";

            this._MP_13_11_19DataSet.Consumo.AddConsumoRow(
                        Id_Consumo,
                        Id_OTMaster,
                        Id_History_EquipBuilding,
                        Id_TypeResource,
                        Desc_TypeResource,
                        Id_ResourceKey,
                        Desc_Resource,
                        PartNo,
                        Quantity,
                        Duration,
                        Unit_Resource,
                        CreatedDate,
                        Cost,
                        Total,
                        Id_OTType,
                        Catalogado,
                        CostCenter,
                        Id_Vale_Detail,
                        Automatico,
                        IsOverTime,
                        MD);

            //this.appData.Consumo.AddConsumoRow(this.appData.Consumo.NewConsumoRow());


            consumoBindingSource.MoveLast();
            consumoBindingSource.EndEdit();
            consumoTableAdapter.Update(this._MP_13_11_19DataSet.Consumo);
        }

		
	}
}
