using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Zendy2.Models;

namespace Zendy2.Views
{
    public class AddRegistryPage : ContentPage
    {
        private Entry _nombreEntry;
        private Entry _apellidopaternoEntry;
        private Entry _apellidomaternoEntry;
        private Entry _numcelularEntry;
        private Entry _direccionEntry;
        private Entry _usernameEntry;
        private Entry _contrasenaEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");
        public AddRegistryPage()
        {
            this.Title = "Agregar Registro";

            StackLayout stackLayout = new StackLayout();

            _nombreEntry = new Entry();
            _nombreEntry.Keyboard = Keyboard.Text;
            _nombreEntry.Placeholder = "Nombre";
            _nombreEntry.TextChanged += _nombreEntry_TextChanged;
            stackLayout.Children.Add( _nombreEntry );

            _apellidopaternoEntry = new Entry();
            _apellidopaternoEntry.Keyboard = Keyboard.Text;
            _apellidopaternoEntry.Placeholder = "Apellido Paterno";
            _apellidopaternoEntry.TextChanged += _apellidopaternoEntry_TextChanged;
            stackLayout.Children.Add(_apellidopaternoEntry);

            _apellidomaternoEntry = new Entry();
            _apellidomaternoEntry.Keyboard = Keyboard.Text;
            _apellidomaternoEntry.Placeholder = "Apellido Materno";
            _apellidomaternoEntry.TextChanged += _apellidomaternoEntry_TextChanged;
            stackLayout.Children.Add(_apellidomaternoEntry);
            
            _numcelularEntry = new Entry();
            _numcelularEntry.Keyboard = Keyboard.Numeric;
            _numcelularEntry.MaxLength = 9;
            _numcelularEntry.Placeholder = "Número de Celular";
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
            _contrasenaEntry.MaxLength = 12;
            _contrasenaEntry.IsPassword = true;
            stackLayout.Children.Add(_contrasenaEntry);

            _saveButton = new Button();
            _saveButton.Text = "Agregar";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);
            Content = stackLayout;
        }

        private void _apellidomaternoEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue) && !IsAlphaWithSpaces(e.NewTextValue))
            {
                _apellidomaternoEntry.Text = e.OldTextValue; // Restaurar el valor anterior si contiene caracteres no alfabéticos
            }
        }

        private void _apellidopaternoEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue) && !IsAlphaWithSpaces(e.NewTextValue))
            {
                _apellidopaternoEntry.Text = e.OldTextValue; // Restaurar el valor anterior si contiene caracteres no alfabéticos
            }
        }

        private void _nombreEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue) && !IsAlphaWithSpaces(e.NewTextValue))
            {
                _nombreEntry.Text = e.OldTextValue; // Restaurar el valor anterior si contiene caracteres no alfabéticos
            }
        }
        private bool IsAlphaWithSpaces(string text)
        {
            return text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_nombreEntry.Text) ||
                string.IsNullOrWhiteSpace(_apellidopaternoEntry.Text) ||
                string.IsNullOrWhiteSpace(_apellidomaternoEntry.Text) ||
                string.IsNullOrWhiteSpace(_numcelularEntry.Text) ||
                string.IsNullOrWhiteSpace(_direccionEntry.Text) ||
                string.IsNullOrWhiteSpace(_usernameEntry.Text) ||
                string.IsNullOrWhiteSpace(_contrasenaEntry.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "Ok");
                return;
            }

            if (!IsValidInput(_nombreEntry.Text) ||
                !IsValidInput(_apellidopaternoEntry.Text) ||
                !IsValidInput(_apellidomaternoEntry.Text))
            {
                await DisplayAlert("Error", "Los campos de nombre y apellidos solo deben contener letras.", "OK");
                return; 
            }
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Cliente>();

            var maxPk = db.Table<Cliente>().OrderByDescending(c => c.IdCliente).FirstOrDefault();

            Cliente cliente = new Cliente()
            {
                IdCliente = (maxPk == null ? 1 : maxPk.IdCliente + 1),
                Nombre = _nombreEntry.Text,
                ApellidoPaterno = _apellidopaternoEntry.Text,
                ApellidoMaterno = _apellidomaternoEntry.Text,
                Num_Celular = Convert.ToInt32(_numcelularEntry.Text),
                Direccion = _direccionEntry.Text,
                Username = _usernameEntry.Text,
                Contrasena = _contrasenaEntry.Text,
            };
            db.Insert(cliente);
            await DisplayAlert(null, cliente.Nombre + " " + "Guardado", "Ok");
            await Navigation.PopAsync();
        }
        private bool IsValidInput(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }
    }
}