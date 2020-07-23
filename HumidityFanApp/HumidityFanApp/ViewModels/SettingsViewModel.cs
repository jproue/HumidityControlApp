using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using RestSharp;
using HumidityFanApp.Models;

namespace HumidityFanApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel()
        {
            Title = "Settings";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
            SaveSettings = new Command(() => { OnSaveSettings(); });
        }
        public void OnSaveSettings()
        {
            RestClient client = new RestClient($"http://{ServerName}");
            RestRequest req = new RestRequest("/settings", Method.POST);
            var settings_req = new SettingsRequest();
            settings_req.temp_threshold = TempThreshold;
            settings_req.humidity_threshold = HumidityThreshold;
            req.AddJsonBody(settings_req);
            var response = client.Execute(req);
        }
        private string _ServerName;
        public string ServerName
        {
            get { return _ServerName; }
            set { SetProperty(ref _ServerName, value); }
        }
        private bool  _FanOnOff;
        public bool FanOnOff
        {
            get { return _FanOnOff; }
            set { SetProperty(ref _FanOnOff, value); }
        }
        private bool _TempOnOff;
        public bool TempOnOff
        {
            get { return _TempOnOff; }
            set { SetProperty(ref _TempOnOff, value); }
        }
        private int _TempThreshold;
        public int TempThreshold
        {
            get { return _TempThreshold; }
            set { SetProperty(ref _TempThreshold, value); }
        }
        private bool _HumidityOnOff;
        public bool HumidityOnOff
        {
            get { return _HumidityOnOff; }
            set { SetProperty(ref _HumidityOnOff, value); }
        }
        private int _HumidityThreshold;
        public int HumidityThreshold
        {
            get { return _HumidityThreshold; }
            set { SetProperty(ref _HumidityThreshold, value); }
        }

        public ICommand SaveSettings
        {
            get; set;
        }
        public ICommand OpenWebCommand { get; }
    }
}