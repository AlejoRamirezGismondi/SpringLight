using UnityEngine;

public static class PauseManager
{
    private static bool _paused;

    public static bool IsPaused()
    {
        return _paused;
    }

    public static void Pause()
    {
        _paused = true;
        Time.timeScale = 0;
    }

    public static void Resume()
    {
        _paused = false;
        Time.timeScale = 1;
    }
}