using MenaDExamen3.Models;
using MenaDExamen3.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenaDExamen3
{
    class ListadoPageViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseRepository _databaseRepository;
        public event PropertyChangedEventHandler? PropertyChanged;
        private List<Dispositivo> _dispositivos;
        private void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dispositivos)));
        }
        public List<Dispositivo> Dispositivos
        {
            get => _dispositivos;
            set
            {
                _dispositivos = value;
                OnPropertyChanged();
            }
        }
        public ListadoPageViewModel()
        {
            string dbPath = DatabaseHelper.GetDatabasePath("Dispositivos.db");
            _databaseRepository = new DatabaseRepository(dbPath);
            LoadDispositivos();
        }
        public void LoadDispositivos()
        {
            Dispositivos = _databaseRepository.GetAllDispositivos();
        }

    }
}
