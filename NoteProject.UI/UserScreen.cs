using NoteProject.BLL.Services;
using NoteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteProject.UI
{
    public partial class UserScreen : Form
    {
        public UserScreen(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            noteService = new NoteService();
        }
        int userId;

        NoteService noteService;
        Note note;
        private void UserScreen_Load(object sender, EventArgs e)
        {
            List<Note> notes = noteService.GetAllByUserId(userId);
            lboxNotlar.DisplayMember = "Title";
            lboxNotlar.ValueMember = "Id";
            lboxNotlar.DataSource = notes;

            SetDefaultSettings(true);
        }

        private void lboxNotlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxNotlar.SelectedIndex > -1)
            {
                int noteId = (int)lboxNotlar.SelectedValue;
                note = noteService.GetById(noteId);
                txtBaslik.Text = note.Title;
                txtIcerik.Text = note.Content;

                SetDefaultSettings(false);
            }
            else
            {
                SetDefaultSettings(true);
            }
        }

        private void SetDefaultSettings(bool set)
        {
            if (set)
            {
                btnNotSil.Enabled = false;
                btnKaydet.Text = "Kaydet";
                txtBaslik.Clear();
                txtIcerik.Clear();
                note = null;
            }
            else
            {
                btnNotSil.Enabled = true;
                btnKaydet.Text = "Güncelle";
            }
        }

        private void btnYeniNot_Click(object sender, EventArgs e)
        {
            SetDefaultSettings(true);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (note is null)
            {
                note = new Note();
                note.UserId = userId;
                note.Title = txtBaslik.Text;
                note.Content = txtIcerik.Text;

                noteService.Add(note);
                lboxNotlar.DataSource = noteService.GetAllByUserId(userId);
                MessageBox.Show("Notunuz eklenmıstır");
                SetDefaultSettings(true);
            }
            else
            {
                note.Title = txtBaslik.Text;
                note.Content = txtIcerik.Text;
                noteService.Update(note);
                MessageBox.Show("Notunuz guncellenmıstır");
                lboxNotlar.DataSource = noteService.GetAllByUserId(userId);
                SetDefaultSettings(true);
            }

        }

        private void btnNotSil_Click(object sender, EventArgs e)
        {
            if (note is not null)
            {
                noteService.Delete(note);
                MessageBox.Show("Notunuz sılınmıstır");
                lboxNotlar.DataSource = noteService.GetAllByUserId(userId);
                SetDefaultSettings(true);
            }
            else
            {
                MessageBox.Show("Silinecek not secınız");
            }
        }

        private void linkSifreDegis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasswordChangeScreen passwordChangeScreen = new PasswordChangeScreen(userId);
            this.Hide();
            passwordChangeScreen.ShowDialog();
            this.Show();
        }
    }
}
