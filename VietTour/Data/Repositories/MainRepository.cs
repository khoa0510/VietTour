namespace VietTour.Data.Repositories
{
	public class MainRepository
	{
		public TourRepository TourRepository { get; private set; }
		public UserRepository UserRepository { get; private set; }

		public MainRepository(ViettourContext viettourContext)
		{
			//viettourContext.Database.EnsureCreated();
			TourRepository = new TourRepository(viettourContext);
			UserRepository = new UserRepository(viettourContext);
		}
	}
}
