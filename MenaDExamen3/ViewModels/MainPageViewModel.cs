using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MenaDExamen3.Models;
using MenaDExamen3.Repositories;

namespace MenaDExamen3
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseRepository _databaseRepository;
        private List<Dispositivo> _dispositivos;
        public string Nombre;
        public string Marca;
        public bool GarantiaActiva;
        public int VidaUtilMeses;

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Dispositivo> Dispositivos
        {
            get => _dispositivos;
            set
            {
                _dispositivos = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dispositivos)));
        }

        public MainPageViewModel()
        {
            string dbPath = DatabaseHelper.GetDatabasePath("Dispositivos.db");
            _databaseRepository = new DatabaseRepository(dbPath);
            LoadDispositivos();
        }
        public void LoadDispositivos()
        {
            Dispositivos = _databaseRepository.GetAllDispositivos();
        }
        public void AddDispositivo()
        {
            var dispositivo = new Dispositivo
            {
                NombreDispositivo = Nombre,
                MarcaDispositivo = Marca,
                GarantiaActiva = GarantiaActiva,
                VidaUtilMeses = VidaUtilMeses
            };
            try 
            {
                if (dispositivo.VidaUtilMeses < 12 && dispositivo.GarantiaActiva)
                {
                    throw new ArgumentException("La garantia no puede estar activa si la vida util es menor a 12 meses.");
                }
                _databaseRepository.InsertDispositivo(dispositivo);
                Dispositivos.Add(dispositivo);  
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, por ejemplo, mostrar un mensaje al usuario
                Console.WriteLine($"Error al agregar dispositivo: {ex.Message}");
            }
            LoadDispositivos();
        }

    }
}
