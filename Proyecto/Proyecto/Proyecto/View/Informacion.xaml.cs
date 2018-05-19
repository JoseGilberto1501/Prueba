using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto.ViewModel;

namespace Proyecto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Informacion : ContentPage
    {
        public Informacion()
        {
            InitializeComponent();
            Title = "Registrar Usuario";
            BindingContext = new InformacionViewModel();

           
            
            //this.NavigationController.NavigationBar.BarTintColor = UIColor.Yellow;

            //NavigationPage.BackgroundColorProperty = Color.FromHex("#E91E63");

            //BackgroundColor = Color.FromHex("#E91E63");
            //Color.FromHex("#00162E");

            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Volver",
                Order = ToolbarItemOrder.Default,
                Command = new Command(() =>
                {
                    Application.Current.MainPage = new Login();
                }),
            });
        }
    }
}
