using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BashNIPI_MVVM.DataTypes;
using BashNIPI_MVVM.Model;
using BashNIPI_MVVM.Services;

namespace BashNIPI_MVVM.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Record> _records;
        private Record _selectedRecord;
        public ObservableCollection<Record> Records { get; private set; }
        public Record SelectedRecord
        {
            get => _selectedRecord;
            set
            {
                _selectedRecord = value;
                OnPropertyChanged("SelectedRecord");
                _OpenSelectedRecord();
            }
        }

        public ApplicationViewModel()
        {
            Records = new ObservableCollection<Record>
            {
                new Document{ Id= 6, Name= "Оформление кода.doc", Body = "Примеры оформления кода"},
                new Document{ Id= 5, Name= "Список задач.doc", Body = "Задачи в списке задач"},
                new Document{ Id= 4, Name= "Заказы.doc", Body = "Вчера заказали заказы"},
                new Goal{ Id= 3, Name= "Оформи код", Body = "Срочно оформи код", Status = EnumStatus.InProgress},
                new Goal{ Id= 2, Name= "Посмотри задачи", Body = "Посмотри файл с задачами", Status = EnumStatus.InProgress},
                new Goal{ Id= 1, Name= "Выполни заказ", Body = "Повтори вчерашние заказы", Status = EnumStatus.InProgress}
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
        private RelayCommand _createRecordCommand;
        public RelayCommand CreateRecordCommand
        {
            get
            {
                return _createRecordCommand ??
                       (_createRecordCommand = new RelayCommand(obj =>
                       {
                           string className = obj.ToString();
                           IRecordFactory factory;
                           switch (className)
                           {
                               case "Document":
                                   factory = new DocumentFactory();
                                   break;
                               case "Goal":
                                   factory = new GoalFactory();
                                   break;
                               default:
                                   throw new Exception(
                                       $"Attempt to create a factory for a non-existent class: {className}");
                           }

                           Record record = factory.CreateRecord("Новая запись");
                           record.Id = Records.Count + 1;
                           Records.Insert(0, record);
                           SelectedRecord = record;
                       }));
            }
        }
        private RelayCommand _openRecordCommand;
        public RelayCommand OpenRecordCommand
        {
            get
            {
                return _openRecordCommand ??
                       (_openRecordCommand = new RelayCommand(obj =>
                       {
                           SelectedRecord = (Record)obj;
                       }));
            }
        }
        private void _OpenSelectedRecord()
        {
            string className = SelectedRecord.ClassName;
            ViewFactory viewFactory;
            switch (className)
            {
                case "Документ":
                    viewFactory = new DocumentViewFactory();
                    break;
                case "Задача":
                    viewFactory = new GoalViewFactory();
                    break;
                default:
                    throw new Exception($"Attempt to create a viewFactory for a non-existent class: {className}");
            }
            viewFactory.CreateView(SelectedRecord);
        }
    }
}
