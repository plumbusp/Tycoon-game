using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu (fileName = "New StoryScene", menuName = "VisualNovel/StoryScene")]
public class Story : ScriptableObject
{
    public Story NextStoryScene;
    public List<Sentence> SentencesList;
}

[Serializable]
public struct Sentence
{
    public string text;
    public Speaker speaker;
}