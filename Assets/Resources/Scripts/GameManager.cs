using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region public º¯¼ö
    public GameObject oSkillPanel;
    public GameObject oInventoryPanel;
    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            oSkillPanel.SetActive(!oSkillPanel.activeSelf);
        }

        else if (Input.GetKeyDown(KeyCode.I))
        {
            oInventoryPanel.SetActive(!oInventoryPanel.activeSelf);
        }
    }
}