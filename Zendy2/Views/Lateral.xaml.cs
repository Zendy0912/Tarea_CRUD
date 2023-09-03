using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zendy2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lateral : MasterDetailPage
    {
        public Lateral()
        {
            InitializeComponent();
            this.Master = new MainPage();
            this.Detail = new NavigationPage(new Page1());
        }
    }
}