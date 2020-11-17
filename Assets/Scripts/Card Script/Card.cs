using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string EffectName;
    
    public bool effectOnPlayer;

    public int effectDuration;

    public ScriptableCard CardData;

    public Card(ScriptableCard cardData)
    {
        CardData = cardData;
    }
}
