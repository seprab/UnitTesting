using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class EditModeTests
{
    [TestCase(1, 8, 9)]
    [TestCase(2, 7, 9)]
    [TestCase(3, 6, 9)]
    [TestCase(4, 5, 9)]
    public void Sum(int a, int b, int expectedResult)
    {
        Assert.AreEqual(expectedResult, a + b);
    }

    
    [TestCase(1f, 8f, 0.125f)]
    [TestCase(2f, 7f, 0.285f)]
    [TestCase(5f, 0f, 0f)]
    [TestCase(3f, 6f, 0.5f)]
    [TestCase(4f, 5f, 0.8f)]
    public void Division(float a, float b, float expectedResult)
    {
        float operationResult = a / b;
        Assert.AreEqual(expectedResult, operationResult );
    }

    [TestCase(1, 8, 8)]
    [TestCase(2, 7, 14)]
    [TestCase(3, 6, 18)]
    [TestCase(4, 5, 20)]
    [TestCase(5, 0, 0)]
    public void Multiply(int a, int b, int expectedResult)
    {
        float operationResult = a * b;
        Assert.AreEqual(expectedResult, operationResult);
    }
}
