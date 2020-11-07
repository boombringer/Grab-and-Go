using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEffect
{
    public int _effectID;
    public int _effectTurnLimit;
    public Node _effectLocation;

    public ActiveEffect(int effectID,int effectTurnLimit, Node effectLocation)
    {
        _effectID = effectID;
        _effectTurnLimit = effectTurnLimit;
        _effectLocation = effectLocation;
    }
    
}
