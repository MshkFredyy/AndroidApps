using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using LocalNdistDB.Models;
using LocalNdistDB.Services;
using System.Collections.ObjectModel;

namespace LocalNdistDB.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ILocalDatabaseService _localDb;
        private readonly IPostgreSQLService _postgreDb;

        private ObservableCollection<Note> _notes;
        public ObservableCollection<Note> Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        private string _connectionStatus = "Не подключено";
        public string ConnectionStatus
        {
            get => _connectionStatus;
            set => SetProperty(ref _connectionStatus, value);
        }

        private Color _connectionStatusColor = Color.Red;
        public Color ConnectionStatusColor
        {
            get => _connectionStatusColor;
            set => SetProperty(ref _connectionStatusColor, value);
        }

        public ICommand RefreshCommand { get; }

        public MainViewModel()
        {
            _localDb = DependencyService.Get<ILocalDatabaseService>();
            _postgreDb = DependencyService.Get<IPostgreSQLService>();
            Notes = new ObservableCollection<Note>();
            RefreshCommand = new Command(async () => await LoadNotes());
        }

        public async Task LoadNotes()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var notes = await _localDb.GetNotesAsync().ConfigureAwait(false);

                Device.BeginInvokeOnMainThread(() =>
                {
                    Notes.Clear();
                    foreach (var note in notes)
                    {
                        Notes.Add(note);
                    }
                });
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task ConnectToPostgreSQL(string connectionString)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var success = await _postgreDb.ConnectAsync(connectionString).ConfigureAwait(false);

                Device.BeginInvokeOnMainThread(() =>
                {
                    if (success)
                    {
                        ConnectionStatus = "Подключено к PostgreSQL";
                        ConnectionStatusColor = Color.Green;
                    }
                    else
                    {
                        ConnectionStatus = "Ошибка подключения";
                        ConnectionStatusColor = Color.Red;
                    }
                });
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task SyncWithPostgreSQL()
        {
            if (IsBusy)
                return;

            if (!_postgreDb.IsConnected)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Сначала подключитесь к PostgreSQL", "OK");
                return;
            }

            IsBusy = true;

            try
            {
                var success = await _postgreDb.SyncWithPostgreSQLAsync().ConfigureAwait(false);
                if (success)
                {
                    await LoadNotes();
                    await Application.Current.MainPage.DisplayAlert("Успех", "Синхронизация завершена", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
