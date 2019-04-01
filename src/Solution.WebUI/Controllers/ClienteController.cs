using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solution.Domain.Entities;
using Solution.Domain.Interfaces.Services;
using Solution.WebUI.ViewModels;
using System.Collections.Generic;

namespace Solution.WebUI.Controllers
{
    public class ClienteController : Controller
    {

        private readonly IMapper _mapper;

        //(I) Numa abordagem simples, poderiamos estar acoplados 
        //diretamente a camada de infraestrutura (nao recomendavel)
        //private readonly IClienteRepository _repository;

        //public ClienteController(IMapper mapper, IClienteRepository repository)
        //{
        //    _mapper = mapper;
        //    _repository = repository;
        //} //constructor


        //(II) Numa abordagem de Clean Architecture (simplificando o DDD)
        //poderiamos estar acoplados diretamente ao servico na camada dominio
        private readonly IClienteService _domainService;

        public ClienteController(IMapper mapper, IClienteService domainService)
        {
            _mapper = mapper;
            _domainService = domainService;
        } //constructor

        //(III) Numa abordagem de DDD o acoplamento ocorrera 
        //ao servico na camada de aplicacao
        //private readonly IClienteService _applicationService;

        //public ClienteController(IMapper mapper, IClienteService applicationService)
        //{
        //    _mapper = mapper;
        //    _applicationService = applicationService;
        //} //constructor



        // GET: Cliente
        public ActionResult Index()
        {
            //For One object
            //Cliente cliente = new Cliente {Nome = "Julio", Sobrenome = "Schurt", Email = "julio.schurt@email.com" };
            //ClienteViewModel model1 = _mapper.Map<ClienteViewModel>(cliente);


            //For IEnumerable

            //Abordagem (I) - Via acesso direto repository
            //IEnumerable<ClienteViewModel> model = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_repository.GetAll());

            //Abordagem (II) - Clean Architecture - Via acesso servico camada dominio            //For IEnumerable
            IEnumerable<ClienteViewModel> model = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_domainService.GetAll());

            //Abordagem (III) - DDD - Via acesso servico camada aplicacao
            //IEnumerable<ClienteViewModel> model = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_applicationService.GetAll());

            return View(model);
        } //Index

        // GET: Cliente/Details/5
        public ActionResult Details(long id)
        {
            Cliente clienteDomain = _domainService.GetById(id);
            ClienteViewModel model = _mapper.Map<Cliente, ClienteViewModel>(clienteDomain);

            return View(model);

        } //Details

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        } //Create

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if(ModelState.IsValid)
            {
                var clientDomain = _mapper.Map<ClienteViewModel, Cliente>(cliente);

                //Abordagem (I) - Via acesso direto repository
                //_repository.Add(clientDomain);

                //Abordagem(II) - Clean Architecture - Via acesso servico camada dominio            
                _domainService.Add(clientDomain);

                //Abordagem (III) - DDD - Via acesso servico camada aplicacao
                //_applicationService.Add(clientDomain);

                return RedirectToAction(nameof(Index));

            } //if

            return View(cliente);

        } //Create

        // GET: Cliente/Edit/5
        public ActionResult Edit(long id)
        {
            Cliente clienteDomain = _domainService.GetById(id);
            ClienteViewModel model = _mapper.Map<Cliente, ClienteViewModel>(clienteDomain);

            return View(model);
        } //Edit

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {

            if (ModelState.IsValid)
            {
                var clientDomain = _mapper.Map<ClienteViewModel, Cliente>(cliente);

                //Abordagem (I) - Via acesso direto repository
                //_repository.Update(clientDomain);

                //Abordagem(II) - Clean Architecture - Via acesso servico camada dominio            
                _domainService.Update(clientDomain);

                //Abordagem (III) - DDD - Via acesso servico camada aplicacao
                //_applicationService.Update(clientDomain);

                return RedirectToAction(nameof(Index));

            } //if

            return View(cliente);

        } //Edit

        // GET: Cliente/Delete/5
        public ActionResult Delete(long id)
        {

            Cliente clienteDomain = _domainService.GetById(id);
            ClienteViewModel model = _mapper.Map<Cliente, ClienteViewModel>(clienteDomain);

            return View(model);

        } //Delete

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {

            Cliente clienteDominio = _domainService.GetById(id);
            _domainService.Remove(clienteDominio);

            return RedirectToAction(nameof(Index));

        } //DeleteConfirmed

    } //class

} //namespace