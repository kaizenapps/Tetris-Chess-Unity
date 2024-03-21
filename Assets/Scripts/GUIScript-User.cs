using UnityEngine;

// ReSharper disable once InconsistentNaming
// ReSharper disable once CheckNamespace
public class GUIScriptUser : MonoBehaviour
{
    private bool gameover;
    private float avgBlockPerMin;
    private float avgRowsPerMin;
    private float blockSpawned = 1;
    private float fourRowsCleared;
    private float labelLeftMargin;
    private float oneRowsCleared;
    private float points = 0;
    private float rowsPerMin = 0;
    private float startTime;
    private float threeRowsCleared;
    private float time;
    private float twoRowsCleared;
    private int block = 0;
    private int fitness;
    private int rowscleared;
    private Rect autoplayRect;
    private Rect avgBlockRect;
    private Rect avgRowRect;
    private Rect blockRect;
    private Rect creditRect;
    private Rect creditwwwRect;
    private Rect fitnessRowRect;
    private Rect fourRowRect;
    private Rect gameoverRect;
    private Rect oneRowRect;
    private Rect settingsBoxRect;
    private Rect speedLabelRect;
    private Rect speedRect;
    private Rect statsBoxRect;
    private Rect threeRowRect;
    private Rect timeRunningRect;
    private Rect totalRowRect;
    private Rect twoRowRect;
    private static bool autoPlayEnabled = false;
    private static float speedHSliderValue = 1f;

    // ReSharper disable once UnusedMember.Local
    private void Start()
    {

    }

    // ReSharper disable once UnusedMember.Local
    // ReSharper disable once InconsistentNaming
    private void OnGUI()
    {
        this.time = Time.time - this.startTime;
        this.avgBlockPerMin = this.blockSpawned / this.time * 60;

        if (this.gameover)
        {
            GUI.Label(this.gameoverRect, "Gameover starting over soon");
        }

        GUI.Box(this.statsBoxRect, string.Empty);
        autoPlayEnabled = GUI.Toggle(this.autoplayRect, autoPlayEnabled, string.Format("Auto play {0}", autoPlayEnabled ? "ON" : "OFF"));

    }

    public bool IsAutoPlay()
    {
        return autoPlayEnabled;
    }

    public void ToogleGameover()
    {
        this.gameover = true;
    }

    public void UpdateScore(Tetris.Engine.GameStats gameResult)
    {
        this.rowscleared = gameResult.TotalRowClearings;
        this.fitness = gameResult.Fitness;
        this.oneRowsCleared = gameResult.OneRowClearings;
        this.twoRowsCleared = gameResult.TwoRowsClearings;
        this.threeRowsCleared = gameResult.ThreeRowsClearings;
        this.fourRowsCleared = gameResult.FourRowsClearings;
        this.blockSpawned = gameResult.BlocksSpawned;
    }

    public float GetGameSpeed()
    {
        return speedHSliderValue;
    }

    private static string PrettyTime(int time)
    {
        var sec = time % 60;
        var min = time % 3600 / 60;
        var hour = time / 3600;

        return string.Format(
            "{0}:{1}:{2}",
            hour.ToString().PadLeft(2, '0'),
            min.ToString().PadLeft(2, '0'),
            sec.ToString().PadLeft(2, '0'));
    }
}
