using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSelector : MonoBehaviour
{
    public PathSelectorUI UI_pathSelect;

    private bool selectorOpen = false;
    public List<int> nodeStatus;

    public Transform UI_transform;

    public void OpenSelectorUI(List<int> nodeStatus, Transform currentNode)
    {
        if (!selectorOpen)
        {
            selectorOpen = true;
            UI_pathSelect.OpenUI(currentNode);
            UI_pathSelect.ToggleUI(true, nodeStatus);

        }

    }

    public int GetSelected() // listen to this
    {
        int temp = UI_pathSelect.Selected;
        if (temp >= 0)
        {
            selectorOpen = false;
            UI_pathSelect.CloseUI();
           // Debug.Log("GetSelected( ) = " + temp);
            return temp;
        }
        else
        {
            return -1;
        }

    }

    public Node NodeSelect(Node current,Node previous)
    {
        int branch = current.NodeActiveConnection();

        if(branch == 2)
        {
            foreach (Node n in current.connection)
            {
                if (n != null && n != previous)
                {
                    return n;
                }
            }
        }
        else if (branch > 2 || branch == 1)
        {
            List<int> stats = current.GetConnection_Status();
            OpenSelectorUI(stats, current.GetTransform());
            int selected = GetSelected();

            if (selected >= 0)
            {
                return current.GetDestinationNode(selected);
            }
        }

        return null;
    }

    private void CloseSelectorUI()
    {
        UI_pathSelect.CloseUI();
    }
}
