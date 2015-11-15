using System;
using TreeLibrary;
using System.Diagnostics;
using NUnit.Framework;
using System.Collections.Generic;

namespace TreeTest
{
    [TestFixture]
    public class NUnitTestTreeNode
    {
        [TestCase(new int[] { 6, 2, 0, 8, 7, 4, 3, 9, 5},  Result="620435879")]
        [TestCase(new int[] { 5, 3, 1, 7, 9, 8, 2}, Result = "5312798")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5}, Result = "012345")]
        [TestCase(new int[] { 5, 4, 3, 2, 1, 0}, Result = "543210")]
        public static string TreePreorderBypassTest(int[] array)
        {
            string s = "";

            Tree<int> tree = new Tree<int>();

            foreach (int a in array)
                tree.AddNode(a);

            foreach (int a in tree.PreorderIterator())
                s += a;

            Debug.WriteLine(s);

            return s;
        }

        [TestCase(new int[] { 6, 2, 0, 8, 7, 4, 3, 9, 5 }, Result = "035427986")]
        [TestCase(new int[] { 5, 3, 1, 7, 9, 8, 2 }, Result = "2138975")]
        public static string TreePostorderIteratorTest(int[] array)
        {
            string s = "";

            Tree<int> tree = new Tree<int>(array[0]);

            for (int a = 1; a < array.Length; a++)
                tree.AddNode(array[a]);

            foreach (int a in tree.PostorderIterator())
                s += a;

            Debug.WriteLine(s);

            return s;
        }
        
        [TestCase(new int[] { 6, 2, 0, 8, 7, 4, 3, 9, 5 }, Result = "023456789")]
        [TestCase(new int[] { 5, 3, 1, 7, 9, 8, 2 }, Result = "1235789")]
        public static string TreeInorderIteratorTest(int[] array)
        {
            string s = "";

            Tree<int> tree = new Tree<int>();

            foreach(var a in array)
                tree.AddNode(a);

            foreach (int a in tree.InorderIterator())
                s += a;

            Debug.WriteLine(s);

            return s;
        }

        [TestCase(new int[] { 1000, 500, 350, 10110, 20, 1, 1001}, Result = "1000500201350101101001")]
        [TestCase(new int[] { 500, 40, 5, 37, 1000, 10000 }, Result = "50040537100010000")]
        public static string TreePreorderBypass_NewCompareInt_Test(int[] array)
        {
            string s = "";

            Tree<int> tree = new Tree<int>(new CompareInt());

            foreach (int a in array)
                tree.AddNode(a);

            foreach (int a in tree.PreorderIterator())
                s += a;

            Debug.WriteLine(s);

            return s;
        }

        [Test]
        public void TreePreorderBypass_NewCompareString_Test()
        {
            string s = "";
            string[] array = new string[] { "500", "40", "5", "37", "1000", "10000" };

            Tree<string> tree = new Tree<string>(new CompareString());

            foreach (var a in array)
                tree.AddNode(a);

            foreach (var a in tree.PreorderIterator())
                s += a;

            Assert.AreEqual(s, "50040537100010000");
        }

        [Test]
        public void TreePreorderBypassString_Test()
        {
            string s = "";
            string[] array = new string[] { "500", "40", "5", "37", "1000", "10000" };

            Tree<string> tree = new Tree<string>();

            foreach (var a in array)
                tree.AddNode(a);

            foreach (var a in tree.PreorderIterator())
                s += a;

            Assert.AreEqual(s, "50040371000100005");
        }
        
        [Test]
        public void TreeInorderBypassBook_Test()
        {
            string s = "";
            Tree<Book> tree = new Tree<Book>();
            tree.AddNode(new Book() { Author = "Лев Толстой", Title = "Война и мир", Genre = "Роман", Year = 1869 });
            tree.AddNode(new Book() { Author = "Алан Александр Милн", Title = "Вини-Пух", Genre = "Детский рассказ", Year = 1926 });
            tree.AddNode(new Book() { Author = "Мари Шелли", Title = "Франкенштейн", Genre = "Научная фантастика", Year = 1818 });
            tree.AddNode(new Book() { Author = "Михаил Булгаков", Title = "Мастер и Маргарита", Genre = "Роман", Year = 1966 });
            tree.AddNode(new Book() { Author = "Федор Достоевский", Title = "Преступление и наказание", Genre = "Роман", Year = 1866 });
            
            foreach (var a in tree.InorderIterator())
                s += a.Title;

            Assert.AreEqual(s, "Вини-ПухВойна и мирМастер и МаргаритаПреступление и наказаниеФранкенштейн");
        }
        
        [Test]
        public void TreeInorderBypassBook_NewComparer_Test()
        {
            string s = "";
            Tree<Book> tree = new Tree<Book>(new CompareBook());
            
            tree.AddNode(new Book() { Author = "Лев Толстой", Title = "Война и мир", Genre = "Роман", Year = 1869 });
            tree.AddNode(new Book() { Author = "Алан Александр Милн", Title = "Вини-Пух", Genre = "Детский рассказ", Year = 1926 });
            tree.AddNode(new Book() { Author = "Мари Шелли", Title = "Франкенштейн", Genre = "Научная фантастика", Year = 1818 });
            tree.AddNode(new Book() { Author = "Михаил Булгаков", Title = "Мастер и Маргарита", Genre = "Роман", Year = 1966 });
            tree.AddNode(new Book() { Author = "Федор Достоевский", Title = "Преступление и наказание", Genre = "Роман", Year = 1866 });

            foreach (var a in tree.InorderIterator())
                s += a.Title;

            Assert.AreEqual(s, "Вини-ПухВойна и мирФранкенштейнМастер и МаргаритаПреступление и наказание");
        }
    }
}