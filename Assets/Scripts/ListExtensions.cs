using System;
using System.Collections.Generic;

namespace MainGameNamespace{
    public static class ListExtensions{
    private static Random random = new Random();
    public static T GetRandomItem<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
            throw new ArgumentException("List cannot be null or empty");
            
        int index = random.Next(list.Count);
        return list[index];
    }
    public static void Shuffle<T>(this List<T> list)
{
    Random random = new Random();
    int n = list.Count;
    
    for (int i = n - 1; i > 0; i--)
    {
        // Pick a random index from 0 to i
        int j = random.Next(0, i + 1);
        
        // Swap list[i] and list[j]
        T temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
}
}
