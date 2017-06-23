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
	public partial class Config : Form
	{
		List<KeyValuePair<string, string>> configs = new List<KeyValuePair<string, string>>();
		List<TextBox> values = new List<TextBox>();
		public Config()
		{
			InitializeComponent();
			this.Text = "SM Formula Percentages";
			int pointX = 10;
			int pointY = 40;

			configs = parseCSV();
			foreach (KeyValuePair<string, string> kvp in configs)
			{
				Console.WriteLine(string.Format("Key: {0} Value: {1}", kvp.Key, kvp.Value));
				//Create label
				Label label = new Label();
				label.Text = kvp.Key;
				label.AutoSize = true;
				label.Location = new Point(pointX, pointY);
				//Create textbox
				TextBox textBox = new TextBox();
				textBox.Location = new Point(pointX, pointY + 15);
				textBox.Text = kvp.Value;
				//Line
				Label line = new Label();
				line.Text = "________________________________________________________";
				line.AutoSize = true;
				line.Location = new Point(pointX, pointY + label.Height + textBox.Height - 10);
				//Add controls to form
				this.Controls.Add(label);
				this.Controls.Add(textBox);
				this.Controls.Add(line);

				values.Add(textBox);
				pointY += 50;// pointY + label.Height + textBox.Height;
				Console.WriteLine(pointY);
			}

			Button save = new Button();
			save.Text = "Save";
			save.Location = new Point(pointX + 40, pointY);

			Button cancel = new Button();
			cancel.Text = "Cancel";
			cancel.Location = new Point(pointX + 120, pointY);

			save.Click += save_Click;
			cancel.Click += cancel_Click;

			this.Controls.Add(cancel);
			this.Controls.Add(save);
		}

		private List<KeyValuePair<string, string>> parseCSV()
		{
			List<KeyValuePair<string, string>> output = new List<KeyValuePair<string, string>>();
			var csvFile = @"config.csv";
			File.WriteAllLines(csvFile, File.ReadAllLines(csvFile).Where(arg => !string.IsNullOrWhiteSpace(arg)));
			int index = 0;
			using (StreamReader reader = new StreamReader(File.OpenRead(csvFile)))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(';');
					output.Insert(index, new KeyValuePair<string, string>(values[0], values[1]));

					//Console.WriteLine(values[0] + "," + values[1]);
					index++;
				}
			}
			return output;
		}

		private void save_Click(object sender, EventArgs e)
		{
			Console.WriteLine("Save");
			int index = 0;
			Console.WriteLine("configs size: " + configs.Count + ", values: " + values.Count);
			using (StreamWriter writer = new StreamWriter("temp.csv"))
			{
				foreach (TextBox tb in values)
				{
					Console.WriteLine(configs[index].Key + ";" + tb.Text);
					writer.WriteLine(configs[index].Key + ";" + tb.Text);
					index++;
				}
			}

			MessageBox.Show("Saved.");
			File.Delete("config.csv");
			System.IO.File.Move("temp.csv", "config.csv");
		}

		//TODO: Check if anything was changed and ask if want to save?
		private void cancel_Click(object sender, EventArgs e)
		{
			Console.WriteLine("Cancel");
			this.Close();
		}
	}
}
