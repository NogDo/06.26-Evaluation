using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSkillParticleControl : MonoBehaviour
{
    #region public º¯¼ö
    public float fRunTime;
    public float fMoveSpeed;
    public bool isMoveParticle;
    #endregion

    void OnEnable()
    {
        StartCoroutine(RemoveParticle());

        if (isMoveParticle)
        {
            StartCoroutine(MoveParticle());
        }
    }

    IEnumerator RemoveParticle()
    {
        yield return new WaitForSeconds(fRunTime);

        Destroy(gameObject);
    }

    IEnumerator MoveParticle()
    {
        while (true)
        {
            transform.Translate(Vector3.forward * fMoveSpeed * Time.deltaTime);

            yield return null;
        }
    }
}