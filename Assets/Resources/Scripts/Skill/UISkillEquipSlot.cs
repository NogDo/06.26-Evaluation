using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillEquipSlot : UISkillInvetorySlot
{
    #region public ����
    public UIPlayerEquipSkillSlot playerEquipSkillSlot;
    #endregion

    public override Skill Skill
    {
        get => base.Skill;

        set
        {
            base.Skill = value;
            playerEquipSkillSlot.SetSkill(value);
        }
    }
}