﻿using KristofferStrube.Blazor.WebWorkers;

public class StringSumJob : JsonJob<string, int>
{
    public override int Work(string input)
    {
        int result = 0;
        for (int i = 0; i < input.Length; i++)
        {
            result += input[i];
        }
        return result;
    }
}