#nullable enable
using System;
using System.Collections.Generic;
using Content.Server.Atmos;
using Robust.Shared.GameObjects.Components.Map;
using Robust.Shared.Interfaces.Serialization;
using Robust.Shared.Log;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Server.GameObjects.Components.Atmos
{
    public partial class GridAtmosphereComponentData
    {
        public struct IntermediateTileAtmosphere : IDeepClone
        {
            public readonly Vector2i Indicies;
            public readonly GasMixture GasMixture;

            public IntermediateTileAtmosphere(Vector2i indicies, GasMixture gasMixture)
            {
                Indicies = indicies;
                GasMixture = gasMixture;
            }

            public IDeepClone DeepClone()
            {
                return new IntermediateTileAtmosphere(
                    IDeepClone.CloneValue(Indicies),
                    IDeepClone.CloneValue(GasMixture)!
                );
            }
        }

        [CustomYamlField("Tiles")] private List<GridAtmosphereComponentData.IntermediateTileAtmosphere> TilesReceiver = new();

        public override void ExposeData(ObjectSerializer serializer)
        {
            base.ExposeData(serializer);
            if (serializer.Reading)
            {
                if (!serializer.TryReadDataField("uniqueMixes", out List<GasMixture>? uniqueMixes) ||
                    !serializer.TryReadDataField("tiles", out Dictionary<Vector2i, int>? tiles))
                    return;

                TilesReceiver.Clear();

                foreach (var (indices, mix) in tiles!)
                {
                    try
                    {
                        TilesReceiver.Add(new IntermediateTileAtmosphere(indices, uniqueMixes![mix]));
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Logger.Error($"Error during atmos serialization! Tile at {indices} points to an unique mix ({mix}) out of range!");
                        throw;
                    }
                }
            }
            else if (serializer.Writing)
            {
                var uniqueMixes = new List<GasMixture>();
                var uniqueMixHash = new Dictionary<GasMixture, int>();
                var tiles = new Dictionary<Vector2i, int>();
                foreach (var intermediateTileAtmosphere in TilesReceiver)
                {
                    if (uniqueMixHash.TryGetValue(intermediateTileAtmosphere.GasMixture, out var index))
                    {
                        tiles[intermediateTileAtmosphere.Indicies] = index;
                        continue;
                    }

                    uniqueMixes.Add(intermediateTileAtmosphere.GasMixture);
                    var newIndex = uniqueMixes.Count - 1;
                    uniqueMixHash[intermediateTileAtmosphere.GasMixture] = newIndex;
                    tiles[intermediateTileAtmosphere.Indicies] = newIndex;
                }

                serializer.DataField(ref uniqueMixes, "uniqueMixes", new List<GasMixture>());
                serializer.DataField(ref tiles, "tiles", new Dictionary<Vector2i, int>());
            }
        }

    }
}
