using System;
using System.Collections.Generic;
using System.Linq;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    public class EmployeeService : IEmployeeService
    {
        private readonly TimesheetDb db;

        public EmployeeService(TimesheetDb dbContext)
        {
            this.db = dbContext;
        }

        public IQueryable<Employee> GetEmployees()
        {
            return this.db.Employees;
        }
        public IQueryable<Timesheeet> GetTimesheet(int id)
        {
            return this.db.Timesheet.Where(x => x.EmployeeId == id);
        }

        public IQueryable<Task> GetTask()
        {
            return this.db.Tasks;
        }
        public IQueryable<Timesheeet> UpdateTask(Timesheeetmodel ts)
        {
            int empid = Convert.ToInt32(ts.timesheetmodel[0].EmployeeId);
            var data = ts.timesheetmodel.Where(t => String.IsNullOrWhiteSpace(t.TimeSheetId.ToString()));
            foreach (var item in data)
            {
                item.Taskname = this.db.Tasks.Where(f => f.Id == item.TaskId).Select(r => r.Name).FirstOrDefault();
                this.db.Timesheet.Add(item);
                this.db.SaveChanges();
            }
            //update employee average and total
            var total = this.db.Timesheet.Where(x => x.EmployeeId == empid);
            int sum = 0;
            foreach (var item in total)
            {
                sum = sum + Convert.ToInt32(item.Monday + item.Tuesday + item.Wednesday + item.Thursday + item.Friday + item.Saturday + item.Sunday);
            }

            var update = (from x1 in this.db.Employees
                          where x1.Id == empid select x1).FirstOrDefault();
            update.WeeklyEffort = sum;
            update.WeeklyAverage = sum / 7;
            this.db.SaveChanges();
            return this.db.Timesheet.Where(x => x.EmployeeId == empid);
        }
    }
    public interface IEmployeeService
    {
        IQueryable<Employee> GetEmployees();
        IQueryable<Timesheeet> GetTimesheet(int id);
        IQueryable<Task> GetTask();
        IQueryable<Timesheeet> UpdateTask(Timesheeetmodel ts);
    }
    public class Timesheeetmodel
    {
        public List<Timesheeet> timesheetmodel { get; set; }
    }
}
