﻿//Class responsible for the connection with the database file and all the methods to manipulate
// data across the application

using SQLite;

namespace PayMaster.Data;
    public class HourlyEmployeeRepository
    {
        
        private SQLiteAsyncConnection _database;
        private string _dbPath;
        //stores the status of the system after a method is called and executed
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
                StatusMessage = $"{employee.FirstName} {employee.LastName} added.";
                await _database.InsertAsync(employee);
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to add {employee.FirstName + employee.LastName}. Error {e}";
            }
        }

        public async Task<int> UpdateEmployee(HourlyEmployee employee)
        {
            try
            {
                await Init();
                StatusMessage = $"{employee.FirstName} {employee.LastName} updated.";
                return await _database.UpdateAsync(employee);
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to update {employee.FirstName + employee.LastName}. Error {e}";
                return 0;
            }
        }

        public async Task<int> DeleteEmployee(HourlyEmployee employee)
        {
            try
            {
                await Init();
                StatusMessage = $"{employee.FirstName} {employee.LastName} deleted.";
                return await _database.DeleteAsync(employee);
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to delete {employee.FirstName + employee.LastName}. Error {e}";
                return 0;
            }
        }
        
    }
    
    