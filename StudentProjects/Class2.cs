using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentProjects2 {
    public class Class2 {
        //200 students
        //300 projects
        //students can choose top 5 projects
        //only 1 project per student

        //You want to find the optimal allocation of projects so most number of students are 'happy'
        //Happiness is defined as having the highest of their 'top5'

        //Look at student’s first choices, assigning to them ones which no other student has requested
        //Go through remaining first choices which more than 1 student has requested
        //Look at second choices and assign to them ones which no other student has asked for
        //Go through remaining second choices which more than 1 student has requested
        //Look at third choices and assign to them ones which no other student has requested 
        //etc..

        [Test]
        public void Given3StudentsWithAllDifferentProjectRequests_And3DProjects_AssignProjects() {
            var studentA = new Student { ChoiceA = 1, ChoiceB = 2, ChoiceC = 3 };
            var studentB = new Student { ChoiceA = 2, ChoiceB = 3, ChoiceC = 1 };
            var studentC = new Student { ChoiceA = 3, ChoiceB = 1, ChoiceC = 2 };
            var students = new List<Student> { studentA, studentB, studentC };
            var projects = new List<int> { 1, 2, 3 };

            var result = FilterUniqueChoiceAs(students, projects);
            students = result.Item1;
            Assert.AreEqual(1, students[0].AssignedProject);
            Assert.AreEqual(2, students[1].AssignedProject);
            Assert.AreEqual(3, students[2].AssignedProject);
        }

        [Test]
        public void Given2StudentsWithAllDifferentProjectRequests_And3DProjects_ShouldAssignAndHave1LeftOverProject() {
            var studentA = new Student { ChoiceA = 1, ChoiceB = 2, ChoiceC = 3 };
            var studentB = new Student { ChoiceA = 2, ChoiceB = 3, ChoiceC = 1 };
            var students = new List<Student> { studentA, studentB };
            var projects = new List<int> { 1, 2, 3 };

            var result = FilterUniqueChoiceAs(students, projects);
            students = result.Item1;
            projects = result.Item2;
            Assert.AreEqual(1, students[0].AssignedProject);
            Assert.AreEqual(2, students[1].AssignedProject);

            Assert.AreEqual(3, projects[0]);
        }

        [Test]
        public void Given3StudentsWithAllDifferentChoiceB_And3DProjects_ShouldAssign() {
            var studentA = new Student { ChoiceA = 2, ChoiceB = 1, ChoiceC = 3 };
            var studentB = new Student { ChoiceA = 2, ChoiceB = 2, ChoiceC = 1 };
            var studentC = new Student { ChoiceA = 2, ChoiceB = 3, ChoiceC = 1 };
            var students = new List<Student> { studentA, studentB, studentC };
            var projects = new List<int> { 1, 2, 3 };

            var result = FilterUniqueChoiceAs(students, projects);
            result = FilterUniqueChoiceBs(students, projects);
            students = result.Item1;
            projects = result.Item2;
            Assert.AreEqual(1, students[0].AssignedProject);
            Assert.AreEqual(2, students[1].AssignedProject);
            Assert.AreEqual(3, students[2].AssignedProject);
        }

        public Tuple<List<Student>, List<int>> FilterUniqueChoiceAs(List<Student> students, List<int> projects) {
            foreach (var student in students) {
                if (IsUniqueChoiceA(student.ChoiceA, students)) {
                    student.AssignedProject = student.ChoiceA;
                    student.Message = String.Format("Assigned project {0} because no other Students wanted this as ChoiceA", student.ChoiceA);
                }
                projects.Remove(student.ChoiceA);
            }
            return Tuple.Create(students, projects);
        }

        public Tuple<List<Student>, List<int>> FilterUniqueChoiceBs(List<Student> students, List<int> projects) {
            foreach (var student in students) {
                if (IsUniqueChoiceB(student.ChoiceB, students)) {
                    student.AssignedProject = student.ChoiceB;
                    student.Message = String.Format("Assigned project {0} because no other Students wanted this as ChoiceB", student.ChoiceB);
                }
                projects.Remove(student.ChoiceB);
            }
            return Tuple.Create(students, projects);
        }

        public bool IsUniqueChoiceA(int choiceA, List<Student> students) {
            {
                var x = students.Count(y => y.ChoiceA == choiceA);
                if (x > 1) return false;
                return true;
            }
        }

        public bool IsUniqueChoiceB(int choiceB, List<Student> students) {
            {
                var x = students.Count(y => y.ChoiceB == choiceB);
                if (x > 1) return false;
                return true;
            }
        }
    }

    public class Student {
        public int Name { get; set; }
        public int ChoiceA { get; set; }
        public int ChoiceB { get; set; }
        public int ChoiceC { get; set; }
        public int AssignedProject { get; set; }
        public string Message { get; set; }
    }
}
