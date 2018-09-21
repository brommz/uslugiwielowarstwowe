using System;
using System.Collections.Generic;
using System.Text;
using webapp;
using webapp.Models;

namespace Tests
{
    public class FakeDatabaseRepository : IDatabaseRepository
    {
        private Dictionary<Guid, SimplePoll> _simplePolls = new Dictionary<Guid, SimplePoll>();
        private Dictionary<Guid, List<SimplePollAnswer>> _answers = new Dictionary<Guid, List<SimplePollAnswer>>();

        public void AddSimplePoll(SimplePoll simplePoll)
        {
            _simplePolls.Add(simplePoll.Id, simplePoll);
        }

        public void AddSimplePollAnswers(Guid simplePollId, List<SimplePollAnswer> simplePollAnswers)
        {
            _answers.Add(simplePollId, simplePollAnswers);
        }

        public void AddSimplePollOptions(Guid simplePollId, List<SimplePollOption> simplePollOptions)
        {
            _simplePolls[simplePollId].Options = simplePollOptions;
        }

        public List<SimplePollAnswer> GetSimplePollAnswers(Guid simplePollId)
        {
            if (!_answers.ContainsKey(simplePollId))
            {
                return new List<SimplePollAnswer>();
            }
            return _answers[simplePollId];
        }

        public SimplePoll GetSimplePollWithOptions(Guid simplePollId)
        {
            return _simplePolls[simplePollId];
        }

    }
}
