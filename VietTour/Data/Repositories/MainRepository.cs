namespace VietTour.Data.Repositories
{
	public class MainRepository
	{
		public TourRepository tourRepository { get; private set; }

		public MainRepository(ViettourContext viettourContext)
		{
			//viettourContext.Database.EnsureCreated();
			tourRepository = new TourRepository(viettourContext);
		}
	}
}
