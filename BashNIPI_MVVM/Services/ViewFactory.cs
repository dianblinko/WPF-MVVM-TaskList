using BashNIPI_MVVM.Model;
using BashNIPI_MVVM.View;
using BashNIPI_MVVM.ViewModel;

namespace BashNIPI_MVVM.Services
{
    public interface ViewFactory
    {
        public void CreateView(Record record);
    }

    public class GoalViewFactory : ViewFactory
    {
        public void CreateView(Record record)
        {

            var goalView = new GoalView
            {
                DataContext = new GoalViewModel((Goal)record)
            };
            goalView.Show();
        }
    }

    public class DocumentViewFactory : ViewFactory
    {
        public void CreateView(Record record)
        {
            var documentView = new DocumentView
            {
                DataContext = new DocumentViewModel((Document)record)
            };
            documentView.Show();
        }
    }
}