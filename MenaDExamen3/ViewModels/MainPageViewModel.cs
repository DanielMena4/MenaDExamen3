using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using MenaDExamen3.Models;
using MenaDExamen3.Repositories;

namespace MenaDExamen3
{
    class MainPageViewModel : BindableObject
    {
        private readonly DatabaseRepository _databaseRepository;
        private List<Dispositivo> _dispositivos;
        public List<Dispositivo> Dispositivos
        {
            get => _dispositivos;
            set
            {
                _dispositivos = value;
                OnPropertyChanged();
            }
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
        public void AddDispositivo(Dispositivo dispositivo)
        {
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
