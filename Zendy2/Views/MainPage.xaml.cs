using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zendy2.Views;

namespace Zendy2.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void btnregistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddRegistryPage());

        }

        private void btneditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditClientes());

        }

        private void btnlistar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GetAllClientes());

        }

        private void btneliminar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeleteCliente());

        }
    }
}
