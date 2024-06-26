using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 스킬 정보를 가지고 있는 클래스
/// </summary>
[System.Serializable]
public class Skill
{
    #region public 변수
    public GameObject oSkillParticle;
    public Sprite skillIcon;
    public float fCooltime;
    public float fManaCost;
    #endregion
}

public class CSkillManager : MonoBehaviour
{
    #region public 변수
    public static CSkillManager Instance { get; private set; }

    public List<Skill> skillList;
    public RectTransform oSkillInventoryContent;
    public RectTransform skillPage;

    public UISkillInvetorySlot focusedSlot;
    #endregion

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < skillList.Count; i++)
        {
            oSkillInventoryContent.GetChild(i).GetComponent<UISkillInvetorySlot>().Skill = skillList[i];
        }
    }
}