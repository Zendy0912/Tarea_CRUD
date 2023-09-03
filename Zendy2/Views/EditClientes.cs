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
    public class EditClientes : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nombreEntry;
        private Entry _apellidopaternoEntry;
        private Entry _apellidomaternoEntry;
        private Entry _numcelularEntry;
        private Entry _direccionEntry;
        private Entry _usernameEntry;
        private Entry _contrasenaEntry;
        private Button _button;

        Cliente _cliente = new Cliente();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");
        public EditClientes()
        {
            this.Title = "Editar Registro";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Cliente>().OrderBy(x=> x.Nombre).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "Id";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add( _idEntry );

            _nombreEntry = new Entry();
            _nombreEntry.Keyboard = Keyboard.Text;
            _nombreEntry.Placeholder = "Nombre";
            stackLayout.Children.Add(_nombreEntry);

            _apellidopaternoEntry = new Entry();
            _apellidopaternoEntry.Keyboard = Keyboard.Text;
            _apellidopaternoEntry.Placeholder = "Apellido Paterno";
            stackLayout.Children.Add(_apellidopaternoEntry);

            _apellidomaternoEntry = new Entry();
            _apellidomaternoEntry.Keyboard = Keyboard.Text;
            _apellidomaternoEntry.Placeholder = "Apellido Materno";
            stackLayout.Children.Add(_apellidomaternoEntry);

            _numcelularEntry = new Entry();
            _numcelularEntry.Keyboard = Keyboard.Text;
            _numcelularEntry.Placeholder = "Número Celular";
            stackLayout.Children.Add(_numcelularEntry);

            _direccionEntry = new Entry();
            _direccionEntry.Keyboard = Keyboard.Text;
            _direccionEntry.Placeholder = "Dirección";
            stackLayout.Children.Add(_direccionEntry);

            _usernameEntry = new Entry();
            _usernameEntry.Keyboard = Keyboard.Text;
            _usernameEntry.Placeholder = "Username";
            stackLayout.Children.Add(_usernameEntry);

            _contrasenaEntry = new Entry();
            _contrasenaEntry.Keyboard = Keyboard.Text;
            _contrasenaEntry.Placeholder = "Contraseña";
            stackLayout.Children.Add(_contrasenaEntry);

            _button = new Button();
            _button.Text = "Actualizar";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add( _button );

            Content = stackLayout;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Cliente cliente = new Cliente()
            {
                IdCliente = Convert.ToInt32(_idEntry.Text),
                Nombre = _nombreEntry.Text,
                ApellidoPaterno = _apellidopaternoEntry.Text,
                ApellidoMaterno = _apellidomaternoEntry.Text,
                Num_Celular = Convert.ToInt32(_numcelularEntry.Text),
                Direccion = _direccionEntry.Text,
                Username = _usernameEntry.Text,
                Contrasena = _contrasenaEntry.Text,
            };
            db.Update( cliente );
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _cliente = (Cliente)e.SelectedItem;
            _idEntry.Text = _cliente.IdCliente.ToString();
            _nombreEntry.Text = _cliente.Nombre;
            _apellidopaternoEntry.Text = _cliente.ApellidoPaterno;
            _apellidomaternoEntry.Text = _cliente.ApellidoMaterno;
            _numcelularEntry.Text = _cliente.Num_Celular.ToString();
            _direccionEntry.Text = _cliente.Direccion;
            _usernameEntry .Text = _cliente.Username;
            _contrasenaEntry.Text = _cliente.Contrasena;

        }
    }
}