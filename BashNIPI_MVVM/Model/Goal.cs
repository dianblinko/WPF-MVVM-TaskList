using BashNIPI_MVVM.DataTypes;
using BashNIPI_MVVM.ViewModel;

namespace BashNIPI_MVVM.Model
{
    public class Goal : Record
    {
        private EnumStatus _status;
        public EnumStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }
        public override string ClassName => "Задача";

        public Goal() : base()
        {
            Status = EnumStatus.InProgress;
        }
    }
}
