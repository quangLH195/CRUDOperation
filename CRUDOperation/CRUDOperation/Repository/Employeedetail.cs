using CRUDOperation.Models;
using Microsoft.EntityFrameworkCore;
namespace CRUDOperation.Repository
{
    public class Employeedetail : IEmployee
    {
        private readonly Empdbcontext _context;
        public Employeedetail(Empdbcontext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployee(Employee employee)
        {
            if (employee != null)
            {
                await _context.Employee.AddAsync(employee);
                await _context.SaveChangesAsync();
                return employee.id;
            }
            return 0;
        }
        public async Task<int> DeleteEmployee(int? id)
        {
            int Getresult = 0;
            if (id != null)
            {
                var rec_id = await _context.Employee.FirstOrDefaultAsync(Empid =>
               Empid.id == id);
                if (rec_id != null)
                {
                    _context.Employee.Remove(rec_id);
                    Getresult = await _context.SaveChangesAsync();
                }
                return Getresult;
            }
            return Getresult;
        }
        public async Task<int> UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();
                return employee.id;
            }
            return 0;
        }
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            if (_context != null)
            {
                return await _context.Employee.ToListAsync();
            }
            return null;
        }
        public Employee GetEmployeeById(int id)
        {
            if (_context != null)
            {
                return _context.Employee.FirstOrDefault(e => e.id == id);
            }
            return null;
        }
    }
}