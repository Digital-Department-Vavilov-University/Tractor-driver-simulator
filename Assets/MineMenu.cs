
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineMenu : MonoBehaviour
{
    public void LoadScene(int indexScene = 0)
    {
        SceneManager.LoadScene(indexScene);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
