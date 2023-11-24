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
    public partial class SignInScreen : Form
    {
        public SignInScreen()
        {
            InitializeComponent();
            userService = new UserService();
        }
        UserService userService;

        private void btnKayit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtSoyad.Text) || string.IsNullOrEmpty(txtKullaniciAdi.Text) || string.IsNullOrEmpty(txtSifre.Text) || string.IsNullOrEmpty(txtSifreTekrar.Text))
            {
                MessageBox.Show("Alanlar bos gecılemez");
                return;
            }

            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Sifreler uyusmuyor");
                return;
            }

            bool userCheck = userService.CheckUser(txtKullaniciAdi.Text);
            if (userCheck)
            {
                MessageBox.Show("Aynı kullanıcı adıyla baska bır kullanıcı mevcut");
                return;
            }

            User user = new User();
            user.FirstName = txtAd.Text;
            user.LastName = txtSoyad.Text;
            user.UserName = txtKullaniciAdi.Text;
            user.Password = txtSifre.Text;

            userService.AddStandartUser(user);
            MessageBox.Show("Kayıt Başarılı");
            this.Close();
        }
    }
}
