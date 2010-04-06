using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace V3.Expressions
{
    public interface ICalculator
    {
        int Plus(int x, int y);

        int Divide(int x, int y);

        string Name { get; }
    }

    public static class MockObjects
    {
        public static void TestWithMocks()
        {
            var mockCalculator = new Mock<ICalculator>();
            mockCalculator.Setup(c => c.Name).Returns("Mock Calculator");
            mockCalculator.Setup(c => c.Plus(1, 2)).Returns(3);
            mockCalculator.Setup(c => c.Plus(2, 4)).Returns(6);
            mockCalculator.Setup(c => c.Divide(0, It.IsAny<int>())).Returns(0);
            mockCalculator.Setup(c => c.Divide(0, It.Is<int>(i => i % 3 == 1))).Returns(0);

            var calculator = mockCalculator.Object;
        }
    }
}
