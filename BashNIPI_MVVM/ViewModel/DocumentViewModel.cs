using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BashNIPI_MVVM.Model;

namespace BashNIPI_MVVM.ViewModel
{
    public class DocumentViewModel : INotifyPropertyChanged
    {
        private readonly Document _document;
        private bool _canEdited;
        public bool CanEdited
        {
            get => _canEdited;
            set
            {
                _canEdited = value;
                OnPropertyChanged("CanEdited");
            }
        }
        public int Id
        {
            get => _document.Id;
            set
            {
                if (CanEdited)
                {
                    _document.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Name
        {
            get => _document.Name;
            set
            {
                if (CanEdited)
                {
                    _document.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Body
        {
            get => _document.Body;
            set
            {
                if (CanEdited)
                {
                    _document.Body = value;
                    OnPropertyChanged("Body");
                }
            }
        }
        public string Signature
        {
            get => _document.Signature == Guid.Empty ? "" : _document.Signature.ToString();
            set
            {
                if (CanEdited)
                {
                    _document.Signature = Guid.Parse(value);
                    OnPropertyChanged("Signature");
                    CanEdited = false;
                }
            }
        }

        public DocumentViewModel(Document document)
        {
            _document = document;
            CanEdited = (Signature == "");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand _signCommand;
        public RelayCommand SignCommand
        {
            get
            {
                return _signCommand ??
                       (_signCommand = new RelayCommand(obj =>
                       {
                           Signature = Guid.NewGuid().ToString();
                       }));
            }
        }
    }
}
