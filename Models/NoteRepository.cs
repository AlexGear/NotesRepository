using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task RemoveByIdAsync(int id)
        {
            Note note = await db.Notes.FindAsync(id);
            if (note == null)
                return;

            db.Notes.Remove(note);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note newNote)
        {
            Note existingNote = await db.Notes.FindAsync(newNote.Id);
            
            if (existingNote == null)
            {
                throw new EntityNotFoundException($"Note with Id = {newNote.Id} not found");
            }

            existingNote.Title = newNote.Title;
            existingNote.Content = newNote.Content;
            
            await db.SaveChangesAsync();
        }
    }
}
