using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using LocalNdistDB.Models;
using LocalNdistDB.Services;

namespace LocalNdistDB.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        private readonly ILocalDatabaseService _databaseService;
        private Note _currentNote;
        private Note _originalNote;

        public Note CurrentNote
        {
            get => _currentNote;
            set => SetProperty(ref _currentNote, value);
        }

        public string PageTitle => CurrentNote.Id == 0 ? "Новая заметка" : "Редактирование";

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public NoteViewModel(Note note)
        {
            _databaseService = DependencyService.Get<ILocalDatabaseService>();
            _currentNote = note;
            _originalNote = CloneNote(note);

            SaveCommand = new Command(async () => await SaveNoteAsync());
            DeleteCommand = new Command(async () => await DeleteNoteAsync());
        }

        public async Task InitializeAsync()
        {
            if (CurrentNote.Id != 0)
            {
                // Загружаем полные данные заметки из базы
                var fullNote = await _databaseService.GetNoteAsync(CurrentNote.Id);
                if (fullNote != null)
                {
                    CurrentNote = fullNote;
                    _originalNote = CloneNote(fullNote);
                }
            }
        }

        public async Task<bool> SaveNoteAsync()
        {
            if (string.IsNullOrWhiteSpace(CurrentNote.Title))
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Заголовок не может быть пустым", "OK");
                return false;
            }

            try
            {
                IsBusy = true;

                var result = await _databaseService.SaveNoteAsync(CurrentNote);

                if (result > 0)
                {
                    _originalNote = CloneNote(CurrentNote);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"Не удалось сохранить: {ex.Message}", "OK");
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> DeleteNoteAsync()
        {
            if (CurrentNote.Id == 0)
                return true;

            try
            {
                IsBusy = true;

                var result = await _databaseService.DeleteNoteAsync(CurrentNote);
                return result > 0;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"Не удалось удалить: {ex.Message}", "OK");
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public bool HasUnsavedChanges()
        {
            return CurrentNote.Title != _originalNote.Title ||
                   CurrentNote.Content != _originalNote.Content;
        }

        private Note CloneNote(Note note)
        {
            return new Note
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CreatedDate = note.CreatedDate,
                ModifiedDate = note.ModifiedDate
            };
        }
    }
}
