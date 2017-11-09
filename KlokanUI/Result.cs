﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlokanUI
{
	struct Result
	{
		public int Year { get; }
		public string Category { get; }
		public int StudentNumber { get; }
		public AnswerType[,,] CorrectedAnswers { get; }
		public int Score { get; }
		public string SheetFilename { get; }
		public bool Error { get; }

		public Result(int year, string category, int studentNumber, AnswerType[,,] correctedAnswers, int score, string sheetFilename, bool error)
		{
			Year = year;
			Category = category;
			StudentNumber = studentNumber;
			CorrectedAnswers = correctedAnswers;
			Score = score;
			SheetFilename = sheetFilename;
			Error = error;
		}

		public Result(bool error)
		{
			Year = 0;
			Category = null;
			StudentNumber = -1;
			CorrectedAnswers = null;
			Score = -1;
			SheetFilename = null;
			Error = error;
		}
	}
}
