﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using System.Data.Entity.Infrastructure;

namespace KlokanUI
{
	public partial class DatabaseDetailForm : Form
	{
		#region Fields

		/// <summary>
		/// Id of the answer sheet that's being viewed in this form.
		/// </summary>
		int answerSheetId;

		/// <summary>
		/// Answer sheet data.
		/// </summary>
		bool[,,] chosenAnswers;

		/// <summary>
		/// A temporary container for editing answer sheet data.
		/// </summary>
		bool[,,] chosenAnswersTemp;

		/// <summary>
		/// Answer sheet data.
		/// </summary>
		bool[,,] correctAnswers;

		/// <summary>
		/// Answer sheet data.
		/// </summary>
		int studentNumber;

		/// <summary>
		/// A temporary variable for editing answer sheet data.
		/// </summary>
		int studentNumberTemp;

		/// <summary>
		/// Answer sheet data.
		/// </summary>
		int points;

		#endregion

		public DatabaseDetailForm(int answerSheetId)
		{
			InitializeComponent();

			this.answerSheetId = answerSheetId;

			chosenAnswers = null;
			chosenAnswersTemp = null;
			correctAnswers = null;

			studentNumber = 0;
			studentNumberTemp = 0;

			points = -1;

			studentNumberTextBox.Hide();

			if (PopulateForm() == false)
			{
				DialogResult = DialogResult.Abort;
				this.Close();
			}
		}

		#region UI Functions

		private void editButton_Click(object sender, EventArgs e)
		{
			editButton.Enabled = false;
			applyButton.Enabled = true;
			discardButton.Enabled = true;
			reevaluateButton.Enabled = false;
			updateDatabaseButton.Enabled = false;

			// make the student number field editable
			studentNumberTextBox.Text = studentNumber.ToString();
			studentNumberValueLabel.Hide();
			studentNumberTextBox.Show();

			// draw only chosen answers as only those can be edited
			ResetTableImages();

			FormTableHandling.DrawAnswers(table1PictureBox, chosenAnswers, 0, FormTableHandling.DrawCross, Color.Black);
			FormTableHandling.DrawAnswers(table2PictureBox, chosenAnswers, 1, FormTableHandling.DrawCross, Color.Black);
			FormTableHandling.DrawAnswers(table3PictureBox, chosenAnswers, 2, FormTableHandling.DrawCross, Color.Black);

			// create a copy of currently chosen answers for editing
			chosenAnswersTemp = new bool[3, 8, 5];
			Array.Copy(chosenAnswers, chosenAnswersTemp, 3 * 8 * 5);
		}

		private void applyButton_Click(object sender, EventArgs e)
		{
			if (int.TryParse(studentNumberTextBox.Text, out studentNumberTemp) == false)
			{
				MessageBox.Show(Properties.Resources.ErrorTextInvalidStudentNumber, Properties.Resources.ErrorCaptionGeneral, 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (studentNumberTemp < 0 || studentNumberTemp > 99999)
			{
				MessageBox.Show(Properties.Resources.ErrorTextStudentNumberOutOfRange, Properties.Resources.ErrorCaptionGeneral, 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			editButton.Enabled = true;
			applyButton.Enabled = false;
			discardButton.Enabled = false;
			reevaluateButton.Enabled = true;

			studentNumberTextBox.Hide();
			studentNumberValueLabel.Text = studentNumberTemp.ToString();
			studentNumberValueLabel.Show();

			studentNumber = studentNumberTemp;
			chosenAnswers = chosenAnswersTemp;
		}

		private void discardButton_Click(object sender, EventArgs e)
		{
			applyButton.Enabled = false;
			discardButton.Enabled = false;
			editButton.Enabled = true;

			studentNumberTextBox.Hide();
			studentNumberValueLabel.Show();

			// draw the original answers
			ResetTableImages();

			FormTableHandling.DrawAnswers(table1PictureBox, chosenAnswers, 0, FormTableHandling.DrawCross, Color.Black);
			FormTableHandling.DrawAnswers(table2PictureBox, chosenAnswers, 1, FormTableHandling.DrawCross, Color.Black);
			FormTableHandling.DrawAnswers(table3PictureBox, chosenAnswers, 2, FormTableHandling.DrawCross, Color.Black);

			FormTableHandling.DrawAnswers(table1PictureBox, correctAnswers, 0, FormTableHandling.DrawCircle, Color.Red);
			FormTableHandling.DrawAnswers(table2PictureBox, correctAnswers, 1, FormTableHandling.DrawCircle, Color.Red);
			FormTableHandling.DrawAnswers(table3PictureBox, correctAnswers, 2, FormTableHandling.DrawCircle, Color.Red);
		}

		private void reevaluateButton_Click(object sender, EventArgs e)
		{
			reevaluateButton.Enabled = false;
			updateDatabaseButton.Enabled = true;

			points = TableArrayHandling.CountScore(chosenAnswers, correctAnswers);
			pointsValueLabel.Text = points.ToString();

			// draw both chosen and correct answers again
			ResetTableImages();

			FormTableHandling.DrawAnswers(table1PictureBox, chosenAnswers, 0, FormTableHandling.DrawCross, Color.Black);
			FormTableHandling.DrawAnswers(table2PictureBox, chosenAnswers, 1, FormTableHandling.DrawCross, Color.Black);
			FormTableHandling.DrawAnswers(table3PictureBox, chosenAnswers, 2, FormTableHandling.DrawCross, Color.Black);

			FormTableHandling.DrawAnswers(table1PictureBox, correctAnswers, 0, FormTableHandling.DrawCircle, Color.Red);
			FormTableHandling.DrawAnswers(table2PictureBox, correctAnswers, 1, FormTableHandling.DrawCircle, Color.Red);
			FormTableHandling.DrawAnswers(table3PictureBox, correctAnswers, 2, FormTableHandling.DrawCircle, Color.Red);
		}

		private void updateDatabaseButton_Click(object sender, EventArgs e)
		{
			updateDatabaseButton.Enabled = false;

			var dialogResult = MessageBox.Show(Properties.Resources.PromptTextDatabaseUpdate, Properties.Resources.PromptCaptionDatabaseUpdate, 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.No)
			{
				return;
			}

			// convert the chosen answers into a DbSet
			List<KlokanDBChosenAnswer> newChosenAnswers = new List<KlokanDBChosenAnswer>();
			for (int i = 0; i < 3; i++)
			{
				newChosenAnswers.AddRange(TableArrayHandling.AnswersToDbSet<KlokanDBChosenAnswer>(chosenAnswers, i, false));
			}

			int newPoints = points;

			using (var db = new KlokanDBContext())
			{
				var query = from sheet in db.AnswerSheets
							where sheet.AnswerSheetId == answerSheetId
							select sheet;

				KlokanDBAnswerSheet answerSheet = query.FirstOrDefault();
				if (answerSheet == null)
				{
					MessageBox.Show(Properties.Resources.ErrorTextSheetNotFoundInDatabase, Properties.Resources.ErrorCaptionGeneral, 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// load the old chosen answers so that EF knows it should delete them when the old answer sheet is deleted
				List<KlokanDBChosenAnswer> blah = new List<KlokanDBChosenAnswer>(answerSheet.ChosenAnswers);

				KlokanDBAnswerSheet updatedAnswerSheet = new KlokanDBAnswerSheet
				{
					StudentNumber = studentNumber,
					Points = newPoints,
					Scan = answerSheet.Scan,
					InstanceId = answerSheet.InstanceId,
					Instance = answerSheet.Instance,
					ChosenAnswers = newChosenAnswers
				};

				db.AnswerSheets.Remove(answerSheet);
				db.AnswerSheets.Add(updatedAnswerSheet);

				try
				{
					db.SaveChanges();

					MessageBox.Show(Properties.Resources.InfoTextDatabaseUpdated, Properties.Resources.InfoCaptionDatabaseUpdated,
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex) when (ex is DbUpdateException || ex is DbUpdateConcurrencyException)
				{
					MessageBox.Show(Properties.Resources.ErrorTextDatabase, Properties.Resources.ErrorCaptionGeneral, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			}
		}

		private void table1PictureBox_Click(object sender, EventArgs e)
		{
			// if in edit mode
			if (editButton.Enabled == false)
			{
				FormTableHandling.HandleTableImageClicks(e as MouseEventArgs, table1PictureBox, 0, chosenAnswersTemp);
			}
		}

		private void table2PictureBox_Click(object sender, EventArgs e)
		{
			// if in edit mode
			if (editButton.Enabled == false)
			{
				FormTableHandling.HandleTableImageClicks(e as MouseEventArgs, table2PictureBox, 1, chosenAnswersTemp);
			}
		}

		private void table3PictureBox_Click(object sender, EventArgs e)
		{
			// if in edit mode
			if (editButton.Enabled == false)
			{
				FormTableHandling.HandleTableImageClicks(e as MouseEventArgs, table3PictureBox, 2, chosenAnswersTemp);
			}

		}

		#endregion

		#region Helper Functions

		/// <summary>
		/// Extract answer sheet data from the database and display it in the form.
		/// Returns false if data could not be loaded.
		/// </summary>
		private bool PopulateForm()
		{
			using (var db = new KlokanDBContext())
			{
				// load sheet data
				var sheetQuery = from sheet in db.AnswerSheets
								 where sheet.AnswerSheetId == answerSheetId
								 select sheet;

				KlokanDBAnswerSheet answerSheet = sheetQuery.FirstOrDefault();
				if (answerSheet == null)
				{
					MessageBox.Show(Properties.Resources.ErrorTextSheetNotFoundInDatabase, Properties.Resources.ErrorCaptionGeneral, 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				var instanceQuery = from instance in db.Instances
									where instance.InstanceId == answerSheet.InstanceId
									select instance;

				KlokanDBInstance currentInstance = instanceQuery.FirstOrDefault();
				if (answerSheet == null)
				{
					MessageBox.Show(Properties.Resources.ErrorTextSheetNotFoundInDatabase, Properties.Resources.ErrorCaptionGeneral,
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				studentNumber = answerSheet.StudentNumber;

				// show sheet data
				studentNumberValueLabel.Text = answerSheet.StudentNumber.ToString();
				idValueLabel.Text = answerSheet.AnswerSheetId.ToString();
				yearValueLabel.Text = currentInstance.Year.ToString();
				categoryValueLabel.Text = currentInstance.Category.ToString();
				pointsValueLabel.Text = answerSheet.Points.ToString();

				// load scan
				scanPictureBox.Image = ImageHandling.GetBitmap(answerSheet.Scan);

				// load answers and draw them
				var chosenAnswersQuery = from chosenAnswer in db.ChosenAnswers
										 where chosenAnswer.AnswerSheetId == answerSheetId
										 select chosenAnswer;

				var chosenAnswersList = chosenAnswersQuery.ToList();
				if (chosenAnswersList.Count == 0)
				{
					MessageBox.Show(Properties.Resources.ErrorTextSheetNotFoundInDatabase, Properties.Resources.ErrorCaptionGeneral, 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				TableArrayHandling.DbSetToAnswers(chosenAnswersList, out chosenAnswers);

				FormTableHandling.DrawAnswers(table1PictureBox, chosenAnswers, 0, FormTableHandling.DrawCross, Color.Black);
				FormTableHandling.DrawAnswers(table2PictureBox, chosenAnswers, 1, FormTableHandling.DrawCross, Color.Black);
				FormTableHandling.DrawAnswers(table3PictureBox, chosenAnswers, 2, FormTableHandling.DrawCross, Color.Black);

				var correctAnswersQuery = from correctAnswer in db.CorrectAnswers
										  where correctAnswer.InstanceId == answerSheet.InstanceId
										  select correctAnswer;

				var correctAnswersList = correctAnswersQuery.ToList();
				if (correctAnswersList.Count == 0)
				{
					MessageBox.Show(Properties.Resources.ErrorTextSheetNotFoundInDatabase, Properties.Resources.ErrorCaptionGeneral,
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				TableArrayHandling.DbSetToAnswers(correctAnswersQuery.ToList(), out correctAnswers);

				FormTableHandling.DrawAnswers(table1PictureBox, correctAnswers, 0, FormTableHandling.DrawCircle, Color.Red);
				FormTableHandling.DrawAnswers(table2PictureBox, correctAnswers, 1, FormTableHandling.DrawCircle, Color.Red);
				FormTableHandling.DrawAnswers(table3PictureBox, correctAnswers, 2, FormTableHandling.DrawCircle, Color.Red);
			}

			return true;
		}

		/// <summary>
		/// Resets all picture boxes in this form which get rid of all answer drawings that had been made.
		/// </summary>
		private void ResetTableImages()
		{
			List<Image> oldImages = new List<Image>();
			oldImages.Add(table1PictureBox.Image);
			oldImages.Add(table2PictureBox.Image);
			oldImages.Add(table3PictureBox.Image);

			foreach (var oldImage in oldImages)
			{
				if (oldImage != null) oldImage.Dispose();
			}

			table1PictureBox.Image = Properties.Resources.answerTable1Image;
			table2PictureBox.Image = Properties.Resources.answerTable2Image;
			table3PictureBox.Image = Properties.Resources.answerTable3Image;

			table1PictureBox.Refresh();
			table2PictureBox.Refresh();
			table3PictureBox.Refresh();
		}

		#endregion
	}
}
