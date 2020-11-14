using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public Player _player;
    public int _effectID = 2;
    public EffectC _effectC;
    public BaseEffect _baseEffect;
    private void Start()
    {
        _effectC = new EffectC(123);
        _baseEffect = (BaseEffect)_effectC;
        Card card = new Card(_player, _effectID.ToString(), true);
        ActivateEffect(card);
    }

    public void ActivateEffect (Card card)
    {
        _baseEffect.ActivateEffect();
        foreach(Transform t in transform)
        {
            string effName = t.name;
            if(effName == card._effectID)
            {
                IEffect effect = t.GetComponent<IEffect>();
                effect.OnEffect(card);
            }
        }
    }

    public void EmbededEffect()
    {

    }
}


public class BaseEffect
{
    public virtual void ActivateEffect()
    {

    }
}


public interface IEffect
{
    void OnEffect(Card card);

}
