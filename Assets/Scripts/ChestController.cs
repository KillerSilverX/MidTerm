using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestController : MonoBehaviour
{
    public Animator animator;
    public GameObject star;
    public Transform startPos;

    public float starSpeed, starGen, startImpulso;

    public bool chestOpen = false;

    void Update()
    {
        if (chestOpen == true)
        {
            StartCoroutine(CreateStar());
        }
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            animator.SetBool("OpenChest", true);

            chestOpen = true;
            
        }
    }

    IEnumerator CreateStar()
    {
        GameObject newStar = Instantiate(star, startPos.position, Quaternion.identity);
        yield return new WaitForSeconds(starGen);
        newStar.GetComponent<Rigidbody2D>().velocity = new Vector2 (starSpeed * Time.fixedDeltaTime, startImpulso * starSpeed);
    }
}
