# Disable Elastic WebVIew in Blazor Android
Add this in codebehind of `MainPage.xaml`
```csharp
 private void BlazorWebView_BlazorWebViewInitialized(object sender, BlazorWebViewInitializedEventArgs e) {
        #if ANDROID
                    // Disable overscroll on Android
                    e.WebView.OverScrollMode = Android.Views.OverScrollMode.Never;
        #endif
    }
```

# ViewModel Bind using Fody
Create a Fody file `FodyWeavers.xml`
```xml
<?xml version="1.0" encoding="utf-8"?>
<Weavers xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="FodyWeavers.xsd">
  <PropertyChanged />
</Weavers>
```

Add this to CSPROJ under `<PropertyGroup/>`
```xml
<PropertyGroup>

    <PropertyChangedAnalyzerConfiguration>
        <IsCodeGeneratorDisabled>false</IsCodeGeneratorDisabled>
        <EventInvokerName>OnPropertyChanged</EventInvokerName>
    </PropertyChangedAnalyzerConfiguration>

</PropertyGroup>
```

Create our ViewModel
```csharp
    [AddINotifyPropertyChangedInterface]
    public partial class ViewModel 
    {
        public int QuestionNumber { get; set; } = 3;
        public SubModel AnotherSample { get; set; } = new();
    }

    [AddINotifyPropertyChangedInterface]
    public partial class SubModel
    {
        public int Test { get; set; } = 3;
    }
```

Set BindingContext to respecting VM
```csharp
public partial class MainPage : ContentPage {

    public ViewModel MyView { get; set; } = new ViewModel();

    public MainPage() {
        InitializeComponent();
        BindingContext = MyView;
    }
}
```

Bind value in UI
```xml
    <Label Text="{Binding QuestionNumber}" />
    <ProgressBar Progress="{Binding AnotherSample.Test}" />
```