using System;
using System.Diagnostics;
using NUnit.Framework;

namespace StudentProjects {

    public class RecursiveNestedLoops {
        int numberOfNestedLoops; // N - number of nested for sequenceOfValues
        int numberOfIterations; // K - for 1..K
        int[] sequenceOfValues;

        [Test]
        public void DoSomething() {
            numberOfNestedLoops = 3;
            numberOfIterations = 2;
            sequenceOfValues = new int[numberOfNestedLoops];
            NestedLoops(0);
        }

        public void NestedLoops(int currentLoop) {
            // Got to the bottom of the recursion, print and return
            if (currentLoop == numberOfNestedLoops) {
                PrintLoops();
                return;
            }

            // Setup an iteration from 1..K in this nestedloop 
            for (int counter = 1; counter <= numberOfIterations; counter++) {
                sequenceOfValues[currentLoop] = counter;
                NestedLoops(currentLoop + 1);
            }
        }

        public void PrintLoops() {
            var message = "";
            for (int i = 0; i < numberOfNestedLoops; i++) {
                message += String.Format("{0} ", sequenceOfValues[i]);
            }
            Debug.WriteLine(message);
        }
    }

    public class NestedLoops {
        [Test]
        public void DoSomething() {
            for (int i = 1; i < 3; i++) {
                for (int j = 1; j < 3; j++) {
                    for (int k = 1; k < 3; k++) {
                        Debug.WriteLine(i.ToString() + j.ToString() + k.ToString());
                    }
                }
            }
        }
    }

    public class NestedLoopsIterative {
        int numberOfNestedLoops;
        int numberOfIterations;
        int[] sequenceOfValues;

        [Test]
        public void DoSomething() {
            numberOfNestedLoops = 3;
            numberOfIterations = 2;
            sequenceOfValues = new int[numberOfNestedLoops];
            NestedLoops();
        }

        public void NestedLoops() {
            InitLoops();

            while (true) {
                PrintLoops();

                int currentPositionInSOV = numberOfNestedLoops - 1;
                sequenceOfValues[currentPositionInSOV] = sequenceOfValues[currentPositionInSOV] + 1;

                while (sequenceOfValues[currentPositionInSOV] > numberOfIterations) {
                    sequenceOfValues[currentPositionInSOV] = 1;
                    currentPositionInSOV--;

                    if (currentPositionInSOV < 0) return;

                    sequenceOfValues[currentPositionInSOV] = sequenceOfValues[currentPositionInSOV] + 1;
                }
            }
        }

        public void InitLoops() {
            for (int i = 0; i < numberOfNestedLoops; i++) {
                sequenceOfValues[i] = 1;
            }
        }

        public void PrintLoops() {
            var message = "";
            for (int i = 0; i < numberOfNestedLoops; i++) {
                message += String.Format("{0} ", sequenceOfValues[i]);
            }
            Debug.WriteLine(message);
        }
    }
}
