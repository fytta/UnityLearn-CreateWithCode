using TMPro;
using UnityEngine;

public class Box : MonoBehaviour
{
    public TextMeshPro scoreText;

    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetText(_score.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        _score++;
        scoreText.SetText(_score.ToString());
    }
}
