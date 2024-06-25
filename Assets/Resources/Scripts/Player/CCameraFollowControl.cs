using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraFollowControl : MonoBehaviour
{
    #region private º¯¼ö
    Transform player;

    Vector3 v3StartPosition;
    Vector3 v3PlayerStartPosition;
    #endregion

    void Awake()
    {
        player = FindObjectOfType<CPlayerController>().transform;

        v3StartPosition = transform.position;
        v3PlayerStartPosition = player.position;
    }

    void LateUpdate()
    {
        transform.position = v3StartPosition + (player.transform.position - v3PlayerStartPosition);
    }
}
