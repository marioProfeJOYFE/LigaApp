using LigaApp.MVVM.Model;
using LigaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LigaApp.MVVM.ViewModel
{
    public class TablaLigaViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _api;
        public ObservableCollection<EquipoModel> listaEquipos { get; set; }

        public ObservableCollection<ResultadoModel> listaResultados { get; set; }

        private bool _estaCargando;

        public ICommand CargarTablaCommand { get; }


        public TablaLigaViewModel()
        {
            //Implementar llamada API
            _api = new ApiService();
            listaEquipos = new ObservableCollection<EquipoModel>();
            listaResultados = new ObservableCollection<ResultadoModel>();
            CargarTablaCommand = new RelayCommand(async async => await CargarClasificacion());
        }

        public bool EstaCargando
        {
            get => _estaCargando;
            set
            {
                _estaCargando = value;
                OnPropertyChanged();
            }
        }

        private async Task CargarClasificacion()
        {
            EstaCargando = true;
            listaEquipos.Clear();

            var lista = await _api.ObtenerClasificacionActual();
            foreach(var equipo in lista)
            {
                equipo.posicion = lista.IndexOf(equipo) + 1;
                listaEquipos.Add(equipo);
            }

            var resultados = await _api.ObtenerResultados();
            foreach(var resultado in resultados)
            {
                resultado.comprobarVisitante();
                listaResultados.Add(resultado);
            }

            EstaCargando = false;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
