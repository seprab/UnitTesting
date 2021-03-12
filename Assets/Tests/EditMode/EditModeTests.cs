using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class EditModeTests
{
    [TestCase(0, 0, 0)]
    [TestCase(1, 8, 9)]
    [TestCase(2, 7, 9)]
    [TestCase(3, 6, 9)]
    [TestCase(4, 5, 9)]
    public void Sum(int a, int b, int expectedResult)
    {
        Assert.AreEqual(a + b, expectedResult);
    }
}
