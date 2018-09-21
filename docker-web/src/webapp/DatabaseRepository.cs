using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;

namespace webapp
{
    public class DatabaseRepository
    {
        private readonly StorageFunctionality _storageFunctionality;

        public DatabaseRepository(StorageFunctionality storageFunctionality)
        {
            _storageFunctionality = storageFunctionality;
        }

        public SimplePoll GetSimplePollWithOptions(Guid simplePollId)
        {
            List<SimplePollOption> options = new List<SimplePollOption>();
            SimplePoll simplePoll = _storageFunctionality.Get<SimplePoll>(simplePollId);

            return new SimplePoll()
            {
                Options = options
            };
        }

        public List<SimplePollAnswer> GetSimplePollAnswers(Guid simplePollId)
        {
            return _storageFunctionality.Get<List<SimplePollAnswer>>(simplePollId);
        }

        public void AddSimplePoll(SimplePoll simplePoll)
        {
            _storageFunctionality.Add(simplePoll.Id, simplePoll);
        }

        public void AddAnswerForOption(Guid simplePollId, Guid optionId, string employeeName)
        {
            SimplePollOption option = _storageFunctionality.Get<SimplePollOption>(optionId);
            SimplePollAnswer answer = new SimplePollAnswer()
            {
                Id = ObjectModel.GenerateGuid(),
                EmployeeName = employeeName,
                SimplePollOptionId = optionId
            };
          _storageFunctionality.Add(simplePollId, answer);
        }

        public void AddSimplePollOptions(Guid simplePollId, List<SimplePollOption> simplePollOptions)
        {
            _storageFunctionality.Add(simplePollId, simplePollOptions);
        }

        public void AddSimplePollAnswers(Guid simplePollId, List<SimplePollAnswer> simplePollAnswers)
        {
            _storageFunctionality.Add(simplePollId, simplePollAnswers);
        }
    }
}
