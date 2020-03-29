using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesRepository.Models
{
    public interface INoteRepository
    {
        Task<Note> GetByIdAsync(int id);
        Task<List<Note>> GetAllAsync();
        Task<List<NoteWithoutContent>> GetAllNotesWithoutContentAsync();
        Task<Note> AddAsync(NoteWithoutId note);
        Task UpdateAsync(Note note);
        Task RemoveByIdAsync(int id);
    }
}
