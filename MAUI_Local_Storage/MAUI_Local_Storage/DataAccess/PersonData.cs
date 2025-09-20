using SQLite;
using MAUI_Local_Storage.Models;

namespace MAUI_Local_Storage.DataAccess
{
    public class PersonData
    {
        SQLiteAsyncConnection database;

        async Task Init()
        {
            if (database is not null)
            {
                return;
            }
            database = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            await database.CreateTableAsync<Person>();
        }
        public async Task<List<Person>> GetPeopleAsync()
        {
            await Init();
            return await database.Table<Person>().ToListAsync();
        }
        public async Task<int> SavePersonAsync(Person person)
        {
            await Init();
            if (person.ID != 0)
            {
                return await database.UpdateAsync(person);
            }
            else
            {
                return await database.InsertAsync(person);
            }
        }
        public async Task<int> DeletePersonAsync(Person person)
        {
            await Init();
            return await database.DeleteAsync(person);
        }
    }
}
