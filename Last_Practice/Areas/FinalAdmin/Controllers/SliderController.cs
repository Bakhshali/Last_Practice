using Last_Practice.Areas.FinalAdmin.Extensions;
using Last_Practice.Areas.FinalAdmin.Utilities;
using Last_Practice.DAL;
using Last_Practice.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Last_Practice.Areas.FinalAdmin.Controllers
{
    [Area("FinalAdmin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult>  Index()
        {
            List<Slider> slider = await _context.Sliders.ToListAsync();
            return View(slider);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();

            if (slider.Photo!=null)
            {
                if (!slider.Photo.IsOkay(1))
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa duzgun sekil formati secin");
                    return View();
                }

                slider.Image = await slider.Photo.FileCreate(_env.WebRootPath, @"assets\img\slider");

            }
            else
            {
                ModelState.AddModelError("Photo", "Sekil secin!");
                return View();
            }

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();  
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            return View(slider);
        }


        public async Task<IActionResult> Edit(int id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Slider slider, int id)
        {
            if (!ModelState.IsValid) return View();

            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(e => e.Id == id);
            if (id!=existedSlider.Id) return BadRequest(); 
            if (existedSlider == null) return NotFound();

            existedSlider.Title = slider.Title;
            existedSlider.Subtitle = slider.Subtitle;

            if (slider.Photo!=null)
            {
                if (slider.Photo.IsOkay(1))
                {
                    existedSlider.Image = await slider.Photo.FileCreate(_env.WebRootPath, @"assets\img\slider");
                }
                else
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa duzgun sekil formati secin");
                    return View();
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
