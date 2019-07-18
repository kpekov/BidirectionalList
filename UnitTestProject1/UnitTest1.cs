using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BidirectionalList;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Node_Data_field_serialization_and_deserialization_check()
        {
            ListRandom list1 = ListRandom.GenerateRandomList();

            Random rnd = new Random();

            int randomNodeIndex = rnd.Next(1, list1.Count + 1);

            ListNode n = list1.Head;

            for (int i = 1; i < randomNodeIndex; i++)
                n = n.Next;

            string dataBeforeSerialization = n.Data;

            var fs = new FileStream("test.blf", FileMode.Create);
            list1.Serialize(fs);

            var fs2 = new FileStream("test.blf", FileMode.Open);
            ListRandom list2 = new ListRandom();
            list2.Deserialize(fs2);

            n = list2.Head;

            for (int i = 1; i < randomNodeIndex; i++)
                n = n.Next;

            string dataAfterSerialization = n.Data;

            Assert.AreEqual(dataBeforeSerialization, dataAfterSerialization);
        }

        [TestMethod]
        public void Node_Random_Data_field_serialization_and_deserialization_check()
        {
            ListRandom list1 = ListRandom.GenerateRandomList();

            Random rnd = new Random();

            int randomNodeIndex = rnd.Next(1, list1.Count + 1);

            ListNode n = list1.Head;

            for (int i = 1; i < randomNodeIndex; i++)
                n = n.Next;

            string dataBeforeSerialization = n.Random.Data;

            var fs = new FileStream("test.blf", FileMode.Create);
            list1.Serialize(fs);

            var fs2 = new FileStream("test.blf", FileMode.Open);
            ListRandom list2 = new ListRandom();
            list2.Deserialize(fs2);

            n = list2.Head;

            for (int i = 1; i < randomNodeIndex; i++)
                n = n.Next;

            string dataAfterSerialization = n.Random.Data;

            Assert.AreEqual(dataBeforeSerialization, dataAfterSerialization);
        }
    }
}
