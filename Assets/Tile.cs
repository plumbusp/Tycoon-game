using UnityEngine;

public class Tile : MonoBehaviour
{
    [HideInInspector] public Transform SpawnPoint;
    public Vector3 HoverScale;
    private Vector3 InitalScale;

    public SpriteRenderer SpriteRen;
    private Color TargetColor;
    public Color HoverColor;
    [Range(0f, 1f)]
    public float HoverAlpha;
    public Color PresedColor;

    private Color normalColor;

    private bool MouseOver = false;
    private bool CountBack = false;
    public float LerpSpeed;
    private float _final_t = 0;
    private bool IsPressed;

    public static Tile SelectedTile { get; private set; }

    private void Start()
    {
        SpawnPoint = transform;
        normalColor = SpriteRen.color;

        HoverColor.a = HoverAlpha;
        TargetColor = HoverColor;

        InitalScale = transform.localScale;
    }
    //void Update()
    //{
    //    SpriteRen.color = Color.Lerp(normalColor, TargetColor, _final_t);

    //    if (IsPressed)
    //        return;
    //    // Lerping color on hover
    //    if (MouseOver)
    //    {
    //        if (_final_t >= 1f) 
    //            return;
    //        _final_t += LerpSpeed;
    //    }
    //    else
    //    {
    //        if(_final_t <= 0f)
    //            return;
    //        _final_t -= LerpSpeed;
    //    }
    //    transform.localScale = Vector3.Lerp(InitalScale, HoverScale, _final_t);
    //}

    public void Select()
    {
        TargetColor = PresedColor;
        IsPressed = true;
        transform.localScale = HoverScale;
    }
    public void Desellect()
    {
        TargetColor = HoverColor;
        IsPressed = false;
        transform.localScale = InitalScale;
    }
    //private void OnMouseUp()
    //{
    //    TargetColor = HoverColor;
    //    IsPressed = false;
    //}
}
