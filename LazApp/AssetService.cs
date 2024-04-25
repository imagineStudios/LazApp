using Microsoft.Maui.Controls.Shapes;
using System.Text.Json;

namespace LazApp
{
    public class AssetService<T>
    {
        private readonly Dictionary<string, T> items = [];

        public AssetService(string assets)
        {
            Task.Run(() => Init(assets.Split('|')));
        }

        public T? this[string scenario] => items.TryGetValue(scenario, out T? value) ? value : default;

        private async Task Init(IEnumerable<string> resources)
        {
            foreach (var r in resources)
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync(r);
                using var reader = new StreamReader(stream);
                var json = reader.ReadToEnd();
                items.Add(r.Split(['.'])[0], JsonSerializer.Deserialize<T>(json));
            }
        }
    }
}
