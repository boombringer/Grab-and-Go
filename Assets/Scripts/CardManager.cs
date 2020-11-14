using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ambil dari pool kartu id
public class CardManager : MonoBehaviour
{
    public GameObject _cardDrawUI;
    public Button _drawButton;
    public List<Player> players;

    public void OpenCardDraw(int id)
    {
        _cardDrawUI.SetActive(true);

        for (int i = 0; i < 2; i++)
        {
            int n = i;
            _drawButton.onClick.AddListener(delegate { OnCardDrawn(n); });

        }
    }

    private void OnCardDrawn(int selected)
    {
        
    }

    public void CloseCardDraw()
    {
        _drawButton.onClick.RemoveAllListeners();
        _cardDrawUI.SetActive(false);

    }

}

public class Card
{
    public string _effectID;
    public Player _player;
    public bool _effectOnPlayer;

    public int _modifier;

    public Card(Player player, string effectID, bool effOnPlayer)
    {
        _effectID = effectID;
        _player = player;
    }
}
