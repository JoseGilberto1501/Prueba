using Proyecto.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();

            BindingContext =  LoginViewModel.GetInstance();
/*
            btnPago.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new Pago());
            };

            btnAcerca.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new AcercaDe());
            };

            btnConfi.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new Configuration());
            };*/
        }

        
    }
}
