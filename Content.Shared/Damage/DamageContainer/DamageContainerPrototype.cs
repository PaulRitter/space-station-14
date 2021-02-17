﻿using System;
using System.Collections.Generic;
using System.Linq;
using Robust.Shared.Interfaces.Serialization;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.ViewVariables;
using YamlDotNet.RepresentationModel;

namespace Content.Shared.Damage.DamageContainer
{
    /// <summary>
    ///     Prototype for the DamageContainer class.
    /// </summary>
    [Prototype("damageContainer")]
    [Serializable, NetSerializable]
    public class DamageContainerPrototype : IPrototype, IIndexedPrototype, IExposeData
    {
        private bool _supportAll;
        private HashSet<DamageClass> _supportedClasses;
        private HashSet<DamageType> _supportedTypes;
        [YamlField("id")]
        private string _id;

        // TODO NET 5 IReadOnlySet
        [ViewVariables] public IReadOnlyCollection<DamageClass> SupportedClasses => _supportedClasses;

        [ViewVariables] public IReadOnlyCollection<DamageType> SupportedTypes => _supportedTypes;

        [ViewVariables] public string ID => _id;

        public void ExposeData(ObjectSerializer serializer)
        {
            serializer.DataField(ref _supportAll, "supportAll", false);
            serializer.DataField(ref _supportedClasses, "supportedClasses", new HashSet<DamageClass>());
            serializer.DataField(ref _supportedTypes, "supportedTypes", new HashSet<DamageType>());

            if (_supportAll)
            {
                _supportedClasses.UnionWith(Enum.GetValues<DamageClass>());
                _supportedTypes.UnionWith(Enum.GetValues<DamageType>());
                return;
            }

            foreach (var supportedClass in _supportedClasses)
            {
                foreach (var supportedType in supportedClass.ToTypes())
                {
                    _supportedTypes.Add(supportedType);
                }
            }

            foreach (var originalType in _supportedTypes)
            {
                _supportedClasses.Add(originalType.ToClass());
            }
        }
    }
}
