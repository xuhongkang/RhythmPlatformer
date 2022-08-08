using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public List<string> words;
    public List<float> pauseDurations;
    public List<float> wordDurations;

    public LevelData()
    {
        this.words = new List<string>();
        this.pauseDurations = new List<float>();
        this.wordDurations = new List<float>();
    }

    public void ParseSentence(string s)
    {
        string[] wordsInSentence = s.Split(" ");
        for (int i = 0; i < wordsInSentence.Length; i++)
        {
            this.words.Add(wordsInSentence[i]);
        }
    }
    
    public void AddPause(float d)
    {
        this.pauseDurations.Add(d);
    }

    public void AddWord(float w)
    {
        this.wordDurations.Add(w);
    }
}
