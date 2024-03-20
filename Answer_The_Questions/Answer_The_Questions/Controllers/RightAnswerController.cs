using Microsoft.AspNetCore.Mvc;
using MVP.Models;
using Answer_The_Questions.Data;
using Microsoft.EntityFrameworkCore;

namespace Answer_The_Questions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RightAnswerController : ControllerBase
    {
        DataContext _dataContext;

        public RightAnswerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetAll")]
        public IEnumerable<RightAnswer> GetAll()
        {
            return _dataContext.RightAnswers;
        }

        [HttpGet]
        public RightAnswer GetAny() 
        {
            return _dataContext.RightAnswers.First();
        }

        [HttpGet("ById/{id:int}")]
        public async Task<ActionResult<RightAnswer>> GetById(int id)
        {
            var rightAnswer = await _dataContext.RightAnswers.FindAsync(id);
            if (rightAnswer == null)
            {
                return BadRequest("User not found.");
            }
            return Ok(rightAnswer);
        }

        [HttpGet("ByQuestionId/{id:int}")]
        public RightAnswer? GetByQuestionId(int id)
        {
            var rightAnswer = _dataContext.RightAnswers.FirstOrDefault(a => a.QuestionId == id);
            return rightAnswer;
        }

        [HttpPost]
        public async Task<ActionResult<List<RightAnswer>>> Add(RightAnswer rightAnswer)
        {
            if (rightAnswer == null)
            {
                return BadRequest("Answer not found");
            }
            _dataContext.RightAnswers.Add(rightAnswer);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.RightAnswers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<RightAnswer>>> Update(RightAnswer request)
        {
            var rightAnswer = await _dataContext.RightAnswers.FindAsync(request.Id);
            if (rightAnswer == null)
            {
                return BadRequest("Answer not found");
            }

            rightAnswer.Content = request.Content;
            rightAnswer.QuestionId = request.QuestionId;
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.RightAnswers.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<RightAnswer>>> Delete(int id)
        {
            var rightAnswer = await _dataContext.RightAnswers.FindAsync(id);
            if(rightAnswer == null)
            {
                return BadRequest("Answer not found");
            }

            _dataContext.RightAnswers.Remove(rightAnswer);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.RightAnswers.ToListAsync());
        }
    }
}
