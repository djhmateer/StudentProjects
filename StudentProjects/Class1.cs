using System;
using System.Collections.Generic;
using Xunit;

namespace StudentProjects {

    public class Student {
        public int ProjectChoiceA { get; set; }
        public int ProjectChoiceB { get; set; }
        public int ProjectChoiceC { get; set; }
        public int ProjectWinner { get; set; }
    }

    public class Class1 {
        //recd
        //200 students
        //300 projects
        //students can choose top 5 projects
        //only 1 project per student

        //You want to find the optimal allocation of projects so most number of students are 'happy'
        //Happiness is defined as having the highest of their 'top5'

        public Tuple<List<Student>, int> Solve(List<Student> students) {
            // run through every project permutation, so we try giving all projects to all students
            // and choose the permutation with the lowest overallScore
            // each student gets a score based on:
            // ChoiceA = 1, ChoiceB = 2 etc..
            int lowestScore = 99999;

            var projects = new[] { 1, 2, 3 };
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    for (int k = 0; k < 3; k++) {
                        // only want where i != j != k
                        if (i != j && j != k && k != i) {

                            // pick a project for each student
                            var projectForStudent0 = projects[i];
                            var projectForStudent1 = projects[j];
                            var projectForStudent2 = projects[k];

                            // get score for this permutation
                            int score = 0;
                            if (projectForStudent0 == students[0].ProjectChoiceA) score += 1;
                            if (projectForStudent0 == students[0].ProjectChoiceB) score += 2;
                            if (projectForStudent0 == students[0].ProjectChoiceC) score += 3;

                            if (projectForStudent1 == students[1].ProjectChoiceA) score += 1;
                            if (projectForStudent1 == students[1].ProjectChoiceB) score += 2;
                            if (projectForStudent1 == students[1].ProjectChoiceC) score += 3;

                            if (projectForStudent2 == students[2].ProjectChoiceA) score += 1;
                            if (projectForStudent2 == students[2].ProjectChoiceB) score += 2;
                            if (projectForStudent2 == students[2].ProjectChoiceC) score += 3;

                            // is this the lowest score, remember which projects
                            if (score <= lowestScore && score >= 3) {
                                lowestScore = score;
                                students[0].ProjectWinner = projectForStudent0;
                                students[1].ProjectWinner = projectForStudent1;
                                students[2].ProjectWinner = projectForStudent2;
                            }
                        }
                    }
                }
            }
            return Tuple.Create(students, lowestScore);
        }

        [Fact]
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

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.Equal(1, students[0].ProjectWinner);
            Assert.Equal(3, students[1].ProjectWinner);
            Assert.Equal(2, students[2].ProjectWinner);

            Assert.Equal(4, score);
        }

        [Fact]
        public void Given3StudentsAnd2ChooseTheSameTopButDifferentSecond_OverallRunScoreShouldBe4ie2FirstAndASecond() {
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

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.Equal(1, students[0].ProjectWinner);
            Assert.Equal(2, students[1].ProjectWinner);
            Assert.Equal(3, students[2].ProjectWinner);

            Assert.Equal(4, score);
        }

        [Fact]
        public void Given3StudentsWhoChoose3DifferentProjectsAsTheirTopDifferentOrder_OverallRunScoreShouldBe3WhichIsPerfectFor3Students() {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            var student2 = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            listOfStudents.Add(student0);
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.Equal(2, students[0].ProjectWinner);
            Assert.Equal(1, students[1].ProjectWinner);
            Assert.Equal(3, students[2].ProjectWinner);

            Assert.Equal(3, score);
        }


        [Fact]
        public void Given3StudentsWhoChoose3DifferentProjectsAsTheirTop_OverallRunScoreShouldBe3WhichIsPerfectFor3Students() {
            var listOfStudents = new List<Student>();
            var student0 = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
            var student1 = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
            var student2 = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
            listOfStudents.Add(student0);
            listOfStudents.Add(student1);
            listOfStudents.Add(student2);

            Tuple<List<Student>, int> tuple = Solve(listOfStudents);
            int score = tuple.Item2;
            List<Student> students = tuple.Item1;
            Assert.Equal(1, students[0].ProjectWinner);
            Assert.Equal(2, students[1].ProjectWinner);
            Assert.Equal(3, students[2].ProjectWinner);

            Assert.Equal(3, score);
        }

        //[Fact]
        //public void Given3StudentsWhoChoose3DifferentProjectsAsTheirTop_ShouldAllocateThemTheirHighestProject() {
        //    var listOfStudents = new List<Student>();
        //    var studentA = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
        //    var studentB = new Student { ProjectChoiceA = 2, ProjectChoiceB = 3, ProjectChoiceC = 1, ProjectWinner = 0 };
        //    var studentC = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
        //    listOfStudents.Add(studentA);
        //    listOfStudents.Add(studentB);
        //    listOfStudents.Add(studentC);

        //    Tuple<List<Student>, int> tuple = Solve(listOfStudents);

        //    List<Student> results = tuple.Item1;
        //    Assert.Equal(1, results[0].ProjectWinner);
        //    Assert.Equal(2, results[1].ProjectWinner);
        //    Assert.Equal(3, results[2].ProjectWinner);
        //}

        //[Fact]
        //public void Given2StudentsWhoChooseTheSameTop_ShouldLookAtChoiceB_() {
        //    var listOfStudents = new List<Student>();
        //    // StudentA should get project2
        //    var studentA = new Student { ProjectChoiceA = 1, ProjectChoiceB = 2, ProjectChoiceC = 3, ProjectWinner = 0 };
        //    // This student should get 1, as then studentC can get project3
        //    var studentB = new Student { ProjectChoiceA = 1, ProjectChoiceB = 3, ProjectChoiceC = 2, ProjectWinner = 0 };
        //    var studentC = new Student { ProjectChoiceA = 3, ProjectChoiceB = 1, ProjectChoiceC = 2, ProjectWinner = 0 };
        //    listOfStudents.Add(studentA);
        //    listOfStudents.Add(studentB);
        //    listOfStudents.Add(studentC);

        //    var results = Solve(listOfStudents);

        //    Assert.Equal(2, results[0].ProjectWinner);
        //    Assert.Equal(1, results[1].ProjectWinner);
        //    Assert.Equal(3, results[2].ProjectWinner);
        //}
    }
}
