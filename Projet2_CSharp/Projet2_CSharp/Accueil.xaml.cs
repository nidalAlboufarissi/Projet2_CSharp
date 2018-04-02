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
        

        public Accueil()
        {
        
            Label header = new Label
            {
                Text = "Rechercher etudiant par filiere",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Picker picker = new Picker
            {
                Title = "Filiere",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

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


            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    picker,
                    
                }
            };

        }
    }
}
