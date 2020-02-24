using NUnit.Framework;
using Unity;

namespace MovieApi.Test
{
	[SetUpFixture]
	public class TestSetup
	{
		public static IUnityContainer Container { get; private set; }

		[OneTimeSetUp]
		public static void ConfigureDependencies()
		{
			AutoMapperConfig.RegisterMappings();
			Container = new UnityContainer();
			UnityConfig.RegisterTypes(Container);
		}
	}
}
