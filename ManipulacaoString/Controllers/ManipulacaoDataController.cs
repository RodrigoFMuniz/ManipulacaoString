using ManipulacaoString.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ManipulacaoString.Controllers
{
    public class ManipulacaoDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Compare(InputResultModel inputResultModel)
        {
            var cultureInfo = new CultureInfo("pt-br");


            var dataLeftParsedSuccess = DateTime.TryParse(inputResultModel.InputLeft, cultureInfo, DateTimeStyles.None, out var parsedLeft);
            var dataRightParsedSuccess = DateTime.TryParse(inputResultModel.InputRight, cultureInfo, DateTimeStyles.None, out var parsedRight);

            if (!dataLeftParsedSuccess)
            {
                inputResultModel.Results = "Formato de data left errado";
                return View("Index", inputResultModel);
            }
            else if (!dataRightParsedSuccess)
            {
                inputResultModel.Results = "Formato de data right errado";
                return View("Index", inputResultModel);
            }
            var compareResult = parsedLeft == parsedRight;
            inputResultModel.Results = compareResult ? "Datas iguais" : "Datas diferentes";

            return View("Index", inputResultModel);
            
        }

        public IActionResult datePlusDays(InputResultModel inputResultModel)
        {
            var cultureInfo = new CultureInfo("pt-br");


            var dataLeftParsedSuccess = DateTime.TryParse(inputResultModel.InputLeft, cultureInfo, DateTimeStyles.None, out var parsedLeft);            

            if (!dataLeftParsedSuccess)
            {
                inputResultModel.Results = "Formato de data left errado";
                return View("Index", inputResultModel);
            }
            var rightParseDays = int.TryParse(inputResultModel.InputRight, out var parsedRight);
            if (!rightParseDays)
            {
                inputResultModel.Results = "Formato de número errado";
                return View("Index", inputResultModel);
            }

            inputResultModel.Results = parsedLeft.AddDays(parsedRight).ToString("s");

            return View("Index", inputResultModel);

        }
    }
}
