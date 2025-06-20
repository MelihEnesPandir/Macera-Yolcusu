using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject playerAnim;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject fadeOut;
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CollisionEnd());
        Debug.Log("OnTriggerEnter çalýþtý: " + other.gameObject.name);
    }
    IEnumerator CollisionEnd()
    {     
        collisionFX.Play();
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        playerAnim.GetComponent<Animator>().SetTrigger("Stumble");
        mainCam.GetComponent<Animator>().Play("CollisionCam");
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
    }
}
