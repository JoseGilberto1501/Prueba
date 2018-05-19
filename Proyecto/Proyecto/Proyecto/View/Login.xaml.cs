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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            BindingContext =  LoginViewModel.GetInstance();
            
        }

      /*  private void BtnIni_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }*/

        private  void BtnRegi_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Informacion());
            
        }
        
    }
}
