using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{

    public AmeliWalk AmeliWalk;
    public Transform LeftPosReference, RightPosReference, StopPosReference;
    public GameObject MenuGameObject, GameText;


    public void MakeTransition()
    {
        Vector3 rightPoint = new Vector3(RightPosReference.position.x, AmeliWalk.transform.position.y, AmeliWalk.transform.position.z);
        Vector3 walkDirection = rightPoint - AmeliWalk.transform.position;
        walkDirection.y = 0;
        Quaternion walkRotation = Quaternion.LookRotation(walkDirection);
        AmeliWalk.StartRotating(AmeliWalk.transform.localRotation, walkRotation, 5, null);
        AmeliWalk.StartWalking(AmeliWalk.transform.position, rightPoint, 5, () =>
        {
            MenuGameObject.SetActive(false);
            GameText.SetActive(true);
            Vector3 leftPoint = new Vector3(LeftPosReference.position.x, AmeliWalk.transform.position.y, AmeliWalk.transform.position.z);
            Vector3 stopPoint = new Vector3(StopPosReference.position.x, AmeliWalk.transform.position.y, AmeliWalk.transform.position.z);
            AmeliWalk.StartWalking(leftPoint, stopPoint, 5, () =>
            {
                AmeliWalk.StartRotating(AmeliWalk.transform.localRotation, Quaternion.Euler(0, 160, 0), 5, null);
            });
        });
    }
}
