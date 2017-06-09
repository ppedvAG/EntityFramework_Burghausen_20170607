using Kammmolch.Core;
using Kammmolch.Core.Interfaces;
using Kammmolch.Core.Services;
using Kammmolch.Data;
using Kammmolch.Data.Shared.Interfaces;
using Kammmolch.Data.Shared.Services;
using StructureMap;

namespace Kammmolch.UI.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel Main { get; }

        public ViewModelLocator()
        {
            var container = new Container(c =>
            {
                c.For<IIdentityManger>().Use<IdentityManager>();
                c.For<IDatetimeManager>().Use<DatetimeManager>();
                c.For<IChangesFinder>().Use<ChangesFinder>();
                c.For<IChangesLogger>().Use<OutputChangesLogger>();
                c.For<IUnitOfWork>().Use<UnitOfWork>();
            });

            Main = container.GetInstance<MainWindowViewModel>();
        }
    }
}
