using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(nameof(LoadingCoroutine));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadingCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync("SampleScene");
    }
}
