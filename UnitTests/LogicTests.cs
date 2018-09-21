using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using webapp;
using Tests;
using webapp.Models;

namespace UnitTests
{
    [TestClass]
    public class LogicTests
    {
        private SimplePollsLogic _logic;

        [TestInitialize]
        public void InitForTesting()
        {
            _logic = new SimplePollsLogic(new FakeDatabaseRepository());
        }

        [TestMethod]
        public void Add_SimplePoll_Get_And_Check_If_The_Same()
        {
            var simplePoll = AddSimplePollToDb();

            var simplePollFromDb =_logic.GetSimplePollById(simplePoll.Id);
            Assert.AreSame(simplePoll, simplePollFromDb);
        }

        [TestMethod]
        public void Add_Option_To_SimplePoll()
        {
            var simplePoll = AddSimplePollToDb();
            var option = AddOptionToDb(simplePoll);

            var simplePollFromDb = _logic.GetSimplePollById(simplePoll.Id);
            var optionFromDb = simplePollFromDb.Options[0];
            Assert.AreSame(option, optionFromDb);
        }

        [TestMethod]
        public void Add_Answer_To_Option()
        {
            var simplePoll = AddSimplePollToDb();
            var option = AddOptionToDb(simplePoll);

            _logic.AddAnswerToSimplePollOption(new SimplePollAnswerUpdateModel()
            {
                EmployeeName = "Czesio",
                SimplePollId = simplePoll.Id,
                SimplePollOptionId = option.Id
            });

            var answerFromDb = _logic.GetAnswers(simplePoll.Id)[0];

            Assert.IsTrue(answerFromDb.EmployeeName == "Czesio"
                && answerFromDb.SimplePollOptionId == option.Id);
        }

        private SimplePoll AddSimplePollToDb()
        {
            var simplePoll = new SimplePoll()
            {
                Id = Guid.NewGuid(),
                Text = "test2",
                Type = SimplePoolType.MultipleChoice
            };
            _logic.AddSimplePoll(simplePoll);

            return simplePoll;
        }

        private SimplePollOption AddOptionToDb(SimplePoll simplePoll)
        {
            var option = new SimplePollOption()
            {
                Id = Guid.NewGuid(),
                Text = "opcja"
            };
            _logic.AddOptionToSimplePoll(simplePoll.Id, option);
            return option;
        }
    }
}
