using UnityEngine;

[CreateAssetMenu (fileName = "New Speaker", menuName = "VisualNovel/Speaker")]
public class Speaker : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public Color TextColor { get; private set; }
}
