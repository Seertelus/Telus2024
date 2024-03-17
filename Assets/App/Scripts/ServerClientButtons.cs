using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode; 



public class ServerClientButtons : MonoBehaviour
{
     //Make sure to attach these Buttons in the Inspector
    public Button serverClientButtons;
    public GameObject networkManager;
    public GameObject buttonGroup; 
    public GameObject digitalTwinActivation; 
    public GameObject eventSystem; 

    void Start()
    {

        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        serverClientButtons.onClick.AddListener(TaskOnClick);
        
    }

    void TaskOnClick()
    {
        if(this.tag == "ServerButton"){
            Debug.Log("server is up!");
            // NetworkManager.Singleton.StartServer();  
           networkManager.GetComponent<LobbyManager>().CreateLobby();  
        }
        else if(this.tag == "ClientButton"){
            // NetworkManager.Singleton.StartClient();  
            Debug.Log("client connected!");
            networkManager.GetComponent<LobbyManager>().QuickJoinLobby(); 
        }
        else if(this.tag == "DigitalTwinButton"){
            eventSystem.SetActive(false);
            digitalTwinActivation.SetActive(true);
            buttonGroup.GetComponent<DisableButtons>().DisableDigitalTwinButton(); 
        }
         Debug.Log("You have clicked the button!");
        buttonGroup.GetComponent<DisableButtons>().DisableServerClientButtons(); 
        

        //Output this to console when Button1 or Button3 is clicked
       
    }

 
}
