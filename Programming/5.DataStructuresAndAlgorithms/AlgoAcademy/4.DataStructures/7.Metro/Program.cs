using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;

enum Direction
{
    Forward,
    Backwards
}

class Program
{
    static readonly string DateFormat = "d.M.yyyy H:mm";

    static IList<KeyValuePair<string, int>> stationsInfo = null;
    static IList<Tuple<DateTime, string, int, int, Direction>> camerasInfo = null;
    static int trainCapacity = 0;

    static Dictionary<string, int> trainScheduleForward = null;
    static Dictionary<string, int> trainScheduleBackwards = null;

    static int trainScheduleDuration = 0;

    static Dictionary<Tuple<DateTime, string, Direction>, int> trains = null;

    static void ParseInput()
    {
        Console.ReadLine();

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

        camerasInfo = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine())
            .Select(line => Regex.Split(line, @" \u007c "))
            .Select(match =>
                new Tuple<DateTime, string, int, int, Direction>(
                    DateTime.ParseExact(match[0], DateFormat, CultureInfo.InvariantCulture),
                    match[1],
                    int.Parse(match[2]),
                    int.Parse(match[3]),
                    match[4] == ">>" ? Direction.Forward : Direction.Backwards
                )
            ).ToArray();

        trainCapacity = int.Parse(Console.ReadLine());

#if DEBUG
        Console.WriteLine("# INPUT");

        Console.WriteLine(string.Join(Environment.NewLine, stationsInfo));
        Console.WriteLine();

        Console.WriteLine(string.Join(Environment.NewLine, camerasInfo));
        Console.WriteLine();

        Console.WriteLine(trainCapacity);
        Console.WriteLine();
#endif
    }

    static void MakeSchedule()
    {
        int currentDuration = 0;

        trainScheduleForward = stationsInfo.ToDictionary(
            kvp => kvp.Key,
            kvp => currentDuration += kvp.Value
        );

        trainScheduleDuration = currentDuration;

        trainScheduleBackwards = trainScheduleForward.Reverse().ToDictionary(
            kvp => kvp.Key,
            kvp => trainScheduleDuration - kvp.Value
        );

#if DEBUG
        Console.WriteLine("# Schedule");

        Console.WriteLine(string.Join(Environment.NewLine, trainScheduleForward));
        Console.WriteLine();

        Console.WriteLine(string.Join(Environment.NewLine, trainScheduleBackwards));
        Console.WriteLine();
#endif
    }

    static void MatchTrains()
    {
        trains = new Dictionary<Tuple<DateTime, string, Direction>, int>();

        foreach (var trainInfo in camerasInfo)
        {
            var startDate = trainInfo.Item1.AddMinutes(-1 *
                (trainInfo.Item5 == Direction.Forward ? trainScheduleForward : trainScheduleBackwards)[trainInfo.Item2]
            );

            var train = new Tuple<DateTime, string, Direction>(startDate, null, trainInfo.Item5);

            trains[train] = 0;
        }

#if DEBUG
        Console.WriteLine("# TRAINS AT START");

        Console.WriteLine(string.Join(Environment.NewLine, trains));
        Console.WriteLine();
#endif
    }

    static void SimulateTrainMovement()
    {
        foreach (var startTrain in trains.ToArray())
        {
            var schedule = (startTrain.Key.Item3 == Direction.Forward ?
                trainScheduleForward : trainScheduleBackwards
            );

            var passengers = startTrain.Value; // 0

            foreach (var stop in schedule)
            {
                var date = startTrain.Key.Item1.AddMinutes(stop.Value);

                var cameraInfo = camerasInfo.Where(info =>
                    info.Item1 == date &&
                    info.Item2 == stop.Key &&
                    info.Item5 == startTrain.Key.Item3
                ).FirstOrDefault();

                if (cameraInfo != null)
                {
                    passengers += cameraInfo.Item3 - cameraInfo.Item4;
                    passengers = Math.Max(0, passengers);

                }
                else if (stop.Value == trainScheduleDuration)
                {
                    passengers = 0;
                }

                var currentTrain = new Tuple<DateTime, string, Direction>(
                    date,
                    stop.Key,
                    startTrain.Key.Item3
                );

                trains[currentTrain] = passengers;
            }
        }

#if DEBUG
        Console.WriteLine("# SIMULATED TRAINS");

        Console.WriteLine(string.Join(Environment.NewLine, trains));
        Console.WriteLine();
#endif
    }

    static void ShowCapacity()
    {
        var output = new StringBuilder();

        foreach (var cameraInfo in camerasInfo)
        {
            int passengers = trains[new Tuple<DateTime, string, Direction>(
                cameraInfo.Item1, cameraInfo.Item2, cameraInfo.Item5
            )];

            if (passengers > trainCapacity)
            {
                output.AppendFormat(string.Join(" | ",
                    cameraInfo.Item1.ToString(DateFormat), cameraInfo.Item2, cameraInfo.Item5 == Direction.Forward ? ">>" : "<<", passengers
                )).AppendLine();
            }
        }

#if DEBUG
        Console.WriteLine("# OUTPUT");
#endif

        Console.Write(output.Length != 0 ? output.ToString() : ("OK" + Environment.NewLine));
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;

        ParseInput();

        MakeSchedule();

        MatchTrains();

        SimulateTrainMovement();

        ShowCapacity();
    }
}
