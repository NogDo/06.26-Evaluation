using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CPlayerSkillController : MonoBehaviour
{
    #region public 변수
    public UIPlayerEquipSkillSlot[] playerSkill;
    public UnityEvent<float> onMpChange;
    public Transform shotPoint;
    #endregion

    #region private 변수
    CPlayerStats playerStats;
    #endregion

    void Awake()
    {
        playerStats = GetComponent<CPlayerStats>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseSkill(0);
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            UseSkill(1);
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            UseSkill(2);
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            UseSkill(3);
        }
    }

    void UseSkill(int index)
    {
        if (playerSkill[index].IsExist())
        {
            if (playerStats.CurrentMP >= playerSkill[index].Skill.fManaCost)
            {
                if (playerSkill[index].TryUseSkill())
                {
                    playerStats.CurrentMP -= playerSkill[index].Skill.fManaCost;
                    onMpChange?.Invoke(playerStats.CurrentMP / playerStats.MaxMP);

                    Instantiate(playerSkill[index].Skill.oSkillParticle, shotPoint.transform.position, shotPoint.transform.rotation);
                }
            }
        }
    }
}