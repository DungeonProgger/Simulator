using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    private static LoadScene instance;
    private static bool shouldPlayOpeningAnimation = false;

    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

   [SerializeField] private Slider _slider;
   [SerializeField] private Text _text;

    public static void SwitchToScene(string sceneName)
    {
        instance.componentAnimator.SetTrigger("In");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);

        instance.loadingSceneOperation.allowSceneActivation = false;

        //instance._slider.value = 0;
    }

    private void Start()
    {
        instance = this;

        componentAnimator = GetComponent<Animator>();

        if (shouldPlayOpeningAnimation)
        {
            componentAnimator.SetTrigger("Out");

            shouldPlayOpeningAnimation = false;
        }
    }

    /*private void Update()
    {
        if (loadingSceneOperation != null)
        {
            _text.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";
            
            _slider.value = Mathf.Clamp01(loadingSceneOperation.progress/ .9f);
        }
    }
    */
    public void OnAnimationOver()
    {
        shouldPlayOpeningAnimation = true;

        loadingSceneOperation.allowSceneActivation = true;
    }
}
