using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadScene2 : MonoBehaviour
{ 
    IEnumerator Example()
    {
        yield return new WaitForSeconds(10);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Example());
            SceneManager.LoadScene("Level 2");
        }
    }
}
