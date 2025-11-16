using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LocalNdistDB.Models;

namespace LocalNdistDB.Services
{
    public interface ILocalDatabaseService
    {
        Task InitializeDatabase();
        Task<List<Note>> GetNotesAsync();
        Task<Note> GetNoteAsync(int id);
        Task<int> SaveNoteAsync(Note note);
        Task<int> DeleteNoteAsync(Note note);
    }
}
