using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButtons : MonoBehaviour
{
    public GameObject clientButton;
    public GameObject serverButton;
    public GameObject digitalTwinButton;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void DisableServerClientButtons(){
        Debug.Log("aaaaa");
        clientButton.SetActive(false); 
        serverButton.SetActive(false);
        digitalTwinButton.SetActive(true);

        
    }

    public void DisableDigitalTwinButton(){
         Debug.Log("disable digtia");
        digitalTwinButton.SetActive(false); 
    }
}
