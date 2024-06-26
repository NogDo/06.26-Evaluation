using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISkillInvetorySlot : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler
{

    #region public ����
    public Image skillIcon;
    #endregion

    #region private ����
    Skill skill;
    #endregion

    /// <summary>
    /// ������ ������ �ִ� ��ų ����
    /// </summary>
    public virtual Skill Skill
    {
        get
        {
            return skill;
        }

        set
        {
            skill = value;

            if (skill is null)
            {
                skillIcon.enabled = false;
            }

            else
            {
                skillIcon.sprite = skill.skillIcon;
                skillIcon.enabled = true;
            }
        }
    }

    void Awake()
    {
        skill = null;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (skill is null)
        {
            return;
        }

        skillIcon.rectTransform.SetParent(CSkillManager.Instance.skillPage);
    }

    public void OnDrag(PointerEventData data)
    {
        if (skill is null)
        {
            return;
        }

        skillIcon.rectTransform.position = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (skill is null)
        {
            return;
        }

        if (CSkillManager.Instance.focusedSlot is not null && CSkillManager.Instance.focusedSlot != this)
        {
            UISkillInvetorySlot targetSlot = CSkillManager.Instance.focusedSlot;
            Skill tempSkill = targetSlot.Skill;

            targetSlot.Skill = skill;
            this.Skill = tempSkill;
        }

        skillIcon.rectTransform.SetParent(transform);
        // �ڽĵ� �� �ֻ�翡 ��ġ�ϵ����ϱ� ���� �Լ� (�θ� �缳���ϸ� ���� �ִ� �̹����麸�� �ʰ� ������ �Ǹ鼭 ��Ÿ��, �ؽ�Ʈ�� ������ ��)
        skillIcon.rectTransform.SetSiblingIndex(2);
        skillIcon.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        CSkillManager.Instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData data)
    {
        CSkillManager.Instance.focusedSlot = null;
    }
}
