using System;
using MovieApi.Application.Interfaces;
using MovieApi.Application.Services;
using MovieApi.CrossCutting.Helpers;
using MovieApi.CrossCutting.Interfaces;
using MovieApi.Domain.Interfaces;
using MovieApi.Domain.Services;
using MovieApi.Infrastructure.Interfaces;
using MovieApi.Infrastructure.Repositories;
using Unity;

namespace MovieApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
	        // Application Services
	        container.RegisterType<IViewerAppService, ViewerAppService>();
	        container.RegisterType<ITheatreManagerAppService, TheatreManagerAppService>();

	        // Domain Services
	        container.RegisterType<IViewerService, ViewerService>();
	        container.RegisterType<ITheatreManagerService, TheatreManagerService>();
	        container.RegisterType<IWeekBoardService, WeekBoardService>();
	        container.RegisterType<IWeekDatesService, WeekDatesService>();

	        // Repositories
	        container.RegisterType<IMoviesRepository, MoviesRepository>();

	        // Cross-cutting
	        container.RegisterType<IAppConfigSettings, AppConfigSettings>();
        }
    }
}