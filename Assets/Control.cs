using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

    public GameObject rocket;
    public GameObject laser;
    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        ShootRocket();
	}

    void ShootRocket() {
        if (Input.GetButtonDown("Fire1") && rocket != null) {
            Vector3 position = transform.Find("RocketSpawner").position;
            GameObject newRocket = (GameObject)Instantiate(rocket, position, transform.rotation);
            newRocket.GetComponent<Rocket>().ShootRocket();
        }
    }

    public void ReceiveShot(Vector3 hitDirection) {
        
  //      Vector3 velocity = (transform.position - projectile.position);
        Vector3 velocity = hitDirection;
    //    velocity.y = 0f;
     //   velocity.Normalize();
     //   velocity = new Vector3(0,0,1);
     //   velocity *= 2f;
        Debug.Log(velocity);
        rb.AddForce(velocity, ForceMode.Impulse);
    }
}
