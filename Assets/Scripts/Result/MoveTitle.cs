using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTitle : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine("GoToTitle");
    }

    // Update is called once per frame
    void Update()
    {

    }


    

    private IEnumerator GoToTitle()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene("TitleScene");
    }
}

