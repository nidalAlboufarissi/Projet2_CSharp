using Plugin.Media;
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
        Etudiant et;
        public Ajouter(Etudiant etud)
        {
            et = etud;
            InitializeComponent();
            image.Source = ImageSource.FromResource("Projet2_CSharp.nobodyM.jpg");

            List<Filiere> l = App.Database.GetAllFils().Result;
            foreach (var colorName in l)
            {
                filiere.Items.Add(colorName.nom_filiere);
            }
            sexe.Items.Add("Male");
            sexe.Items.Add("Female");
            cne.Text = et.cne;
            filiere.SelectedItem = App.Database.GetFilById(etud.id_fil).Result.nom_filiere;
            prenom.Text = et.prenom;
            nom.Text = et.nom;
            date.Date = et.date_naissance;
            sexe.SelectedItem = et.sexe;
        }
        private void addEtudiant(object sender, EventArgs e)
        {
            Etudiant et = new Etudiant()
            {
                cne = cne.Text,
                prenom = prenom.Text,
                nom = nom.Text,
                date_naissance = date.Date,
                // image = new ImageSource("nobdyM.jpg"),
                sexe = sexe.SelectedItem.ToString(),
                id_fil = App.Database.GetFilByName(filiere.SelectedItem.ToString()).Result.id_filiere
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
            cne.Text = "";
            prenom.Text = "";
            nom.Text = "";
            date.Date = DateTime.Now;
            DisplayAlert("supprimer", "", "ok");



        }
        private async void photo(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                // Supply media options for saving our photo after it's taken.
                var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Name = $"{DateTime.UtcNow}.jpg"
                };

                // Take a photo of the business receipt.
                var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);
                image.Source = ImageSource.FromStream(() => file.GetStream());
            }

        }

    }

}