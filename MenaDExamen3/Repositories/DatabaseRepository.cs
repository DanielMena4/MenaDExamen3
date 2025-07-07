using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MenaDExamen3.Models;

namespace MenaDExamen3.Repositories
{
    class DatabaseRepository
    {
        private readonly SQLiteConnection _connection;
        public DatabaseRepository(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Dispositivo>();
        }
        public void InsertDispositivo(Dispositivo dispositivo)
        {
            _connection.Insert(dispositivo);
        }
        public List<Dispositivo> GetAllDispositivos()
        {
            return _connection.Table<Dispositivo>().ToList();
        }
    }
}
