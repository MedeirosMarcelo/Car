using UnityEngine;
using System.Collections;

public class Rocket : Projectile {

    void Start() {
    }

    public void ShootRocket() {
        Rigidbody rb = GetComponent<Rigidbody>();
        Shoot(rb);
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            Debug.Log("HIT");
            ContactPoint contact = col.contacts[0];
            Vector3 hitDirection = contact.point - transform.position;
       //     col.transform.GetComponent<Control>().ReceiveShot(hitDirection);
            Destroy(this.gameObject);
        }
    }
}
