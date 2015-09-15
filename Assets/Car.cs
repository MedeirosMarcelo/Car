using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

    public float currentSpeed = 0f;
    public float acceleration = 0.2f;
    public float topSpeed = 50f;
    public float reverseTopSpeed = -50f;
    public float steerSpeed = 25f;
    public float steerMaxAngle = 5f;
    public float breakForce = 0.4f;
    public float attrition;
    Rigidbody rigidbody;
    Vector3 velocity;

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
        Drive ();
	}

    void Drive () {
        velocity = transform.forward;
        if (Input.GetButton("Accelerate")) {
            currentSpeed += acceleration;
        }
        else if (Input.GetButton("Reverse")){
            currentSpeed -= acceleration;
        }
        else {
            if (currentSpeed > 0) {
                currentSpeed -= acceleration * 0.5f;
            }
        }
        if (Input.GetButton("Break")) {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, breakForce);
        }
        currentSpeed = Mathf.Clamp(currentSpeed, reverseTopSpeed, topSpeed);
        velocity *= currentSpeed;
        
        float steerRotation = Input.GetAxis("Steering") * steerSpeed;
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, steerRotation, 0) * Time.deltaTime);

        rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
    }
}
