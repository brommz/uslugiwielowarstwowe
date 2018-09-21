using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;

namespace webapp
{
    public class DatabaseRepository : IDatabaseRepository
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

            return simplePoll;
        }

        public List<SimplePollAnswer> GetSimplePollAnswers(Guid simplePollId)
        {
            var list = _storageFunctionality.Get<List<SimplePollAnswer>>(BuildKeyForAnswers(simplePollId));
            return list;
        }

        public void AddSimplePoll(SimplePoll simplePoll)
        {
            _storageFunctionality.Add(simplePoll.Id, simplePoll);
        }

        public void AddSimplePollOptions(Guid simplePollId, List<SimplePollOption> simplePollOptions)
        {
            var poll = _storageFunctionality.Get<SimplePoll>(simplePollId);

            var options = poll.Options;
            options.AddRange(simplePollOptions);

            _storageFunctionality.Add(simplePollId, poll);
        }

        public void AddSimplePollAnswers(Guid simplePollId, List<SimplePollAnswer> simplePollAnswers)
        {
            _storageFunctionality.Add(BuildKeyForAnswers(simplePollId), simplePollAnswers);
        }

        private string BuildKeyForAnswers(Guid simplePollId)
        {
            return simplePollId.ToString() + "_Answers";
        }
    }
}
