using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��ų ������ ������ �ִ� Ŭ����
/// </summary>
[System.Serializable]
public class Skill
{
    #region public ����
    public GameObject oSkillParticle;
    public Sprite skillIcon;
    public float fCooltime;
    public float fManaCost;
    #endregion
}

public class CSkillManager : MonoBehaviour
{
    #region public ����
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