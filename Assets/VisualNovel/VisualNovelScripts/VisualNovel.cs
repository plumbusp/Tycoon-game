using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Controls the visual novel flow, responsible for switching its fragments
/// </summary>

[RequireComponent(typeof(VisualNovelVisualsController))]
public class VisualNovel : MonoBehaviour
{
    [SerializeField] private GameObject _Tutorial;
    [SerializeField] private string _NextSceneName;  // Name of the scene for the screen loader to load after the visual novel has finished.
    [SerializeField] private Story _BegginingStoryScene;
    [SerializeField] private Button _changeButton; //Stroy Scene change button

    private Story _currentStoryScene;
    private VisualNovelVisualsController _speechPanelController;

    private void Start()
    {
        _speechPanelController = GetComponent<VisualNovelVisualsController>();
        _currentStoryScene = _BegginingStoryScene;
        _speechPanelController.PlayScene(_currentStoryScene);
        _changeButton.onClick.AddListener(HandleSkip);

        _Tutorial.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            HandleSkip();
        }
    }

    private void HandleSkip()
    {
        if (_speechPanelController.IsSentenceComplited())
        {
            if (_speechPanelController.IsLastSentence())
            {
                if (_currentStoryScene.NextStoryScene == null)
                {
                    SceneManager.LoadScene(_NextSceneName);
                }

                else
                {
                    _currentStoryScene = _currentStoryScene.NextStoryScene;
                    _speechPanelController.PlayScene(_currentStoryScene);
                }
            }
            else
            {
                _speechPanelController.RunNextSentence();
            }
        }
        else
        {
            _speechPanelController.CompleteSentenceImmediately();
        }
    }
}
