using BlazorApp.Data;
using Microsoft.AspNetCore.Components.WebView;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorApp;

public partial class MainPage : ContentPage {

    public ViewModel MyView { get; set; } = new ViewModel();

    public MainPage() {
        InitializeComponent();
        BindingContext = MyView;
    }

    private void BlazorWebView_BlazorWebViewInitialized(object sender, BlazorWebViewInitializedEventArgs e) {
        #if ANDROID
                    // Disable overscroll on Android
                    e.WebView.OverScrollMode = Android.Views.OverScrollMode.Never;
        #endif
    }

    private void Button_Clicked(object sender, EventArgs e) {
        MyView.QuestionNumber++;
    }
}