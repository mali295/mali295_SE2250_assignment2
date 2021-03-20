using System.Collections;                // Required for Arrays and other Collections
using System.Collections.Generic;        // Required to use Lists or Dictionaries
using UnityEngine;                       // Required for Unity

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f;
    public bool keepOnScreen = true;

    [Header("Set Dynamically")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;
    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;
    

    void Awake() {
        // Camera.main gives you access to the first camera with the tag MainCamera in the scene
        camHeight = Camera.main.orthographicSize;
        // is the aspect ratio of the camera in width/height as defined by the aspect ratio of the Game pane
        camWidth = camHeight * Camera.main.aspect;
    }
    
    // called every frame after Update() has been called on all GameObjects
    void LateUpdate() {
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        if (pos.x > camWidth - radius) {
            pos.x = camWidth - radius;
            offRight = true;
        }
        if (pos.x < -camWidth + radius) {
            pos.x = -camWidth + radius;
            offLeft = true;
        }
        if (pos.y > camHeight - radius) {
            pos.y = camHeight - radius;
            offUp = true;
        }
        if (pos.y < -camHeight + radius) {
            pos.y = -camHeight + radius;
            offDown = true;
        }

        isOnScreen = !(offRight || offLeft || offUp || offDown);
        if(keepOnScreen && !isOnScreen) {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
        
    }

    // Draw the bounds in the Scene pane using OnDrawGizmos()
    // OnDrawGizmos is a built-in MonoBehaviour method that can draw to the Scene pane
    void OnDrawGizmos() {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth*2, camHeight*2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
