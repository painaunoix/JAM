
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// using Dan.Main;

// public class leaderboard : MonoBehaviour
// {
//     [SerializeField]
//     private List<TextMeshProUGUI> names;
//     [SerializeField]
//     private List<TextMeshProUGUI> scores;
//     private string publicLeaderboardkey =
//     "77f22e55683418628dab2da71b03b6a3440c5c5b81003ddbbbfabfba3d2a3da3";
    
//     private void Start() {
//         GetLeaderboard(); 
//     }
    
//     public void GetLeaderboard() {
//         LeaderboardCreator.GetLeaderboard(publicLeaderboardkey, ((msg) => {
//             int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
//             for (int i = 0; i < loopLength; i++) {
//                 names[i].text = msg[i].Username;
//                 scores[i].text = msg[i].Score.ToString();
//             }
//         }));
//     }

//     public void SetLeaderboardEntry(string username, int score) {
//         LeaderboardCreator.UploadNewEntry(publicLeaderboardkey, username, score, ((msg) => {
//             GetLeaderboard();
//         }));
//     }
// }

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;
    private string publicLeaderboardkey = "77f22e55683418628dab2da71b03b6a3440c5c5b81003ddbbbfabfba3d2a3da3";

    private void Start() {
        GetLeaderboard();
    }

    public void GetLeaderboard() {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardkey, (msg) => {
            int loopLength = Mathf.Min(msg.Length, names.Count);
            Debug.Log($"Received {msg.Length} leaderboard entries.");

            // Reset all text fields before updating
            for (int i = 0; i < names.Count; i++) {
                names[i].text = "";
                scores[i].text = "";
            }

            for (int i = 0; i < loopLength; i++) {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
                Debug.Log($"Entry {i}: {msg[i].Username} - {msg[i].Score}");
            }
        });
    }

    public void SetLeaderboardEntry(string username, int score) {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardkey, username, score, (msg) => {
            Debug.Log($"Uploaded new entry: {username} with score {score}");
            GetLeaderboard();
        });
    }
}
