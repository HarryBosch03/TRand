using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TRand.ModSystems;

public abstract class IdShuffler : ModSystem
{
    public static int[] data;

    protected abstract int count { get; }
    protected virtual string key => $"{GetType().FullName}.data";

    public override void ClearWorld()
    {
        data = null;
    }

    public override void SaveWorldData(TagCompound tag)
    {
        tag[key] = data;
    }
    
    public override void LoadWorldData(TagCompound tag)
    {
        if (tag.ContainsKey(key))
            data = tag.GetIntArray(key);
    }
    
    public override void OnWorldLoad()
    {
        if (data == null)
            GenerateData();
    }

    public void GenerateData()
    {
        data = new int[count];
        var pool = new List<int>();
        while(pool.Count < count) pool.Add(pool.Count);

        for (var i = 0; i < count; i++)
        {
            var j = Terraria.Main.rand.Next(pool.Count);
            data[i] = pool[j];
            pool.RemoveAt(j);
        }
    }
}