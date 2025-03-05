using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScreenUIHandler : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
