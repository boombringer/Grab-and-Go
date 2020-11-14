using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectA : MonoBehaviour, IEffect
{
    public int _effectID;

    private void Start()
    {
        gameObject.name = _effectID.ToString();
        this.enabled = false;
    }

    public void OnEffect(Card card)
    {
        Debug.Log("eff B");
        Player player = card._player;

        player.playerMoney = 200;
    }

}
