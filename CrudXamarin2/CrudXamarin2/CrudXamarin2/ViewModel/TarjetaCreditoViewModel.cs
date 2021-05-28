using CrudApiXamarin2.Models;
using CrudXamarin2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrudXamarin2.ViewModel
{
    public class TarjetaCreditoViewModel : TarjetaCredito
    {
        private ObservableCollection<TarjetaCredito> _tarjetasCredito;
        public ObservableCollection<TarjetaCredito> tarjetasCredito 
        { 
            get => _tarjetasCredito;
            set
            {
                _tarjetasCredito = value;
                OnPropertyChanged();
            }
        }

        TarjetaCreditoService servicio = new TarjetaCreditoService();

        TarjetaCredito modelo;
        

        public Command GuardarCommand { get; set; }
        public Command EliminarCommand { get; set; }
        public Command ModificarCommand { get; set; }
        public Command LimpiarCommand { get; set; }

        public TarjetaCreditoViewModel()
        {
            Consultar();
            GuardarCommand = new Command(async () => await Guardar(), () => !IsBusy);
            EliminarCommand = new Command(async () => await Eliminar(), () => !IsBusy);
            ModificarCommand = new Command(async () => await Modificar(), () => !IsBusy);
            LimpiarCommand = new Command(() => Limpiar(), () => !IsBusy);
        }

        private async void Consultar()
        {
            var tc = await servicio.Consultar();
            tarjetasCredito = new ObservableCollection<TarjetaCredito>(tc);
        }

        private async Task Guardar()
        {
            IsBusy = true;
            modelo = new TarjetaCredito()
            {
                titular = titular,
                numeroTarjeta = numeroTarjeta,
                fechaExpiracion = fechaExpiracion,
                cvv = cvv,
                fecha = DateTime.Now
            };

            servicio.Guardar(modelo);
            await Task.Delay(2000);
            Consultar();
            Limpiar();
            IsBusy = false;
        }

        private async Task Modificar()
        {
            IsBusy = true;
            modelo = new TarjetaCredito()
            {
                titular = titular,
                numeroTarjeta = numeroTarjeta,
                fechaExpiracion = fechaExpiracion,
                cvv = cvv,
                id = id,
                fecha = DateTime.Now
            };

            servicio.Modificar(modelo);
            await Task.Delay(2000);
            Consultar();
            Limpiar();
            IsBusy = false;
        }

        private async Task Eliminar()
        {
            IsBusy = true;

            servicio.Eliminar(id);
            await Task.Delay(2000);
            Consultar();
            Limpiar();
            IsBusy = false;
        }

        private void Limpiar()
        {
            titular = "";
            numeroTarjeta = "";
            id = 0;
            fechaExpiracion = "";
            cvv = "";
        }
    }
}
