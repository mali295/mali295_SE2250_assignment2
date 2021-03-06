using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    // speed of the scroll
    public float scroll_Speed = 0.1f;
    // this is where we hold the material in order to scroll
    private MeshRenderer mesh_Renderer;

    private float x_Scroll;

    // Start is called before the first frame update
    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll() {
        // time.time is the time since we started the game
        x_Scroll = Time.time * scroll_Speed;

        Vector2 offset = new Vector2(x_Scroll, 0f);
        // pass the name of the texture
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }


}
