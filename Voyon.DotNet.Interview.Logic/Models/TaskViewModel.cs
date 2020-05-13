namespace Voyon.DotNet.Interview.Logic.Models
{
    public class TaskViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; }

        public UserViewModel AssignedUser { get; set; }
    }
}