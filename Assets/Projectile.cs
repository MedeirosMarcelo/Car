using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed;

    protected void Shoot(Rigidbody rb) {
        Vector3 velocity = transform.forward * speed;
        rb.AddForce(velocity, ForceMode.Acceleration);
    }
}
