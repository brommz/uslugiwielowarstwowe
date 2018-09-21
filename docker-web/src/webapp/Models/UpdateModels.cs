using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Models
{
    public class SimplePollUpdateModel
    {
        public SimplePoolType Type { get; set; }
        public string Text { get; set; }
    }

    public class SimplePollOptionUpdateModel
    {
        public Guid SimplePollId { get; set; }
        public string Text { get; set; }
    }

    public class SimplePollAnswerUpdateModel
    {
        public Guid? SimplePollId {get;set;}
        public Guid? SimplePollOptionId {get;set;} 
        public string EmployeeName {get;set;}
    }
}
