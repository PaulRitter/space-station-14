#nullable enable
using Content.Server.GameObjects.Components.MachineLinking;
using Content.Server.GameObjects.EntitySystems;
using Content.Shared.Interfaces.GameObjects.Components;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Random;

namespace Content.Server.GameObjects.Components.Salvage
{
    [RegisterComponent]
    public class SalvageMagnetComponent : Component, ISignalReceiver<bool>, IInteractHand
    {
        public override string Name => "SalvageMagnet";

        private bool _active;
        private SalvageCrewSystem.SalvageCrewAsteroid? _attachedAsteroid;
        private const int AREA_SIZE = 10;

        public void ToggleOn()
        {
            _active = !_active;
            if (_active && !ValidateArea())
            {
                _active = false;
            }
        }

        public bool ValidateArea()
        {
            //todo validate a AREA_SIZE*2 * AREA_SIZE*2 area with us in the center
            return true;
        }

        public void ToggleMagnet()
        {
            if(!_active) return;
            if(!Owner.TryGetComponent<IPhysicsComponent>(out var physComp) || !physComp.Anchored) return;

            //TODO play warning sound
            //todo delay
            if (_attachedAsteroid == null)
            {
                var grid = IoCManager.Resolve<IMapManager>().CreateGrid(Owner.Transform.MapID);
                grid.WorldPosition = Owner.Transform.WorldPosition;
                _attachedAsteroid = new SalvageCrewSystem.SalvageCrewAsteroid(grid, AREA_SIZE, IoCManager.Resolve<IRobustRandom>());
            }
            else
            {
                IoCManager.Resolve<IMapManager>().DeleteGrid(_attachedAsteroid.Value.Grid.Index);
                _attachedAsteroid = null;
            }
        }

        public void TriggerSignal(bool signal)
        {
            ToggleMagnet();
        }

        public bool InteractHand(InteractHandEventArgs eventArgs)
        {
            ToggleOn();
            return true;
        }
    }
}
