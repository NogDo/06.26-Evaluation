using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerController : MonoBehaviour
{
    #region private º¯¼ö
    Vector3 v3TargetPosition;

    float fMoveSpeed = 5.0f;
    float fRotateSpeed = 6.0f;

    bool isMoving = false;
    #endregion

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                v3TargetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                isMoving = true;
            }
        }

        if (isMoving)
        {
            Move();
            Rotate();
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, v3TargetPosition, fMoveSpeed * Time.deltaTime);

        float distance = (transform.position - v3TargetPosition).sqrMagnitude;
        if (distance <= 0.1f)
        {
            isMoving = false;
        }
    }

    void Rotate()
    {
        Quaternion targetRotation = Quaternion.LookRotation(v3TargetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, fRotateSpeed * Time.deltaTime);
    }
}