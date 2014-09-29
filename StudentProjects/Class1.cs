using System.Collections.Generic;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace StudentProjects {
    public class NestedLoopsIterativeStudent {
        int numberOfNestedLoops;
        int numberOfIterations;
        int[] sequenceOfValues;
        int lastPositionInArray;

        //[Test]
        //public void DoSomething() {
        //    numberOfNestedLoops = 3;
        //    numberOfIterations = 3;
        //    lastPositionInArray = numberOfNestedLoops - 1;
        //    sequenceOfValues = new int[numberOfNestedLoops];
        //    Solve();
        //}

        [Test]
        public void Given3StudentsWhoChoose3DifferentProjectsAsTheirTop_OverallRunScoreShouldBe3WhichIsPerfectFor3Students() {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student2 = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            listOfStudents.Add(student0);
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);

            numberOfNestedLoops = 3;
            numberOfIterations = 3;
            lastPositionInArray = numberOfNestedLoops - 1;
            sequenceOfValues = new int[numberOfNestedLoops];

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.AreEqual(1, students[0].ProjectWinner);
            Assert.AreEqual(2, students[1].ProjectWinner);
            Assert.AreEqual(3, students[2].ProjectWinner);

            Assert.AreEqual(3, score);
        }

        public Tuple<List<Student>, int> Solve(List<Student> listOfStudents) {
            InitLoops();
            int lowestScore = 99999;
            while (true) {
                PrintLoops();

                // get score for this permutation eg 1 2 3
                // pick a project for each student
                var projectForStudent0 = sequenceOfValues[0];
                var projectForStudent1 = sequenceOfValues[1];
                var projectForStudent2 = sequenceOfValues[2];

                if (projectForStudent0 != projectForStudent1 &&
                    projectForStudent1 != projectForStudent2 &&
                    projectForStudent2 != projectForStudent0)
                {
                    // get score for this permutation
                    int score = 0;
                    if (projectForStudent0 == listOfStudents[0].ProjectChoiceA) score += 1;
                    if (projectForStudent0 == listOfStudents[0].ProjectChoiceB) score += 2;
                    if (projectForStudent0 == listOfStudents[0].ProjectChoiceC) score += 3;

                    if (projectForStudent1 == listOfStudents[1].ProjectChoiceA) score += 1;
                    if (projectForStudent1 == listOfStudents[1].ProjectChoiceB) score += 2;
                    if (projectForStudent1 == listOfStudents[1].ProjectChoiceC) score += 3;

                    if (projectForStudent2 == listOfStudents[2].ProjectChoiceA) score += 1;
                    if (projectForStudent2 == listOfStudents[2].ProjectChoiceB) score += 2;
                    if (projectForStudent2 == listOfStudents[2].ProjectChoiceC) score += 3;

                    // is this the lowest score, remember which projects
                    if (score <= lowestScore && score >= 3) {
                        lowestScore = score;
                        listOfStudents[0].ProjectWinner = projectForStudent0;
                        listOfStudents[1].ProjectWinner = projectForStudent1;
                        listOfStudents[2].ProjectWinner = projectForStudent2;
                    }
                }
               
                int currentPositionInSOV = lastPositionInArray;
                sequenceOfValues[currentPositionInSOV] += 1;

                while (sequenceOfValues[currentPositionInSOV] > numberOfIterations) {
                    sequenceOfValues[currentPositionInSOV] = 1;
                    currentPositionInSOV--;

                    if (currentPositionInSOV < 0) return Tuple.Create(listOfStudents, lowestScore);
                    sequenceOfValues[currentPositionInSOV] += 1;
                }
            }
        }

        public void PrintLoops() {
            var message = "";
            for (int i = 0; i < numberOfNestedLoops; i++) {
                message += String.Format("{0} ", sequenceOfValues[i]);
            }
            Debug.WriteLine(message);
        }

        public void InitLoops() {
            for (int i = 0; i < numberOfNestedLoops; i++) {
                sequenceOfValues[i] = 1;
            }
        }
    }
}
