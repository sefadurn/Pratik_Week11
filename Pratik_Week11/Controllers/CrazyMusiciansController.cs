using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pratik_Week11.Models;

namespace Pratik_Week11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrazyTaskItemsController : ControllerBase
    {

        public static List<TaskItem> TaskItem = new List<TaskItem>
        {
         new TaskItem { Id = 1, Name = "Ahmet Çağlı", Job = "Ünlü Çağlı Çalar", FunFeature = "Her zaman yanlış nota çalar, ama çok eğlencelidir" },
        new TaskItem { Id = 2, Name = "Zeynep Melodi", Job = "Popüler Melodi Yazan", FunFeature = "Şarkıları yanlış anlaşılır ama çok popülerdir" },
        new TaskItem { Id = 3, Name = "Cemil Akor", Job = "Çılgın Akorist", FunFeature = "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli" },
        new TaskItem { Id = 4, Name = "Fatma Nota", Job = "Sürpriz Nota Üreticisi", FunFeature = "Nota üretirken sürekli sürprizler hazırlar" },
        new TaskItem { Id = 5, Name = "Hasan Ritim", Job = "Ritim Canavanı", FunFeature = "Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir" },
        new TaskItem { Id = 6, Name = "Elif Armoni", Job = "Armoni Ustası", FunFeature = "Armonilerini bazen yanlış çalar, ama çok yaratıcıdır" },
        new TaskItem { Id = 7, Name = "Ali Perde", Job = "Perde Uygulayıcı", FunFeature = "Her perdeyi farklı şekilde çalar, her zaman sürprizlidir" },
        new TaskItem { Id = 8, Name = "Ayşe Rezonans", Job = "Rezonans Uzmanı", FunFeature = "Rezonansı konusunda uzman, ama bazen çok gürültü çıkarır" },
        new TaskItem { Id = 9, Name = "Murat Ton", Job = "Tonlama Meraklısı", FunFeature = "Tonlamalardaki farklılıklar bazen komik, ama oldukça ilginç" },
        new TaskItem { Id = 10, Name = "Selin Akor", Job = "Akor Sihirbazı", FunFeature = "Akorları değiştirdiğinde bazen sihirli bir hava yaratır" }
        };

        [HttpGet]
        public IActionResult GetAll()  // Tüm müzisyenleri listeler.
        { 
            return Ok(TaskItem);
        }

        [HttpGet("{id}")]  // Id parametresi ile belirli bir müzisyeni getiririz.
        public IActionResult Get(int id)
        {
            var musician = TaskItem.FirstOrDefault(x => x.Id == id); // Id parametresi ile müzisyeni listeden bul.
            if(musician == null) // Eğer bulunamazsa 404 NotFound dön.
                return NotFound();
            return Ok(musician);
        }

        [HttpGet("search")]   // FromQuery yapısı istenmişti soruda.
        public IActionResult Search([FromQuery] string name)
        {
            var results = TaskItem
                .Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Ok(results);

        }

        [HttpPost]
        public IActionResult Create(TaskItem taskItem)
        {
            taskItem.Id = TaskItem.Max(x => x.Id) + 1; // Id'yi otomatik arttır.
            TaskItem.Add(taskItem); // Yeni müsiyeni listeye ekle.
            return Ok();
        }

        [HttpPut("{id}")]  // Belirtilen Id'deki müzisyenin tüm bilgilerini günceller.
        public IActionResult Update(int id, TaskItem updated)
        {
            var musician = TaskItem.FirstOrDefault(x=> x.Id == id);
            if (musician == null)
                return NotFound();
            // Aşağıdaki bilgileri günceller.
            musician.Name = updated.Name;
            musician.Job = updated.Job;
            musician.FunFeature = updated.FunFeature;
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, string funFeature ) // Sadece belirli bir alanı yani FunFeature alanını güncelleriz.
        {
            var musician = TaskItem.FirstOrDefault(x=> x.Id == id);
            if(musician ==null)
                return NotFound();

            musician.FunFeature = funFeature;
            return Ok(musician);
        }

        [HttpDelete("{id}")] // verilen müzisyeni sileriz.
        public IActionResult Delete(int id)
        {
            var musician = TaskItem.FirstOrDefault(x=> x.Id ==id);
            if(musician == null)
                return NotFound();
            TaskItem.Remove(musician);
            return NoContent();
        }
    }
}
