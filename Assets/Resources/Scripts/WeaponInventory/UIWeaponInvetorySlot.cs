using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIWeaponInvetorySlot : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    #region public 변수
    public Image weaponIcon;
    #endregion

    #region private 변수
    Item item;
    #endregion

    /// <summary>
    /// 슬롯이 가지고 있는 스킬 정보
    /// </summary>
    public virtual Item Item
    {
        get
        {
            return item;
        }

        set
        {
            item = value;

            if (item is null)
            {
                weaponIcon.enabled = false;
            }

            else
            {
                weaponIcon.sprite = item.weaponIcon;
                weaponIcon.enabled = true;
            }
        }
    }

    void Awake()
    {
        item = null;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (item is null)
        {
            return;
        }

        weaponIcon.rectTransform.SetParent(CItemManager.Instance.inventoryPage);
    }

    public void OnDrag(PointerEventData data)
    {
        if (item is null)
        {
            return;
        }

        weaponIcon.rectTransform.position = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (item is null)
        {
            return;
        }

        if (CItemManager.Instance.focusedSlot is not null && CItemManager.Instance.focusedSlot != this)
        {
            UIWeaponInvetorySlot targetSlot = CItemManager.Instance.focusedSlot;
            Item weaponItem = targetSlot.Item;

            targetSlot.Item = item;
            this.Item = weaponItem;
        }

        weaponIcon.rectTransform.SetParent(transform);
        // 자식들 중 최상당에 위치하도록하기 위한 함수 (부모를 재설정하면 원래 있던 이미지들보다 늦게 렌더링 되면서 쿨타임, 텍스트를 가리게 됨)
        weaponIcon.rectTransform.SetSiblingIndex(2);
        weaponIcon.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        CItemManager.Instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData data)
    {
        CItemManager.Instance.focusedSlot = null;
    }
}
