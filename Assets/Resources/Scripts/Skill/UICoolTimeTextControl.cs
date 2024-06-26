using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoolTimeTextControl : MonoBehaviour
{
    #region public 변수
    public UIPlayerEquipSkillSlot skillEquipSlot;
    #endregion

    #region private 변수
    TextMeshProUGUI cooltimeText;

    float fCooltime;
    #endregion

    void OnEnable()
    {
        if (cooltimeText is null)
        {
            cooltimeText = GetComponent<TextMeshProUGUI>();
        }

        fCooltime = skillEquipSlot.Skill.fCooltime;

        StartCoroutine(DecreaseTextTime());
    }

    /// <summary>
    /// Text를 남은 시간으로 바꾸는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator DecreaseTextTime()
    {
        float fNowCooltime = fCooltime;
        cooltimeText.text = fNowCooltime.ToString();

        while (fNowCooltime > 0)
        {
            cooltimeText.text = fNowCooltime.ToString("F1");
            fNowCooltime -= Time.deltaTime;

            yield return null;
        }

        cooltimeText.text = "0";

        gameObject.SetActive(false);
    }
}
