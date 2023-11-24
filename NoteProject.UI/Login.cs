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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        UserService userService;

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Alanalr Boş Geçilemez");
                return;
            }
            userService = new UserService();
            User user = userService.GetByUserName(txtKullaniciAdi.Text);
            if (user == null)
            {
                MessageBox.Show("Kullanıcı bulunamadı lutfen kayıt olun");
                return;
            }

            if (user.Password != txtSifre.Text)
            {
                MessageBox.Show("Şifreniz yanlış");
                return;
            }

            if (!user.IsActive)
            {
                MessageBox.Show("Hesabınız onaylanmamıştır lütfen admin ile iletişime geçiniz");
                return;
            }

            switch (user.UserType)
            {
                case Domain.Enums.UserType.Admin:
                    AdminScreen adminScreen = new AdminScreen();
                    this.Hide();
                    adminScreen.ShowDialog();
                    this.Show();
                    break;
                case Domain.Enums.UserType.Standart:
                    UserScreen userScreen = new UserScreen(user.Id);
                    this.Hide();
                    userScreen.ShowDialog();
                    this.Show();
                    break;
            }
        }

        private void linkKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignInScreen signInScreen = new SignInScreen();
            this.Hide();
            signInScreen.ShowDialog();
            this.Show();
        }
    }
}
