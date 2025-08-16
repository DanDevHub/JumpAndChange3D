using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorCheck : MonoBehaviour
{
    public GameObject LoadDead;
    public GameObject boom;
    public GameObject player;

    public static bool endp;
    public static bool playerdead;
    public static bool boostingfield;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "YellowGround" && ChangeColor.playercolor == "Red")
        {
            Dead();

        }
        else if (col.gameObject.tag == "RedGround" && ChangeColor.playercolor == "Yellow")
        {
            Dead();

        }
        else if (col.gameObject.tag == "Deadblock")
        {
            Dead();

        }

        if(col.gameObject.tag == "EndPortal")
        {
            endp = true;
        }

       if(col.gameObject.tag == "boostingfield")
        {
            boostingfield = true;
        }
        Debug.Log("enter");
    }
    private void OnTriggerStay(Collider stay)
    {
        Debug.Log("stay");
        if(stay.gameObject.tag == "YellowGround" && ChangeColor.playercolor == "Red")
        {
            Dead();
        }
        else if (stay.gameObject.tag == "RedGround" && ChangeColor.playercolor == "Yellow")
        {
            Dead();
        }
    }

    private void Dead()
    {
        playerdead = true;
        if (player != null)
        {
            float playerX = player.gameObject.transform.position.x;
            float playerY = player.gameObject.transform.position.y + 2f;
            float playerZ = player.gameObject.transform.position.z;
            Instantiate(boom, new Vector3(playerX, playerY, playerZ), transform.rotation);
        }
        StartCoroutine(Deadtrans());
    }

    IEnumerator Deadtrans()
    { 
        Destroy(player);
        yield return new WaitForSeconds(1);
        FindObjectOfType<SceneLoader>().respawn();
        playerdead = false;
    }
}
