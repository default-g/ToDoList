using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DateTimeOffset date = DateTimeOffset.Now.Date;
        public DateTimeOffset Date
        {
            set
            {
                this.RaiseAndSetIfChanged(ref date, value);
                ChangeObservableCollection(this.date);

            }
            get
            {
                return this.date;
            }
        }
        public ObservableCollection<ToDo> Items { get; set; }

        private Dictionary<DateTimeOffset, List<ToDo>> ListsOnDays;

        public MainWindowViewModel()
        {
            this.date = DateTimeOffset.Now.Date;
            InitToDoList();
            this.AppendAction(date, new ToDo("Sleep", "eat"));
            this.AppendAction(date, new ToDo("Sleep", "eat"));
            this.AppendAction(date, new ToDo("Sleep", "eat"));
            this.AppendAction(date.AddDays(-1), new ToDo("DSd", "eat"));
            this.AppendAction(date, new ToDo("Sleep", "eat"));
            this.AppendAction(date, new ToDo("Sleep", "eat"));
            this.Items = new ObservableCollection<ToDo>(this.ListsOnDays[this.date]);
        }

       

        private void InitToDoList()
        {
            var ListsOnDays = new Dictionary<DateTimeOffset, List<ToDo>>();
            ListsOnDays.Add(this.date, new List<ToDo>());
            this.ListsOnDays = ListsOnDays;
        }

        public void AppendAction(DateTimeOffset date, ToDo item)
        {
            if(!this.ListsOnDays.ContainsKey(date))
            {
                this.ListsOnDays.Add(date, new List<ToDo>());
            }
            this.ListsOnDays[date].Add(item);
        }

        public void ChangeObservableCollection(DateTimeOffset date)
        {
            if (!this.ListsOnDays.ContainsKey(date))
            {
                this.Items.Clear();
            }
            else
            {
                this.Items.Clear();
                foreach (var item in this.ListsOnDays[date])
                {
                    this.Items.Add(item);
                }
            }
        }
        
    }
}
