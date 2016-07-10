using System;
using System.Collections.Generic;
using Castle.Windsor.Installer;

namespace Pet.Assignment.IoC
{
    public class PetTestInstallerFactory : InstallerFactory
    {
        public override IEnumerable<Type> Select(IEnumerable<Type> installerTypes)
        {
            return installerTypes;
        }
    }
}
