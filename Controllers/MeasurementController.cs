using Assignment1RM.Models;
using Assignment1RM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1RM.Controllers
{
    public class MeasurementController : Controller
    {
        private readonly MeasurementDbContext _measurementDbcontext;

        public MeasurementController(MeasurementDbContext measurementDbcontext)
        {
            _measurementDbcontext = measurementDbcontext;
        }

        [HttpGet("/edit/{id?}")]
        public IActionResult Edit(int id)
        {
            var measurementViewModel = new MeasurementViewModel()
            {
                ActiveMeasurement = _measurementDbcontext.Measurements.Find(id),
                Positions = _measurementDbcontext.Positions.ToList(),
            };
            return View(measurementViewModel);
        }

        [HttpPost("/edit/{id?}")]
        public IActionResult Edit(MeasurementViewModel measurementViewModel)
        {
            if (ModelState.IsValid)
            {
                _measurementDbcontext.Measurements.Update(measurementViewModel.ActiveMeasurement);
                _measurementDbcontext.SaveChanges();

                TempData["notify"] = $"BP measurement{measurementViewModel.ActiveMeasurement.Diastolic}/{measurementViewModel.ActiveMeasurement.Systolic} updated!";
                TempData["class"] = "info";

                return RedirectToAction("List", "measurements");
            }
            else
            {
                return View(measurementViewModel);
            }
        }

        [HttpGet("/delete/{id?}")]
        public IActionResult Delete(int id)
        {
            var measurementViewModel = new MeasurementViewModel()
            {
                ActiveMeasurement = _measurementDbcontext.Measurements.Find(id)
            };
            return View(measurementViewModel);
        }

        [HttpPost("/delete/{id?}")]
        public IActionResult Delete(MeasurementViewModel measurementViewModel)
        {
            _measurementDbcontext.Measurements.Remove(measurementViewModel.ActiveMeasurement);
            _measurementDbcontext.SaveChanges();

            TempData["notify"] = $"Bp measurement {measurementViewModel.ActiveMeasurement.Diastolic}/{measurementViewModel.ActiveMeasurement.Systolic} deleted!";
            TempData["class"] = "danger";

            return RedirectToAction("List", "measurements");
        }
    }
}
