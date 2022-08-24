using System;

namespace BashNIPI_MVVM.Model
{
    public class Document : Record
    {
        private Guid _signature;
        public Guid Signature
        {
            get => _signature;
            set
            {
                _signature = value;
                OnPropertyChanged("Signature");
            }
        }
        public override string ClassName => "Документ";
    }
}
