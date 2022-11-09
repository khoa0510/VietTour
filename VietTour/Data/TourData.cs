using VietTour.Models;

namespace VietTour.Data
{
	public class TourData
	{
		private readonly IConfiguration _configuration;
		private string connectionString;
		public TourData(IConfiguration configuration)
		{
			_configuration = configuration;
			connectionString = _configuration.GetValue<string>("ConnectionString");
		}
	}
}
