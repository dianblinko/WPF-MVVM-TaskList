using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BashNIPI_MVVM.Model
{
    public abstract class Record : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string? _body;
        public abstract string ClassName { get;}

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value == "" ? "Запись" : value;
                OnPropertyChanged("Name");
            }
        }
        public string? Body
        {
            get => _body;
            set
            {
                _body = value;
                OnPropertyChanged("Value");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
