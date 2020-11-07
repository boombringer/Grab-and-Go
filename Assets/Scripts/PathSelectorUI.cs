using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathSelectorUI : MonoBehaviour
{
    public List<GameObject> arrow;

    public bool debugerOn;

    public int Selected = -1;

    public List<Button> arrowButton;

    private void Awake()
    {
        /*for (int i = 0; i < arrowButton.Count; i++)
        {
            int n = i;
            arrowButton[i].onClick.AddListener(delegate { ArrowSelect(n); });

        }*/

        /*arrowButton[0].onClick.AddListener(Selected_N);
        arrowButton[1].onClick.AddListener(Selected_S);
        arrowButton[2].onClick.AddListener(Selected_E);
        arrowButton[3].onClick.AddListener(Selected_W);*/

        foreach (GameObject obj in arrow)
        {
            obj.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public void OpenUI(Transform selectorTransform)
    {
        Selected = -1;
        transform.position = new Vector3(selectorTransform.position.x, transform.position.y, selectorTransform.position.z);

        //ADD LISTENER
        for (int i = 0; i < arrowButton.Count; i++)
        {
            int n = i;
            arrowButton[i].onClick.AddListener(delegate { ArrowSelect(n); });

        }
        gameObject.SetActive(true);
    }

    public void OpenUI()
    {
        Selected = -1;
        gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        foreach (Button bt in arrowButton)
        {
            bt.onClick.RemoveAllListeners();
        }
        Selected = -1;
        gameObject.SetActive(false);
    }

    public void ToggleUI(bool show, List<int> con)
    {
        Selected = -1;

        for (int i = 0; i < arrow.Count; i++)
        {
            if (con[i] == 1)
            {
                arrow[i].SetActive(true);
            }
            else if (con[i] == 0)
            {
                arrow[i].SetActive(false);
            }

        }
    }

    public void ArrowSelect(int s)
    {
        Selected = s;
    }

/*    public void Selected_N()
    {
        Selected = 0;
    }

    public void Selected_S()
    {
        Selected = 1;
    }

    public void Selected_E()
    {
        Selected = 2;
    }

    public void Selected_W()
    {
        Selected = 3;
    }*/


}
