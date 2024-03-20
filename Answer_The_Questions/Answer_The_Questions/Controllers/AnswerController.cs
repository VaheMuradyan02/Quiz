using Answer_The_Questions.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVP.Models;


namespace Answer_The_Questions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerController : Controller
    {
        DataContext _dataContext;

        public AnswerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Answer> GetAll()
        {
            return _dataContext.AllAnswers;
        }

        [HttpGet("ById/{id:int}")]
        public Answer? GetById(int id)
        {
            return _dataContext.AllAnswers.FirstOrDefault(e => e.Id == id);
        }

        [HttpGet]
        public Answer GetAny()
        {
            return _dataContext.AllAnswers.First();
        }

        [HttpPost]
        public async Task<ActionResult<List<Answer>>> AddAnswer(Answer answer)
        {
            if (answer == null)
            {
                return BadRequest("Answer not found.");
            }
            _dataContext.AllAnswers.Add(answer);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.AllAnswers.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<Answer>>> UpdateAnswer(Answer request)
        {
            var answer = await _dataContext.AllAnswers.FindAsync(request.Id);
            if (answer == null)
            {
                return BadRequest("Answer not found.");
            }
            answer.Content = request.Content;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.AllAnswers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Answer>>> DeleteAnswer(int id)
        {
            var answer = await _dataContext.AllAnswers.FindAsync(id);
            if (answer == null)
            {
                return BadRequest("Answer not found.");
            }

            _dataContext.AllAnswers.Remove(answer);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.AllAnswers.ToListAsync());
        }
    }
}
