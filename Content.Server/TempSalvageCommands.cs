using System.Linq;
using Content.Server.Administration;
using Content.Server.GameObjects.EntitySystems;
using Content.Shared.Administration;
using Robust.Shared.Console;
using Robust.Shared.IoC;
using Robust.Shared.Map;

namespace Content.Server
{
    [AdminCommand(AdminFlags.Host)]
    public class TempSalvageCommands : IConsoleCommand
    {
        public string Command => "salvagetest";
        public string Description => "salvagetest.";
        public string Help => $"{Command}";
        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            float[] distances = new float[8] {1,1,1,1,1,1,1,1};
            for (int i = 0; i < distances.Length && i < args.Length; i++)
            {
                if (int.TryParse(args[i], out var temp_dist))
                {
                    distances[i] = temp_dist;
                }
            }

            var entity = shell.Player?.AttachedEntity;
            if (entity == null) return;

            var grid = IoCManager.Resolve<IMapManager>().CreateGrid(entity.Transform.MapID);
            grid.WorldPosition = entity.Transform.WorldPosition;

            var shape = new SalvageCrewSystem.SalvageCrewAsteroid(grid, distances[0], distances[1], distances[2],
                distances[3], distances[4], distances[5], distances[6], distances[7]);

            /*var msg = "Grid:";
            for (int y = min_y; y <= max_y; y++)
            {
                msg += "\n";
                for (int x = min_x; x <= max_x; x++)
                {
                    msg += shape.offsets.FirstOrNull(v => v.X == x && v.Y == y) == null ? "=" : "X";
                }
            }

            shell.SendText(player, msg);*/
        }
    }
}
