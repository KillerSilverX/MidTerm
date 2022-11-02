using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarDie : MonoBehaviour
{
    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyStar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroyStar()
    {
        yield return new WaitForSeconds(destroyTime);
        starDie();
    }

    void starDie()
    {
        Destroy(gameObject);
    }
}
