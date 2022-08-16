using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currStudent = Console.ReadLine()
                    .Split();
                string studentName = currStudent[0];
                decimal studentGrade = decimal.Parse(currStudent[1]);

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<decimal>());
                }

                students[studentName].Add(studentGrade);
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {PrintStudentGrades(student.Value)}(avg: {student.Value.Average():f2})");
            }
        }

        static string PrintStudentGrades(List<decimal> grades)
        {
            StringBuilder gradesSb = new StringBuilder();

            foreach (var grade in grades)
            {
                gradesSb.Append($"{grade:f2} ");
            }

            return gradesSb.ToString();
        }
    }
}
