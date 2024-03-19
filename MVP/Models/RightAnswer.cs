namespace MVP.Models
{
    public class RightAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }

        //public virtual Question Question { get; set; }

        public string? Content { get; set; }
    }
}
