using System;

namespace Voyon.DotNet.Interview.Core.Models
{
    public class Task : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsFinished { get; set; }

        public Guid AssignedUserId { get; set; }
    }
}
