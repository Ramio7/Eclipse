using UnityEngine.SceneManagement;

public static class SceneSelector
{
    public static Scene ActiveScene { get; private set; }

    public static void SetMainMenuScene()
    {
        LoadScene((int)GameScens.MainMenu);
    }

    public static void SetGameScene()
    {
        LoadScene((int)GameScens.Game);
    }

    private static void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
        ActiveScene = SceneManager.GetActiveScene();
    }
}
