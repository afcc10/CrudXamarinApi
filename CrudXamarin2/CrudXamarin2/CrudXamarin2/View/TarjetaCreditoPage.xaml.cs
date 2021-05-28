using CrudApiXamarin2.Models;
using CrudXamarin2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudXamarin2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TarjetaCreditoPage : ContentPage
    {
        TarjetaCreditoViewModel contexto ;
        public TarjetaCreditoPage()
        {
            InitializeComponent();            
            LstTarjetas.ItemSelected += LstTarjetas_ItemSelected;
        }

        private void LstTarjetas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                TarjetaCredito modelo = (TarjetaCredito)e.SelectedItem;
                contexto.titular = modelo.titular;
                contexto.numeroTarjeta = modelo.numeroTarjeta;
                contexto.fechaExpiracion = modelo.fechaExpiracion;
                contexto.cvv = modelo.cvv;
                contexto.id = modelo.id;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            contexto = new TarjetaCreditoViewModel();
            this.BindingContext = contexto;
        }

    }
}