﻿using DualWield.Storage;
using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace DualWield.Harmony
{
    [HarmonyPatch(typeof(ThingOwner<Thing>), "Remove")]
    class ThingOwner_Remove
    {
        static void Postfix(Thing item)
        {
            if(item == null)
            {
                Log.Message("Item was null!");
            }
            ExtendedDataStorage store = Base.Instance.GetExtendedDataStorage();
            if (item is ThingWithComps eq && store.TryGetExtendedDataFor(eq, out ExtendedThingWithCompsData result))
            {
                store.DeleteExtendedDataFor(eq);
            }
        }
    }
}