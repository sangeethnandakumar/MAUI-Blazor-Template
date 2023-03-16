using PropertyChanged;
using System.ComponentModel;

namespace BlazorApp.Data {

    [AddINotifyPropertyChangedInterface]
    public partial class ViewModel : INotifyPropertyChanged {
        public int QuestionNumber { get; set; } = 3;
        public ViewModel2 AnotherSample { get; set; } = new();
    }

    [AddINotifyPropertyChangedInterface]
    public partial class ViewModel2 : INotifyPropertyChanged {
        public int Test { get; set; } = 3;
    }
}
