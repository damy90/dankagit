using System;
using System.Collections.Generic;

//* Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).
class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 3, -2, 1, 5, 23 };
        //вкарвам стойносите за сортиране:

        List<int> result = MergeSort(list);
        //отпечатвам резултата:
        foreach (int i in result)
            Console.WriteLine(i);
    }
    static List<int> MergeSort(List<int> list)
    {
        if (list.Count < 2)
            return list;//прекъсване на рекурсията, няма нужда да се сортира 1 елемент - връщаме list непроменен
        List<int> left = MergeSort( list.GetRange( 0, list.Count/2 ) );//сортирам лявата половина на списъка
        List<int> right = MergeSort( list.GetRange( left.Count, list.Count - left.Count ) );//сортирам дясната половина на списъка
        List<int> result = new List<int>();
        //left и right са сортирани, обединявам двата списъка в result:
        while (left.Count > 0 && right.Count > 0)//докато някой от двата списъка не се изпразни...
        {
            //...сравнявам първите елементи от двата списъка, премествам по-малкия в result
            if (left[0]<=right[0])
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
            else
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
        }
        //ако някой от двата списъка все още не е празен (поне 1 от тях е празен) - добавям го в result
        result.AddRange(left);
        result.AddRange(right);
        return result;
    }
}