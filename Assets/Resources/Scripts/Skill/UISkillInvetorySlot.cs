using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISkillInvetorySlot : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler
{

    #region public 변수
    public Image skillIcon;
    #endregion

    #region private 변수
    Skill skill;
    #endregion

    /// <summary>
    /// 슬롯이 가지고 있는 스킬 정보
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
        // 자식들 중 최상당에 위치하도록하기 위한 함수 (부모를 재설정하면 원래 있던 이미지들보다 늦게 렌더링 되면서 쿨타임, 텍스트를 가리게 됨)
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
