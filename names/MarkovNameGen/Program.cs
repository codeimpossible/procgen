// See https://aka.ms/new-console-template for more information
using System.Reflection;
using MarkovNameGen;

var rootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
List<string> names = new();
List<string> _trainingSet = new();
foreach(var arg in args) {
    var path = Path.Combine(rootDirectory, $@"lib/{arg}.txt");
    var contents = File.ReadAllLines(path);
    _trainingSet.AddRange(contents);
}
var generator = new NameGenerator(_trainingSet, 3, 0.01d);
var generatedNames = await generator.GenerateNames(50, 4, 12, new Random());
names.AddRange(generatedNames);

foreach(var name in names)
{
    Console.WriteLine(name);
}
