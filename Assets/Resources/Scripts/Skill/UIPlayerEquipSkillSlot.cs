using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerEquipSkillSlot : MonoBehaviour
{
    #region public 변수
    public Image skillIcon;
    public GameObject oSkillCoolTime;
    public GameObject oCoolTimeText;
    #endregion

    #region private 변수
    Skill skill;
    #endregion

    public Skill Skill
    {
        get
        {
            return skill;
        }
    }

    public void SetSkill(Skill skill)
    {
        this.skill = skill;

        if (skill is not null)
        {
            skillIcon.sprite = skill.skillIcon;
            skillIcon.enabled = true;
        }

        else
        {
            skillIcon.enabled = false;
        }
    }

    public bool TryUseSkill()
    {
        if (!oSkillCoolTime.activeSelf)
        {
            oSkillCoolTime.SetActive(true);
            oCoolTimeText.SetActive(true);

            return true;
        }

        else
        {
            return false;
        }
    }

    public bool IsExist()
    {
        return skill is not null;
    }
}
