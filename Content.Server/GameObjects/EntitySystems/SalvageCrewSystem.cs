using System;
using System.Collections.Generic;
using Robust.Shared.GameObjects.Systems;
using Robust.Shared.Maths;
using Robust.Shared.Utility;

namespace Content.Server.GameObjects.EntitySystems
{

    public class SalvageCrewSystem : EntitySystem
    {
        public struct SalvageCrewObjectShape
        {
            public Vector2i[] offsets;

            public SalvageCrewObjectShape(float n, float ne, float e, float se, float s, float sw, float w, float nw)
            {
                Vector2[] anchors_raw = new Vector2[8];
                anchors_raw[0] = new Vector2(0, -1)*n;
                anchors_raw[1] = new Vector2(1, -1)*ne;
                anchors_raw[2] = new Vector2(1, 0)*e;
                anchors_raw[3] = new Vector2(1, 1)*se;
                anchors_raw[4] = new Vector2(0, 1)*s;
                anchors_raw[5] = new Vector2(-1, 1)*sw;
                anchors_raw[6] = new Vector2(-1, 0)*w;
                anchors_raw[7] = new Vector2(-1, -1)*nw;

                List<Vector2i> positions = new List<Vector2i>();
                for (int i = 0; i < anchors_raw.Length; i++)
                {
                    var start = anchors_raw[i].ToVector2i();
                    var end = i+1 == anchors_raw.Length ? anchors_raw[0].ToVector2i() : anchors_raw[i + 1].ToVector2i();

                    positions.AddRange(GetPointsBetween(start, end));
                }

                offsets = positions.ToArray();
            }

            private static List<Vector2i> GetPointsBetween(Vector2i p1, Vector2i p2)
            {
                var step_size = 0.1f;
                var points = new List<Vector2i>();
                var pointer = p1.ToVector2();

                int CompareX(Vector2i start, Vector2i end)
                {
                    return end.X.CompareTo(start.X);
                }
                int CompareY(Vector2i start, Vector2i end)
                {
                    return end.Y.CompareTo(start.Y);
                }

                int x_comp = CompareX(p1, p2);
                int y_comp = CompareY(p1, p2);

                Vector2 delta = (p2 - p1).ToVector2() * step_size;
                var pointer_floored = pointer.ToVector2i();
                while ((x_comp != CompareX(p2, pointer_floored) || x_comp == 0) && (y_comp != CompareY(p2, pointer_floored) || y_comp == 0))
                {
                    if(!points.Contains(pointer_floored)) points.Add(pointer_floored);
                    pointer += delta;
                    pointer_floored = pointer.ToVector2i();
                }

                return points;
            }
        }
    }

    public static class SalvageCrewVectorExtensions
    {
        public static Vector2i ToVector2i(this Vector2 v) => new Vector2i((int) Math.Floor(v.X), (int) Math.Floor(v.Y));

        public static Vector2 ToVector2(this Vector2i v) => new Vector2(v.X, v.Y);
    }
}
