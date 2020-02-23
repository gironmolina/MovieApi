using AutoMapper;
using MovieApi.Application.Dtos;
using MovieApi.Entities;

namespace MovieApi
{
	public static class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<RecommendationEntity, RecommendationDto>();
				cfg.CreateMap<RecommendationMovieEntity, RecommendationMovieDto>();
				cfg.CreateMap<RecommendationTvShowEntity, RecommendationTvShowDto>();
				cfg.CreateMap<RecommendationDocumentaryEntity, RecommendationDocumentaryDto>();
				cfg.CreateMap<BillboardEntity, BillboardDto>();
				cfg.CreateMap<MovieScreenEntity, MovieScreenDto>();
			});
		}
	}
}