using AutoMapper;

namespace VietTour.Data.Repositories
{
	public class MainRepository
	{
		public TourRepository TourRepository { get; private set; }
		public UserRepository UserRepository { get; private set; }

		public MainRepository(ViettourContext viettourContext, IMapper mapper)
		{
			//viettourContext.Database.EnsureCreated();
			TourRepository = new TourRepository(viettourContext, mapper);
			UserRepository = new UserRepository(viettourContext, mapper);
		}
	}
}
