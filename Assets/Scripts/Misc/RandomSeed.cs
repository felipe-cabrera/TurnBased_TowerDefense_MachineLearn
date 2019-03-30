using System;
using UnityEngine;

public class RandomSeed : MonoBehaviour
{

    private UnityEngine.Random.State seedGenerator;
    private int seedGeneratorSeed = 1337;
    private bool seedGeneratorInitialized = false;
    
    public int GenerateSeed()
    {
        // remember old seed
        var temp = UnityEngine.Random.state;

        // initialize generator state if needed
        if (!seedGeneratorInitialized)
        {
            UnityEngine.Random.InitState(seedGeneratorSeed);
            seedGenerator = UnityEngine.Random.state;
            seedGeneratorInitialized = true;
        }

        // set our generator state to the seed generator
        UnityEngine.Random.state = seedGenerator;
        // generate our new seed
        var generatedSeed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        // remember the new generator state
        seedGenerator = UnityEngine.Random.state;
        // set the original state back so that normal random generation can continue where it left off
        UnityEngine.Random.state = temp;

        return generatedSeed;
    }

}