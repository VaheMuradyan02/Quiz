namespace MVP.Models
{
    public class Question
    {
        public int Id { get; set; }
        public virtual ICollection<WrongAnswer> WrongAnswers { get; set; }
        public virtual RightAnswer RightAnswer { get; set; }
        public string Content {  get; set; } 
    }
}
