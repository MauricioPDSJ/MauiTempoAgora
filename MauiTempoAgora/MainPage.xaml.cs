using System;
using System.Diagnostics;

namespace MauiTempoAgora
{
    public partial class MainPage : ContentPage
    {
        CancellationTokenSource _cancelTokenSource;
        bool _isCheckingLocation;

        string? cidade;


        public MainPage()
        {
            InitializeComponent();
        }


        // https://learn.microsoft.com/en-us/bingmaps/getting-started/bing-maps-dev-center-help/getting-a-bing-maps-key
        // https://stackoverflow.com/questions/75174113/maui-windows-platform-cant-access-location

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                _cancelTokenSource = new CancellationTokenSource();

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                Location? location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                {
                    lbl_latitude.Text = location.Latitude.ToString();
                    lbl_longitude.Text = location.Longitude.ToString();

                    Debug.WriteLine("-------------------------------------------");
                    Debug.WriteLine(location);

                    Debug.WriteLine("-------------------------------------------");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Erro: Dispositivo não Suporta", fnsEx.Message, "OK");
            }
            catch (FeatureNotEnabledException fnsEx)
            {
                await DisplayAlert("Erro: Localização Desabilitada", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx) 
            {
                await DisplayAlert("Erro: Permissão", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro: ", ex.Message, "OK");
            }

        }



        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }

}
