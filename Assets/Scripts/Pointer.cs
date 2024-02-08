using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    Dictionary<int, Vector3> checkpointsDictionary = new Dictionary<int, Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Checkpoint checkpoint in GameObject.FindObjectsOfType<Checkpoint>())
        {
            checkpointsDictionary.Add(checkpoint.index, checkpoint.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, checkpointsDictionary[Checkpoint.current] - transform.position);
    }
}
