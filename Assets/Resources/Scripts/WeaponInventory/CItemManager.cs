using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    #region public 변수
    public Sprite weaponIcon;
    public float fAttak;
    public float fDeffence;
    #endregion
}

public class CItemManager : MonoBehaviour
{
    #region public 변수
    public static CItemManager Instance { get; private set; }

    public List<Item> itemList;
    public RectTransform oWeaponInventoryContent;
    public RectTransform inventoryPage;

    public UIWeaponInvetorySlot focusedSlot;
    #endregion

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            oWeaponInventoryContent.GetChild(i).GetComponent<UIWeaponInvetorySlot>().Item = itemList[i];
        }
    }
}
