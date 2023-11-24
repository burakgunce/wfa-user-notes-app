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
    public partial class PasswordChangeScreen : Form
    {
        public PasswordChangeScreen(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            userService = new UserService();
        }
        
        int userId;
        UserService userService;

        private void btnSifreDegis_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEskiSifre.Text) || string.IsNullOrEmpty(txtYeniSifre.Text) || string.IsNullOrEmpty(txtYeniSifreTekrar.Text))
            {
                MessageBox.Show("Alanlar bos gecılemez");
                return;
            }

            if (txtYeniSifre.Text != txtYeniSifreTekrar.Text)
            {
                MessageBox.Show("Yrni sıfreler uyusmuyor");
                return;
            }

            User user = userService.GetById(userId);
            if (user.Password != txtEskiSifre.Text)
            {
                MessageBox.Show("Eskı sıfrenız yanlıs");
                return;
            }

            user.Password = txtYeniSifre.Text;
            userService.Update(user);
            MessageBox.Show("Sıfrenız guncellenmıstır");
            this.Close();
        }
    }
}
