using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Models
{
    public enum SimplePoolType
    {
        SingleChoice = 0,
        MultipleChoice = 1
    }

    public class SimplePoll
    {
        public Guid Id { get; set; }
        public SimplePoolType Type { get; set; }
        public string Text { get; set; }

        public List<SimplePollOption> Options { get; set; }
    }

}
