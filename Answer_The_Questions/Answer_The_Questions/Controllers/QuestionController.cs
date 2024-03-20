using Microsoft.AspNetCore.Mvc;
using Answer_The_Questions.Data;
using Microsoft.EntityFrameworkCore;
using MVP.Models;

namespace Answer_The_Questions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        DataContext _dataContext;
        public QuestionController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Question> GetAll()
        {
            return _dataContext
                .Questions
                .Include(q => q.WrongAnswers)
                .Include(q => q.RightAnswer);
        }

        [HttpGet("ById/{id:int}")]
        public Question? GetById(int id)
        {
            return _dataContext.Questions.FirstOrDefault(e => e.Id == id);
        }

        [HttpGet]
        public Question GetAny() 
        {
            return _dataContext.Questions.Include(q => q.WrongAnswers).Include(q => q.RightAnswer).First();
        }

        [HttpPost]
        public async Task<ActionResult<List<Question>>> AddQuestion(Question question) 
        {
            if (question == null)
            {
                return BadRequest("Question not found.");
            }
            _dataContext.Questions.Add(question);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Questions.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<Question>>> UpdateQuestion(Question request)
        {
            var question = await _dataContext.Questions.FindAsync(request.Id);
            if (question == null)
            {
                return BadRequest("Question not found.");
            }
            question.Content = request.Content;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Questions.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Question>>> DeleteQuestion(int id)
        {
            var question = await _dataContext.Questions.FindAsync(id);
            if (question == null)
            {
                return BadRequest("Question not found.");
            }

            _dataContext.Questions.Remove(question);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Questions.ToListAsync());
        }
    }
}
