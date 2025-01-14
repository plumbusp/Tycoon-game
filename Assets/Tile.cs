using UnityEngine;

public class Tile : MonoBehaviour
{
    [HideInInspector] public Transform SpawnPoint;
    public Vector3 HoverScale;
    private Vector3 InitalScale;

    public SpriteRenderer SpriteRen;
    public Color HoverColor;
    [Range(0f, 1f)]
    public float HoverAlpha;

    private Color normalColor;

    private bool MouseOver = false;
    private bool CountBack = false;
    public float LerpSpeed;
    private float _final_t = 0;

    private void Start()
    {
        SpawnPoint = transform;
        normalColor = SpriteRen.color;

        HoverColor.a = HoverAlpha;

        InitalScale = transform.localScale;
    }
    void Update()
    {
        // Lerping color on hover
        if (MouseOver)
        {
            if (_final_t >= 1f) 
                return;
            _final_t += LerpSpeed;
        }
        else
        {
            if(_final_t <= 0f)
                return;
            _final_t -= LerpSpeed;
        }
        SpriteRen.color = Color.Lerp(normalColor, HoverColor, _final_t);
        transform.localScale = Vector3.Lerp(InitalScale, HoverScale, _final_t);
    }

    private void OnMouseEnter()
    {
        MouseOver = true;
    }
    private void OnMouseExit()
    {
        MouseOver = false;
    }
}
