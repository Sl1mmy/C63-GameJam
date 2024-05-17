using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;
    [SerializeField] Animator transitionAnim;
    [SerializeField] Image image;

    public void StartGame()
    {
        StartCoroutine(LoadGame("Level1"));
    }

    public void StartEndScene()
    {
        StartCoroutine(LoadGame("End"));

    }

    IEnumerator LoadGame(string scene)
    {
        transitionAnim.SetBool("Fade", true);
        yield return new WaitUntil(() => image.color.a == 1);
        SceneManager.LoadScene(scene);
    }
}
