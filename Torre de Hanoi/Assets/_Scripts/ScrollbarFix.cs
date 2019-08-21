using UnityEngine;
using UnityEngine.UI;

public class ScrollbarFix : MonoBehaviour
{
    [SerializeField] private Scrollbar sb;

    private void Start()
    {
        sb.value = 3;
        sb.size = 0;
    }

    public void ResetSize()
    {
        sb.size = 0;
    }
}
