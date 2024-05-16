using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;
    [SerializeField] Animator transitionAnim;
    [SerializeField] Image image;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Level1");
        transitionAnim.SetTrigger("Start");
    }
}
