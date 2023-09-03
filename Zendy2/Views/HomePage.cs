using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Zendy2.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Seleccionar Opción";

            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Agregar Registro";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Listar";
            button.Clicked += Button_Clicked1;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Editar";
            button.Clicked += Button_Clicked2;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Eliminar";
            button.Clicked += Button_Clicked3;
            stackLayout.Children.Add(button);
        }

        private async void Button_Clicked3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCliente());
        }

        private async void Button_Clicked2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditClientes());
        }

        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllClientes());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRegistryPage());
        }
    }
}