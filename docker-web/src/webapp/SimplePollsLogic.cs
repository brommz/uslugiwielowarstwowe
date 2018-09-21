using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;

namespace webapp
{
    public class SimplePollsLogic
    {
        private readonly DatabaseRepository _database;

        public SimplePollsLogic(DatabaseRepository database)
        {
            _database = database;
        }

        public SimplePoll GetSimplePollById(Guid simplePollId)
        {
            return _database.GetSimplePollWithOptions(simplePollId);
        }

        public List<SimplePollAnswer> GetAnswers(Guid simplePollId)
        {
            List<SimplePollAnswer> answers = 
                _database.GetSimplePollAnswers(simplePollId)
                .ToList();
            return answers;
        }

        public void AddSimplePoll(SimplePoll poll)
        {
            _database.AddSimplePoll(poll);
        }

        public void AddOptionToSimplePoll(SimplePoll poll, SimplePollOption option)
        {
            var options = poll.Options;
            options.Add(option);
            _database.AddSimplePollOptions(poll.Id, options);
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

            var answers = _database.GetSimplePollAnswers(updateModel.SimplePollId.Value)
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

            answers.Add(new SimplePollAnswer()
            {
                EmployeeName = updateModel.EmployeeName,
                SimplePollOptionId = updateModel.SimplePollOptionId.Value
            });

            _database.AddSimplePollAnswers(updateModel.SimplePollId.Value, answers);

            return true;
        }

    }
}
