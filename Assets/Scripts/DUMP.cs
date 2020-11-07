using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUMP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*public class QuestManager : MonoBehaviour
{
    public List<PlayerQuest> playerQuest;

    public bool PickUpCheck(int playerID, Node currentNode)
    {       
        playerID -= 1;
        Quest qt = GetActiveQuest(playerID);
        if (currentNode == qt.pickUpNode)
        {
            qt.nextState();
            return true;
        }
        else return false;
    }

    private Quest GetActiveQuest(int ID)
    {
        return playerQuest[ID].activeQuest;
    }



}

[System.Serializable]
public class Player
{
    public int playerId;
    public int money;
    public Quest activeQuest;

    public bool ActiveQuest()
    {
        if (activeQuest == null) return false;
        else return true;
    }
}

[System.Serializable]
public class Quest
{
    private enum QuestState { pickUp = 0, dropOff = 1, finished = 2 }
    private QuestState questState = QuestState.pickUp;

    public Node pickUpNode;
    public Node destinationNode;

    public int reward = -1;
    public int turnToFinish = -1;

    public Quest(QuestScriptable questPreset)
    {
        pickUpNode = questPreset.pickUpNode;
        destinationNode = questPreset.destinationNode;
        reward = questPreset.reward;
        turnToFinish = questPreset.turnToFinish;
        questState = QuestState.pickUp;
    }

}

[CreateAssetMenu(fileName = "Scriptable Quest", menuName = "Scriptable/Quest")]
public class QuestScriptable : ScriptableObject
{
    public Node pickUpNode;
    public Node destinationNode;

    public int reward = -1;
    public int turnToFinish = -1;
}
*/
