using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int index = 0;
    public static int current = 0;
    public Material nextMaterial;
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = transform.GetChild(0).gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(index == current)
        {
            renderer.material = nextMaterial;
        }
        else
        {
            renderer.material = null;
        }
        
        transform.GetChild(0).gameObject.active = index + 1 >= current;
    }
}
