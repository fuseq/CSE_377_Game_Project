using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class DestroyPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<Health>().heal(10);
            Debug.Log(collision.gameObject.GetComponent<Health>().getHeal());
            GetComponent<PhotonView>().RPC("destroyHealthPack", RpcTarget.AllBuffered);
            foreach (Transform eachChild in collision.transform)
            {
                if (eachChild.name == "pfHealthBar")
                {
                    eachChild.localScale =new Vector3((collision.gameObject.GetComponent<Health>().getHeal()/100)*1,1,1);
                }
            }
        }
                
    }
    [PunRPC]
    public void destroyHealthPack() 
    {
        Destroy(gameObject);
    }
}