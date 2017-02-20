using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Globalization;
using System.Diagnostics;

//TODO: Parse file name of input file and use that to save as output file
//display output in grid display (currently being used by this app)
//TODO: Add button to open/edit configs
//open any first sheet http://stackoverflow.com/questions/20618154/how-to-select-from-any-spreadsheet-in-excel-file-using-oledbdataadapter
namespace SMFormulaProgram
{
	public partial class Form1 : Form
	{
		System.Data.DataTable dtexcel = new System.Data.DataTable();
		OleDbConnection con;
		OleDbCommand command;
		string filePath = "";
		string fileName = "";
		List<Dictionary<string, int>> masterList = new List<Dictionary<string, int>>();
		Dictionary<string, double> masterDictionary = new Dictionary<string, double>();
		List<string> ignoreList = new List<string>();
		char delimiter = ';';
		public Form1()
		{
			InitializeComponent();
			this.Text = "SM Formula";
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				foreach (string filePath in files)
				{
					Console.WriteLine(filePath);
					this.fileName = Path.GetFileName(filePath);
					textBox1.Text = this.fileName;
					this.filePath = filePath;
					output.Text = "Click Read File to start.";
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.DragEnter += Form1_DragEnter;
			this.DragDrop += Form1_DragDrop;
		}

		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void btnChooseFile(object sender, EventArgs e)
		{
			string filePath = string.Empty;
			string fileExt = string.Empty;
			OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
			if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
			{
				filePath = file.FileName; //get the path of the file  
				fileExt = Path.GetExtension(filePath); //get the file extension  
				if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
				{
					try
					{
						System.Data.DataTable dtExcel = new System.Data.DataTable();
						dtExcel = ReadExcel(filePath, fileExt); //read excel file  
						dataGridView1.Visible = true;
						dataGridView1.DataSource = dtExcel;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message.ToString());
					}
				}
				else
				{
					MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
				}
			}
		}

		public System.Data.DataTable ReadExcel(string fileName, string fileExt)
		{
			string conn = string.Empty;
			System.Data.DataTable dtexcel = new System.Data.DataTable();
			if (fileExt.CompareTo(".xls") == 0)
				conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
			else
				conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
			using (OleDbConnection con = new OleDbConnection(conn))
			{
				try
				{
					con.Open();
					System.Data.DataTable dtSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
					string Sheet1 = dtSchema.Rows[0].Field<string>("TABLE_NAME");
					Console.WriteLine(Sheet1);
					OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [" + Sheet1 + "]", con); //here we read data from sheet1  
					oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
				}
				catch { }
			}
			return dtexcel;
		}

		private void readConfLists()
		{
			masterDictionary.Clear();
			ignoreList.Clear();
			//TODO: Read files from config (csv)
			var csvFile = @"config.csv";
			File.WriteAllLines(csvFile, File.ReadAllLines(csvFile).Where(arg => !string.IsNullOrWhiteSpace(arg)));

			using (StreamReader reader = new StreamReader(File.OpenRead(csvFile)))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(delimiter);

					if (!masterDictionary.ContainsKey(values[0]))
					{
						masterDictionary.Add(values[0].ToString(), Convert.ToDouble(values[1]));
					}

					Console.WriteLine(values[0] + "," + values[1]);
				}
			}

			//Read ignore list
			var ignore = @"ignore.csv";
			File.WriteAllLines(ignore, File.ReadAllLines(ignore).Where(arg => !string.IsNullOrWhiteSpace(arg)));
			using (StreamReader ignoreListReader = new StreamReader(File.OpenRead(ignore)))
			{
				while (!ignoreListReader.EndOfStream)
				{
					var line = ignoreListReader.ReadLine();
					ignoreList.Add(line);
				}
			}
		}


		private void readFile_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource = null;
			dataGridView1.Rows.Clear();
			dataGridView1.Refresh();
			dataGridView1.Visible = true;
			dtexcel.Reset();
			dtexcel.Clear();
			dtexcel = new System.Data.DataTable();

			List<string> names = new List<string>();
			List<double> prices = new List<double>();
			string outputText = "";
			string conn = string.Empty;
			if (Path.GetExtension(this.filePath).CompareTo(".xls") == 0)
				conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.filePath + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
			else
				conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.filePath + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
			using (con = new OleDbConnection(conn))
			{
				try
				{

					con.Open();
					System.Data.DataTable dtSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
					string Sheet1 = dtSchema.Rows[0].Field<string>("TABLE_NAME");
					Console.WriteLine(Sheet1);
					command = new OleDbCommand(@"SELECT * FROM [" + Sheet1 + "]", con); //here we read data from sheet1

					using (OleDbDataReader dr = command.ExecuteReader())
					{
						readConfLists();
						double total = 0;
						double oldTotal = 0;
						double newPrice = 0.0;
						string cardHolderName = "";
						double cardHolderTotal = 0;
						double cardHolderNumber = 0;
						double oldCardHolderTotal = 0;
						double price = 0;
						List<string> unknownStores = new List<string>();

						//TODO: add option to display in string or double (totals)
						dtexcel.Columns.Add("Card Number", typeof(double));
						dtexcel.Columns.Add("Cardholder", typeof(string));
						dtexcel.Columns.Add("Old Total", typeof(double));
						dtexcel.Columns.Add("New Total", typeof(double));
						dtexcel.Columns.Add("Quarter", typeof(double));
						dtexcel.Columns.Add("Diff", typeof(double));
						while (dr.Read())
						{
							var name = dr.GetValue(0);
							if (name != DBNull.Value)
							{
								//TODO: Add checking if not in masterDictionary, prompt? open config? show name of ones not found?
								//TODO: add another masterList for ignored items
								//TODO: Major bug, need to open and save again the journal details file
								//TODO: Fix rogue exceptions
								string nameToCheck = (name as string).Trim();
								string priceToCheck = dr[4] as string;
								names.Add(nameToCheck);
								if (masterDictionary.ContainsKey(nameToCheck))
								{
									if (!Regex.IsMatch(priceToCheck, @"^[a-zA-Z: _]+$"))
									{
										price = Math.Round(Convert.ToDouble(Regex.Replace(priceToCheck, "[^0-9.]", "")), 2, MidpointRounding.AwayFromZero);

										prices.Add(price);
										newPrice = Math.Round(price + (prices[prices.Count - 1] * masterDictionary[nameToCheck]), 2, MidpointRounding.AwayFromZero);
										oldCardHolderTotal += price;
										cardHolderTotal += newPrice;
										total += newPrice;
										oldTotal += price;
										Console.WriteLine(nameToCheck + ", old:" + price + " new: " + newPrice);
									}
									else
									{
										//Console.WriteLine("Not a price.");
									}
								}
								else if (ignoreList.Contains(nameToCheck) || nameToCheck.Equals("")) // Name is in ignore list
								{
									//ignore
								}
								else if (nameToCheck.Equals("Credit Card No.:")) // Name is equal to total (need to total and reset some values), get name of person (save it somewhere)
								{
									cardHolderName = dr[3] as string;
									Console.WriteLine("Card Holder: " + cardHolderName);
									string temp = dr[1] as string;
									string substr = temp.Substring(temp.Length - 6);
									cardHolderNumber = Convert.ToDouble(substr);
								}
								else if (nameToCheck.Equals("Total:"))
								{
									Console.Write(cardHolderName + ", total: ");
									Console.WriteLine(cardHolderTotal);

									DataRow dataRow = dtexcel.NewRow();
									dataRow["Card Number"] = cardHolderNumber;
									dataRow["Cardholder"] = cardHolderName;
									dataRow["Old Total"] = Math.Round(oldCardHolderTotal, 2, MidpointRounding.AwayFromZero);
									dataRow["New Total"] = Math.Round(cardHolderTotal, 2, MidpointRounding.AwayFromZero);
									dataRow["Diff"] = Math.Round(cardHolderTotal - oldCardHolderTotal, 2, MidpointRounding.AwayFromZero);
									dataRow["Quarter"] = Math.Round(cardHolderTotal / 4, 2, MidpointRounding.AwayFromZero);
									dtexcel.Rows.Add(dataRow);

									cardHolderTotal = 0;
									oldCardHolderTotal = 0;
								}
								else // Name is new and should prompt XXX and must be added to master List
								{
									if (!unknownStores.Contains(nameToCheck))
										unknownStores.Add(nameToCheck);
									Console.WriteLine(nameToCheck + " is not in master list.");
								}
							}
							else
							{
								//Console.WriteLine("Name is null.");
							}
						}

						if (unknownStores.Count > 0)
						{
							string temp = "";
							System.Data.DataTable missingShopsDt = new System.Data.DataTable();
							missingShopsDt.Columns.Add("Missing Shops", typeof(string));
							DataRow missRow = missingShopsDt.NewRow();
							foreach (string store in unknownStores)
							{
								temp += store + "\n";
								missRow["Missing Shops"] = store;
								missingShopsDt.Rows.Add(missRow);

								ConfigSetup configSetup = new ConfigSetup(temp);
								configSetup.Show();
							}
							dataGridView1.DataSource = missingShopsDt;
						}
						else
						{

							outputText += "Old Total: " + oldTotal.ToString("C2", CultureInfo.CreateSpecificCulture("en-PH")) + "\n";
							outputText += "Total: " + total.ToString("C2", CultureInfo.CreateSpecificCulture("en-PH")) + "\n";
							Console.WriteLine("Old Total: " + oldTotal);
							Console.WriteLine("Total: " + total);
							output.Text = outputText;
							DataRow dataRow = dtexcel.NewRow();
							//dataRow["Cardholder"] = "";
							dataRow["Old Total"] = Math.Round(oldTotal, 2, MidpointRounding.AwayFromZero);
							dataRow["New Total"] = Math.Round(total, 2, MidpointRounding.AwayFromZero);
							dataRow["Diff"] = Math.Round(total - oldTotal, 2, MidpointRounding.AwayFromZero);
							//dataRow["Quarter"] = Math.Round(total / 4, 2, MidpointRounding.AwayFromZero);
							dtexcel.Rows.Add(dataRow);
							dataGridView1.DataSource = dtexcel;
							dataGridView1.Columns["Old Total"].DefaultCellStyle.Format = "C";
							dataGridView1.Columns["Old Total"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-PH");
							dataGridView1.Columns["New Total"].DefaultCellStyle.Format = "C";
							dataGridView1.Columns["New Total"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-PH");
							dataGridView1.Columns["Diff"].DefaultCellStyle.Format = "C";
							dataGridView1.Columns["Diff"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-PH");
							dataGridView1.Columns["Quarter"].DefaultCellStyle.Format = "C";
							dataGridView1.Columns["Quarter"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-PH");
						}
					}
				}
				catch
				{
					MessageBox.Show("Drag Journal details file to program before clicking read file.");
					Console.WriteLine("Wala");
				}
			}
		}

		private void updateConfigs_Click(object sender, EventArgs e)
		{
			Process.Start("notepad.exe", "config.csv");
		}

		//TODO: add option to select where to save output
		private void export_Click(object sender, EventArgs e)
		{
			var lines = new List<string>();

			string[] columnNames = dtexcel.Columns.Cast<DataColumn>().
											  Select(column => column.ColumnName).
											  ToArray();

			var header = string.Join(",", columnNames);
			lines.Add(header);

			var valueLines = dtexcel.AsEnumerable()
							   .Select(row => string.Join(",", row.ItemArray));
			lines.AddRange(valueLines);

			File.WriteAllLines(fileName + "_output.csv", lines);
		}
	}
}
