using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public Transform playerTransform;
    public Transform otherPortal;

    bool isCoolDown;

    private void Start() {
        isCoolDown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && isCoolDown == false)
        {
            playerTransform.transform.position = otherPortal.transform.position;
            isCoolDown = true;
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {

        yield return new WaitForSeconds(2);

        isCoolDown = false;

        yield return null;

    }
}
