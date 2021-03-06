using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    public float speed = 5f;

    public float min_Y, max_Y;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer() {
        // for loop is used when the space is above 0 and if no key is pressed it will stay at 0
        if (Input.GetAxisRaw("Vertical") > 0f) {

             Vector3 temp = transform.position;
             temp.y += speed * Time.deltaTime;

            // I am putting this for loop to show that the value cannot be greated than the 4.3 that has been set and if it is greater it will be set at 4.3
             if (temp.y > max_Y) 
                 temp.y = max_Y; 
             

             transform.position = temp;
        
        // for loop is used when the space is below 0 and if no key is pressed it will stay at 0
        } else if (Input.GetAxisRaw("Vertical") < 0f) {

            Vector3 temp = transform.position;
            // using Time.deltaTime so it can move slowly/smoothly
            temp.y -= speed * Time.deltaTime;


            // I am putting this for loop to show that the value cannot be greated than the -4.3 that has been set and if it is smaller then the value will be set at -4.3 
             if (temp.y < min_Y) 
                 temp.y = min_Y; 
             

            transform.position = temp;
        }
    }
}
