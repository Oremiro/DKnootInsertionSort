using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = PrepareData();
            var sorters = new List<ISorter>()
            {
                new BubbleSorter(),
                new InsertionSorter(),
                new QSorter()
            };
            foreach (var sorter in sorters)
            {
                RunSort(sorter.GetType().Name.ToString(), sorter, data);
            }
        }

        private static int[] PrepareData()
        {
            var directory = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current dir := {directory}");
            string[] lines = File.ReadLines($"{directory}/input.txt").ToArray();
            Console.WriteLine("Input array:");
            List<int> resultList = new List<int>();
            foreach (var line in lines)
            {
                Console.Write(line + " ");
                resultList.AddRange(line.Split(" ").Select(r => Convert.ToInt32(r)));
            }
            var result = resultList.ToArray();
            return result;
        }

        private static void RunSort(string sortName, ISorter sort, int[] data)
        {
            var directory = Directory.GetCurrentDirectory();
            var dtStart = DateTime.Now;
            var sortedData = sort.Sort(data);
            var dtEnd = DateTime.Now;
            string[] lines = sortedData.Select(i => i.ToString()).ToArray();
            File.WriteAllLines($"{directory}/{sortName}_output.txt", lines);
            var time = dtEnd - dtStart;
            Console.WriteLine($"[{sortName}] Time := {time}; Data saved in file {sortName}_output.txt");
        }
    }
}