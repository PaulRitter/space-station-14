using System;
using System.Collections.Generic;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Server.GameObjects.Components.AI
{
    public partial class AiFactionTagComponentData
    {
        [CustomYamlField("factions")]
        public Faction Factions { get; private set; } = Faction.None;

        public override void ExposeData(ObjectSerializer serializer)
        {
            base.ExposeData(serializer);

            serializer.DataReadWriteFunction(
                "factions",
                new List<Faction>(),
                factions => factions.ForEach(faction => Factions |= faction),
                () =>
                {
                    var writeFactions = new List<Faction>();
                    foreach (Faction fac in Enum.GetValues(typeof(Faction)))
                    {
                        if ((Factions & fac) != 0)
                        {
                            writeFactions.Add(fac);
                        }
                    }

                    return writeFactions;
                });
        }
    }
}