using Xunit;

namespace StudentProjects {
    public class Class2 {
        [Fact]
        public void DoSomething() {
            int total = Recursive(5);
            Assert.Equal(10, total);
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
