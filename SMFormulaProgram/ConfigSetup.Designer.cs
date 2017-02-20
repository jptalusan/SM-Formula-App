namespace SMFormulaProgram
{
	partial class ConfigSetup
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
			this.shopName = new System.Windows.Forms.Label();
			this.shopPercentTB = new System.Windows.Forms.TextBox();
			this.save = new System.Windows.Forms.Button();
			this.description = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// shopName
			// 
			this.shopName.AutoSize = true;
			this.shopName.Location = new System.Drawing.Point(12, 51);
			this.shopName.Name = "shopName";
			this.shopName.Size = new System.Drawing.Size(35, 13);
			this.shopName.TabIndex = 0;
			this.shopName.Text = "label1";
			this.shopName.Click += new System.EventHandler(this.label1_Click);
			// 
			// shopPercentTB
			// 
			this.shopPercentTB.Location = new System.Drawing.Point(321, 48);
			this.shopPercentTB.Name = "shopPercentTB";
			this.shopPercentTB.Size = new System.Drawing.Size(53, 20);
			this.shopPercentTB.TabIndex = 1;
			this.shopPercentTB.TextChanged += new System.EventHandler(this.shopPercentTB_TextChanged);
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(134, 86);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(118, 23);
			this.save.TabIndex = 2;
			this.save.Text = "Save and Close";
			this.save.UseVisualStyleBackColor = true;
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// description
			// 
			this.description.AutoSize = true;
			this.description.Location = new System.Drawing.Point(13, 13);
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(35, 13);
			this.description.TabIndex = 3;
			this.description.Text = "label1";
			// 
			// ConfigSetup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(390, 121);
			this.Controls.Add(this.description);
			this.Controls.Add(this.save);
			this.Controls.Add(this.shopPercentTB);
			this.Controls.Add(this.shopName);
			this.Name = "ConfigSetup";
			this.Text = "ConfigSetup";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label shopName;
		private System.Windows.Forms.TextBox shopPercentTB;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Label description;
	}
}