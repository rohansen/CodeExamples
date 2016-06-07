using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleNoteKeeper.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string NoteText { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}