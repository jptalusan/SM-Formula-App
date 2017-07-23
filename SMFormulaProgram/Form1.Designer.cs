namespace SMFormulaProgram
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.readFile = new System.Windows.Forms.Button();
			this.output = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.updateConfigs = new System.Windows.Forms.Button();
			this.export = new System.Windows.Forms.Button();
			this.openPercentages = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridView1.Location = new System.Drawing.Point(12, 42);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(792, 306);
			this.dataGridView1.TabIndex = 2;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(470, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(334, 20);
			this.textBox1.TabIndex = 3;
			// 
			// readFile
			// 
			this.readFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.readFile.Location = new System.Drawing.Point(687, 354);
			this.readFile.Name = "readFile";
			this.readFile.Size = new System.Drawing.Size(117, 23);
			this.readFile.TabIndex = 4;
			this.readFile.Text = "Read File";
			this.readFile.UseVisualStyleBackColor = true;
			this.readFile.Click += new System.EventHandler(this.readFile_Click);
			// 
			// output
			// 
			this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.output.AutoSize = true;
			this.output.Location = new System.Drawing.Point(12, 359);
			this.output.Name = "output";
			this.output.Size = new System.Drawing.Size(35, 13);
			this.output.TabIndex = 5;
			this.output.Text = "label1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "File Name:";
			// 
			// updateConfigs
			// 
			this.updateConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.updateConfigs.Location = new System.Drawing.Point(687, 383);
			this.updateConfigs.Name = "updateConfigs";
			this.updateConfigs.Size = new System.Drawing.Size(117, 23);
			this.updateConfigs.TabIndex = 7;
			this.updateConfigs.Text = "Update Shop List";
			this.updateConfigs.UseVisualStyleBackColor = true;
			this.updateConfigs.Visible = false;
			this.updateConfigs.Click += new System.EventHandler(this.updateConfigs_Click);
			// 
			// export
			// 
			this.export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.export.Location = new System.Drawing.Point(687, 383);
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(116, 23);
			this.export.TabIndex = 8;
			this.export.Text = "Export Results";
			this.export.UseVisualStyleBackColor = true;
			this.export.Click += new System.EventHandler(this.export_Click);
			// 
			// openPercentages
			// 
			this.openPercentages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.openPercentages.Location = new System.Drawing.Point(584, 383);
			this.openPercentages.Name = "openPercentages";
			this.openPercentages.Size = new System.Drawing.Size(97, 23);
			this.openPercentages.TabIndex = 9;
			this.openPercentages.Text = "Percentages";
			this.openPercentages.UseVisualStyleBackColor = true;
			this.openPercentages.Click += new System.EventHandler(this.openPercentages_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(816, 417);
			this.Controls.Add(this.openPercentages);
			this.Controls.Add(this.export);
			this.Controls.Add(this.updateConfigs);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.output);
			this.Controls.Add(this.readFile);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.dataGridView1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button readFile;
		private System.Windows.Forms.Label output;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button updateConfigs;
		private System.Windows.Forms.Button export;
		private System.Windows.Forms.Button openPercentages;
	}
}

