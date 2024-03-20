using Microsoft.AspNetCore.Mvc;
using MVP.Models;
using Answer_The_Questions.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Answer_The_Questions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WrongAnswerController : ControllerBase
    {
        DataContext _dataContext;

        public WrongAnswerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public WrongAnswer GetAny()
        {
            return _dataContext.WrongAnswers.First();
        }

        [HttpGet("GetAll")]
        public IEnumerable<WrongAnswer> GetAll()
        {
            return _dataContext.WrongAnswers;
        }

        [HttpGet("ByQuestionId/{id:int}")]
        public IEnumerable<WrongAnswer> GetByQuestionId(int id)
        {
            var wrongAnswers = _dataContext.WrongAnswers.Where(a => a.QuestionId == id);
            return wrongAnswers;
            //return Ok(wrongAnswer);
            /*var list = new List<WrongAnswer>();

            for (int i = 0; i < 3; i++)
            {
                var wrongAnswer = _dataContext.WrongAnswers.First(a => a.QuestionId == id);
                list.Add(wrongAnswer);

            }
            return list;*/
        }

        [HttpGet("ById/{id:int}")]
        public async Task<ActionResult<WrongAnswer>> GetById(int id)
        {
            var wrongAnswer = await _dataContext.WrongAnswers.FindAsync(id);
            if (wrongAnswer == null)
            {
                return BadRequest("User not found.");
            }
            return Ok(wrongAnswer);
        }

        [HttpPost]
        public async Task<ActionResult<List<WrongAnswer>>> Add(WrongAnswer wrongAnswer)
        {
            if (wrongAnswer == null)
            {
                return BadRequest("Answer not found");
            }
            _dataContext.WrongAnswers.Add(wrongAnswer);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.WrongAnswers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<WrongAnswer>>> Update(WrongAnswer request)
        {
            var wrongAnswer = await _dataContext.WrongAnswers.FindAsync(request.Id);
            if (wrongAnswer == null)
            {
                return BadRequest("Answer not found");
            }

            wrongAnswer.Content = request.Content;
            
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.WrongAnswers.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<WrongAnswer>>> Delete(int id)
        {
            var wrongAnswer = await _dataContext.WrongAnswers.FindAsync(id);
            if (wrongAnswer == null)
            {
                return BadRequest("Answer not found");
            }

            _dataContext.WrongAnswers.Remove(wrongAnswer);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.WrongAnswers.ToListAsync());
        }
    }
}
