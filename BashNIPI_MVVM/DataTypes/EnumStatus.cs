using System.ComponentModel;
using BashNIPI_MVVM.Converters;
using BashNIPI_MVVM.ViewModel;

namespace BashNIPI_MVVM.DataTypes
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum EnumStatus
    {
        [Description("В процессе")]
        InProgress,
        [Description("Готово")]
        Done
    }
}
