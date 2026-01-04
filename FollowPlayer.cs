using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //finds refrence of player object in inspector
    public GameObject player;
    private Vector3 offset = new Vector3(0, 7, -10);


   
    void Start()
    {
        
    }

  

    //Making camera wait for update method
    void LateUpdate()
    {
        //camera position follows player with offset 
        transform.position = player.transform.position + offset; 
    }
}
