﻿using Projet2_CSharp.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Projet2_CSharp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        private async void Button_Clicked(object sender, EventArgs e)
        {

            Admin d = App.Database.Login(new Admin() { login = login.Text, password = password.Text }).Result;
            if (d == null)
            {
                msg.Text = "failed to login";
                login.Text = "";
                password.Text = "";
            }
            else await Navigation.PushAsync(new Accueil());




        }
    
}
}
