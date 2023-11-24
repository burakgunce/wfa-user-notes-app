using NoteProject.DAL.Context;
using NoteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.DAL.Repositories
{
    public class NoteRepository
    {
        public NoteRepository()
        {
            db = new AppDbContext();
        }
        AppDbContext db;

        public void Add(Note note)
        {
            db.Notes.Add(note);
            db.SaveChanges();
        }

        public void Update(Note note)
        {
            db.Notes.Update(note);
            db.SaveChanges();
        }

        public void Delete(int noteId)
        {
            Note note = db.Notes.Find(noteId);
            db.Notes.Remove(note);
            db.SaveChanges();
        }

        public Note GetById(int noteId)
        {
            Note note = db.Notes.Find(noteId);
            return note;
        }

        public List<Note> GetNotesByUserId(int userId)
        {
            List<Note> notes = db.Notes.Where(x => x.UserId == userId && x.Status != Domain.Enums.Status.Deleted).ToList();
            return notes;
        }
    }
}
