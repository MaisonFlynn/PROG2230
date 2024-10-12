using Microsoft.AspNetCore.Mvc;
using Ass1gnment.Models;
using Ass1gnment.Services;
using Ass1gnment.Entities;

namespace Ass1gnment.Controllers
{
    public class MeasurementController : Controller
    {
        private readonly IMeasurementService _measurementService;

        public MeasurementController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        [HttpGet("/all")]
        public IActionResult All()
        {
            var viewModel = new AllViewModel()
            {
                AllMeasurement = _measurementService.GetAllMeasurement()
            };

            return View("All", viewModel);
        }

        [HttpGet("/add")]
        public IActionResult Add()
        {
            var viewModel = new AddViewModel()
            {
                NewMeasurement = new Measurement(),
                Position = _measurementService.GetPosition()
            };

            return View("Add", viewModel);
        }

        [HttpPost("/add")]
        public IActionResult Add(AddViewModel viewModel)
        { 
            if (!ModelState.IsValid)
            {
                viewModel.Position = _measurementService.GetPosition();
                return View(viewModel);
            }
            else
            {
                _measurementService.AddMeasurement(viewModel.NewMeasurement);
                TempData["Message"] = $"+ {viewModel.NewMeasurement.Systolic}/{viewModel.NewMeasurement.Diastolic} ✓";
                return RedirectToAction("All");
            }
        }

        [HttpGet("/edit/{measurementID}")]
        public IActionResult Edit(int measurementID)
        {
            var viewModel = new EditViewModel()
            {
                CRUDMeasurement = _measurementService.GetMeasurement(measurementID),
                Position = _measurementService.GetPosition()
            };

            return View("Edit", viewModel);
        }

        [HttpPost("/edit/{measurementID}")]
        public IActionResult Edit(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Position = _measurementService.GetPosition();
                return View("Edit", viewModel);
            }
            else
            {
                _measurementService.UpdateMeasurement(viewModel.CRUDMeasurement);
                TempData["Message"] = $"Δ {viewModel.CRUDMeasurement.Systolic}/{viewModel.CRUDMeasurement.Diastolic} ✓";
                return RedirectToAction("All");
            }
        }

        [HttpGet("/delete/{measurementID}")]
        public IActionResult Delete(int measurementID)
        {
            var viewModel = new DeleteViewModel()
            {
                CRUDMeasurement = _measurementService.GetMeasurement(measurementID)
            };

            return View("Delete", viewModel);
        }

        [HttpPost("/delete/{measurementID}")]
        public IActionResult Delete(DeleteViewModel viewModel)
        {
            _measurementService.DeleteMeasurement(viewModel.CRUDMeasurement);
            TempData["Message"] = $"- {viewModel.CRUDMeasurement.Systolic}/{viewModel.CRUDMeasurement.Diastolic} ✓";
            return RedirectToAction("All");
        }
    }
}
