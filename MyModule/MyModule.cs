using Prism.Modularity;
using Prism.Regions;

namespace MyModule
{
    public class MyModule : IModule
    {
        private IRegionManager _regionManager;

        public MyModule()
        {
        }

        public MyModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void Initialize()
        {
            
            _regionManager.RegisterViewWithRegion(nameof(MyModule), typeof(Views.MyModule));
            
        }
    }
}
