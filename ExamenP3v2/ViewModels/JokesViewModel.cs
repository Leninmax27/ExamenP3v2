using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3v2.ViewModels
{
    public class JokesViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        public JokesViewModel()
        {
            _databaseService = new DatabaseService();
            LoadJokes();
        }

        private async void LoadJokes()
        {
            Jokes = await _databaseService.GetJokes();
        }

        private List<Joke> _jokes;
        public List<Joke> Jokes
        {
            get => _jokes;
            set
            {
                _jokes = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
