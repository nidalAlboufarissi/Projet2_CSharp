using Projet2_CSharp.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet2_CSharp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Ajouter : ContentPage
	{
		public Ajouter ()
		{
            InitializeComponent();
            image.Source = ImageSource.FromResource("nobodyM.jpg");

            sexe.Items.Add("Male");
            sexe.Items.Add("Female");
        }
        private void addEtudiant(object sender, EventArgs e)
        {
            Etudiant et = new Etudiant() {
                cne = cne.Text,
                prenom = prenom.Text,
                nom = nom.Text,
                date_naissance = date.Date,
               // image = new ImageSource("nobdyM.jpg"),
            };
            App.Database.SaveItemAsync(et);
            DisplayAlert("insertion", "", "ok");
            cne.Text = "";
            prenom.Text = "";
            nom.Text = "";
            date.Date = DateTime.Now;
        }
        private void edit(object sender, EventArgs e)
        {
            Etudiant et = new Etudiant()
            {
                cne = cne.Text,
                prenom = prenom.Text,
                nom = nom.Text,
                date_naissance = date.Date,
                // image = new ImageSource("nobdyM.jpg"),
            };
            App.Database.SaveItemAsync(et);
            DisplayAlert("insertion", "", "ok");
        }
        private void Delete(object sender, EventArgs e)
        {
            Etudiant et = new Etudiant()
            {
                cne = cne.Text,
                prenom = prenom.Text,
                nom = nom.Text,
                date_naissance = date.Date,
                // image = new ImageSource("nobdyM.jpg"),
            };
            App.Database.delete(et);
            cne.Text="";
            prenom.Text = "";
            nom.Text = "";
            date.Date = DateTime.Now;
            DisplayAlert("supprimer", "", "ok");



        }

    }

}