
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadExtractFile.Models;
using ReadExtractFile.Models.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ReadExtractFile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileRepository _fileRepository;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IFileRepository fileRepository)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _fileRepository = fileRepository;
        }

        public IActionResult Index()
        {
            var dataTransactions = _fileRepository.GetAll();
            return View("Index", dataTransactions);
        }
        [HttpPost]
        public ActionResult ReadFiles(List<IFormFile> fileupload)
        {
            IEnumerable<FinancialTransaction> ListTransactions = new List<FinancialTransaction>();

            try
            {
                if (fileupload.Count() > 0)
                {
                    List<string> PathFiles = new List<string>();

                    foreach (var file in fileupload)
                    {
                        if (file.FileName.EndsWith("ofx"))
                        {
                            var path = Path.Combine(_webHostEnvironment.ContentRootPath + "\\Files", file.FileName);

                            using (FileStream DestinationStream = new FileStream(path, FileMode.Create))
                            {
                                file.CopyToAsync(DestinationStream);
                            }

                            PathFiles.Add(path);
                        }
                        else
                        {
                            ViewBag.ErrorMessage += "<p>Arquivo inválido: " + file.FileName + "</p>";
                        }
                    }

                    if (PathFiles.Count() > 0)
                    {
                        List<FinancialTransaction> trans = _fileRepository.ReadFile(PathFiles);

                        if (trans.Count() > 0)
                        {
                            foreach (var listTrans in trans)
                            {
                                if (_fileRepository.SearchByParameter(listTrans).Count() == 0)
                                    _fileRepository.Add(listTrans);
                            }

                            ListTransactions = _fileRepository.GetAll();
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Nenhum registro encontrado";
                        }
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Nenhum arquivo selecionado.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage =
                    "Houve uma falha ao ler os arquivos" + Environment.NewLine + ex.Message.ToString();
            }

            return View("Index", ListTransactions);
        }
        public ActionResult EditObs(FinancialTransaction transaction)
        {
            try
            {
                if (transaction != null)
                {                    
                        var data = _fileRepository.GetById(transaction.ID_TRANSACTION);
                        data.OBS = transaction.OBS;

                        _fileRepository.Update(data);                    
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage =
                    "Houve uma falha ao inserir a observação" + Environment.NewLine + ex.Message.ToString();
            }

            return RedirectToAction("Index");
        }
        public ActionResult GetTransaction(int id)
        {
            FinancialTransaction dataTransactions = new FinancialTransaction();
            try
            {
                dataTransactions = _fileRepository.GetById(id);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage =
                    "Houve uma falha ao obter os dados" + Environment.NewLine + ex.Message.ToString();
            }
            return View("Edit", dataTransactions);
        }

        [HttpPost]
        public ActionResult SearchTransactions(FinancialTransaction trans)
        {
            List<FinancialTransaction> dataTransactionForDate = new List<FinancialTransaction>();

            try
            {
                if (trans.FromDate > trans.ToDate)
                {
                    ViewBag.ErrorMessage = "Informe uma data válida.";
                }
                else
                {
                    dataTransactionForDate = _fileRepository.SearchByDate(trans.FromDate, trans.ToDate);

                    if (dataTransactionForDate.Count() == 0)
                        ViewBag.ErrorMessage = "Nenhum registro encontrado";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage =
                    "Houve uma falha ao listar os registros" + Environment.NewLine + ex.Message.ToString();
            }

            return View("Index", dataTransactionForDate);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
