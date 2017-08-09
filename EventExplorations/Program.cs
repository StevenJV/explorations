using System;
using System.Threading.Tasks;

namespace EventExplorations
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => {
                Worker joe = new Worker("Joe");
                new Reporter(joe);
                joe.DoTask("one");
                Console.WriteLine("---");
            });

            Task.Run(() => {
                Worker jack = new Worker("Jack");
                new Reporter(jack);
                jack.DoTask("two");
                Console.WriteLine("---");
            });
            Task.Run(() => {
                Worker mary = new Worker("Mary");
                new Reporter(mary);
                mary.DoTask("three");
            });

            Console.WriteLine("---");
            Console.ReadKey();
        }
    }

    public class Worker
    {
        //public delegate void WorkBegunHandler(object sender, WorkArgs e);
        public EventHandler<WorkArgs> WorkBegun;
        public EventHandler<WorkArgs> WorkCompleted;

        private static readonly Random Rnd = new Random();
        readonly int _timeToComplete = Rnd.Next(1, 8);
        public string Name { get; set; }
        public string Task { get; set; }

        public Worker(string name)
        {
            Name = name;
            Console.WriteLine($"{Name} reporting for duty");
        }

        public void DoTask(string taskName)
        {
            Task = taskName;
            OnWorkBegun();
            for (int i = 0; i <= _timeToComplete; i++) Console.WriteLine($"{Name} working");
            OnWorkCompleted();
        }

        protected virtual void OnWorkBegun()
        {
            WorkArgs args = new WorkArgs(Name, Task, "Started");
            WorkBegun?.Invoke(this, args);
        }

        protected virtual void OnWorkCompleted()
        {
            WorkArgs args = new WorkArgs(Name, Task, "Completed");
            WorkCompleted?.Invoke(this, args);
        }
    }

    public class WorkArgs : EventArgs
    {
        public string WorkerName;
        public string TaskName;
        public string Status;

        public WorkArgs(string workerName, string taskName, string status)
        {
            this.WorkerName = workerName;
            this.TaskName = taskName;
            this.Status = status;
        }
    }

    public class Reporter
    {

        public Reporter(Worker reportOn)
        {
            reportOn.WorkBegun += ReportSomething;
            reportOn.WorkCompleted += ReportSomething;
        }

        private void ReportSomething(object sender, WorkArgs e)
        {
            Console.WriteLine($"reporting: {e.WorkerName} {e.Status} {e.TaskName}");
        }
    }
}