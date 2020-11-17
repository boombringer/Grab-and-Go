using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerEffectManager : MonoBehaviour
{
    private bool _onEffect;
    private bool _drawCard;

    public Card cardDrawn;

    public CardManager cardManager;

    public void GetCard()
    {
        if (_onEffect) return;
        cardDrawn = cardManager.GetNewCard();
    }

    public void DrawCard()
    {
        if (_drawCard) return;
        //Draw CArd
    }
}