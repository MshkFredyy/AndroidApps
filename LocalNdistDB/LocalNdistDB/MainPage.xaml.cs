using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using LocalNdistDB.Models;
using LocalNdistDB.Services;
using LocalNdistDB.ViewModels;

namespace LocalNdistDB
{
    public partial class MainPage : ContentPage
    {
        private readonly ILocalDatabaseService _databaseService;

        public MainPage()
        {
            InitializeComponent();
            _databaseService = DependencyService.Get<ILocalDatabaseService>();

            // Устанавливаем BindingContext после инициализации
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                statusLabel.Text = "Инициализация базы данных...";
                activityIndicator.IsVisible = true;
                activityIndicator.IsRunning = true;

                // Инициализируем базу данных
                await _databaseService.InitializeDatabase();

                // Загружаем заметки
                await LoadNotes();

                statusLabel.Text = "Готово";
                statusLabel.TextColor = Color.Green;
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Ошибка: {ex.Message}";
                statusLabel.TextColor = Color.Red;
                Console.WriteLine($"Ошибка инициализации: {ex}");
            }
            finally
            {
                activityIndicator.IsVisible = false;
                activityIndicator.IsRunning = false;
            }
        }

        private async System.Threading.Tasks.Task LoadNotes()
        {
            try
            {
                activityIndicator.IsVisible = true;
                activityIndicator.IsRunning = true;

                var notes = await _databaseService.GetNotesAsync();

                // Используем простой способ отображения данных
                if (notes.Any())
                {
                    notesListView.ItemsSource = notes;
                    emptyLabel.IsVisible = false;
                    notesListView.IsVisible = true;
                }
                else
                {
                    emptyLabel.IsVisible = true;
                    notesListView.IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Не удалось загрузить заметки: {ex.Message}", "OK");
                Console.WriteLine($"Ошибка загрузки заметок: {ex}");
            }
            finally
            {
                activityIndicator.IsVisible = false;
                activityIndicator.IsRunning = false;
            }
        }

        private async void OnLoadButtonClicked(object sender, EventArgs e)
        {
            await LoadNotes();
        }

        private async void OnAddNoteClicked(object sender, EventArgs e)
        {
            try
            {
                var notePage = new NotePage(new Note());
                notePage.Disappearing += async (s, args) =>
                {
                    await LoadNotes(); // Перезагружаем список после возврата
                };
                await Navigation.PushAsync(notePage);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }

        private async void OnNoteSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            try
            {
                var note = e.SelectedItem as Note;
                notesListView.SelectedItem = null; // Сбрасываем выбор

                var notePage = new NotePage(note);
                notePage.Disappearing += async (s, args) =>
                {
                    await LoadNotes(); // Перезагружаем список после возврата
                };
                await Navigation.PushAsync(notePage);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }

        private async void OnConnectPostgreSQLClicked(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Host=localhost;Port=5432;Database=notesdb;Username=postgres;Password=G_!$204_!";

                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    statusLabel.Text = "Подключаемся к PostgreSQL...";
                    var postgreService = DependencyService.Get<IPostgreSQLService>();
                    var success = await postgreService.ConnectAsync(connectionString);

                    if (success)
                    {
                        statusLabel.Text = "Подключено к PostgreSQL";
                        statusLabel.TextColor = Color.Green;
                    }
                    else
                    {
                        statusLabel.Text = "Ошибка подключения";
                        statusLabel.TextColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }
    }
}
