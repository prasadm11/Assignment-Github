using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public MembersController(IMemberRepository memberRepository, UserManager<ApplicationUser> userManager)
        {
            _memberRepository = memberRepository;
            _userManager = userManager;
        }

        // GET: api/members
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _memberRepository.GetAllAsync();
            return Ok(members);
        }

        // GET: api/members/{userId}
        [Authorize(Roles = "Admin")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMemberById(string userId)
        {
            var member = await _memberRepository.GetByIdAsync(userId);
            if (member == null)
                return NotFound($"Member with User ID {userId} not found.");

            return Ok(member);
        }

        // POST: api/members
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] Member member)
        {
            if (member == null)
                return BadRequest("Invalid member data.");

            await _memberRepository.AddAsync(member);
            return CreatedAtAction(nameof(GetMemberById), new { userId = member.UserId }, member);
        }

        // PUT: api/members/{userId}
        [Authorize(Roles = "Admin,User")]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateMember(string userId, [FromBody] Member member)
        {
            if (member == null || userId != member.UserId)
                return BadRequest("Invalid member data.");

            var existingMember = await _memberRepository.GetByIdAsync(userId);
            if (existingMember == null)
                return NotFound($"Member with User ID {userId} not found.");

            await _memberRepository.UpdateAsync(member);
            return NoContent();
        }

        // DELETE: api/members/{userId}
        [Authorize(Roles = "Admin")]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteMember(string userId)
        {
            var existingMember = await _memberRepository.GetByIdAsync(userId);
            if (existingMember == null)
                return NotFound($"Member with User ID {userId} not found.");

            await _memberRepository.DeleteAsync(userId);
            return NoContent();
        }




    }
}
