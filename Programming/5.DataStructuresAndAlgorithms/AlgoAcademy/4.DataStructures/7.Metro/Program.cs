using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;

class Program
{
    static readonly string DateFormat = "d.M.yyyy H:mm";

    static IList<KeyValuePair<string, int>> stationsInfo = null;
    static IList<Tuple<DateTime, int, int, int, char>> camerasInfo = null;
    static int trainCapacity = 0;

    static Dictionary<int, int> trainScheduleForward = null;
    static Dictionary<int, int> trainScheduleBackwards = null;

    static int trainScheduleDuration = 0;

    static Dictionary<Tuple<DateTime, int, char>, int> trains = new Dictionary<Tuple<DateTime, int, char>, int>();

    static Dictionary<string, int> stationsByName = null;
    static Dictionary<int, string> stationsByIndex = null;

    static void ParseInput()
    {
        int n = int.Parse(Console.ReadLine());

        stationsInfo = Regex.Matches(
                ("0 --> " + Console.ReadLine()).Replace(" --> ", "►"),
                "([^►]+)►([^►]+)"
            ).Cast<Match>()
            .Select(match =>
                new KeyValuePair<string, int>(
                    match.Groups[2].Value,
                    int.Parse(match.Groups[1].Value)
                )
            ).ToArray();

        int id = 0;
        stationsByName = stationsInfo.ToDictionary(
            info => info.Key,
            info => id++
        );

        stationsByIndex = stationsByName.ToDictionary(
            kvp => kvp.Value,
            kvp => kvp.Key
        );

        var separator = new string[] { " | " };

        camerasInfo = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine())
            .Select(line => line.Split(separator, StringSplitOptions.None))
            .Select(match =>
                new Tuple<DateTime, int, int, int, char>(
                    DateTime.ParseExact(match[0], DateFormat, CultureInfo.InvariantCulture),
                    stationsByName[match[1]],
                    int.Parse(match[2]),
                    int.Parse(match[3]),
                    match[4][0]
                )
            ).ToArray();

        trainCapacity = int.Parse(Console.ReadLine());

#if DEBUG
        //Console.WriteLine("# INPUT");

        //Console.WriteLine(string.Join(Environment.NewLine, stationsInfo));
        //Console.WriteLine();

        //Console.WriteLine(string.Join(Environment.NewLine, camerasInfo));
        //Console.WriteLine();

        //Console.WriteLine(trainCapacity);
        //Console.WriteLine();
#endif
    }

    static void MakeSchedule()
    {
        int currentDuration = 0;

        trainScheduleForward = stationsInfo.ToDictionary(
            kvp => stationsByName[kvp.Key],
            kvp => currentDuration += kvp.Value
        );

        trainScheduleDuration = currentDuration;

        trainScheduleBackwards = trainScheduleForward.Reverse().ToDictionary(
            kvp => kvp.Key,
            kvp => trainScheduleDuration - kvp.Value
        );

#if DEBUG
        //Console.WriteLine("# Schedule");

        //Console.WriteLine(string.Join(Environment.NewLine, trainScheduleForward));
        //Console.WriteLine();

        //Console.WriteLine(string.Join(Environment.NewLine, trainScheduleBackwards));
        //Console.WriteLine();
#endif
    }

    static void MatchTrains()
    {
        foreach (var trainInfo in camerasInfo)
        {
            var startDate = trainInfo.Item1.AddMinutes(-1 *
                (trainInfo.Item5 == '>' ? trainScheduleForward : trainScheduleBackwards)[trainInfo.Item2]
            );

            var train = new Tuple<DateTime, int, char>(startDate, -1, trainInfo.Item5);

            trains[train] = 0;
        }

#if DEBUG
        //Console.WriteLine("# TRAINS AT START");

        //Console.WriteLine(string.Join(Environment.NewLine, trains));
        //Console.WriteLine();
#endif
    }

    static void SimulateTrainMovement()
    {
        var camerasInfoDict = camerasInfo.ToDictionary(
            info =>
                new Tuple<DateTime, int, char>(
                    info.Item1, info.Item2, info.Item5
                ),
            info =>
                info.Item3 - info.Item4
        );

        foreach (var startTrain in trains.ToArray())
        {
            var schedule = startTrain.Key.Item3 == '>' ?
                trainScheduleForward : trainScheduleBackwards;

            var passengers = startTrain.Value; // 0

            foreach (var stop in schedule)
            {
                var date = startTrain.Key.Item1.AddMinutes(stop.Value);

                int delta = 0;

                bool found = camerasInfoDict.TryGetValue(
                    new Tuple<DateTime, int, char>(date, stop.Key, startTrain.Key.Item3),
                    out delta
                );

                if (found)
                {
                    passengers += delta;
                    passengers = Math.Max(0, passengers);
                }
                else continue;

                var currentTrain = new Tuple<DateTime, int, char>(
                    date,
                    stop.Key,
                    startTrain.Key.Item3
                );

                trains[currentTrain] = passengers;
            }
        }

#if DEBUG
        //Console.WriteLine("# SIMULATED TRAINS");

        //Console.WriteLine(string.Join(Environment.NewLine, trains));
        //Console.WriteLine();
#endif
    }

    static void ShowOverCapacity()
    {
        var output = new StringBuilder();

        foreach (var cameraInfo in camerasInfo)
        {
            int passengers = trains[new Tuple<DateTime, int, char>(
                cameraInfo.Item1, cameraInfo.Item2, cameraInfo.Item5
            )];

            if (passengers > trainCapacity)
            {
                output.AppendFormat(string.Join(" | ",
                    cameraInfo.Item1.ToString(DateFormat),
                    stationsByIndex[cameraInfo.Item2],
                    cameraInfo.Item5 == '>' ? ">>" : "<<",
                    passengers
                )).AppendLine();
            }
        }

        if (output.Length == 0)
            output.AppendLine("OK");

#if DEBUG
        Console.WriteLine("# OUTPUT");
#endif

        Console.Write(output);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        ParseInput();

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif

        MakeSchedule();

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif

        MatchTrains();

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif

        SimulateTrainMovement();

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif

        ShowOverCapacity();

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
