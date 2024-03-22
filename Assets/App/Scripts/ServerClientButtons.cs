using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode; 
using System; 




public class ServerClientButtons : NetworkBehaviour
{
     //Make sure to attach these Buttons in the Inspector
    public Button serverClientButtons;
    public GameObject networkManager;
    public GameObject buttonGroup; 
    public GameObject digitalTwinActivation; 
    public GameObject eventSystem; 
    public GameObject sessionCamera; 
    
    public bool isServer = false; 
    public bool digitalTwinEnabledInServer = false; 

    void Start()
    {

        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        serverClientButtons.onClick.AddListener(TaskOnClick);
        
    }

    void TaskOnClick()
    {
        if(this.tag == "ServerButton"){
            Debug.Log("server is up!");
            isServer = true; 
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
            digitalTwinEnabledInServer = true; 
            PingServerRpc();
            //  PingClientRpc(3);
        }
         Debug.Log("You have clicked the button!");
        buttonGroup.GetComponent<DisableButtons>().DisableServerClientButtons(isServer); 
        

        //Output this to console when Button1 or Button3 is clicked
       
    }

    [ServerRpc(RequireOwnership=false)]
public void PingServerRpc()
{
    Debug.Log("it comes here!");
    // Server -> Clients because PongRpc sends to NotServer
    // Note: This will send to all clients.
    // Sending to the specific client that requested the pong will be discussed in the next section.
    PingClientRpc("Send From the Server");
}

    [ClientRpc]
public void PingClientRpc(String pingCount)
{
        buttonGroup.SetActive(false);
    // Server -> Clients because PongRpc sends to NotServer
    // Note: This will send to all clients.
    // Sending to the specific client that requested the pong will be discussed in the next section.
    if(!digitalTwinEnabledInServer){
        sessionCamera.SetActive(true);
    
    Debug.Log("Recieved in Client!");
    }
}
}
