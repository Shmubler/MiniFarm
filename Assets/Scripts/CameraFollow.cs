using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Drop this script into the MainCamera object of any scene where you want the camera to follow the player
public class CameraFollow : MonoBehaviour
{
    [NonSerialized] Transform playerObject;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindObjectOfType<PlayerMovementKeyboard>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    void followPlayer()
    {
        gameObject.transform.position = playerObject.position  - new Vector3(0.0f, 0.0f, 10.0f);
    }
}
