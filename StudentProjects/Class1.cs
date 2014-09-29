using System.Collections.Generic;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace StudentProjects {
    public class NestedLoopsIterativeStudent {
        public int numberOfNestedLoops;
        public int numberOfIterations;
        public int[] sequenceOfValues;
        public int lastPositionInArray;

        //[Test]
        //public void DoSomething() {
        //    numberOfNestedLoops = 3;
        //    numberOfIterations = 3;
        //    lastPositionInArray = numberOfNestedLoops - 1;
        //    sequenceOfValues = new int[numberOfNestedLoops];
        //    Solve();
        //}

        [Test]
        public void Given3StudentsWhoChoose3DifferentProjectsAsTheirTopDifferentOrder_OverallRunScoreShouldBe3WhichIsPerfectFor3Students() {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
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
            Assert.AreEqual(2, students[0].ProjectWinner);
            Assert.AreEqual(1, students[1].ProjectWinner);
            Assert.AreEqual(3, students[2].ProjectWinner);

            Assert.AreEqual(15, score);
        }

        [Test]
        public void Given3StudentsAnd2ChooseTheSameTopButDifferentThird_OverallRunScoreShould() {
            var listOfStudents = new List<Student>();
            //First choice
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            //Should get second
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            //First
            var student2 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 1, ProjectChoiceC = 3, ProjectWinner = 0 };
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
            Assert.AreEqual(3, students[1].ProjectWinner);
            Assert.AreEqual(2, students[2].ProjectWinner);

            Assert.AreEqual(14, score);
        }

        [Test]
        public void Given3StudentsAnd2ChooseTheSameTopButDifferentSecond_OverallRunScoreShouldBe14ie2FirstAndASecond() {
            var listOfStudents = new List<Student>();
            //First choice
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            //First choice 
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 1, ProjectChoiceC = 3, ProjectWinner = 0 };
            //Second choice
            var student2 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
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

            Assert.AreEqual(14, score);
        }

        [Test]
        public void Given3StudentsWhoChoose3DifferentProjectsAsTheirTop_OverallRunScoreShouldBe3WhichIsPerfectFor3Students() {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student2 = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            listOfStudents.Add(student0);
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);

            numberOfNestedLoops = 3; // Students
            numberOfIterations = 3; // Projects
            lastPositionInArray = numberOfNestedLoops - 1;
            sequenceOfValues = new int[numberOfNestedLoops];

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.AreEqual(1, students[0].ProjectWinner);
            Assert.AreEqual(2, students[1].ProjectWinner);
            Assert.AreEqual(3, students[2].ProjectWinner);

            Assert.AreEqual(15, score);
        }

        [Test]
        public void Given4StudentsWhoChoose3DifferentProjectsAsTheirTop_OverallRunScoreShouldBe4WhichIsPerfectFor4Students() {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student2 = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student3 = new Student { ProjectChoiceA = 4, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            listOfStudents.Add(student0);
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);
            listOfStudents.Add(student3);

            numberOfNestedLoops = 4; // 3 students
            numberOfIterations = 4; // 4 projects
            lastPositionInArray = numberOfNestedLoops - 1;
            sequenceOfValues = new int[numberOfNestedLoops];

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.AreEqual(1, students[0].ProjectWinner);
            Assert.AreEqual(2, students[1].ProjectWinner);
            Assert.AreEqual(3, students[2].ProjectWinner);
            Assert.AreEqual(4, students[3].ProjectWinner);

            Assert.AreEqual(20, score);
        }

        [Test]
        public void Given5StudentsWhoChoose3DifferentProjectsAsTheirTop_OverallRunScoreShouldBe4WhichIsPerfectFor4Students() {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student2 = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student3 = new Student { ProjectChoiceA = 4, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student4 = new Student { ProjectChoiceA = 5, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            listOfStudents.Add(student0);
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);
            listOfStudents.Add(student3);
            listOfStudents.Add(student4);

            numberOfNestedLoops = 5; // 5 students
            numberOfIterations = 5; // 5 projects.. have to be more projects than students!
            lastPositionInArray = numberOfNestedLoops - 1;
            sequenceOfValues = new int[numberOfNestedLoops];

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.AreEqual(1, students[0].ProjectWinner);
            Assert.AreEqual(2, students[1].ProjectWinner);
            Assert.AreEqual(3, students[2].ProjectWinner);
            Assert.AreEqual(4, students[3].ProjectWinner);
            Assert.AreEqual(5, students[4].ProjectWinner);

            Assert.AreEqual(25, score);
        }

        [Test]
        public void Given3StudentsWhoChoose3DifferentProjectsAsTheirTopFromATotalOf4Projects_OverallRunScoreShouldBe() {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student2 = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            listOfStudents.Add(student0);
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);

            numberOfNestedLoops = 3; // students
            numberOfIterations = 4; // projects.. have to be more projects than students!
            lastPositionInArray = numberOfNestedLoops - 1;
            sequenceOfValues = new int[numberOfNestedLoops];

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.AreEqual(1, students[0].ProjectWinner);
            Assert.AreEqual(2, students[1].ProjectWinner);
            Assert.AreEqual(3, students[2].ProjectWinner);

            Assert.AreEqual(15, score);
        }

        [Test]
        public void Given4StudentsWhoChoose3DifferentProjectsAsTheirTopFromATotalOf6Projects_OverallRunScoreShouldBe() {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student2 = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student3 = new Student { ProjectChoiceA = 4, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            listOfStudents.Add(student0);
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);
            listOfStudents.Add(student3);

            numberOfNestedLoops = 4; // students
            numberOfIterations = 6; // projects.. have to be more projects than students!
            lastPositionInArray = numberOfNestedLoops - 1;
            sequenceOfValues = new int[numberOfNestedLoops];

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.AreEqual(1, students[0].ProjectWinner);
            Assert.AreEqual(2, students[1].ProjectWinner);
            Assert.AreEqual(3, students[2].ProjectWinner);
            Assert.AreEqual(4, students[3].ProjectWinner);

            Assert.AreEqual(20, score);
        }

        [Test]
        public void GivenManyStudentsWhoChoose3DifferentProjectsAsTheirTopFromATotalOf5Projects_OverallRunScoreShouldBe() {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student2 = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student3 = new Student { ProjectChoiceA = 4, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student4 = new Student { ProjectChoiceA = 5, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            listOfStudents.Add(student0);
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);
            listOfStudents.Add(student3);
            listOfStudents.Add(student4);

            numberOfNestedLoops = 5; // students
            numberOfIterations = 5; // projects.. have to be more projects than students!
            lastPositionInArray = numberOfNestedLoops - 1;
            sequenceOfValues = new int[numberOfNestedLoops];

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.AreEqual(1, students[0].ProjectWinner);
            Assert.AreEqual(2, students[1].ProjectWinner);
            Assert.AreEqual(3, students[2].ProjectWinner);
            Assert.AreEqual(4, students[3].ProjectWinner);
            Assert.AreEqual(5, students[4].ProjectWinner);

            Assert.AreEqual(25, score);
        }

        //[Test]
        // too many for nunit
        public void GivenManyStudentsWhoChoose3DifferentProjectsAsTheirTopFromATotalOf6Projects_OverallRunScoreShouldBe() {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student2 = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student3 = new Student { ProjectChoiceA = 4, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student4 = new Student { ProjectChoiceA = 5, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            var student5 = new Student { ProjectChoiceA = 6, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            listOfStudents.Add(student0);
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);
            listOfStudents.Add(student3);
            listOfStudents.Add(student4);
            listOfStudents.Add(student5);

            numberOfNestedLoops = 6; // students
            numberOfIterations = 6; // projects.. have to be more projects than students!
            lastPositionInArray = numberOfNestedLoops - 1;
            sequenceOfValues = new int[numberOfNestedLoops];

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.AreEqual(1, students[0].ProjectWinner);
            Assert.AreEqual(2, students[1].ProjectWinner);
            Assert.AreEqual(3, students[2].ProjectWinner);
            Assert.AreEqual(4, students[3].ProjectWinner);
            Assert.AreEqual(5, students[4].ProjectWinner);
            Assert.AreEqual(6, students[5].ProjectWinner);

            Assert.AreEqual(30, score);
        }

        public Tuple<List<Student>, int> Solve(List<Student> listOfStudents) {
            InitLoops();
            int highestScore = 0;

            // Make a projectsChoice array of 1,2,3... 
            var projectsChoice = new int[numberOfIterations];
            for (int i = 0; i < numberOfIterations; i++) {
                projectsChoice[i] = i;
            }

            while (true) {
                PrintLoops();

                // don't want any duplicates in sequenceOfValues eg want 1 2 3, 2 1 3, not 1 1 2
                var dictionary = new Dictionary<int, int>();
                foreach (int n in sequenceOfValues) {
                    if (!dictionary.ContainsKey(n))
                        dictionary[n] = 0;
                    dictionary[n]++;
                }
                bool duplicates = false;
                foreach (var pair in dictionary) {
                    if (pair.Value > 1) {
                        duplicates = true;
                    }
                }

                if (!duplicates) {
                    // get score for this permutation eg 1 2 3
                    // for each student pick a project based on loop
                    for (int i = 0; i < numberOfNestedLoops; i++) {
                        listOfStudents[i].ProjectTry = sequenceOfValues[i];
                    }

                    // get score for this permutation
                    int score = 0;
                    bool gotOne = false;
                    // loop over students and score
                    for (int i = 0; i < numberOfNestedLoops; i++) {
                        if (listOfStudents[i].ProjectTry == listOfStudents[i].ProjectChoiceA) { score += 5; gotOne = true; }
                        if (listOfStudents[i].ProjectTry == listOfStudents[i].ProjectChoiceB) { score += 4; gotOne = true; }
                        if (listOfStudents[i].ProjectTry == listOfStudents[i].ProjectChoiceC) { score += 3; gotOne = true; }
                    }
                    // is this the highest score, remember which projects
                    if (score >= highestScore && gotOne) {
                        highestScore = score;
                        for (int i = 0; i < numberOfNestedLoops; i++) {
                            listOfStudents[i].ProjectWinner = listOfStudents[i].ProjectTry;
                        }
                    }
                }

                int currentPositionInSOV = lastPositionInArray;
                sequenceOfValues[currentPositionInSOV] += 1;

                while (sequenceOfValues[currentPositionInSOV] > numberOfIterations) {
                    sequenceOfValues[currentPositionInSOV] = 1;
                    currentPositionInSOV--;

                    if (currentPositionInSOV < 0) return Tuple.Create(listOfStudents, highestScore);
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
