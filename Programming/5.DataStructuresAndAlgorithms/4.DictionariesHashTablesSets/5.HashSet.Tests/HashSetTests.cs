using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class HashSetTests
{
    [TestMethod]
    public void Add()
    {
        var hashSet = new HashSet<int>();

        hashSet.Add(1);
        Assert.AreEqual(1, hashSet.Count);

        hashSet.Add(1);
        Assert.AreEqual(1, hashSet.Count);

        Assert.IsTrue(hashSet.Contains(1));
    }

    [TestMethod]
    public void AddMultiple()
    {
        var hashSet = new HashSet<int>();

        var elementsCount = 1000;

        for (int i = 0; i < elementsCount; i++)
            hashSet.Add(i);

        Assert.IsTrue(Enumerable.Range(0, elementsCount).SequenceEqual(hashSet));
        Assert.AreEqual(elementsCount, hashSet.Count);
    }

    [TestMethod]
    public void RemoveMultiple()
    {
        var hashSet = new HashSet<int>();

        var elementsCount = 1000;

        for (int i = 0; i < elementsCount; i++)
            hashSet.Add(i);

        for (int i = 0; i < elementsCount / 2; i++)
            hashSet.Remove(i);

        Assert.IsTrue(Enumerable.Range(elementsCount / 2, elementsCount / 2).SequenceEqual(hashSet));
        Assert.AreEqual(elementsCount / 2, hashSet.Count);
    }

    [TestMethod]
    public void RemoveValid()
    {
        var hashSet = new HashSet<int> { 1, 1, 1 };

        var actual = hashSet.Remove(1);
        Assert.IsTrue(actual);

        Assert.AreEqual(0, hashSet.Count);
        Assert.IsFalse(hashSet.Contains(1));
    }

    [TestMethod]
    public void RemoveInvalid()
    {
        var hashSet = new HashSet<int>();

        var actual = hashSet.Remove(3);

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void Clear()
    {
        var hashSet = new HashSet<int> { 1, 2, 3 };

        hashSet.Clear();

        Assert.AreEqual(0, hashSet.Count);
    }

    [TestMethod]
    public void Union()
    {
        var hashSet = new HashSet<int> { 1, 2, 3 };

        hashSet.Union(new[] { 2, 3, 4 });

        Assert.IsTrue(Enumerable.Range(1, 4).SequenceEqual(hashSet));
    }

    [TestMethod]
    public void Intersect()
    {
        var hashSet = new HashSet<int> { 1, 2, 3 };

        hashSet.Intersect(new[] { 2, 3, 4 });

        Assert.IsTrue(Enumerable.Range(2, 2).SequenceEqual(hashSet));
    }
}
