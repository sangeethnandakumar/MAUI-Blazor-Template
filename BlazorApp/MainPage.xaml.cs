using Microsoft.AspNetCore.Components.WebView;

namespace BlazorApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        blazorWebView.BlazorWebViewInitialized += BlazorWebView_BlazorWebViewInitialized;
    }

    private void BlazorWebView_BlazorWebViewInitialized(object sender, BlazorWebViewInitializedEventArgs e) {
        #if ANDROID
            // Disable overscroll on Android
            e.WebView.OverScrollMode = Android.Views.OverScrollMode.Never;
        #endif
    }
}
