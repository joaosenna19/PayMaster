using SQLite;

namespace PayMaster.Data;
    public class HourlyEmployeeRepository
    {
        
        private SQLiteAsyncConnection _database;
        private string _dbPath;
        public string StatusMessage { get; private set; }


        private async Task Init()
        {
            if (_database != null) return;

            _database = new SQLiteAsyncConnection(_dbPath);
            await _database.CreateTableAsync<HourlyEmployee>();
        }
        
        public HourlyEmployeeRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task<List<HourlyEmployee>> GetEmployees()
        {
            try
            {
                await Init();
                return await _database.Table<HourlyEmployee>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to retrieve data. Error {e}";
            }

            return new List<HourlyEmployee>();
        }

        public async Task CreateEmployee(HourlyEmployee employee)
        {
            try
            {
                await Init();
                StatusMessage = $"{employee.FirstName + employee.LastName} added.";
                await _database.InsertAsync(employee);
                
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to add {employee.FirstName + employee.LastName}. Error {e}";
            }
        }

        public async Task<int> UpdateEmployee(HourlyEmployee account)
        {
            return await _database.UpdateAsync(account);
        }

        public async Task<int> DeleteEmployee(HourlyEmployee account)
        {
            return await _database.DeleteAsync(account);
        }
        
    }
    
    