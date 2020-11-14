using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectC : BaseEffect
{
    int _test = 123;
    public EffectC(int test)
    {
        _test = test;
    }
    public override void ActivateEffect()
    {
        Debug.Log("test class "+_test);
    }

}