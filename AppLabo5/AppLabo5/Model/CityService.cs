using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace AppLabo5.Model
{
    class CityService
    {
        public async Task<IEnumerable<City>> GetCitiesFromJson()
        {
            var jsonString = await getStringFromFile(@"Assets\city.list.json");
            var rawCities = JArray.Parse(jsonString);
            var cities = rawCities.Select(c => new City()
                {
                    ID = c["_id"].Value<double>(),
                    Name = c["name"].Value<string>(),
                    Country = c["country"].Value<string>(),
                    Longitude = c["coord"]["lon"].Value<double>(),
                    Latitude = c["coord"]["lat"].Value<double>()
                });

            return cities;
        }

        private async Task<string> getStringFromFile(string filepath)
        {
            StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await folder.GetFileAsync(filepath); // error here
            return await Windows.Storage.FileIO.ReadTextAsync(file);
        }
    }
}
