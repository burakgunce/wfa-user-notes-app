using NoteProject.DAL.Repositories;
using NoteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.BLL.Services
{
    public class NoteService
    {
        public NoteService()
        {
            noteRepository = new NoteRepository();
        }
        NoteRepository noteRepository;

        public void Add(Note note)
        {
            note.Status = Domain.Enums.Status.Added;
            //note.CreateDate = DateTime.Now; entity de default olarak alıyo zaten degerını
            noteRepository.Add(note);
        }

        public void Update(Note note)
        {
            note.ModifiedDate = DateTime.Now;
            note.Status = Domain.Enums.Status.Modified;
            noteRepository.Update(note);
        }

        public void Delete(Note note)
        {
            note.DeletedDate = DateTime.Now;
            note.Status = Domain.Enums.Status.Deleted;
            noteRepository.Update(note);
        }

        public Note GetById(int noteId)
        {
            return noteRepository.GetById(noteId);
        }

        public List<Note> GetAllByUserId(int userId)
        {
            return noteRepository.GetNotesByUserId(userId);
        }
    }
}
