using ExamenPM02.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace ExamenPM02.ViewModels
{
    public class LogicData
    {
        readonly SQLiteAsyncConnection _database;

        public LogicData(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Data>().Wait();
        }

        public LogicData()
        {
        }

        public Task<List<Data>> GetTaskAsync()
        {
            return _database.Table<Data>().OrderByDescending(x => x.Fecha).ToListAsync();
        }

        
        public Task<int> SaveTaskAsync(Data taskModel)
        {

            if (taskModel.Id_pago != 0)
            {
                return _database.UpdateAsync(taskModel);
            }
            else
            {
                return _database.InsertAsync(taskModel);
            }

        }

        public Task<int>UpdateTaskAsync(Data pagos)
        {
            return _database.UpdateAsync(pagos);
        }

        public Task<int> deleteAsync(Data pagos)
        {
            return _database.DeleteAsync(pagos);
        }

        public Task<Data> GetItemAsync(int personId)
        {
            return _database.Table<Data>().Where(i => i.Id_pago == personId).FirstOrDefaultAsync();
        }

        public Task<Data> DeleteItemAsync(int personId)
        {
            return _database.Table<Data>().Where(i => i.Id_pago == personId).FirstOrDefaultAsync();
        }

    }
}