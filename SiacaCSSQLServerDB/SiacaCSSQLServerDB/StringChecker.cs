using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiacaCSSQLServerDB
{
	class StringChecker
	{
		public List<char> listaCaracteresBaneados= new List<char>();
		public List<char> listaCaracteresAReemplazar = new List<char>();

		public StringChecker()
		{
			this.listaCaracteresBaneados.Add('ñ');
			this.listaCaracteresAReemplazar.Add('n');
			this.listaCaracteresBaneados.Add('Ñ');
			this.listaCaracteresAReemplazar.Add('N');
			this.listaCaracteresBaneados.Add('á');
			this.listaCaracteresAReemplazar.Add('a');
			this.listaCaracteresBaneados.Add('Á');
			this.listaCaracteresAReemplazar.Add('A');
			this.listaCaracteresBaneados.Add('é');
			this.listaCaracteresAReemplazar.Add('e');
			this.listaCaracteresBaneados.Add('É');
			this.listaCaracteresAReemplazar.Add('E');
			this.listaCaracteresBaneados.Add('í');
			this.listaCaracteresAReemplazar.Add('i');
			this.listaCaracteresBaneados.Add('Í');
			this.listaCaracteresAReemplazar.Add('I');
			this.listaCaracteresBaneados.Add('ó');
			this.listaCaracteresAReemplazar.Add('o');
			this.listaCaracteresBaneados.Add('Ó');
			this.listaCaracteresAReemplazar.Add('O');
			this.listaCaracteresBaneados.Add('ú');
			this.listaCaracteresAReemplazar.Add('u');
			this.listaCaracteresBaneados.Add('Ú');
			this.listaCaracteresAReemplazar.Add('U');

		}

		public string CheckForBans(string str)
		{
			//MessageBox.Show("string entrante: " +str);
			for(int i = 0; i < this.listaCaracteresAReemplazar.Count(); i++)
			{
				string result = str.Replace(this.listaCaracteresBaneados[i], this.listaCaracteresAReemplazar[i]);
				str = result;
			}
			//MessageBox.Show("string saliente: " + str);
			return str;
		}

		public string TrimWhiteSpace(string str)
		{
			string result = str.Trim();
			return result;
		}
	}
}
