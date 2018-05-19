using Proyecto.Model;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Proyecto.ViewModel
{
    public class ConfigurationViewModel 
    {
      /*  public ConfigurationViewModel()
        {
            InitClass();
            InitCommands();
        }

        private ICommand ActualizarCommand;
        public Realm _realmDB;
        private List<DatosPersonales> info = new List<DatosPersonales>();

        private DatosPersonales currentuser { get; set; }

        public List<DatosPersonales> Info
        {
            get {
                return info;
            }
            set {
                info = value;
                OnPropertyChanged("Info");
            }
        }

        public DatosPersonales Currentuser
        {
            get
            {
                return currentuser;
            }
            set
            {
                currentuser = value;
                OnPropertyChanged("Currentuser");
            }
        }

        public object Actualizar { get; private set; }

        #region atributos
        #endregion

        #region propiedades
        #endregion

        #region metodos


        private void InitCommands()
        {
           // ActualizarCommand = new Command(Actualizar);
        }

        private void InitClass()
        {
            _realmDB = Helper.UtilDB.GetInstanceRealm();
           // Info = _realmDB.Find("DatosPersonales", Email);
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        */
    }
}
