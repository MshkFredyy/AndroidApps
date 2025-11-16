using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LocalNdistDB.Models;
using LocalNdistDB.ViewModels;

namespace LocalNdistDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage : ContentPage
    {
        private readonly NoteViewModel _viewModel;

        public NotePage(Note note)
        {
            InitializeComponent();
            _viewModel = new NoteViewModel(note);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.InitializeAsync();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var success = await _viewModel.SaveNoteAsync();
            if (success)
            {
                await DisplayAlert("Успех", "Заметка сохранена", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Ошибка", "Не удалось сохранить заметку", "OK");
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_viewModel.CurrentNote.Id == 0)
            {
                await Navigation.PopAsync();
                return;
            }

            var result = await DisplayAlert("Подтверждение",
                "Вы уверены, что хотите удалить эту заметку?", "Да", "Нет");

            if (result)
            {
                var success = await _viewModel.DeleteNoteAsync();
                if (success)
                {
                    await DisplayAlert("Успех", "Заметка удалена", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Ошибка", "Не удалось удалить заметку", "OK");
                }
            }
        }

        // Обработка аппаратной кнопки "Назад" на Android
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await CheckForUnsavedChanges();
            });
            return true;
        }

        private async System.Threading.Tasks.Task CheckForUnsavedChanges()
        {
            if (_viewModel.HasUnsavedChanges())
            {
                var result = await DisplayAlert("Несохраненные изменения",
                    "У вас есть несохраненные изменения. Сохранить?", "Сохранить", "Не сохранять");

                if (result)
                {
                    await _viewModel.SaveNoteAsync();
                }
            }
            await Navigation.PopAsync();
        }
    }
}