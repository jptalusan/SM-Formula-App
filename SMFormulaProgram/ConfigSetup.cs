using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMFormulaProgram
{
	public partial class ConfigSetup : Form
	{
		private string unknownShop = "";

		public ConfigSetup(string text)
		{
			string note = "These is not in list. Please update config first and rerun program.";
			InitializeComponent();
			unknownShop = text;
			shopName.Text = unknownShop;
			description.Text = unknownShop + note;
			this.Text = unknownShop;
			this.shopPercentTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(shopPercentTB_KeyPress);
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void save_Click(object sender, EventArgs e)
		{
			//Write label + textbox to end of file in config.csv
			File.AppendAllText(@"config.csv", unknownShop.Trim() + ";" + shopPercentTB.Text + Environment.NewLine);
			//Close
			this.Close();
		}

		private void shopPercentTB_TextChanged(object sender, EventArgs e)
		{

		}

		private void shopPercentTB_KeyPress(object sender, KeyPressEventArgs e)
		{
			onlynumwithsinglepoint(sender, e);
		}

		public void onlynumwithsinglepoint(object sender, KeyPressEventArgs e)
		{
			if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
			{ e.Handled = true; }
			TextBox txtDecimal = sender as TextBox;
			if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
			{
				e.Handled = true;
			}
		}
	}
}
