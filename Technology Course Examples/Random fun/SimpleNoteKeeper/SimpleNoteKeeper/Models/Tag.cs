using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleNoteKeeper.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Note> Notes { get; set; }

    }
}