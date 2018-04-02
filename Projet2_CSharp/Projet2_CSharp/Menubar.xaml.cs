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
	public partial class Menubar : MasterDetailPage
	{
		public Menubar ()
		{
			InitializeComponent ();
            listView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                switch (item.TargetType)
                {
                    case "Accueil":
                        Navigation.PushAsync(new Accueil());
                        break;
                    case "Filiere":
                        Navigation.PushAsync(new FilierePage());
                        break;
                    case "Statistique":
                        Navigation.PushAsync(new Statistique());
                        break;

                }
                listView.SelectedItem = null;
                IsPresented = false;
            }
            
        }
        }
}