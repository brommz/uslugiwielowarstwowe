using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;

namespace webapp
{
    public class SimplePollsLogic
    {
        private readonly IDatabaseRepository _database;

        public SimplePollsLogic(IDatabaseRepository database)
        {
            _database = database;
        }

        public SimplePoll GetSimplePollById(Guid simplePollId)
        {
            return _database.GetSimplePollWithOptions(simplePollId);
        }

        public List<SimplePollAnswer> GetAnswers(Guid simplePollId)
        {
            var answersFromDb = _database.GetSimplePollAnswers(simplePollId);

            if (answersFromDb == null)
            {
                return new List<SimplePollAnswer>();
            }

            List<SimplePollAnswer> answers = answersFromDb
                .ToList();
            return answers;
        }

        public void AddSimplePoll(SimplePoll poll)
        {
            _database.AddSimplePoll(poll);
        }

        public void AddOptionToSimplePoll(Guid simplePollId, SimplePollOption option)
        {
            _database.AddSimplePollOptions(simplePollId, new List<SimplePollOption>() { option });
        }

        public bool AddAnswerToSimplePollOption(SimplePollAnswerUpdateModel updateModel)
        {
            SimplePoll simplePoll = GetSimplePollById(updateModel.SimplePollId.Value);

            if (simplePoll == null)
            {
                return false;
            }

            var simplePollOption = simplePoll.Options.FirstOrDefault(o => o.Id == updateModel.SimplePollOptionId);
            if (simplePollOption == null)
            {
                return false;
            }

            List<SimplePollAnswer> answersDb = _database.GetSimplePollAnswers(updateModel.SimplePollId.Value);
            if (answersDb == null)
            {
                answersDb = new List<SimplePollAnswer>();
            }
            var answers = answersDb
                .Where(a => a.EmployeeName == updateModel.EmployeeName)
                .ToList();

            if (simplePoll.Type == SimplePoolType.SingleChoice)
            {
                if (answers.Any())
                {
                    return false;
                }
            }
            else if (simplePoll.Type == SimplePoolType.MultipleChoice)
            {
                if (answers.Select(a => a.SimplePollOptionId).Contains(updateModel.SimplePollOptionId.Value))
                {
                    return false;
                }
            }

            answersDb.Add(new SimplePollAnswer()
            {
                EmployeeName = updateModel.EmployeeName,
                SimplePollOptionId = updateModel.SimplePollOptionId.Value
            });

            _database.AddSimplePollAnswers(updateModel.SimplePollId.Value, answersDb);

            return true;
        }

    }
}
