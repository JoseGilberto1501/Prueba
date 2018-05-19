using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using Proyecto.Model;

namespace Proyecto.ViewModel
{
    public class InformacionViewModel : INotifyPropertyChanged
    {
        public InformacionViewModel()
        {
            InitClass();
            InitCommands();
        }


        #region Atributos
        private string _email;
        private string _contrasena;
        private string _nombre;
        private string _apellidos;
        private string _telefono;
        private string _direccion;

        public Realm _realmDB;


        public ICommand GuardarCommand { get; set; }

        #endregion

        #region Propiedades

        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("email");
            }
        }
        public string contrasena
        {
            get
            {
                return _contrasena;
            }
            set
            {
                _contrasena = value;
                OnPropertyChanged("contrasena");
            }
        }
        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                OnPropertyChanged("nombre");
            }
        }
        public string apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                _apellidos = value;
                OnPropertyChanged("apellidos");
            }
        }
        public string telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
                OnPropertyChanged("telefono");
            }
        }
        public string direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
                OnPropertyChanged("direccion");
            }
        }

        #endregion
        #region Metodos
        private void InitCommands()
        {
            GuardarCommand = new Command(btnGuardar);
        }

        private void btnGuardar()
        {
            var DatosPersonales = new DatosPersonales()
            {
                Email = email,
                Contrasena = contrasena,
                Nombre = nombre,
                Apellidos = apellidos,
                Telefono = telefono,
                Direccion = direccion


            };

            if (ValidaDatos(DatosPersonales))
            {
                if (ValidaEmail(DatosPersonales))
                {
                    try
                    {
                        /* _realmUsers.Write(() =>
                    {
                        NewUser = _realmUsers.Add(NewUser);
                    });*/
                        _realmDB.Write(() =>
                        {
                            DatosPersonales = _realmDB.Add(DatosPersonales); 
                            

                        });

                        Application.Current.MainPage.DisplayAlert("Alerta", "Nuevo cliente registrado exitosamente", "Ok");

                    }
                    catch (Exception ex)
                    {
                        Application.Current.MainPage.DisplayAlert("Alerta", "Error al intentar registrar el usuario...(ERROR: )" + ex.Message, "Ok");
                    }
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Alerta", "Debe ingresar un email valido...", "Ok");
                }
                
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Alerta", "Validar campos con (*) son obligatorios", "Ok");
            }
            //Application.Current.MainPage.DisplayAlert("Alerta","La imagen se ha guardado","Ok");
        }

        private bool ValidaDatos(DatosPersonales datos)
        {
            return (!string.IsNullOrWhiteSpace(datos.Nombre) && !string.IsNullOrWhiteSpace(datos.Contrasena) &&
                 !string.IsNullOrWhiteSpace(datos.Direccion));
        }

        private bool ValidaEmail(DatosPersonales datos)
        {
            return (!string.IsNullOrWhiteSpace(datos.Email) && datos.Email.Contains("@"));
        }
        

        private void InitClass()
        {
            _realmDB = Helper.UtilDB.GetInstanceRealm();
        }

        #endregion
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
