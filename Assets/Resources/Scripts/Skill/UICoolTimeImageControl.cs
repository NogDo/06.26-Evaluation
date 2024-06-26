using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoolTimeImageControl : MonoBehaviour
{
    #region public ����
    public UIPlayerEquipSkillSlot skillEquipSlot;
    #endregion

    #region private ����
    Image cooltimeImage;

    float fCooltime;
    #endregion

    void OnEnable()
    {
        cooltimeImage = GetComponent<Image>();

        fCooltime = skillEquipSlot.Skill.fCooltime;

        StartCoroutine(DecreaseAmount());
    }

    /// <summary>
    /// Image�� fillAmount�� �ð��� ���� ���� ���̴� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator DecreaseAmount()
    {
        float fNowCooltime = fCooltime;
        cooltimeImage.fillAmount = 1.0f;

        while (fNowCooltime > 0)
        {
            cooltimeImage.fillAmount = fNowCooltime / fCooltime;
            fNowCooltime -= Time.deltaTime;

            yield return null;
        }

        cooltimeImage.fillAmount = 0.0f;

        gameObject.SetActive(false);
    }
}
