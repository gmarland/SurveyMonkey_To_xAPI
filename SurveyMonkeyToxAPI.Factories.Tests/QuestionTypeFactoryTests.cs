using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurveyMonkeyToxAPI.Models;
using SurveyMonkeyToxAPI.Models.QuestionTypes;

namespace SurveyMonkeyToxAPI.Factories.Tests
{
    [TestClass]
    public class QuestionTypeFactoryTests
    {
        [TestMethod]
        public void GetQuestionTypePassing()
        {
            Assert.AreEqual(QuestionType.Single, QuestionTypeFactory.GetQuestionType("single_choice", "vertical"));
            Assert.AreEqual(QuestionType.Multiple, QuestionTypeFactory.GetQuestionType("multiple_choice", "vertical"));
            Assert.AreEqual(QuestionType.MatrixSingle, QuestionTypeFactory.GetQuestionType("matrix", "single"));
            Assert.AreEqual(QuestionType.MatrixMultiple, QuestionTypeFactory.GetQuestionType("matrix", "multiple"));
            Assert.AreEqual(QuestionType.MatrixRating, QuestionTypeFactory.GetQuestionType("matrix", "rating"));
            Assert.AreEqual(QuestionType.MatrixRanking, QuestionTypeFactory.GetQuestionType("matrix", "ranking"));
            Assert.AreEqual(QuestionType.OpenEndedSingle, QuestionTypeFactory.GetQuestionType("open_ended", "single"));
            Assert.AreEqual(QuestionType.OpenEndedMulti, QuestionTypeFactory.GetQuestionType("open_ended", "multi"));
            Assert.AreEqual(QuestionType.OpenEndedNumerical, QuestionTypeFactory.GetQuestionType("open_ended", "numerical"));
            Assert.AreEqual(QuestionType.DateQuestion, QuestionTypeFactory.GetQuestionType("datetime"));

            Assert.AreEqual(QuestionType.Unknown, QuestionTypeFactory.GetQuestionType("random"));
        }

        [TestMethod]
        public void GetQuestionTypeModulePassing()
        {
            Assert.IsInstanceOfType(QuestionTypeFactory.GetQuestionTypeModule(QuestionType.Single, null), typeof(Models.QuestionTypes.Single));
            Assert.IsInstanceOfType(QuestionTypeFactory.GetQuestionTypeModule(QuestionType.Multiple, null), typeof(Multiple));
            Assert.IsInstanceOfType(QuestionTypeFactory.GetQuestionTypeModule(QuestionType.MatrixSingle, null), typeof(MatrixSingle));
            Assert.IsInstanceOfType(QuestionTypeFactory.GetQuestionTypeModule(QuestionType.MatrixMultiple, null), typeof(MatrixMultiple));
            Assert.IsInstanceOfType(QuestionTypeFactory.GetQuestionTypeModule(QuestionType.MatrixRating, null), typeof(MatrixRating));
            Assert.IsInstanceOfType(QuestionTypeFactory.GetQuestionTypeModule(QuestionType.MatrixRanking, null), typeof(MatrixRanking));
            Assert.IsInstanceOfType(QuestionTypeFactory.GetQuestionTypeModule(QuestionType.OpenEndedSingle, null), typeof(OpenEndedSingle));
            Assert.IsInstanceOfType(QuestionTypeFactory.GetQuestionTypeModule(QuestionType.OpenEndedMulti, null), typeof(OpenEndedMulti));
            Assert.IsInstanceOfType(QuestionTypeFactory.GetQuestionTypeModule(QuestionType.OpenEndedNumerical, null) , typeof(OpenEndedNumerical));
            Assert.IsInstanceOfType(QuestionTypeFactory.GetQuestionTypeModule(QuestionType.DateQuestion, null), typeof(DateQuestion));

            Assert.AreEqual(null, QuestionTypeFactory.GetQuestionTypeModule(QuestionType.Unknown, null));
        }
    }
}
