using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIWeaponInvetorySlot : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    #region public ����
    public Image weaponIcon;
    #endregion

    #region private ����
    Item item;
    #endregion

    /// <summary>
    /// ������ ������ �ִ� ��ų ����
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
        // �ڽĵ� �� �ֻ�翡 ��ġ�ϵ����ϱ� ���� �Լ� (�θ� �缳���ϸ� ���� �ִ� �̹����麸�� �ʰ� ������ �Ǹ鼭 ��Ÿ��, �ؽ�Ʈ�� ������ ��)
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
