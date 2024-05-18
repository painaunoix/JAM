// using UnityEngine;
// using TMPro;
// using UnityEngine.Events;

// public class NewBehaviourScript : MonoBehaviour
// {
//     [SerializeField]
//     private TextMeshProUGUI inputScore;
//     [SerializeField]
//     private TMP_InputField inputName;

//     public UnityEvent<string, int> submitScoreEvent;

//     public void SubmitScore() {
//         submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
//     }
// }

using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore() {
        if (int.TryParse(inputScore.text, out int parsedScore)) {
            submitScoreEvent.Invoke(inputName.text, parsedScore);
            Debug.Log($"Score submitted: {inputName.text} with score {parsedScore}");
        } else {
            Debug.LogError("Invalid score input");
        }
    }
}
