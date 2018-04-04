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
    public partial class Accueil : ContentPage
    {

        ObservableCollection<Etudiant> etudiants;
        public Accueil()
        {
            InitializeComponent();
            add.Source = ImageSource.FromResource("Projet2_CSharp.adduser.ico");

            etudiants = new ObservableCollection<Etudiant>();

            listView.ItemsSource = etudiants;
            foreach (var colorName in App.Database.GetAllFils().Result)
            {
                picker.Items.Add(colorName.nom_filiere);
            }


            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {

                }
                else
                {
                    string colorName = picker.Items[picker.SelectedIndex];
                }
            };
        }
        void afficher(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            Etudiant ed = (Etudiant)e.SelectedItem;
            Navigation.PushAsync(new Projet2_CSharp.Ajouter(ed));

            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
        Picker pick =new Picker();
        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            pick = (Picker)sender;
            int selectedIndex = pick.SelectedIndex;
            string selectedItem = pick.SelectedItem.ToString();

            if (selectedIndex != -1)
            {

                Filiere fil = App.Database.GetFilByName(selectedItem).Result;
                etudiants.Clear();
                foreach (var item in App.Database.GetEtudByFil(fil.id_filiere).Result)
                    etudiants.Add(item);
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (pick.SelectedIndex != -1)
            {
                Filiere fil = App.Database.GetFilByName(pick.SelectedItem.ToString()).Result;
                etudiants.Clear();
                foreach (var item in App.Database.GetEtudByFil(fil.id_filiere).Result)
                    etudiants.Add(item);
            }
            //LoadServerRegisteredCitizen is a method which i used to load items inside the listview        
        }
        private void ajouter(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Projet2_CSharp.Ajouter(new Etudiant()));
        }

    }
}