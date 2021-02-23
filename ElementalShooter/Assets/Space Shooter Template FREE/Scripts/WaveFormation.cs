using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveFormation : MonoBehaviour
{
    [SerializeField]
    List<WavePiece> wavePieces;
    [SerializeField]
    public WaveFormationType type;

    public void CreateWaveFormation(int index,float incrementX,float positionY,int countPerline,Vector3 position, UnityAction action)
    {
        StartCoroutine(wavePieces[index].CreateEnemyWave(position, incrementX, positionY, countPerline,action));
    }
}

public enum WaveFormationType { OnePerHorizonatlLine, OnePerVerticalLine, Blocks }
