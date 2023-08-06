using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using ContactDatabase.API.Data;
using ContactDatabase.API.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ContactDatabase.API.Server.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactDbContext _context;

        public ContactsController(ContactDbContext context)
        {
            _context = context;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var contacts = await _context.GetContactsAsync();
            return Ok(contacts);
        }

        // POST: api/contacts
        [HttpPost]
        public async Task<ActionResult<Contact>> AddContact(Contact newContact)
        {
            if (ModelState.IsValid)
            {
                await _context.InsertContactAsync(newContact);
                return Ok(newContact);
            }
            return BadRequest(ModelState);
        }

    }
}
