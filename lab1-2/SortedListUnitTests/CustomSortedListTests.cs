using SortedList;
using Xunit;
namespace SortedListUnitTests
{
    public class CustomSortedListTests
    {
        [Fact]
        public void Test_Add_Int()
        {

            int atIndex2Expected = 22;

            CustomSortedList<int> sortedList = new CustomSortedList<int>();
            sortedList.Add(122);
            sortedList.Add(1);
            sortedList.Add(22);
            sortedList.Add(7);
            sortedList.Add(121);
            sortedList.Add(123);
            sortedList.Add(124);
            sortedList.Add(125);
            sortedList.Add(126);
            sortedList.Add(127);
            sortedList.Add(128);

            int atIndex2Actual = sortedList[2];
            Assert.Equal(atIndex2Expected, atIndex2Actual);
        }

        [Fact]
        public void Test_Add_String()
        {

            string atIndex2Expected = "22";

            CustomSortedList<string> sortedList = new CustomSortedList<string>();
            sortedList.Add("122");
            sortedList.Add("1");
            sortedList.Add("22");
            sortedList.Add("7");

            string atIndex2Actual = sortedList[2];
            Assert.Equal(atIndex2Expected, atIndex2Actual);

        }
        [Fact]
        public void Test_Contains()
        {
            bool expected1 = true;
            bool expected2 = false;

            CustomSortedList<string> sortedList1 = new CustomSortedList<string>();
            sortedList1.Add("122");
            sortedList1.Add("1");
            sortedList1.Add("22");
            sortedList1.Add("33");

            bool actual1 = sortedList1.Contains("22");

            sortedList1.Delete("33");
            bool actual2 = sortedList1.Contains("33");

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }
        [Fact]
        public void Test_Delete()
        {
            bool expectedContain1 = false;
            bool expectedContain13 = true;
            bool expectedContain22 = true;
            bool expectedContain44 = false;
            bool expectedContain55 = true;

            CustomSortedList<int> sortedList1 = new CustomSortedList<int>();

            sortedList1.Add(22);
            sortedList1.Add(13);
            sortedList1.Add(1);
            sortedList1.Add(44);
            sortedList1.Add(55);

            sortedList1.Delete(1);
            sortedList1.Delete(44);

            bool actualContain1 = sortedList1.Contains(1);
            bool actualContain13 = sortedList1.Contains(13);
            bool actualContain22 = sortedList1.Contains(22);
            bool actualContain44 = sortedList1.Contains(44);
            bool actualContain55 = sortedList1.Contains(55);

            Assert.Equal(expectedContain1, actualContain1);
            Assert.Equal(expectedContain13, actualContain13);
            Assert.Equal(expectedContain22, actualContain22);
            Assert.Equal(expectedContain44, actualContain44);
            Assert.Equal(expectedContain55, actualContain55);


        }
        [Fact]
        public void Test_DeleteAt()
        {
            bool expectedContain1 = false;
            bool expectedContain13 = true;
            bool expectedContain22 = true;
            bool expectedContain44 = false;
            bool expectedContain55 = true;

            CustomSortedList<int> sortedList1 = new CustomSortedList<int>();

            sortedList1.Add(22);
            sortedList1.Add(13);
            sortedList1.Add(1);
            sortedList1.Add(44);
            sortedList1.Add(55);

            sortedList1.DeleteAt(0);
            sortedList1.DeleteAt(2);

            bool actualContain1 = sortedList1.Contains(1);
            bool actualContain13 = sortedList1.Contains(13);
            bool actualContain22 = sortedList1.Contains(22);
            bool actualContain44 = sortedList1.Contains(44);
            bool actualContain55 = sortedList1.Contains(55);

            Assert.Equal(expectedContain1, actualContain1);
            Assert.Equal(expectedContain13, actualContain13);
            Assert.Equal(expectedContain22, actualContain22);
            Assert.Equal(expectedContain44, actualContain44);
            Assert.Equal(expectedContain55, actualContain55);


        }
        [Fact]
        public void Test_Compare()
        {

            int expected1 = 1;
            int expected2 = -1;
            int expected3 = 0;

            CustomSortedList<string> sortedList1 = new CustomSortedList<string>();
            sortedList1.Add("122");
            sortedList1.Add("1");
            sortedList1.Add("22");
            sortedList1.Add("33");

            CustomSortedList<string> sortedList2 = new CustomSortedList<string>();
            sortedList2.Add("122");
            sortedList2.Add("1");
            sortedList2.Add("22");
            sortedList2.Add("7");

            int actual1 = sortedList2.CompareTo(sortedList1);
            int actual2 = sortedList1.CompareTo(sortedList2);

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);

            sortedList2.Delete("7");
            sortedList1.Delete("33");

            int actual3 = sortedList1.CompareTo(sortedList2);

            Assert.Equal(expected3, actual3);
        }
        [Fact]
        public void Test_Clear()
        {

            int expected1 = 1;
            int expected2 = 0;
            CustomSortedList<string> sortedList1 = new CustomSortedList<string>();
            sortedList1.Add("122");
            sortedList1.Add("1");
            sortedList1.Add("22");
            sortedList1.Add("33");

            CustomSortedList<string> sortedList2 = new CustomSortedList<string>();


            int actual1 = sortedList2.CompareTo(sortedList1);

            Assert.Equal(expected1, actual1);


            sortedList1.Clear();
            int actual2 = sortedList2.CompareTo(sortedList1);
            Assert.Equal(expected2, actual2);


        }
    }
}
