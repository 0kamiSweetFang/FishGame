using UnityEngine;

public class makeSomeNoise : MonoBehaviour
{
    public miniGameHelper mgh;
    int noiseCount = 0;
    public AudioSource[] audioSources;
    int atNoise;
    public GameObject pipe;
    public int shakeAmount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            noiseCount++;
            atNoise++;
            if (atNoise >= audioSources.Length)
            {
                atNoise = 0;
            }
            audioSources[atNoise].Play();
            shakeAmount += 8;
        }
        if (noiseCount > 24)
        {
            mgh.finalScore = 1;
        }
    }

    private void FixedUpdate()
    {
        if (shakeAmount > 0)
        {
            shakeAmount--;
            pipe.transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        }
    }
}