using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
