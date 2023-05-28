using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private static LoadScene instance;
    private static bool shouldPlayOpeningAnimation = false;

    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

    public static void SwitchToScene(string sceneName)
    {
        instance.gameObject.SetActive(true);
        instance.componentAnimator.SetTrigger("In");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);

        instance.loadingSceneOperation.allowSceneActivation = false;
    }

    private void Start()
    {
        instance = this;
        instance.gameObject.SetActive(false);

        componentAnimator = GetComponent<Animator>();

        if (shouldPlayOpeningAnimation)
        {
            instance.gameObject.SetActive(true);
            componentAnimator.SetTrigger("Out");

            shouldPlayOpeningAnimation = false;
        }
    }
    public void OnAnimationOver()
    {
        shouldPlayOpeningAnimation = true;

        loadingSceneOperation.allowSceneActivation = true;
    }
}
