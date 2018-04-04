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
        List<Filiere> l = App.Database.GetAllFils().Result;

        public Ajouter(Etudiant etud)
        {
            InitializeComponent();
            image.Source = ImageSource.FromResource("Projet2_CSharp.nobodyM.jpg");
            foreach (var colorName in l)
            {
                filiere.Items.Add(colorName.nom_filiere);
            }
            sexe.Items.Add("Male");
            sexe.Items.Add("Female");
            if (etud.id_fil == 0)
            {
                cne.Text = "";
                prenom.Text = "";
                nom.Text = "";
                date.Date = DateTime.Now;
                Modifier.IsEnabled = false;
                Supprimer.IsEnabled = false;

            }
            else
            {
                et = etud;
                cne.Text = et.cne;
                filiere.SelectedItem = App.Database.GetFilById(etud.id_fil).Result.nom_filiere;
                prenom.Text = et.prenom;
                nom.Text = et.nom;
                date.Date = et.date_naissance;
                sexe.SelectedItem = et.sexe;
            }
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
            DisplayAlert("insertion",et.nom+ "a été ajouté", "ok");
            cne.Text = "";
            prenom.Text = "";
            nom.Text = "";
            date.Date = DateTime.Now;
            MessagingCenter.Send(this, "MyItemsChanged");

        }
        private void edit(object sender, EventArgs e)
        {
            Etudiant etud = new Etudiant()
            {
                cne = et.cne,
                prenom = prenom.Text,
                nom = nom.Text,
                date_naissance = date.Date,
                sexe=sexe.SelectedItem.ToString(),
                id_fil=App.Database.GetFilByName(filiere.SelectedItem.ToString()).Result.id_filiere
                // image = new ImageSource("nobdyM.jpg"),
            };
            App.Database.UpdatEtud(etud);
            DisplayAlert("Modification", etud.nom+" a été modifié", "ok");
            MessagingCenter.Send(this, "MyItemsChanged");

        }
        private async  void Delete(object sender, EventArgs e)
        {
            Etudiant et = new Etudiant()
            {
                cne = cne.Text,
                prenom = prenom.Text,
                nom = nom.Text,
                date_naissance = date.Date,
                sexe=sexe.SelectedItem.ToString(),
                id_fil = App.Database.GetFilByName(filiere.SelectedItem.ToString()).Result.id_filiere
                // image = new ImageSource("nobdyM.jpg"),
            };
            var answer = await DisplayAlert("Confirmation?", "l'étudiant " + et.nom + " va étre supprimée ?", "Oui", "Non");
            if (answer)
            {
                await App.Database.delete(et);
            }
            cne.Text = "";
            prenom.Text = "";
            nom.Text = "";
            date.Date = DateTime.Now;
            MessagingCenter.Send(this, "MyItemsChanged");




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