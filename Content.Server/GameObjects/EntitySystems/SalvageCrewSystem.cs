using System;
using System.Collections.Generic;
using System.Linq;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Random;

namespace Content.Server.GameObjects.EntitySystems
{

    public class SalvageCrewSystem : EntitySystem
    {
        public struct SalvageCrewAsteroid
        {
            public readonly Vector2i[] Offsets;
            public readonly IMapGrid Grid;

            public SalvageCrewAsteroid(IMapGrid grid, int maxSize, IRobustRandom random) : this(
                grid,
                random.Next(1, maxSize),
                random.Next(1, maxSize),
                random.Next(1, maxSize),
                random.Next(1, maxSize),
                random.Next(1, maxSize),
                random.Next(1, maxSize),
                random.Next(1, maxSize),
                random.Next(1, maxSize)){}

            public SalvageCrewAsteroid(IMapGrid grid, float n, float ne, float e, float se, float s, float sw, float w, float nw)
            {
                Grid = grid;
                var anchorsRaw = new Vector2[8];
                anchorsRaw[0] = new Vector2(0, -1)*n;
                anchorsRaw[1] = new Vector2(1, -1)*ne;
                anchorsRaw[2] = new Vector2(1, 0)*e;
                anchorsRaw[3] = new Vector2(1, 1)*se;
                anchorsRaw[4] = new Vector2(0, 1)*s;
                anchorsRaw[5] = new Vector2(-1, 1)*sw;
                anchorsRaw[6] = new Vector2(-1, 0)*w;
                anchorsRaw[7] = new Vector2(-1, -1)*nw;

                var positions = new HashSet<Vector2i>();
                for (int i = 0; i < anchorsRaw.Length; i++)
                {
                    var start = anchorsRaw[i].ToVector2i();
                    var end = i+1 == anchorsRaw.Length ? anchorsRaw[0].ToVector2i() : anchorsRaw[i + 1].ToVector2i();

                    positions.UnionWith(GetPointsInTriangle(start, end, (0,0)));
                }

                Offsets = positions.ToArray();
                foreach (var vec in Offsets)
                {
                    grid.SetTile(new EntityCoordinates(grid.GridEntityId, vec), new Tile(IoCManager.Resolve<ITileDefinitionManager>()["floor_steel"].TileId));
                }
            }

            private static IEnumerable<Vector2i> GetPointsBetween(Vector2i p1, Vector2i p2, float stepSize)
            {
                var points = new HashSet<Vector2i>();
                var pointer = p1.ToVector2();

                int CompareX(Vector2i start, Vector2i end)
                {
                    return end.X.CompareTo(start.X);
                }
                int CompareY(Vector2i start, Vector2i end)
                {
                    return end.Y.CompareTo(start.Y);
                }

                var xComp = CompareX(p1, p2);
                var yComp = CompareY(p1, p2);

                var delta = (p2 - p1).ToVector2() * stepSize;
                var pointerFloored = pointer.ToVector2i();
                while ((xComp != CompareX(p2, pointerFloored) || xComp == 0) && (yComp != CompareY(p2, pointerFloored) || yComp == 0))
                {
                    if (!points.Contains(pointerFloored))
                    {
                        points.Add(pointerFloored);
                        yield return pointerFloored;
                    }
                    pointer += delta;
                    pointerFloored = pointer.ToVector2i();
                }
            }

            private static HashSet<Vector2i> GetPointsInTriangle(Vector2i a, Vector2i b, Vector2i c,
                float stepSize = 0.01f)
            {
                var set = new HashSet<Vector2i>();
                foreach (var ab in GetPointsBetween(a,b, stepSize))
                {
                    set.UnionWith(GetPointsBetween(ab,c, stepSize));
                }

                return set;
            }
        }
    }

    public static class SalvageCrewVectorExtensions
    {
        public static Vector2i ToVector2i(this Vector2 v) => new Vector2i((int) Math.Floor(v.X), (int) Math.Floor(v.Y));

        public static Vector2 ToVector2(this Vector2i v) => new Vector2(v.X, v.Y);
    }
}
