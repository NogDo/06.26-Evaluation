using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoolTimeTextControl : MonoBehaviour
{
    #region public ����
    public UIPlayerEquipSkillSlot skillEquipSlot;
    #endregion

    #region private ����
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
    /// Text�� ���� �ð����� �ٲٴ� �ڷ�ƾ
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
