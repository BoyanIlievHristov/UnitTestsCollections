using Collections;
using System.Data;

namespace Collection.UnitTests
{
    public class CollectionTests
    {
        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            var coll = new Collection<int>();
            Assert.AreEqual(coll.ToString(), "[]");
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var num = new Collection<int>(77);
            var actual = num.ToString();
            var expected = "[77]";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var num = new Collection<int>(10, 50, 88);
            var actual = num.ToString();
            var expected = "[10, 50, 88]";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var coll = new Collection<int>(5, 6);

            Assert.AreEqual(coll.Count, 2);
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count));
        }

        [Test]
        public void Test_Collection_Insert()
        {
            var coll = new Collection<int>(10, 50, 88);
            coll.InsertAt(1, 666);
            var actual = coll.ToString();
            var expected = "[10, 666, 50, 88]";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_Add()
        {
            var nums = new Collection<int>(3);
            nums.Add(1);
            nums.Add(2);
            var actual = nums.ToString();
            var expected = "[3, 1, 2]";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var coll = new Collection<int>(3, 4, 5);
            var item = coll[0];
            var actual = item.ToString();
            var expected = "3";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_Exchange()
        {
            var coll = new Collection<int>(3, 4, 5);
            coll.Exchange(0, 2);
            var actual = coll.ToString();
            var expected = "[5, 4, 3]";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_RemoveByIndex()
        {
            var coll = new Collection<int>(3, 4, 5);
            coll.RemoveAt(1);
            var actual = coll.ToString();
            var expected = "[3, 5]";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var coll = new Collection<int>(3, 4, 5);
            coll[0] = 69;
            var actual = coll.ToString();
            var expected = "[69, 4, 5]";

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var coll = new Collection<int>(3, 4, 5);
            Assert.That(() => { var item = coll[3]; }, 
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var coll = new Collection<int>();
            for (int i = 0; i <= 10; i++)
            {
                coll.Add(i);
            }
            var expected = "[0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]";
            var actual = coll.ToString();
            Assert.AreEqual(expected, actual);           
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var coll = new Collection<int>(3, 4, 5);
            coll.Clear();
            var actual = coll.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_Collection_AddRange()
        {
            var coll = new Collection<int>(3, 4, 5);
            coll.AddRange(6, 7, 8);

            Assert.That(coll.ToString, Is.EqualTo("[3, 4, 5, 6, 7, 8]") );
        }
    }
}