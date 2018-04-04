using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Projet2_CSharp
{
	public partial class App : Application
	{
        static DbController database;

        public static DbController Database
        {
            get
            {
                if (database == null)
                {
                    //database = new DbController();
                    database = new DbController(DependencyService.Get<SqlLite_db>().GetLocalFilePath("Gestion.db3"));

                }
                return database;
            }
        }
        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new Projet2_CSharp.MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
