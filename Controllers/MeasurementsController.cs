using Assignment1RM.Entities;
using Assignment1RM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment1RM.Controllers
{
	public class MeasurementsController : Controller
	{
		private readonly MeasurementDbContext _measurementDbcontext;

		public MeasurementsController(MeasurementDbContext measurementDbcontext)
		{
			_measurementDbcontext = measurementDbcontext;
		}


		[HttpGet("/measurements")]
		public IActionResult List()
		{
			var measurementsViewModel = new MeasurementsViewModel()
			{
				Measurements = _measurementDbcontext.Measurements.Include(m => m.Position).ToList(),
			};
			return View(measurementsViewModel);
		}


        [HttpGet("/add")]
        public IActionResult Add()
        {
            var measurementViewModel = new MeasurementViewModel()
            {
                ActiveMeasurement = new Measurement(),
				Positions = _measurementDbcontext.Positions.ToList()
            };
            return View(measurementViewModel);
        }


        [HttpPost("/add")]
        public IActionResult Add(MeasurementViewModel measurementViewModel)
        {
            
            if (ModelState.IsValid)
            {
                _measurementDbcontext.Measurements.Add(measurementViewModel.ActiveMeasurement);
                _measurementDbcontext.SaveChanges();


                TempData["message"] = $"BP measurement {measurementViewModel.ActiveMeasurement.Systolic}/{measurementViewModel.ActiveMeasurement.Diastolic} added!";
                TempData["class"] = "success";

                return RedirectToAction("List", "Measurements");
            }
            else
            {
             
                measurementViewModel.Positions = _measurementDbcontext.Positions.ToList();
                return View(measurementViewModel);
            }
        }

    }
}
