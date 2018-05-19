using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Proyecto.View;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Proyecto
{
    public partial class App : Application
    {
      //  public static MasterDetailPage MasterDetail { get; set; }
        public static bool usuarioLogeado { get; set; }

      /*  public async static Task NavigateMasterDetail(Page page)
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(page);
        }*/
        public App()
        {
            InitializeComponent();
            
                MainPage = new Login();
            
            

            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
