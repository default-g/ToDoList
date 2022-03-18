using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    internal class FirstViewModel : ViewModelBase
    {

        private Dictionary<DateTimeOffset, List<ToDo>> ListsOnDays;

        public FirstViewModel(ref Dictionary<DateTimeOffset, List<ToDo>> ListsOnDays)
        {
            this.ListsOnDays = ListsOnDays;
            
        }
       

        

    }
}
