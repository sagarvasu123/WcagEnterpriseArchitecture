using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WcagEnterprise.Api.Data;

namespace WcagEnterprise.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RulesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RulesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WcagRuleEntity>>> GetRules()
        {
            var rules = await _context.WcagRules.AsNoTracking().ToListAsync();
            return Ok(rules);
        }

        [HttpPost]
        public async Task<ActionResult<WcagRuleEntity>> CreateRule([FromBody] WcagRuleEntity newRule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.WcagRules.AddAsync(newRule);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRules), new { id = newRule.Id }, newRule);
        }
    }
}