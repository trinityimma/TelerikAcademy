using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class HashTableTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AddNullKey()
    {
        var hashTable = new HashTable<string, int>();

        hashTable[null] = 0;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetNullKey()
    {
        var hashTable = new HashTable<string, int>();

        var value = hashTable[null];
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetMissingKey()
    {
        var hashTable = new HashTable<string, int>();

        var value = hashTable["Pesho"];
    }

    [TestMethod]
    public void AddMultiple()
    {
        var hashTable = new HashTable<int, int>();

        const int elementsCount = 1000;

        for (int i = 0; i < elementsCount; i++)
            hashTable[i] = i;

        Assert.AreEqual(elementsCount, hashTable.Count);
        Assert.AreEqual(elementsCount, hashTable.Keys.Count);

        var values = hashTable.Select(kvp => kvp.Value);

        var set = new HashSet<int>(Enumerable.Range(0, elementsCount));
        set.ExceptWith(values);

        Assert.AreEqual(0, set.Count);
    }

    [TestMethod]
    public void RemoveMultiple()
    {
        var hashTable = new HashTable<int, int>();

        const int elementsCount = 1000;

        for (int i = 0; i < elementsCount; i++)
            hashTable[i] = i;

        for (int i = 0; i < elementsCount / 2; i++)
            hashTable.Remove(i);

        Assert.AreEqual(elementsCount / 2, hashTable.Count);
        Assert.AreEqual(elementsCount / 2, hashTable.Keys.Count);
    }

    [TestMethod]
    public void RemoveValid()
    {
        var hashTable = new HashTable<int, int>();

        hashTable[1] = 7;

        var expected = true;
        var actual = hashTable.Remove(1);

        Assert.AreEqual(expected, actual);
        Assert.AreEqual(0, hashTable.Count);
    }

    [TestMethod]
    public void RemoveInvalid()
    {
        var hashTable = new HashTable<int, int>();

        hashTable[1] = 7;

        var expected = false;
        var actual = hashTable.Remove(3);

        Assert.AreEqual(expected, actual);
        Assert.AreEqual(1, hashTable.Count);
    }
}
