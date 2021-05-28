using CrudApiXamarin2.Models;
using CrudXamarin2.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrudXamarin2.Services
{
    public class TarjetaCreditoService 
    {
        private ObservableCollection<TarjetaCredito> _tarjetasCredito;

        public ObservableCollection<TarjetaCredito> tarjetasCredito
        {
            get => _tarjetasCredito; 
            set
            {
                _tarjetasCredito = value;                
            }
        }

        public TarjetaCreditoService()
        {
            if (tarjetasCredito == null)
            {
                tarjetasCredito = new ObservableCollection<TarjetaCredito>();
            }
        }

        public async Task<ObservableCollection<TarjetaCredito>> Consultar()
        {
            var url = "https://localhost:44323/api/TarjetaCredito";
            var service = new HttpHelper<TarjetaCredito>();
            var tarjeta = await service.GetRestServiceDataAsync(url);
            tarjetasCredito = new ObservableCollection<TarjetaCredito>((IEnumerable<TarjetaCredito>)tarjeta);

            return tarjetasCredito;
        }

        public async void Guardar(TarjetaCredito modelo)
        {
            var url = "https://localhost:44323/api/TarjetaCredito";
            var service = new HttpHelper<TarjetaCredito>();
            await service.PostRestServiceDataAsync(modelo,url);
            
            //tarjetasCredito.Add(modelo);
        }

        public async void Modificar(TarjetaCredito modelo)
        {
            for (int i = 0; i < tarjetasCredito.Count; i++)
            {
                if (tarjetasCredito[i].id == modelo.id)
                {
                    var url = $"https://localhost:44323/api/TarjetaCredito/{modelo.id}";
                    var service = new HttpHelper<TarjetaCredito>();
                    await service.PutRestServiceDataAsync(modelo, url);
                    //tarjetasCredito[i] = modelo;
                }
            }
        }

        public async void Eliminar(int id)
        {
            var url = $"https://localhost:44323/api/TarjetaCredito/{id}";
            var service = new HttpHelper<TarjetaCredito>();
            await service.DeleteRestServiceDataAsync(url);
            //TarjetaCredito modelo = tarjetasCredito.FirstOrDefault(x => x.id == id);
            //tarjetasCredito.Remove(modelo);
        }

       
    }
}
