using Android.Net;
using ExamenP3v2.Models;
using ExamenP3v2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamenP3v2.ViewModels
{
    public class JokeViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private readonly DatabaseService _databaseService;

        public JokeViewModel()
        {
            _apiService = new ApiService();
            _databaseService = new DatabaseService();
            GenerateJokeCommand = new Command(async () => await GenerateJoke());
            NavigateToJokesPageCommand = new Command(async () => await NavigateToJokesPage());
            NavigateToFavoriteCharacterPageCommand = new Command(async () => await NavigateToFavoriteCharacterPage());
        }

        public ICommand GenerateJokeCommand { get; }
        public ICommand NavigateToJokesPageCommand { get; }
        public ICommand NavigateToFavoriteCharacterPageCommand { get; }

        private async Task GenerateJoke()
        {
            var jokeText = await _apiService.GetJoke();
            var code = $"LC{new Random().Next(1000, 2000)}";
            var joke = new Joke
            {
                JokeText = jokeText,
                Code = code,
                LeninCando = "LC"
            };
            await _databaseService.SaveJoke(joke);
        }

        private async Task NavigateToJokesPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new JokesPage());
        }

        private async Task NavigateToFavoriteCharacterPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new FavoriteCharacterPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


}
