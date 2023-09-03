using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Zendy2.Models;

namespace Zendy2.Views
{
    public class DeleteCliente : ContentPage
    {
        private ListView _listView;
        private Button _button;

        Cliente _cliente = new Cliente();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");

        public DeleteCliente()
        {
            this.Title = "Eliminar Registro";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Cliente>().OrderBy(x => x.Nombre).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Eliminar";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _cliente = (Cliente)e.SelectedItem;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Cliente>().Delete(x => x.IdCliente == _cliente.IdCliente);
            await Navigation.PopAsync();
        }
    }
}