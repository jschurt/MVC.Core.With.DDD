using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solution.Domain.Entities;
using Solution.Domain.Interfaces.Services;
using Solution.WebUI.ViewModels;

namespace Solution.WebUI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IMapper _mapper;

        //(I) Numa abordagem simples, poderiamos estar acoplados 
        //diretamente a camada de infraestrutura (nao recomendavel)
        //private readonly IProdutoRepository _repository;

        //public ProdutoController(IMapper mapper, IProdutoRepository repository)
        //{
        //    _mapper = mapper;
        //    _repository = repository;
        //} //constructor


        //(II) Numa abordagem de Clean Architecture (simplificando o DDD)
        //poderiamos estar acoplados diretamente ao servico na camada dominio
        private readonly IProdutoService _domainProdutoService;
        private readonly IClienteService _domainClienteService;

        public ProdutoController(IMapper mapper, IProdutoService domainProdutoService, IClienteService domainClienteService)
        {
            _mapper = mapper;
            _domainProdutoService = domainProdutoService;
            _domainClienteService = domainClienteService;
        } //constructor


        //(III) Numa abordagem de DDD o acoplamento ocorrera 
        //ao servico na camada de aplicacao
        //private readonly IProdutoService _applicationService;

        //public ProdutoController(IMapper mapper, IProdutoService applicationService)
        //{
        //    _mapper = mapper;
        //    _applicationService = applicationService;
        //} //constructor



        // GET: Produto
        public ActionResult Index()
        {
            //For One object
            //Produto Produto = new Produto {Nome = "Julio", Sobrenome = "Schurt", Email = "julio.schurt@email.com" };
            //ProdutoViewModel model1 = _mapper.Map<ProdutoViewModel>(Produto);


            //For IEnumerable

            //Abordagem (I) - Via acesso direto repository
            //IEnumerable<ProdutoViewModel> model = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_repository.GetAll());

            //Abordagem (II) - Clean Architecture - Via acesso servico camada dominio 
            IEnumerable<ProdutoViewModel> model = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_domainProdutoService.GetAll(true));

            //Abordagem (III) - DDD - Via acesso servico camada aplicacao
            //IEnumerable<ProdutoViewModel> model = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_applicationService.GetAll());

            return View(model);
        } //Index

        // GET: Produto/Details/5
        public ActionResult Details(long id)
        {
            Produto ProdutoDomain = _domainProdutoService.GetById(id);
            ProdutoViewModel model = _mapper.Map<Produto, ProdutoViewModel>(ProdutoDomain);

            return View(model);

        } //Details

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.Clientes = _domainClienteService.GetAll();
            return View();
        } //Create

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel Produto)
        {
            if (ModelState.IsValid)
            {
                var clientDomain = _mapper.Map<ProdutoViewModel, Produto>(Produto);

                //Abordagem (I) - Via acesso direto repository
                //_repository.Add(clientDomain);

                //Abordagem(II) - Clean Architecture - Via acesso servico camada dominio            
                _domainProdutoService.Add(clientDomain);

                //Abordagem (III) - DDD - Via acesso servico camada aplicacao
                //_applicationService.Add(clientDomain);

                return RedirectToAction(nameof(Index));

            } //if

            ViewBag.Clientes = _domainClienteService.GetAll();
            return View(Produto);

        } //Create

        // GET: Produto/Edit/5
        public ActionResult Edit(long id)
        {
            ViewBag.Clientes = _domainClienteService.GetAll();
            Produto ProdutoDomain = _domainProdutoService.GetById(id);
            ProdutoViewModel model = _mapper.Map<Produto, ProdutoViewModel>(ProdutoDomain);

            return View(model);
        } //Edit

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel Produto)
        {

            if (ModelState.IsValid)
            {
                var clientDomain = _mapper.Map<ProdutoViewModel, Produto>(Produto);

                //Abordagem (I) - Via acesso direto repository
                //_repository.Update(clientDomain);

                //Abordagem(II) - Clean Architecture - Via acesso servico camada dominio            
                _domainProdutoService.Update(clientDomain);

                //Abordagem (III) - DDD - Via acesso servico camada aplicacao
                //_applicationService.Update(clientDomain);

                return RedirectToAction(nameof(Index));

            } //if

            ViewBag.Clientes = _domainClienteService.GetAll();
            return View(Produto);

        } //Edit

        // GET: Produto/Delete/5
        public ActionResult Delete(long id)
        {

            Produto ProdutoDomain = _domainProdutoService.GetById(id);
            ProdutoViewModel model = _mapper.Map<Produto, ProdutoViewModel>(ProdutoDomain);

            return View(model);

        } //Delete

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {

            Produto ProdutoDominio = _domainProdutoService.GetById(id);
            _domainProdutoService.Remove(ProdutoDominio);

            return RedirectToAction(nameof(Index));

        } //DeleteConfirmed

    } //class

} //namespace