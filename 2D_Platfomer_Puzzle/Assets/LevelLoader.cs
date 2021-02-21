using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    private TextMeshProUGUI dieText;
    
    private void Start() {
        dieText = gameObject.transform.Find("CrossFade").GetComponent<TextMeshProUGUI>();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); 
    }

    public void ReloadThisLevel()
    {
        
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
       StartCoroutine(ShowDieText());
    }

    // IEnumerator ReloadLevel(int levelIndex)
    // {
    //     //Play animation
    //     transition.SetTrigger("Start");
    //     //Wait
    //     yield return new WaitForSeconds(1);
    //     //Load scene
    //     SceneManager.LoadScene(levelIndex);
    // }

    IEnumerator ShowDieText()
    {
        //Show
        dieText.enabled = true;
        //Wait
        yield return new WaitForSeconds(1);
        dieText.enabled = false;

        //Hide
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(1);
        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
