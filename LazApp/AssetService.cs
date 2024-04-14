using LazApp.Models;
using System.Text.Json;

namespace LazApp
{
    public class AssetService
    {
        private readonly Dictionary<string, Scenario> scenarios = [];

        public AssetService()
        {
            Task.Run(Init);
        }

        public Scenario? this[string scenario] => scenarios[scenario];

        private async Task Init()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("HilfeleistungSilber.json");
            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            scenarios.Add("Silber", JsonSerializer.Deserialize<Scenario>(json));
        }
    }
}
