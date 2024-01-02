// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Solarsystem.Generation;

Console.WriteLine("Hello, World!");


JsonConvert.DefaultSettings = (() =>
{
    var settings = new JsonSerializerSettings();
    settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter {
        NamingStrategy = new DefaultNamingStrategy()
    });
    settings.Formatting = Formatting.Indented;
    return settings;
});

var universe = Generator.CreateUniverse();
var json = JsonConvert.SerializeObject(universe);
Console.WriteLine(json);

File.WriteAllText("generated.json", json);
