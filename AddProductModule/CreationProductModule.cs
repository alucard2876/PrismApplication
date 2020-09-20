using Prism.Modularity;
using Prism.Regions;

namespace AddProductModule
{
    public class CreationProductModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public CreationProductModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(CreationProductModule), typeof(Views.CreationProduct));
        }
    }
}
