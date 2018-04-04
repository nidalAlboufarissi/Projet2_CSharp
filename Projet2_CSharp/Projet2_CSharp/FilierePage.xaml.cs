using Projet2_CSharp.database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet2_CSharp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilierePage : ContentPage
	{
        ObservableCollection<Filiere> filieres;
        public FilierePage ()
		{
			InitializeComponent ();
            filieres = new ObservableCollection<Filiere>();
            listView.ItemsSource = filieres;
            foreach (var i in App.Database.GetAllFils().Result)
                filieres.Add(i);
            add.Source = ImageSource.FromResource("Projet2_CSharp.add.png");
            edit.Source = ImageSource.FromResource("Projet2_CSharp.edit.jpg");
            delete.Source = ImageSource.FromResource("Projet2_CSharp.delete (1).png");

        }
        private void ajouter(object sender,EventArgs e)
        {
            Navigation.PushAsync(new Projet2_CSharp.AddFil(new Filiere()));
        }
        private void modifier(object sender, EventArgs e)
        {
            
            Filiere fil = (Filiere)listView.SelectedItem;

            if (fil == null) DisplayAlert("Erreur","Selectionner une filiere","Retry");
            else Navigation.PushAsync(new Projet2_CSharp.AddFil(fil));

        }
        private async void del(object sender, EventArgs e)
        {
            Filiere fil = (Filiere)listView.SelectedItem;
            if (fil == null) await DisplayAlert("Erreur", "Selectionner une filiere", "Retry");
            else
            {
                var answer = await DisplayAlert("Confirmation?", "la filiere" + fil.nom_filiere + " va étre supprimée ?", "Oui", "Non");
                if (answer)
                {
                    await App.Database.delete(fil);
                    filieres.Remove(fil);
                }
            }

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            filieres.Clear();
            foreach (var i in App.Database.GetAllFils().Result)
                filieres.Add(i);           
            //LoadServerRegisteredCitizen is a method which i used to load items inside the listview        
        }
    }
}