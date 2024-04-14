//using System.Text.Json;
//using LazApp.Base;

//namespace LazApp;

//public class LAZapiReader
//{
//    private readonly Question[]? questions;

//    public LAZapiReader(string filename)
//    {
//        var text = File.ReadAllText(filename);
//        questions = JsonSerializer.Deserialize<Question[]>(text);
//    }

//    public Question? GetQuestion(int id) => questions?.FirstOrDefault(q => q.Id == id);

//    public Question[] GetRandomQuestions(int count)
//    {
//        return RandomPicker<ProbabilityDecorator<Question>>
//            .Draw(questions.Select(q => new ProbabilityDecorator<Question>(q)), count)
//            .Select(d => d.Item)
//            .ToArray();
//    }
//}
