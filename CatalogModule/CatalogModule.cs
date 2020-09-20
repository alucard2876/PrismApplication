using Prism.Modularity;
using Prism.Regions;

namespace CatalogModule
{
    public class CatalogModule : IModule
    {
        private IRegionManager _regionManager;
        public CatalogModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(CatalogModule), typeof(Views.CatalogView));
        }
    }
    
}
