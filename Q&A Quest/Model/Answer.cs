using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_A_Quest.Model
{
    public class Answer
    {
        public int Id {  get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; }
    }
}
