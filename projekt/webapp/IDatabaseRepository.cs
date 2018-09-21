using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;

namespace webapp
{
    public interface IDatabaseRepository
    {
        SimplePoll GetSimplePollWithOptions(Guid simplePollId);
        List<SimplePollAnswer> GetSimplePollAnswers(Guid simplePollId);
        void AddSimplePoll(SimplePoll simplePoll);
        void AddSimplePollOptions(Guid simplePollId, List<SimplePollOption> simplePollOptions);
        void AddSimplePollAnswers(Guid simplePollId, List<SimplePollAnswer> simplePollAnswers);
    }
}
