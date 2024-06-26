using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CPlayerStats : MonoBehaviour
{
    #region public 변수
    public UnityEvent<string> onChangeAttackText;
    public UnityEvent<string> onChangeDeffenceText;
    #endregion

    #region private 변수
    float fMaxHP = 100.0f;
    float fCurrentHP = 100.0f;
    float fMaxMP = 100.0f;
    float fCurrentMP = 100.0f;
    float fAttack = 10.0f;
    float fDeffence = 10.0f;
    #endregion

    void Start()
    {
        string attack = $"ATK : {fAttack}";
        string deffence = $"DEF : {fDeffence}";

        onChangeAttackText?.Invoke(attack);
        onChangeDeffenceText?.Invoke(deffence);
    }

    public float MaxHP 
    {
        get
        {
            return fMaxHP;
        }
    }

    public float CurrentHP
    {
        get
        {
            return fCurrentHP;
        }

        set
        {
            fCurrentHP = value;
        }
    }

    public float MaxMP
    {
        get
        {
            return fMaxMP;
        }
    }

    public float CurrentMP
    {
        get
        {
            return fCurrentMP;
        }

        set
        {
            fCurrentMP = value;
        }
    }

    public float Attack
    {
        get
        {
            return fAttack;
        }

        set
        {
            fAttack = value;

            string attack = $"ATK : {fAttack}";
            onChangeAttackText?.Invoke(attack);
        }
    }

    public float Deffence
    {
        get
        {
            return fDeffence;
        }

        set
        {
            fDeffence = value;

            string deffence = $"DEF : {fDeffence}";
            onChangeDeffenceText?.Invoke(deffence);
        }
    }
}