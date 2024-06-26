using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWeaponEquipSlot : UIWeaponInvetorySlot
{
    #region public 변수
    public CPlayerStats playerStats;
    #endregion

    #region private 변수
    float fPrevAttack = 0.0f;
    float fPrevDeffence = 0.0f;
    #endregion

    public override Item Item 
    { 
        get => base.Item; 

        set
        {
            base.Item = value;

            if (value is null)
            {
                playerStats.Attack -= fPrevAttack;
                playerStats.Deffence -= fPrevDeffence;

                fPrevAttack = 0.0f;
                fPrevDeffence = 0.0f;
            }

            else
            {
                playerStats.Attack -= fPrevAttack;
                playerStats.Deffence -= fPrevDeffence;

                playerStats.Attack += value.fAttak;
                playerStats.Deffence += value.fDeffence;

                fPrevAttack = value.fAttak;
                fPrevDeffence = value.fDeffence;
            }
        }
    }
}