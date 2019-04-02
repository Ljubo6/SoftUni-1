using NUnit.Framework;
using System;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class CustomLinkedListTests
    {
        private DynamicList<int> list;
        private int elementsCount = 100;

        [SetUp]
        public void SetUp()
        {
            this.list = new DynamicList<int>();
            for (int i = 0; i < elementsCount; i++)
            {
                this.list.Add(i);
            }
        }

        [Test]
        public void AddMethod_ShouldReturnCorrectCount()
        {
            int actualCount = list.Count;
            Assert.AreEqual(elementsCount, actualCount, 
                "Count of all elements in list is incorrect!");
        }

        [Test]
        public void AddMethod_ShouldAddToEndOfList()
        {
            int expected = 99;
            int actual = list[elementsCount - 1];

            Assert.AreEqual(expected, actual, 
                "The list only adds to the end of it. The element on last index is not the same as expected!");
        }

        [Test]
        public void RemoveMethod_ShouldDecreaseCount()
        {
            this.list.Remove(99);
            Assert.AreEqual(99, this.list.Count, 
                "Remove method does not work correctly. Count is incorrect!");
        }

        [Test]
        public void RemoveMethod_ShouldReturnCorrectIndex()
        {
            int index = this.list.Remove(99);
            Assert.AreEqual(99, index, 
                "Remove method does not return correct index of the element being removed!");
        }

        [Test]
        public void RemoveAtMethod_ShouldDecreaseCount()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.RemoveAt(i);
            }

            var expectedCount = 90;
            var actualCount = this.list.Count;
            Assert.AreEqual(expectedCount, actualCount, 
                "Removing at specified index returns wrong count of elements left in the list!");
        }

        [Test]
        public void RemoveAtMethod_ShouldReturnCorrectDeletedElement()
        {
            for (int i = 0; i < 10; i++)
            {
                int deletedElement = this.list.RemoveAt(0);
                Assert.AreEqual(i, deletedElement, "Deleted and returned elements are not equal!");
            }
        }

        [Test]
        [TestCase(-1)]
        [TestCase(100)]
        public void RemoveAtMethod_ShouldThrowExceptionWithInvalidIndex(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.list.RemoveAt(index), 
                "The method removes an element at non-present index!");
        }

        [Test]
        public void ContainsMethod_ShouldReturnTrueWithPresentElements()
        {
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int element = random.Next(elementsCount);
                Assert.IsTrue(this.list.Contains(element), 
                    "The method does not find element which is present in the list!");
            }
        }

        [Test]
        public void ContainsMethod_ShouldReturnFalseWithNonPresentElements()
        {
            Assert.IsFalse(this.list.Contains(100), 
                "The method finds element which is not present in the list!");
        }

        [Test]
        public void IndexOfMethod_ShouldFindCorrectElement()
        {
            var random = new Random();

            for (int i = 0; i < elementsCount; i++)
            {
                int elementIndex = random.Next(elementsCount);
                var actual = this.list.IndexOf(elementIndex);
                Assert.AreEqual(elementIndex, actual, 
                    "The method does not return the correct element at given index!");
            }
        }

        [Test]
        public void GetValueOfIndex_ShouldReturnCorrectElementWhenIndexInRange()
        {
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var randomIndex = random.Next(elementsCount);

                Assert.AreEqual(randomIndex, this.list[randomIndex], 
                    "Element at given index is wrong!");
            }
        }

        [Test]
        [TestCase(-1)]
        [TestCase(100)]
        public void GetValueOfIndex_ShouldThrowExceptionWithInvalidIndex(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { int element = this.list[index]; }, 
                "The method returns element at non-present index!");
        }

        [Test]
        public void SetValueOfIndex_ShouldReturnCorrectElementWhenIndexInRange()
        {
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var randomIndex = random.Next(elementsCount);
                this.list[randomIndex] = 0;

                var actual = this.list[randomIndex];

                Assert.AreEqual(0, actual, 
                    "Element is not set correctly at given index!");
            }
        }

        [Test]
        [TestCase(-1)]
        [TestCase(100)]
        public void SetValueOfIndex_ShouldThrowExceptionWithInvalidIndex(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { this.list[index] = 0; }, 
                "The method sets element value at non-present index!");
        }
    }
}
