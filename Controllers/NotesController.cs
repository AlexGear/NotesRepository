using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesRepository.Models;

namespace NotesRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<NoteWithoutContent>> GetAllNotesWithoutContent()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id)
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody] NoteWithoutId note)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromBody] NoteWithoutId note)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveNote(int id)
        {
            throw new NotImplementedException();
        }
    }
}
