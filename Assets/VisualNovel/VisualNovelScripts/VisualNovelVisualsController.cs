using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Responsible for the output of the visual novel's visuals. Stores the current visual novel scene.
/// </summary>
public class VisualNovelVisualsController : MonoBehaviour
{
    [SerializeField] private TMP_Text _speechTextField;
    [SerializeField] private TMP_Text _nameTextField;
    [SerializeField] private Image _characterImageField;

    private Story _currentStory;    //the current visual novel scene
    private State _state = State.COMPLITED;
    private int _currentSentenceIndex;

    private WaitForSeconds _waitUntilNextChar = new WaitForSeconds(0.05f);
    

    public bool IsSentenceComplited() => _state == State.COMPLITED;
    public bool IsLastSentence() => _currentSentenceIndex + 1 == _currentStory.SentencesList.Count;

    /// <summary>
    /// Changes the current visual novel scene to a new one and runs its first sentence
    /// </summary>
    /// <param name="visualNovelScene"></param>
    public void PlayScene(Story visualNovelScene)
    {
        _currentStory = visualNovelScene;
        _currentSentenceIndex = -1;
        RunNextSentence();
    }
    public void RunNextSentence()
    {
        StartCoroutine(TypeText(_currentStory.SentencesList[++_currentSentenceIndex].text));
        _nameTextField.text = _currentStory.SentencesList[_currentSentenceIndex].speaker.name;
        _nameTextField.color = _currentStory.SentencesList[_currentSentenceIndex].speaker.TextColor;
        _characterImageField.sprite = _currentStory.SentencesList[_currentSentenceIndex].speaker.Sprite;
    }
    public void CompleteSentenceImmediately()
    {
        _speechTextField.text = _currentStory.SentencesList[_currentSentenceIndex].text;
        _state = State.COMPLITED;
    }

    /// <summary>
    /// Typing text of the sentence by simbols while the state is TEXTING.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private IEnumerator TypeText(string text)
    {
        _speechTextField.text = "";
        _state = State.TEXTING;

        for (int i = 0; i < text.Length; i++)
        {
            if(_state == State.COMPLITED)
            {
                break;
            }
            _speechTextField.text += text[i];
            yield return _waitUntilNextChar;
        }
        _state = State.COMPLITED;
    }

    public enum State
    {
        TEXTING,
        COMPLITED
    }
}
