using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectB : MonoBehaviour, IEffect
{
    public int _effectID;

    private void Start()
    {
        gameObject.name = _effectID.ToString();
    }

    public void OnEffect(Card card)
    {
        Debug.Log("eff B");
        Player player = card._player;

        //Effect
        player.playerMoney = 1000;
    }

}
