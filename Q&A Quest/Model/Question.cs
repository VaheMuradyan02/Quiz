using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_A_Quest.Model
{
    public class Question
    {
        public int Id { get; set; }
        public virtual ICollection<WrongAnswer> WrongAnswers { get; set; }
        public virtual RightAnswer RightAnswer { get; set; }
        public string Content { get; set; }
    }
}
