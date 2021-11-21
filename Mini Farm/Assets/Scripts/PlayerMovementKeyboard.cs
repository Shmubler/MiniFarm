using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKeyboard : MonoBehaviour {
    private Vector3 change;
    private float speed;
    private Rigidbody2D myRigidbody;
    private bool wasMovingVertical;

    // Start is called before the first frame update
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        bool isShiftKeyDown = Input.GetKey(KeyCode.LeftShift);
        if (isShiftKeyDown) {
            speed = 14f;
        }
        else {
            speed = 8f;
        }

        change.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        bool isMovingHorizontal = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f;
        change.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        bool isMovingVertical = Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f;

        if (isMovingVertical && isMovingHorizontal) {
            if (wasMovingVertical) {
                change.y = 0;
            }
            else {
                change.x = 0;
            }
        }
        else if (isMovingHorizontal) {
            wasMovingVertical = false;
        }
        else if (isMovingVertical) {
            wasMovingVertical = true;
        }
    }

    void FixedUpdate() {
        myRigidbody.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    }
}