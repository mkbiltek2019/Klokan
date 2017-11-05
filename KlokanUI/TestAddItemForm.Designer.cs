﻿namespace KlokanUI
{
	partial class TestAddItemForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestAddItemForm));
			this.chooseFileButton = new System.Windows.Forms.Button();
			this.filePathLabel = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.okButton = new System.Windows.Forms.Button();
			this.expectedValuesLabel = new System.Windows.Forms.Label();
			this.answerTable3PictureBox = new System.Windows.Forms.PictureBox();
			this.answerTable2PictureBox = new System.Windows.Forms.PictureBox();
			this.answerTable1PictureBox = new System.Windows.Forms.PictureBox();
			this.scanPictureBox = new System.Windows.Forms.PictureBox();
			this.studentTablePictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.answerTable3PictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.answerTable2PictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.answerTable1PictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scanPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.studentTablePictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// chooseFileButton
			// 
			this.chooseFileButton.Location = new System.Drawing.Point(35, 37);
			this.chooseFileButton.Name = "chooseFileButton";
			this.chooseFileButton.Size = new System.Drawing.Size(90, 23);
			this.chooseFileButton.TabIndex = 0;
			this.chooseFileButton.Text = "Choose File";
			this.chooseFileButton.UseVisualStyleBackColor = true;
			this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
			// 
			// filePathLabel
			// 
			this.filePathLabel.AutoSize = true;
			this.filePathLabel.Location = new System.Drawing.Point(144, 42);
			this.filePathLabel.Name = "filePathLabel";
			this.filePathLabel.Size = new System.Drawing.Size(68, 13);
			this.filePathLabel.TabIndex = 1;
			this.filePathLabel.Text = "filePathLabel";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "JPEG Files|(*.jpg;*.jpeg;*JPG;*.JPEG)";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(925, 687);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 17;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// expectedValuesLabel
			// 
			this.expectedValuesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.expectedValuesLabel.AutoSize = true;
			this.expectedValuesLabel.Location = new System.Drawing.Point(512, 41);
			this.expectedValuesLabel.Name = "expectedValuesLabel";
			this.expectedValuesLabel.Size = new System.Drawing.Size(90, 13);
			this.expectedValuesLabel.TabIndex = 18;
			this.expectedValuesLabel.Text = "Expected Values:";
			// 
			// answerTable3PictureBox
			// 
			this.answerTable3PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.answerTable3PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("answerTable3PictureBox.Image")));
			this.answerTable3PictureBox.Location = new System.Drawing.Point(512, 487);
			this.answerTable3PictureBox.MaximumSize = new System.Drawing.Size(241, 225);
			this.answerTable3PictureBox.MinimumSize = new System.Drawing.Size(241, 225);
			this.answerTable3PictureBox.Name = "answerTable3PictureBox";
			this.answerTable3PictureBox.Size = new System.Drawing.Size(241, 225);
			this.answerTable3PictureBox.TabIndex = 16;
			this.answerTable3PictureBox.TabStop = false;
			this.answerTable3PictureBox.Click += new System.EventHandler(this.answerTable3PictureBox_Click);
			// 
			// answerTable2PictureBox
			// 
			this.answerTable2PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.answerTable2PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("answerTable2PictureBox.Image")));
			this.answerTable2PictureBox.Location = new System.Drawing.Point(759, 256);
			this.answerTable2PictureBox.MaximumSize = new System.Drawing.Size(241, 225);
			this.answerTable2PictureBox.MinimumSize = new System.Drawing.Size(241, 225);
			this.answerTable2PictureBox.Name = "answerTable2PictureBox";
			this.answerTable2PictureBox.Size = new System.Drawing.Size(241, 225);
			this.answerTable2PictureBox.TabIndex = 15;
			this.answerTable2PictureBox.TabStop = false;
			this.answerTable2PictureBox.Click += new System.EventHandler(this.answerTable2PictureBox_Click);
			// 
			// answerTable1PictureBox
			// 
			this.answerTable1PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.answerTable1PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("answerTable1PictureBox.Image")));
			this.answerTable1PictureBox.Location = new System.Drawing.Point(512, 256);
			this.answerTable1PictureBox.MaximumSize = new System.Drawing.Size(241, 225);
			this.answerTable1PictureBox.MinimumSize = new System.Drawing.Size(241, 225);
			this.answerTable1PictureBox.Name = "answerTable1PictureBox";
			this.answerTable1PictureBox.Size = new System.Drawing.Size(241, 225);
			this.answerTable1PictureBox.TabIndex = 14;
			this.answerTable1PictureBox.TabStop = false;
			this.answerTable1PictureBox.Click += new System.EventHandler(this.answerTable1PictureBox_Click);
			// 
			// scanPictureBox
			// 
			this.scanPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.scanPictureBox.Location = new System.Drawing.Point(35, 86);
			this.scanPictureBox.Name = "scanPictureBox";
			this.scanPictureBox.Size = new System.Drawing.Size(464, 624);
			this.scanPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.scanPictureBox.TabIndex = 2;
			this.scanPictureBox.TabStop = false;
			// 
			// studentTablePictureBox
			// 
			this.studentTablePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.studentTablePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("studentTablePictureBox.Image")));
			this.studentTablePictureBox.Location = new System.Drawing.Point(512, 86);
			this.studentTablePictureBox.MaximumSize = new System.Drawing.Size(488, 164);
			this.studentTablePictureBox.MinimumSize = new System.Drawing.Size(488, 164);
			this.studentTablePictureBox.Name = "studentTablePictureBox";
			this.studentTablePictureBox.Size = new System.Drawing.Size(488, 164);
			this.studentTablePictureBox.TabIndex = 19;
			this.studentTablePictureBox.TabStop = false;
			this.studentTablePictureBox.Click += new System.EventHandler(this.studentTablePictureBox_Click);
			// 
			// TestAddItemForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1040, 750);
			this.Controls.Add(this.studentTablePictureBox);
			this.Controls.Add(this.expectedValuesLabel);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.answerTable3PictureBox);
			this.Controls.Add(this.answerTable2PictureBox);
			this.Controls.Add(this.answerTable1PictureBox);
			this.Controls.Add(this.scanPictureBox);
			this.Controls.Add(this.filePathLabel);
			this.Controls.Add(this.chooseFileButton);
			this.MinimumSize = new System.Drawing.Size(1056, 789);
			this.Name = "TestAddItemForm";
			this.Text = "Klokan - Test - Add Item";
			((System.ComponentModel.ISupportInitialize)(this.answerTable3PictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.answerTable2PictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.answerTable1PictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.scanPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.studentTablePictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button chooseFileButton;
		private System.Windows.Forms.Label filePathLabel;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.PictureBox scanPictureBox;
		private System.Windows.Forms.PictureBox answerTable1PictureBox;
		private System.Windows.Forms.PictureBox answerTable2PictureBox;
		private System.Windows.Forms.PictureBox answerTable3PictureBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label expectedValuesLabel;
		private System.Windows.Forms.PictureBox studentTablePictureBox;
	}
}