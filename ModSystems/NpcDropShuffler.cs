using System.Collections.Generic;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;

namespace TRand.ModSystems;

public class NpcDropShuffler : IdShuffler
{
    protected override int count => NPCID.Count;

    protected override void Register()
    {
        base.Register();
        On_ItemDropDatabase.GetRulesForNPCID += OnGetRulesForNPCID;
    }

    private List<IItemDropRule> OnGetRulesForNPCID(On_ItemDropDatabase.orig_GetRulesForNPCID orig, ItemDropDatabase self, int npcnetid, bool includeglobaldrops)
    {
        return orig(self, data != null && npcnetid >= 0 ? data[npcnetid] : npcnetid, includeglobaldrops);
    }
}