using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotesRepository.Models
{
    public class NoteWithoutContent
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
