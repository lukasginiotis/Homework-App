using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApplication.Models;
using MyApplication.Functions;
using System.Data.SqlClient;
using System;
using MyApplication.Data;
using Microsoft.Extensions.Configuration;

namespace MyApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChooseBundleController : ControllerBase
    {
        private readonly AnswersContext _context;

        public ChooseBundleController(AnswersContext context)
        {
            _context = context;
        }

        // GET: api/Answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answers>>> GetAnswers()
        {
            return await _context.Answers.ToListAsync();
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answers>> GetAnswers(long id)
        {
            var answers = await _context.Answers.FindAsync(id);

            if (answers == null)
            {
                return NotFound();
            }

            return answers;
        }

        // POST: api/Answers
        [HttpPost]
        public async Task<ActionResult<Answers>> PostAnswers(Answers answers)
        {
            _context.Answers.Add(answers);
            await _context.SaveChangesAsync();

            Bundle bundle = GetBundle.ReturnBundle(answers);
            RecommendedBundle recBundle = new RecommendedBundle(answers.Id, answers.Age, answers.Student, answers.Income, bundle.Name);

            List<RecommendedBundle> outputBundles = new List<RecommendedBundle>();

            return CreatedAtAction("GetAnswers", new { id = answers.Id }, bundle);
        }
    }
}