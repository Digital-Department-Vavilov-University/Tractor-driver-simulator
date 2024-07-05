using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private Camera camer;
    private float height;
    [SerializeField] private Scrollbar scrollbar;

    private float Remap(float value, float minIn, float maxIn, float minOut, float maxOut)
    {
        return minOut + (value - minIn) * (maxOut - minOut) / (maxIn - minIn);
    }
    void Update()
    {
        float valueHeight = Remap(scrollbar.value, 0, 1f, 5f, 250f);
        camer.orthographicSize = valueHeight;
    }
}
