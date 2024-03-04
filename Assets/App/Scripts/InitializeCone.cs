using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeCone : MonoBehaviour
{
    public GameObject cone;
    // Start is called before the first frame update
    void Start()
    {
        cone.GetComponent<MeshRenderer>().enabled = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
