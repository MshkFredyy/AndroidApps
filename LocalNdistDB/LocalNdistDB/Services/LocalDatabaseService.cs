using System;
using System.Collections.Generic;
using System.Text;
using LocalNdistDB.Models;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LocalNdistDB.Services
{
    public class LocalDatabaseService : ILocalDatabaseService
    {
        private SQLiteAsyncConnection _database;

        public async Task InitializeDatabase()
        {
            try
            {
                if (_database != null)
                    return;

                var databasePath = Path.Combine(FileSystem.AppDataDirectory, "notes.db");
                Console.WriteLine($"Database path: {databasePath}");

                _database = new SQLiteAsyncConnection(databasePath);
                await _database.CreateTableAsync<Note>();

                Console.WriteLine("Database initialized successfully");

                // Проверяем есть ли данные
                var count = await _database.Table<Note>().CountAsync();
                Console.WriteLine($"Notes in database: {count}");

                if (count == 0)
                {
                    await AddSampleData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database initialization error: {ex}");
                throw;
            }
        }

        private async Task AddSampleData()
        {
            try
            {
                var sampleNote = new Note
                {
                    Title = "Добро пожаловать!",
                    Content = "Это ваша первая заметка. Вы можете редактировать её или создать новую.",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                await _database.InsertAsync(sampleNote);
                Console.WriteLine("Sample note added");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding sample data: {ex}");
            }
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            await InitializeDatabase();

            try
            {
                var notes = await _database.Table<Note>()
                    .OrderByDescending(n => n.ModifiedDate)
                    .ToListAsync();

                Console.WriteLine($"Retrieved {notes?.Count ?? 0} notes");
                return notes ?? new List<Note>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting notes: {ex}");
                return new List<Note>();
            }
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            await InitializeDatabase();
            return await _database.Table<Note>()
                .Where(n => n.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> SaveNoteAsync(Note note)
        {
            await InitializeDatabase();

            if (note.Id != 0)
            {
                note.ModifiedDate = DateTime.Now;
                return await _database.UpdateAsync(note);
            }
            else
            {
                note.CreatedDate = DateTime.Now;
                note.ModifiedDate = DateTime.Now;
                return await _database.InsertAsync(note);
            }
        }

        public async Task<int> DeleteNoteAsync(Note note)
        {
            await InitializeDatabase();
            return await _database.DeleteAsync(note);
        }
    }
}
