using System.Collections;              // Required for Arrays and other Collections
using System.Collections.Generic;      // Required to use Lists or Dictionaries
using UnityEngine;                     // Required for Unity
using UnityEngine.SceneManagement;     // for loading and reloading of scenes

public class Main : MonoBehaviour
{
    static public Main S;

    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;            // Array of Enemy prefabs 
    public float enemySpawnPerSecond = 0.5f;      // Enemies/second
    public float enemyDefaultPadding = 1.5f;      // Padding for position

    private BoundsCheck _bndCheck;
    

    void Awake() {
        S = this;
        // Set bndCheck to reference the BoundsCheck component on this GameObject
        _bndCheck = GetComponent<BoundsCheck>();

        // Invoke SpawnEnemy() once in 2 seconds, based on default values
        Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
    }

    public void SpawnEnemy() {
        // Pick a random Enemy prefab to instantiate 
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        // Position the Enemy above the screen with a random x position 
        float enemyPadding = enemyDefaultPadding;
        if(go.GetComponent<BoundsCheck>() != null) {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        //Set the initial position for the spawned Enemy
        Vector3 pos = Vector3.zero;
        float xMin = -_bndCheck.camWidth + enemyPadding;
        float xMax = _bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = _bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;

        // Invoke SpawnEnemy() again
        Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);

       

    
        
    }
}
