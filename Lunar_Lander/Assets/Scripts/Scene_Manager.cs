using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static void ChangeToGameScene() 
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);        
    }

    public static void ChangeToCreditsScene() 
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public static void ChangeToMenuScene() 
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public static void QuitGame() 
    {
        Application.Quit();
    }
}
