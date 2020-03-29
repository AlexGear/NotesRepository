using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace NotesRepository.Models
{
    class NoteRepository : INoteRepository
    {
        private readonly NotesDbContext db;

        public NoteRepository(NotesDbContext db)
        {
            this.db = db;
        }

        public async Task<Note> AddAsync(NoteWithoutId noteWithoutId)
        {
            var note = new Note
            {
                Title = noteWithoutId.Title,
                Content = noteWithoutId.Content
            };
            await db.Notes.AddAsync(note);
            await db.SaveChangesAsync();
            
            return note;
        }

        public Task<List<Note>> GetAllAsync()
        {
            return db.Notes.AsNoTracking().ToListAsync();
        }

        public Task<List<NoteWithoutContent>> GetAllNotesWithoutContentAsync()
        {
            return db.Notes
                .Select(note => new NoteWithoutContent
                {
                    Id = note.Id,
                    Title = note.Title
                }).ToListAsync();
        }

        public Task<Note> GetByIdAsync(int id)
        {
            return db.Notes.AsNoTracking().Where(note => note.Id == id).FirstOrDefaultAsync();
        }

        public Task RemoveByIdAsync(int id)
        {
            return db.Notes.Where(note => note.Id == id).DeleteAsync();
        }

        public async Task UpdateAsync(Note newNote)
        {
            int num = await db.Notes.Where(note => note.Id == newNote.Id)
                .UpdateAsync(x => new Note
                {
                    Title = newNote.Title,
                    Content = newNote.Content
                });
            if (num == 0)
            {
                throw new EntityNotFoundException($"Note with Id = {newNote.Id} not found");
            }
        }
    }
}
