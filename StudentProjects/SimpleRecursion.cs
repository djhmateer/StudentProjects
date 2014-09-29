
using NUnit.Framework;

namespace StudentProjects {
    public class SimpleRecursion {
        public void DoSomething() {
            int total = Recursive(5);
            Assert.AreEqual(10, total);
        }

        public int Recursive(int value) {
            if (value >= 10) {
                return value;
            }
            value++;
            //passes valueToReturn back 5 times from the output of 5 different calls to Recursive
            int valueToReturn = Recursive(value);
            return valueToReturn;
        }
    }
}
