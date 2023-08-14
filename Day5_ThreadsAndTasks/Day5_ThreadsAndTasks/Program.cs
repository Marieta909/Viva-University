////---------------------Task 1------------
//string firstFile = "firstfile.txt";
//string secondFile = "secondfile.txt";

//Task<int[]> readLinesTask = Task.Run(() =>
//{
//    string[] first1 = File.ReadAllLines(firstFile);
//    string[] second1 = File.ReadAllLines(secondFile);

//    return new[] { first1.Length, second1.Length };
//});

//Task printTask = Task.Run(() =>
//{
//    int seconds = 0;
//    while (!readLinesTask.IsCompleted)
//    {
//        Console.WriteLine($"Elapsed seconds: {seconds}");
//        seconds++;

//    }

//    Task.Delay(3000);
//});

//Task.WaitAll(readLinesTask, printTask);

//int[] lineCounts = readLinesTask.Result;
//int totalLines = lineCounts[0] + lineCounts[1];

//Console.WriteLine($"\nTotal lines: {totalLines}");

////-------------------Task 2 ---------------

//class Program
//{
//    static async Task Main()
//    {
//        string directoryPath = "Images";

//        string[] imageFiles = Directory.GetFiles(directoryPath, "*.jpg");

//        await MutateImages(imageFiles);

//        Console.WriteLine("All images are mutated.");
//    }

//    static async Task MutateImages(string[] imageFiles)
//    {
//        foreach (string file in imageFiles)
//        {
//            string fileName = Path.GetFileName(file);
//            Console.WriteLine($"Mutating image: {fileName}");

//            await Task.Run(() =>
//            {
//                using var image = Image.Load<Rgba32>(file);
//                image.Mutate(x => x.Resize(256, 0));
//                image.Mutate(x => x.BlackWhite()); //կարող էի grayscale value(RGB avg) հաշվելով էլ անել, բայց այս տարբերակը գտա

//                string newFilePath = Path.Combine("NewImages", fileName);
//                image.Save(newFilePath);
//            });

//            Console.WriteLine($"Image mutated: {fileName}");
//        }
//    }
//}

//---------------------Task 3-----

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var scheduler = new TaskScheduler();

        CancellationTokenSource task1TokenSource = scheduler.ScheduleTask(() => Console.WriteLine("Task 1 running."), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(2));
        CancellationTokenSource task2TokenSource = scheduler.ScheduleTask(() => Console.WriteLine("Task 2 running."), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));

        DateTime dateTime1 = DateTime.Now.AddSeconds(10);
        CancellationTokenSource task3TokenSource = scheduler.ScheduleTask(() => Console.WriteLine("Task 3 running."), dateTime1);

        DateTime dateTime2 = DateTime.Now.AddSeconds(15);
        CancellationTokenSource task4TokenSource = scheduler.ScheduleTask(() => Console.WriteLine("Task 4 running."), dateTime2);

        Console.WriteLine("Press Enter to cancel a task...");
        Console.ReadLine();

        task2TokenSource.Cancel();

        Console.WriteLine("Task 2 cancelled. Press Enter to exit.");
        Console.ReadLine();
    }
}

class TaskScheduler
{
    private readonly List<Task> _tasks;

    public TaskScheduler()
    {
        _tasks = new List<Task>();
    }

    public CancellationTokenSource ScheduleTask(Action action, TimeSpan delay, TimeSpan interval)
    {
        CancellationTokenSource tokenSource = new();
        CancellationToken cancellationToken = tokenSource.Token;

        async Task TaskRunner()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(delay, cancellationToken);

                if (!cancellationToken.IsCancellationRequested)
                {
                    action();
                }

                await Task.Delay(interval, cancellationToken);
            }
        }

        Task task = TaskRunner();
        _tasks.Add(task);

        cancellationToken.Register(() => task.ContinueWith(_ => { }, TaskContinuationOptions.OnlyOnCanceled));

        return tokenSource;
    }

    public CancellationTokenSource ScheduleTask(Action action, DateTime dateTime)
    {
        TimeSpan delay = dateTime - DateTime.Now;

        if (delay < TimeSpan.Zero)
        {
            throw new ArgumentException("Specified DateTime has already passed.", nameof(dateTime));
        }

        CancellationTokenSource tokenSource = new();
        CancellationToken cancellationToken = tokenSource.Token;

        async Task TaskRunner()
        {
            await Task.Delay(delay, cancellationToken);

            if (!cancellationToken.IsCancellationRequested)
            {
                action();
            }
        }

        Task task = TaskRunner();
        _tasks.Add(task);

        cancellationToken.Register(() => task.ContinueWith(_ => { }, TaskContinuationOptions.OnlyOnCanceled));

        return tokenSource;
    }
}
