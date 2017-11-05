﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;

namespace KlokanUI
{
	public partial class TestAddItemForm : Form
	{
		KlokanTestDBScan newScanItem;
		string scanFilePath;

		bool[,,] chosenValuesStudentTable;
		bool[,,] chosenValuesAnswerTable;

		public TestAddItemForm(KlokanTestDBScan newScanItem)
		{
			InitializeComponent();

			filePathLabel.Text = "";

			this.newScanItem = newScanItem;
			scanFilePath = null;

			// this array is effectively two-dimensional; this is a trick to help make the code cleaner and faster
			// (I want to work with multi-dimensional arrays as opposed to jagged arrays)
			chosenValuesStudentTable = new bool[1, 5, 10];
			chosenValuesAnswerTable = new bool[3, 8, 5];
		}

		private void chooseFileButton_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				scanFilePath = openFileDialog.FileName;

				filePathLabel.Text = scanFilePath;

				Image scanImage = new Bitmap(scanFilePath);
				scanPictureBox.Image = scanImage;
			}
		}

		private void studentTablePictureBox_Click(object sender, EventArgs e)
		{
			HelperFunctions.HandleTableImageClicks(e as MouseEventArgs, studentTablePictureBox, 0, chosenValuesStudentTable);
		}

		private void answerTable1PictureBox_Click(object sender, EventArgs e)
		{
			HelperFunctions.HandleTableImageClicks(e as MouseEventArgs, answerTable1PictureBox, 0, chosenValuesAnswerTable);
		}

		private void answerTable2PictureBox_Click(object sender, EventArgs e)
		{
			HelperFunctions.HandleTableImageClicks(e as MouseEventArgs, answerTable2PictureBox, 1, chosenValuesAnswerTable);
		}

		private void answerTable3PictureBox_Click(object sender, EventArgs e)
		{
			HelperFunctions.HandleTableImageClicks(e as MouseEventArgs, answerTable3PictureBox, 2, chosenValuesAnswerTable);
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (scanFilePath == null || scanFilePath == "")
			{
				MessageBox.Show("No file has been selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!HelperFunctions.CheckAnswers(chosenValuesStudentTable, 0))
			{
				MessageBox.Show("Student number has not been properly selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			for (int i = 0; i < 3; i++)
			{
				if (!HelperFunctions.CheckAnswers(chosenValuesAnswerTable, i))
				{
					MessageBox.Show("Expected answers have not been properly selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			// prepare the DbSet of chosen expected answers
			List<KlokanTestDBExpectedAnswer> expectedAnswers = new List<KlokanTestDBExpectedAnswer>();
			expectedAnswers.AddRange(HelperFunctions.AnswersToDbSet<KlokanTestDBExpectedAnswer>(chosenValuesStudentTable, 0, true));
			for (int i = 0; i < 3; i++)
			{
				expectedAnswers.AddRange(HelperFunctions.AnswersToDbSet<KlokanTestDBExpectedAnswer>(chosenValuesAnswerTable, i, false));
			}

			newScanItem.Image = HelperFunctions.GetImageBytes(scanFilePath, ImageFormat.Png);
			newScanItem.ExpectedValues = expectedAnswers;
			newScanItem.Correctness = -1;		// correctness will only have a valid value once the evaluation is run

			DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
