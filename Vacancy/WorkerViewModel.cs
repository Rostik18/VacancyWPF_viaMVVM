using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vacancy
{
    class WorkerViewModel
    {
        private Worker selectedWorker;
        private Worker worker;

        public ObservableCollection<Worker> Workers { get; set; }
        public Worker SelectedWorker
        {
            get { return selectedWorker; }
            set { selectedWorker = value; }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Worker worker = new Worker();
                      Workers.Insert(0, worker);
                      SelectedWorker = worker;

                  }));
            }
        }
        private RelayCommand addToDBCommand;
        public RelayCommand AddToDBCommand
        {
            get
            {
                return addToDBCommand ??
                  (addToDBCommand = new RelayCommand(obj =>
                  {
                      using (WorkerContext db = new WorkerContext())
                      {
                          db.Workers.AddRange(Workers);
                          db.SaveChanges();
                      }
                  }));
            }
        }

        public WorkerViewModel()
        {
            Workers = new ObservableCollection<Worker>();
            Workers.Add(new Worker() { Name = "Bob", Position = "front", Birthday = new DateTime(1984, 1, 10) });
        }

        public string Name
        {
            get { return worker.Name; }
            set { worker.Name = value; }
        }
        public string Position
        {
            get { return worker.Position; }
            set { worker.Position = value; }
        }
        public DateTime Birthday
        {
            get { return worker.Birthday; }
            set { worker.Birthday = value; }
        }
    }
}
