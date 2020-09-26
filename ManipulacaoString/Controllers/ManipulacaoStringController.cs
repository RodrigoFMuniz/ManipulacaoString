using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManipulacaoString.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManipulacaoString.Controllers
{
    public class ManipulacaoStringController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Concat(InputResultModel manipulacaoStringModel)
        {
            
            manipulacaoStringModel.Results = manipulacaoStringModel.InputLeft + manipulacaoStringModel.InputRight;
            return View("Index", manipulacaoStringModel);
        }
        public IActionResult Compare(InputResultModel manipulacaoStringModel)
        {
            //Duas maneiras possíveis de realizar uma comparação de strings
            //var isEqual = string.Equals(manipulacaoStringModel.InputLeft, manipulacaoStringModel.InputRight, StringComparison.Ordinal);
            var isComparable = string.Compare(manipulacaoStringModel.InputLeft, manipulacaoStringModel.InputRight);
            manipulacaoStringModel.Results = isComparable != -1 ? "Igual" : "Diferente";
            return View("Index", manipulacaoStringModel);
        }
        public IActionResult CompareIgnoreCase(InputResultModel manipulacaoStringModel)
        {
            var isEqual = string.Equals(manipulacaoStringModel.InputLeft, manipulacaoStringModel.InputRight, StringComparison.OrdinalIgnoreCase);
            manipulacaoStringModel.Results = isEqual ? "Igual" : "Diferente";
            return View("Index", manipulacaoStringModel);
        }
    }
}
