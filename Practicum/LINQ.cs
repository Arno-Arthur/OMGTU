using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        string jsonInput = File.ReadAllText("C:\\Users\\Admin\\Documents\\Files\\sample.json");
        JObject input = JObject.Parse(jsonInput);

        string taskName = input["taskName"].ToString();
        JArray data = (JArray)input["data"];

        dynamic result = null;

        if (taskName == "GetStudentsWithHighestGPA") result = GetStudentsWithHighestGPA(data);
        else if (taskName == "CalculateGPAByDiscipline") result = CalculateGPAByDiscipline(data);


        JObject outputData = new JObject();
        outputData["Response"] = JArray.FromObject(result);

        File.WriteAllText("C:\\Users\\Admin\\Documents\\Files\\output.json", outputData.ToString());
    }

    static dynamic GetStudentsWithHighestGPA(JArray data)
    {
        var averageMarks = data.GroupBy(x => x["name"])
                                .ToDictionary(x => x.Key.ToString(),
                                              x => x.Average(y => (int)y["mark"]));

        var maxGPA = averageMarks.Max(x => x.Value);

        return averageMarks.Where(x => x.Value == maxGPA)
                           .Select(x => new { Cadet = x.Key, GPA = maxGPA });
    }
    static JArray CalculateGPAByDiscipline(JArray data)
    {
        var averageMarksByDiscipline = data.GroupBy(x => x["discipline"])
                                            .ToDictionary(
                                                x => x.Key.ToString(),
                                                x => x.Average(y => (int)y["mark"])
                                            );

        JArray response = new JArray(
            averageMarksByDiscipline.Select(x => new JObject(new JProperty(x.Key, x.Value)))
        );

        return response;
    }

}
