// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Text.RegularExpressions;
using MarkovNameGen;

T GetArgument<T>(string name, T defaultValue = default(T)) {
    object result = null;
    var expectedType = typeof(T);
    foreach(var arg in Environment.GetCommandLineArgs()) {
        if (arg.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)) {
            var val = "";
            if (defaultValue is bool) {
                val = "true";
            } else {
                val = arg.Split('=')[1];
            }
            if (expectedType.IsArray) {
                result = GetManyItems(val, expectedType);
            } else {
                result = GetSingleItem(val, expectedType);
            }
            break;
        }
    }
    return result == null ? defaultValue : (T)result;
}
object GetSingleItem(string input, Type outputType) {
    return Convert.ChangeType(input, outputType);
}
object[] GetManyItems(string input, Type outputType) {
    var vals = input.Split(',');
    var array = (object[])Activator.CreateInstance(outputType, new object[] { vals.Length })!;
    var idx = 0;
    foreach(var val in vals) {
        array[idx] = val;
        idx++;
    }
    return array;
}
var ignoreSpecialChars = GetArgument<bool>("--ignoreSpecial");
var sets = GetArgument<string[]>("--sets");
var seed = GetArgument<int>("--seed", 1024);
var count = GetArgument<int>("--count", 50);
var rootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
List<string> _trainingSet = new();
foreach(var arg in sets) {
    var path = Path.Combine(rootDirectory, $@"lib/{arg}.txt");
    var contents = File.ReadAllLines(path);
    foreach(var line in contents) {
        if (ignoreSpecialChars && line.Any(ch => !char.IsLetterOrDigit(ch))) continue;
        _trainingSet.Add(line);
    }
    _trainingSet.AddRange(contents);
}
var generator = new NameGenerator(_trainingSet, 3, 0.01d);
var generatedNames = await generator.GenerateNames(count, 4, 12, new Random(seed));

foreach(var name in generatedNames) {
    Console.WriteLine(name);
}
