using Content.Server.Botany;
using Robust.Shared.IoC;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Server.GameObjects.Components.Botany
{
    public partial class SeedComponentData
    {
        [DataClassTarget("Seed")] public Seed Seed;

        public void ExposeData(ObjectSerializer serializer)
        {
            var prototypeManager = IoCManager.Resolve<IPrototypeManager>();

            serializer.DataReadFunction<string>("seed", null,
                (s) =>
                {
                    if(!string.IsNullOrEmpty(s))
                        Seed = prototypeManager.Index<Seed>(s);
                });
        }
    }
}