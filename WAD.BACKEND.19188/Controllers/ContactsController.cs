using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD.BACKEND._19188.Models;
using WAD.BACKEND._19188.Repositories;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacts>>> GetContacts()
        {
            var contacts = await _contactRepository.GetAllContactsAsync();
            return Ok(contacts);
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacts>> GetContact(int id)
        {
           
            var contact = await _contactRepository.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<Contacts>> PostContact(Contacts contact)
        {
           
            if (contact.GroupId <= 0)
            {
                return BadRequest("Invalid Group ID.");
            }

            
            var group = await _contactRepository.GetGroupByIdAsync(contact.GroupId);
            if (group == null)
            {
                return BadRequest("Group not found.");
            }

       
            contact.Group = group;

            await _contactRepository.AddContactAsync(contact);
            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contacts contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            await _contactRepository.UpdateContactAsync(contact);
            return NoContent();
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactRepository.DeleteContactAsync(id);
            return NoContent();
        }
    }
}
