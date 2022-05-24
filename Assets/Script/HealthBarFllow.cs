using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFllow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playerthansform;
    public Vector3 offset = new Vector3 (0, 1, 0);
    void Start()
    {
        playerthansform = GameObject.Find("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerthansform.position + offset;
    }
}
