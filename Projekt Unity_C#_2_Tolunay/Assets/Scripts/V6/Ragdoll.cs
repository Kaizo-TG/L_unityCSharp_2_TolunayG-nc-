using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Collider mainCollider;
    private Collider[] ragdollCollider;
    private Rigidbody[] ragdollRigidbody;

    private void Awake()
    {
        mainCollider = GetComponent<Collider>();
        ragdollCollider = GetComponentsInChildren<Collider>();
        ragdollRigidbody = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            EnableRagdoll();
        }
    }

    private void DisableRagdoll()
    {
        foreach (Collider col in ragdollCollider)
        {
            col.enabled = false;
        }
        GetComponent<Animator>().enabled = true;
        mainCollider.enabled = true;
    }

    private void EnableRagdoll()
    {
        foreach (Collider col in ragdollCollider)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rb in ragdollRigidbody)
        {
            rb.isKinematic = false;
        }

        mainCollider.enabled = false;
        GetComponent<Animator>().enabled = false;
    }
}
