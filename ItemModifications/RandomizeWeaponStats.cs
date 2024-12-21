using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRand.ItemModifications;

public class RandomizeWeaponStats : ModSystem
{
    private static List<int> idList = new List<int>();
    private static Dictionary<int, ItemStats> stats = new Dictionary<int, ItemStats>();

    public static float variance = 0f;
    
    protected override void Register()
    {
        base.Register();

        for (var i = 0; i < ItemID.Count; i++)
        {
            var item = new Item(i);
            if (item.damage > 0)
            {
                idList.Add(i);
            }
        }

        foreach (var id in idList)
        {
            stats.Add(id, new ItemStats());
        }
    }

    public override void OnWorldLoad()
    {
        var rand = new System.Random(Terraria.WorldGen.currentWorldSeed.GetHashCode());
        foreach (var id in idList)
        {
            stats[id] = new ItemStats()
            {
                damageScalar = 
            }
        }
    }

    public float GetRandomScalar(System.Random random)
    {
        var v = (float)random.NextDouble();
        return MathF.Tan(MathF.PI * (v + 0.5f)) * variance;
    }

    public struct ItemStats
    {
        public float damageScalar;
    }
}