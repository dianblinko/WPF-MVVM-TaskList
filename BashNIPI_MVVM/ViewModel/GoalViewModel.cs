using System.ComponentModel;
using System.Runtime.CompilerServices;
using BashNIPI_MVVM.DataTypes;
using BashNIPI_MVVM.Model;

namespace BashNIPI_MVVM.ViewModel
{
    public class GoalViewModel
    {
        private Goal _goal;

        public int Id
        {
            get => _goal.Id;
            set
            {
                _goal.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get => _goal.Name;
            set
            {
                _goal.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Body
        {
            get => _goal.Body;
            set
            {
                _goal.Body = value;
                OnPropertyChanged("Body");
            }
        }

        public EnumStatus Status
        {
            get => _goal.Status;
            set
            {
                _goal.Status = value;
                OnPropertyChanged("Status");
            }
        }

        public GoalViewModel(Goal goal)
        {
            _goal = goal;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}