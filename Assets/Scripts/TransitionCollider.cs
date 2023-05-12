using UnityEngine;

public class TransitionCollider : MonoBehaviour
{
    public string sceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.FindWithTag("SceneSwitcher").GetComponent<SceneChanger>().LoadScene(sceneName);
    }
}
