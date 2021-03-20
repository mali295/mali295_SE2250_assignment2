using System.Collections;           // Required for Arrays and other Collections
using System.Collections.Generic;   // Required to use Lists or Dictionaries
using UnityEngine;                  // Required for Unity

public class Hero : MonoBehaviour
{

    static public Hero S; // Singleton
    [Header("Set in Inspector")]

    // these fields control the movement of the ship
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    [Header("Set Dynamically")]
    [SerializeField]
    // this variable has a reference to the last triggering GameObject
    private float _cockpitLevel = 1;    // having underscore because it is a private variable 
    

    // this variable holds a reference to the last triggering GameObject
    private GameObject _lastTriggerGo = null;

    void Awake() {
        if (S == null) {
           S = this; 
        } else {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Pull in information from the Input class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // Change transform.position based on the axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        // Rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis*pitchMult,xAxis*rollMult,0);
    }

    void OnTriggerEnter(Collider other) {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        

        //Make sure it's not the same triggering go as last time
        if(go == _lastTriggerGo) {
            return;
        }
        _lastTriggerGo = go;

        if(go.tag == "Enemy") {      // if the cockpit was triggered by an enemy
            cockpitLevel--;          // Decrease the level of the cockpit by 1
            Destroy(go);            // and Destroy the enemy
        } else {
            print("Triggered by non-Enemy: "+go.name);
        }

       
    }

    public float cockpitLevel {
        get {
            return(_cockpitLevel);
        }
        set {
            _cockpitLevel = Mathf.Min(value, 4);
            // if the shield is going to be set less than zero
            if(value < 1) {
                Destroy(this.gameObject);
            }
        }
    }
}
