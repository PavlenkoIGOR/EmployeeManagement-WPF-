using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomPerson;


namespace EmployeeManagement.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public EmployeeRepository()
        {
            Person rand = new Person();
            _employees.Add(
              new Employee()
              {
                  
                  Id = Guid.NewGuid(),
                  FirstName = rand.Name,
                  LastName = rand.LastName,
                  Age = rand.Age,
                  CompanyName = "Инжиринг",
                  Position = "Инженер",
                  CityName = "Владивосток"
              });

            _employees.Add(
              new Employee()
              {
                  Id = Guid.NewGuid(),
                  FirstName = "Сергей",
                  LastName = "Сергеев",
                  Age = 34,
                  CompanyName = "Дальний рубеж",
                  Position = "Архитектор",
                  CityName = "Уфа"
              });

            _employees.Add(
              new Employee()
              {
                  Id = Guid.NewGuid(),
                  FirstName = "Константин",
                  LastName = "Петров",
                  Age = 42,
                  CompanyName = "Океан",
                  Position = "Программист",
                  CityName = "Москва"
              });
        }

        public IEnumerable<Employee> GetAll() => _employees;

        public Employee GetById(Guid id) => _employees
          .FirstOrDefault(v => v.Id == id);

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Delete(Guid id)
        {
            _employees.RemoveAll(v => v.Id == id);
        }
    }
}
