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

    public GameObject selectUI;

    private void Awake()
    {
        foreach (GameObject obj in arrow)
        {
            obj.SetActive(false);
        }

        selectUI.SetActive(false);
    }

    public void OpenToggleUI(bool show, List<int> con , Transform selectorTransform) // useThis
    {
        Selected = -1;

        selectUI.transform.position = new Vector3(selectorTransform.position.x, transform.position.y, selectorTransform.position.z);

        selectUI.SetActive(true);

        //ADD LISTENER
        for (int i = 0; i < arrowButton.Count; i++)
        {
            int n = i;
            arrowButton[i].onClick.AddListener(delegate { ArrowSelect(n); });

            if (con[i] == 1) arrow[i].SetActive(true);
            if (con[i] == 0) arrow[i].SetActive(false);        

        }

    }

    public void DisableUI()
    {
        foreach (Button bt in arrowButton)
        {
            bt.onClick.RemoveAllListeners();
        }

        Selected = -1;

        selectUI.SetActive(false);
    }

    

    public void ArrowSelect(int s)
    {
        Selected = s;
    }


}
