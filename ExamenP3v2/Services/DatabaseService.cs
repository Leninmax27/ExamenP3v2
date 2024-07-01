using ExamenP3v2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3v2.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Jokes.db3");
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<Joke>().Wait();
        }

        public Task<List<Joke>> GetJokes()
        {
            return _database.Table<Joke>().ToListAsync();
        }

        public Task<int> SaveJoke(Joke joke)
        {
            return _database.InsertAsync(joke);
        }

        public Task<int> UpdateJoke(Joke joke)
        {
            return _database.UpdateAsync(joke);
        }

        public Task<int> DeleteJoke(Joke joke)
        {
            return _database.DeleteAsync(joke);
        }
    }

}
