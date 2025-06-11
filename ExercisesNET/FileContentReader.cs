using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET
{

    // T => async Task<T>
    // void => async Task

    // void => async void   ==> tylko dla eventów!!!!  void Mth(object obj, EventArgs e)

    internal class FileContentReader
    {

        // void => async Task
        public async Task ReadAndLogAsync(string path)
        {
            var taskRead = File.ReadAllTextAsync(path);

            //
            //
            //

            var content = await taskRead;


            Console.WriteLine($"Odczytano plik: {content}");
        }



        public async Task ReadAndLogAsyncWithTask(string path)
        {
            var taskRead = Task.Run(() => File.ReadAllText(path));


            //
            //

            var content = await taskRead;

            Console.WriteLine($"Odczytano plik: {content}");
        }


        // string => Task<string>        T => Task<T>
        public async Task<string> GetReadAndLogAsync(string path)
        {
            var taskRead = File.ReadAllTextAsync(path);

            //
            //
            //

            var content = await taskRead;


            Console.WriteLine($"Odczytano plik: {content}");

            return content;
        }


        public string GetReadAndLog(string path)
        {
            var content = File.ReadAllText(path);

            Console.WriteLine($"Odczytano plik: {content}");

            return content;
        }



        public void ReadAndLog(string path)
        {
            var content = File.ReadAllText(path);

            Console.WriteLine($"Odczytano plik: {content}");
        }


        public async void ReadAndLogAsyncvoid(string path)
        {
            var content = await File.ReadAllTextAsync(path);

            Console.WriteLine($"Odczytano plik: {content}");
        }


        public async Task ReadFilesFromDirectoryAsync(string folderPath, CancellationToken token)
        {
            foreach (var filePath in Directory.GetFiles(folderPath, "*.txt"))
            {
                var taskRead = Task.Run(() => {
                    Thread.Sleep(10);
                    return File.ReadAllText(filePath);
                });

                Thread.Sleep(5);
                var content = await taskRead;
                Thread.Sleep(1);
                Console.WriteLine($"Odczytano plik: {content}");

                //if (token.IsCancellationRequested) return;
                token.ThrowIfCancellationRequested();
            }
        }

        public async Task TestCancellationAsync()
        {
            var cts = new CancellationTokenSource();

            try
            {
                var task = ReadFilesFromDirectoryAsync("C:\\temp", cts.Token);
                Thread.Sleep(12);
                cts.Cancel(true);

                await task;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Przerwano operację wypisywania plików");
            }
        }


        public async void Test()
        {
            Task t = null;

            try
            {

                t = ReadAndLogAsyncWithTask("C:\\testFile.txt");


                //await t;

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString()); 
            }
        }
    }
}
