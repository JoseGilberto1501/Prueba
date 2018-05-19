using Proyecto.Model;
using Proyecto.View;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyecto.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
       

        #region Singleton
        private static LoginViewModel instance = null;

        public LoginViewModel()
        {
            InitClass();
            InitCommands();
        }
        // Constructor


        public static LoginViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new LoginViewModel();
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
        #endregion

        public Realm _realmDB;
        private string _txtEmail;
        private string _txtContrasena;
        public static string _nombreSession = "NombreSession";

        private DatosPersonales datos { get; set; }
        public ICommand IniciarSessionCommand { get; set; }

        public ICommand VerConfiguracion { get; set; }

        public string txtEmail
        {
            get
            {
                return _txtEmail;
            }
            set
            {
                _txtEmail = value;
                OnPropertyChanged("txtEmail");
            }
        }

        public DatosPersonales Datos
        {
            get
            {
                return datos;
            }
            set
            {
                datos=value;
                OnPropertyChanged("Datos");
            }
        }
        public string txtContrasena
        {
            get
            {
                return _txtContrasena;
            }
            set
            {
                _txtContrasena = value;
                OnPropertyChanged("txtContrasena");
            }
        }
        private void InitCommands()
        {
            IniciarSessionCommand = new Command(Logearse);
            VerConfiguracion = new Command(abrirConfiguracion);
        }
        private void InitClass()
        {
            _realmDB = Helper.UtilDB.GetInstanceRealm();
            txtEmail = "joseg93151@gmail.com";
            txtContrasena = "123";
        }

        private void abrirConfiguracion()
        {
            var Usuario = new DatosPersonales
            {
                Email = txtEmail,
                Contrasena = txtContrasena
            };

            Datos =(DatosPersonales) _realmDB.Find("DatosPersonales", Usuario.Email);

            ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync(new Configuration());

           

        }

       private void Logearse()
        {
            /* var Usuario = new DatosPersonales
             {
                 Email = txtEmail,
                 Contrasena = txtContrasena
             };

             if (!string.IsNullOrWhiteSpace(txtEmail) && txtEmail.Contains("@"))
             {
                 Application.Current.MainPage.DisplayAlert("Alerta", "Debe ingresar un usuario valido", "Ok");
             }

             if (!string.IsNullOrWhiteSpace(txtContrasena))
             {
                 Application.Current.MainPage.DisplayAlert("Alerta", "Debe ingresar una contraseña", "Ok");
             }

             if (ValidaUsuario(Usuario))
             {
                 App.usuarioLogeado = true;
                 Application.Current.MainPage = new NavigationPage(new MainPage());
             }*/

            NavigationPage navigation = new NavigationPage(new Detail());
            App.Current.MainPage = new MasterDetailPage
            {
                Master = new Master(),
                Detail = navigation

            };
            //Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        private bool ValidaUsuario(DatosPersonales datos)
        {           

            DatosPersonales UsuarioIngreso = (DatosPersonales)_realmDB.Find("Email", datos.Email);
            if (UsuarioIngreso == null)
            {
                if (datos.Email == SuperUser.FullUser && datos.Contrasena == SuperUser.FullUserPass)
                {
                    return true;
                }
                return false;
            }
            return datos.Email == UsuarioIngreso.Email && datos.Contrasena == UsuarioIngreso.Contrasena;
            
        }



        #region Eventos
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        
        #endregion
    }
}
