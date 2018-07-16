using Resolver;
using System.ComponentModel.Composition;

namespace Evolent.BusinessLogic
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IContactServices, ContactService>();

        }
    }
}
