using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    [SerializeField] string m_changeSceneName;

    public void SceneChange()
    {
        SceneManager.LoadSceneAsync(m_changeSceneName);
    }
}
