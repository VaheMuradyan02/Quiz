using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Q_A_Quest.Model;

namespace Q_A_Quest
{
    public partial class Form1 : Form
    {        
        static HttpClient httpClient = new HttpClient();
        
        static readonly HttpRequestMessage requestForQuestion = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7175/Question/GetAll");
        static readonly HttpRequestMessage requestForAnswer = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7175/Answer/GetAll");

        static readonly HttpResponseMessage responseForQuestion = httpClient.SendAsync(requestForQuestion).Result;
        static readonly HttpResponseMessage responseForAnswer = httpClient.SendAsync(requestForAnswer).Result;

        static string dataForQuestion = responseForQuestion.Content.ReadAsStringAsync().Result;
        static string dataForAnswer = responseForAnswer.Content.ReadAsStringAsync().Result;

        List<Question> jsonForQuestion = JsonConvert.DeserializeObject<List<Question>>(dataForQuestion);
        List<Answer> jsonForAnswer = JsonConvert.DeserializeObject<List<Answer>>(dataForAnswer);

        int _trueAnswer;
        int _questionNumber = 1;
        int _score;
        int _count = 0;

        public Form1()
        {
            InitializeComponent();

            AskQuestion(_questionNumber);

        }

        private void checkAnswerEvent(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;
            var buttonTag = Convert.ToInt32(senderObject.Tag);

            if (buttonTag == _trueAnswer) 
            {
                _score++;
            }
            if (_questionNumber == 10) 
            {
                MessageBox.Show("Quiz Ended\n Your Score : " + _score);
            }
            _questionNumber++;
            AskQuestion(_questionNumber);
        }

        private void AskQuestion(int qNum)
        {
            switch (qNum)
            {
                case 1:
                    label1.Text = jsonForQuestion[0].Content;

                    button1.Text = jsonForAnswer[_count].Content;
                    button2.Text = jsonForAnswer[++_count].Content;
                    button3.Text = jsonForAnswer[++_count].Content;
                    button4.Text = jsonForAnswer[++_count].Content;

                    var rightAnswer = GetRightAnswer(jsonForAnswer[_count].QuestionId);

                    if (button1.Text == rightAnswer)
                    {
                        _trueAnswer = 1;
                    }
                    else if (button2.Text == rightAnswer)
                    {
                        _trueAnswer = 2;
                    }
                    else if (button3.Text == rightAnswer)
                    {
                        _trueAnswer = 3;
                    }
                    else
                    {
                        _trueAnswer = 4;
                    }

                    ++_count;

                    break;
                case 2:
                    label1.Text = jsonForQuestion[1].Content;

                    button1.Text = jsonForAnswer[_count].Content;
                    button2.Text = jsonForAnswer[++_count].Content;
                    button3.Text = jsonForAnswer[++_count].Content;
                    button4.Text = jsonForAnswer[++_count].Content;

                    rightAnswer = GetRightAnswer(jsonForAnswer[_count].QuestionId);

                    if (button1.Text == rightAnswer)
                    {
                        _trueAnswer = 1;
                    }
                    else if (button2.Text == rightAnswer)
                    {
                        _trueAnswer = 2;
                    }
                    else if (button3.Text == rightAnswer)
                    {
                        _trueAnswer = 3;
                    }
                    else
                    {
                        _trueAnswer = 4;
                    }

                    ++_count;

                    break;
                case 3:
                    label1.Text = jsonForQuestion[2].Content;

                    button1.Text = jsonForAnswer[_count].Content;
                    button2.Text = jsonForAnswer[++_count].Content;
                    button3.Text = jsonForAnswer[++_count].Content;
                    button4.Text = jsonForAnswer[++_count].Content;

                    rightAnswer = GetRightAnswer(jsonForAnswer[_count].QuestionId);

                    if (button1.Text == rightAnswer)
                    {
                        _trueAnswer = 1;
                    }
                    else if (button2.Text == rightAnswer)
                    {
                        _trueAnswer = 2;
                    }
                    else if (button3.Text == rightAnswer)
                    {
                        _trueAnswer = 3;
                    }
                    else
                    {
                        _trueAnswer = 4;
                    }

                    ++_count;

                    break;
                case 4:
                    label1.Text = jsonForQuestion[3].Content;

                    button1.Text = jsonForAnswer[_count].Content;
                    button2.Text = jsonForAnswer[++_count].Content;
                    button3.Text = jsonForAnswer[++_count].Content;
                    button4.Text = jsonForAnswer[++_count].Content;

                    rightAnswer = GetRightAnswer(jsonForAnswer[_count].QuestionId);

                    if (button1.Text == rightAnswer)
                    {
                        _trueAnswer = 1;
                    }
                    else if (button2.Text == rightAnswer)
                    {
                        _trueAnswer = 2;
                    }
                    else if (button3.Text == rightAnswer)
                    {
                        _trueAnswer = 3;
                    }
                    else
                    {
                        _trueAnswer = 4;
                    }

                    ++_count;

                    break;
                case 5:
                    label1.Text = jsonForQuestion[4].Content;

                    button1.Text = jsonForAnswer[_count].Content;
                    button2.Text = jsonForAnswer[++_count].Content;
                    button3.Text = jsonForAnswer[++_count].Content;
                    button4.Text = jsonForAnswer[++_count].Content;

                    rightAnswer = GetRightAnswer(jsonForAnswer[_count].QuestionId);

                    if (button1.Text == rightAnswer)
                    {
                        _trueAnswer = 1;
                    }
                    else if (button2.Text == rightAnswer)
                    {
                        _trueAnswer = 2;
                    }
                    else if (button3.Text == rightAnswer)
                    {
                        _trueAnswer = 3;
                    }
                    else
                    {
                        _trueAnswer = 4;
                    }

                    ++_count;

                    break;
                case 6:
                    label1.Text = jsonForQuestion[5].Content;

                    button1.Text = jsonForAnswer[_count].Content;
                    button2.Text = jsonForAnswer[++_count].Content;
                    button3.Text = jsonForAnswer[++_count].Content;
                    button4.Text = jsonForAnswer[++_count].Content;

                    rightAnswer = GetRightAnswer(jsonForAnswer[_count].QuestionId);

                    if (button1.Text == rightAnswer)
                    {
                        _trueAnswer = 1;
                    }
                    else if (button2.Text == rightAnswer)
                    {
                        _trueAnswer = 2;
                    }
                    else if (button3.Text == rightAnswer)
                    {
                        _trueAnswer = 3;
                    }
                    else
                    {
                        _trueAnswer = 4;
                    }

                    ++_count;

                    break;
                case 7:
                    label1.Text = jsonForQuestion[6].Content;

                    button1.Text = jsonForAnswer[_count].Content;
                    button2.Text = jsonForAnswer[++_count].Content;
                    button3.Text = jsonForAnswer[++_count].Content;
                    button4.Text = jsonForAnswer[++_count].Content;

                    rightAnswer = GetRightAnswer(jsonForAnswer[_count].QuestionId);

                    if (button1.Text == rightAnswer)
                    {
                        _trueAnswer = 1;
                    }
                    else if (button2.Text == rightAnswer)
                    {
                        _trueAnswer = 2;
                    }
                    else if (button3.Text == rightAnswer)
                    {
                        _trueAnswer = 3;
                    }
                    else
                    {
                        _trueAnswer = 4;
                    }

                    ++_count;

                    break;
                case 8:
                    label1.Text = jsonForQuestion[7].Content;

                    button1.Text = jsonForAnswer[_count].Content;
                    button2.Text = jsonForAnswer[++_count].Content;
                    button3.Text = jsonForAnswer[++_count].Content;
                    button4.Text = jsonForAnswer[++_count].Content;

                    rightAnswer = GetRightAnswer(jsonForAnswer[_count].QuestionId);

                    if (button1.Text == rightAnswer)
                    {
                        _trueAnswer = 1;
                    }
                    else if (button2.Text == rightAnswer)
                    {
                        _trueAnswer = 2;
                    }
                    else if (button3.Text == rightAnswer)
                    {
                        _trueAnswer = 3;
                    }
                    else
                    {
                        _trueAnswer = 4;
                    }

                    ++_count;

                    break;
                case 9:
                    label1.Text = jsonForQuestion[8].Content;

                    button1.Text = jsonForAnswer[_count].Content;
                    button2.Text = jsonForAnswer[++_count].Content;
                    button3.Text = jsonForAnswer[++_count].Content;
                    button4.Text = jsonForAnswer[++_count].Content;

                    rightAnswer = GetRightAnswer(jsonForAnswer[_count].QuestionId);

                    if (button1.Text == rightAnswer)
                    {
                        _trueAnswer = 1;
                    }
                    else if (button2.Text == rightAnswer)
                    {
                        _trueAnswer = 2;
                    }
                    else if (button3.Text == rightAnswer)
                    {
                        _trueAnswer = 3;
                    }
                    else
                    {
                        _trueAnswer = 4;
                    }

                    ++_count;

                    break;
                case 10:
                    label1.Text = jsonForQuestion[9].Content;

                    button1.Text = jsonForAnswer[_count].Content;
                    button2.Text = jsonForAnswer[++_count].Content;
                    button3.Text = jsonForAnswer[++_count].Content;
                    button4.Text = jsonForAnswer[++_count].Content;

                    rightAnswer = GetRightAnswer(jsonForAnswer[_count].QuestionId);

                    if (button1.Text == rightAnswer)
                    {
                        _trueAnswer = 1;
                    }
                    else if (button2.Text == rightAnswer)
                    {
                        _trueAnswer = 2;
                    }
                    else if (button3.Text == rightAnswer)
                    {
                        _trueAnswer = 3;
                    }
                    else
                    {
                        _trueAnswer = 4;
                    }

                    ++_count;

                    break;

            }
        }
        private string GetRightAnswer(int questionId)
        {
            var requestForAnswer = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7175/RightAnswer/ByQuestionId/{questionId}");
            var responseForRightAnswer = httpClient.SendAsync(requestForAnswer).Result;
            var dataForRightAnswer = responseForRightAnswer.Content.ReadAsStringAsync().Result;
            var jsonForRightAnswer = JsonConvert.DeserializeObject<RightAnswer>(dataForRightAnswer);

            return jsonForRightAnswer.Content;
        }
    }
}
