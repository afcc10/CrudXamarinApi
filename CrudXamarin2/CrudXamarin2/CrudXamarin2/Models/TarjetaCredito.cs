using CrudXamarin2.Models;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CrudApiXamarin2.Models
{
    public class TarjetaCredito: BaseModel
    {    
        private int _id;

        public int id
        {
            get { return _id; }
            set 
            { 
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _titular;

        public string titular
        {
            get { return _titular; }
            set 
            {
                _titular = value;
                OnPropertyChanged();
            }
        }

        private string _numeroTarjeta;

        public string numeroTarjeta
        {
            get { return _numeroTarjeta; }
            set 
            { 
                _numeroTarjeta = value;
                OnPropertyChanged();
            }
        }

        private string _fechaExpiracion;

        public string fechaExpiracion
        {
            get { return _fechaExpiracion; }
            set 
            { 
                _fechaExpiracion = value;
                OnPropertyChanged();
            }
        }

        private string _cvv;

        public string cvv
        {
            get { return _cvv; }
            set 
            { 
                _cvv = value;
                OnPropertyChanged();
            }
        }

        private DateTime _fecha;

        public DateTime fecha
        {
            get { return _fecha; }
            set 
            { 
                _fecha = value;
                OnPropertyChanged();
            }
        }

        private bool _estado;

        public bool estado
        {
            get { return _estado; }
            set 
            { 
                _estado = value;
                OnPropertyChanged();
            }
        }

        private string _clienteCedula;

        public string clienteCedula
        {
            get { return _clienteCedula; }
            set 
            { 
                _clienteCedula = value;
                OnPropertyChanged();
            }
        }
        
    }
}
