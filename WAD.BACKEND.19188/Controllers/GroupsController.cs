using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._19188.DATA;
using WAD.BACKEND._19188.Models;
using WAD.BACKEND._19188.Repositories;

namespace WAD.BACKEND._19188.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupsController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            var groups = await _groupRepository.GetAllGroupsAsync();
            return Ok(groups);
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var group = await _groupRepository.GetGroupByIdAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // POST: api/Groups
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group group)
        {
            await _groupRepository.AddGroupAsync(group);
            return CreatedAtAction("GetGroup", new { id = group.Id }, group);
        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group group)
        {
            if (id != group.Id)
            {
                return BadRequest();
            }

            await _groupRepository.UpdateGroupAsync(group);
            return NoContent();
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await _groupRepository.DeleteGroupAsync(id);
            return NoContent();
        }
    }
}
