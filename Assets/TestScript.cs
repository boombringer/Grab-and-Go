using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// it fuking works
public class TestScript : MonoBehaviour
{
    /*private void Start()
    {
        TestableClass tClass = new TestableClass(2);
        ITestable iTest = tClass;
        iTest.Test(20);
    }*/
}

public interface ITestable
{
    void Test(int a);
}

public class TestableClass : MonoBehaviour, ITestable
{
    int num;
    public TestableClass (int isi)
    {
        num = isi;
    }

    public void Test(int isi)
    {
        Debug.Log(" bruh isi "+isi);
    }
}