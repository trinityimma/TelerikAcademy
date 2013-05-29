using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;

class Program
{
    static readonly string DateFormat = "d.M.yyyy H:mm";

    static int n = 0;

    static IList<KeyValuePair<string, int>> stationsInfo = null;
    static IList<Tuple<DateTime, int, int, int, char>> camerasInfo = null;
    static int trainCapacity = 0;

    static Dictionary<int, int> trainScheduleForward = null;
    static Dictionary<int, int> trainScheduleBackwards = null;

    static int trainScheduleDuration = 0;

    static Dictionary<Tuple<DateTime, char>, int[]> trains = new Dictionary<Tuple<DateTime, char>, int[]>();

    static Dictionary<string, int> stationsByName = null;
    static Dictionary<int, string> stationsByIndex = null;

    static void ParseInput()
    {
        n = int.Parse(Console.ReadLine());

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

    static void SimulateTrainMovement()
    {
        foreach (var cameraInfo in camerasInfo)
        {
            var start = cameraInfo.Item1.AddMinutes(-1 *
                (cameraInfo.Item5 == '>' ? trainScheduleForward : trainScheduleBackwards)[cameraInfo.Item2]
            );

            var train = new Tuple<DateTime, char>(start, cameraInfo.Item5);

            if (!trains.ContainsKey(train))
                trains[train] = new int[n];

            trains[train][cameraInfo.Item2] = cameraInfo.Item4 - cameraInfo.Item3;
        }

        foreach (var train in trains)
        {
            int passengers = 0;

            if (train.Key.Item2 == '>')
            {
                for (int i = 0; i < train.Value.Length; i++)
                {
                    passengers -= train.Value[i];
                    passengers = Math.Max(passengers, 0);
                    train.Value[i] = passengers;
                }

                train.Value[train.Value.Length - 1] = 0;
            }
            else
            {
                for (int i = train.Value.Length - 1; i >= 0; i--)
                {
                    passengers -= train.Value[i];
                    passengers = Math.Max(passengers, 0);
                    train.Value[i] = passengers;
                }

                train.Value[0] = 0;
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
            var start = cameraInfo.Item1.AddMinutes(-1 *
                (cameraInfo.Item5 == '>' ? trainScheduleForward : trainScheduleBackwards)[cameraInfo.Item2]
            );

            int passengers = trains[new Tuple<DateTime, char>(
                start, cameraInfo.Item5
            )][cameraInfo.Item2];

            if (passengers > trainCapacity)
            {
                output.AppendFormat(string.Join(" | ",
                    cameraInfo.Item1.ToString(DateFormat),
                    stationsByIndex[cameraInfo.Item2],
                    new string(cameraInfo.Item5, 2),
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

        MakeSchedule();

        SimulateTrainMovement();

        ShowOverCapacity();

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
