using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSelector : MonoBehaviour
{
    public List<Quest> questOptions;

    public GameObject questUI;

    //ambil random dari pool tapi nanti doooong
    private List<Quest> questPool;

    public List<Button> questButtons;

    public List<Player> players;

    // selecting ID
    private int selectorsID;

    public void OpenQuestSelector(int id)
    {
        questUI.SetActive(true);
        selectorsID = id;

        for (int i = 0; i < 2; i++)
        {
            int n = i;
            questButtons[i].onClick.AddListener(delegate { OnQuestSelected(n); });
            
        }
    }

    public void CloseQuestSelector()
    {
        foreach (Button bt in questButtons)
        {
            bt.onClick.RemoveAllListeners();
        }

        selectorsID = -1;
        questUI.SetActive(false);

    }

    private void OnQuestSelected (int selected)
    {
        players[selectorsID - 1].SetQuest(questOptions[selected]);  //insert ke player yang ada
        CloseQuestSelector(); // tutup selector
    }


    
}
