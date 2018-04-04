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
	public partial class AddFil : ContentPage
	{
        Filiere fili;
		public AddFil (Filiere filiere)
		{
            fili = filiere;
			InitializeComponent ();
            if (filiere.id_filiere == 0)
            {
                valider.Text = "Ajouter";
            }
            else
            {
                valider.Text = "Valider la Modification";
                Nom.Text = filiere.nom_filiere;
                responsable.Text = filiere.responsable;
            }
        }
        void Ajouter(object sender,EventArgs e)
        {
            if (Nom.Text == "" || responsable.Text == "") DisplayAlert("Erreur","Un champ est vide !!" ,"Retry");
            else
            {
                Filiere fil = new Filiere() { nom_filiere = Nom.Text, responsable = responsable.Text,id_filiere=fili.id_filiere };
                App.Database.SaveFiliere(fil);
                    MessagingCenter.Send(this, "MyItemsChanged");

                Navigation.PopAsync();
            }
        }
	}
}