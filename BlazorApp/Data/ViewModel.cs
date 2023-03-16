using PropertyChanged;
using System.ComponentModel;

namespace BlazorApp.Data {

    [AddINotifyPropertyChangedInterface]
    public partial class ViewModel : INotifyPropertyChanged {
        public int QuestionNumber { get; set; } = 3;
        public SubModel AnotherSample { get; set; } = new();
    }

    [AddINotifyPropertyChangedInterface]
    public partial class SubModel : INotifyPropertyChanged {
        public int Test { get; set; } = 3;
    }
}
