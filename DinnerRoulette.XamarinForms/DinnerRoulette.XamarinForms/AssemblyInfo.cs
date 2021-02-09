using Android.App;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: ExportFont("Courgette-Regular.ttf", Alias = "Courgette")]
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
