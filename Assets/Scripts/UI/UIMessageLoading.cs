using UnityEngine.UI;

public class UIMessageLoading : UIBase
{
    public override UILayer Layer => UILayer.Loading;

    private Scrollbar progress;
    protected override void OnLoad()
    {
        progress = GetComponent<Scrollbar>("Scrollbar");
    }

    private int current;
    private const float valueMax = 100.0f;
    protected override void OnFixedUpdate()
    {
        progress.value = current++ / valueMax;
        if (current > valueMax)
        {
            current = 0;
        }
    }
}
