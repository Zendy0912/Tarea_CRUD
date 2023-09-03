using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Xamarin.Forms;
using SQLite;
using Zendy2.Models;

namespace Zendy2.Views
{
    public class GetAllClientes : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");
        public GetAllClientes()
        {
            this.Title = "Registros";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Cliente>().OrderBy(x => x.Nombre).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
            
        }
    }
}