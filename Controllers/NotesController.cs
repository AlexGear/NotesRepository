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
            return await noteRepository.GetAllNotesWithoutContentAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id)
        {
            Note note = await noteRepository.GetByIdAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody] NoteWithoutId noteWithoutId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Note newNote = await noteRepository.AddAsync(noteWithoutId);
            var idOnly = new { id = newNote.Id };
            return CreatedAtAction(nameof(GetNoteById), idOnly, idOnly);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromBody] NoteWithoutId note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await noteRepository.UpdateAsync(new Note
                {
                    Id = id,
                    Title = note.Title,
                    Content = note.Content
                });
                return Ok();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public Task RemoveNote(int id)
        {
            return noteRepository.RemoveByIdAsync(id);
        }
    }
}
