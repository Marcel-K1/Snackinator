using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessTester : MonoBehaviour
{
    [SerializeField]
    private AudioSource audiosource;

    [SerializeField]
    private int sampleDataLength = 1024;

    [SerializeField]
    private float updateStep = 0.1f; float clipLoudness; float currentUpdateTime = 0f; float minSize = 0; float maxSize = 500f; float sizeFactor = 1f;

    [SerializeField]
    private float[] clipSampleData;

    [SerializeField]
    private Light discoLight;

    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }

    void Update()
    {
        //Audioclipdata einholen und in einen passenden float für die Anpassung an die Lichtstärke vorbereiten
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audiosource.clip.GetData(clipSampleData, audiosource.timeSamples);
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength;

            clipLoudness *= sizeFactor;
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);

            //Die Lichtintensität an die Audioclipldata anpassen
            discoLight.intensity = clipLoudness;
            float factor1 = Random.Range(0, 255);
            float factor2 = Random.Range(0, 255);
            float factor3 = Random.Range(0, 255);
            discoLight.color = new Color (clipLoudness*factor1, clipLoudness*factor2, clipLoudness*factor3);
        }
    }
}
