using System.Diagnostics;
using StudentProjects;
using System;
using System.Collections.Generic;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student2 = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student3 = new Student { ProjectChoiceA = 4, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student4 = new Student { ProjectChoiceA = 5, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student5 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 6, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student6 = new Student { ProjectChoiceA = 7, ProjectChoiceB = 2, ProjectChoiceC = 2, ProjectWinner = 0 };
            listOfStudents.Add(student0);
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);
            listOfStudents.Add(student3);
            listOfStudents.Add(student4);
            listOfStudents.Add(student5);
            listOfStudents.Add(student6);

            var solver = new NestedLoopsIterativeStudent();
            solver.numberOfNestedLoops = 7; // students
            solver.numberOfIterations = 7; // projects.. have to be more projects than students!
            solver.lastPositionInArray = solver.numberOfNestedLoops - 1;
            solver.sequenceOfValues = new int[solver.numberOfNestedLoops];

            var sw = new Stopwatch();
        
            sw.Start();
            Tuple<List<Student>, int> tuple = solver.Solve(listOfStudents);
            sw.Stop();

            int score = tuple.Item2;
            List<Student> students = tuple.Item1;

            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            Console.WriteLine("score: {0}", score);
            foreach (var student in students) {
                Console.WriteLine(student.ProjectWinner);
            }
            Console.ReadLine();
        }
    }
}
