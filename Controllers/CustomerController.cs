﻿using CustomerManagement.DAL.Abstract;
using CustomerManagement.Models.DTO;
using CustomerManagement.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            var result = await _customerRepository.GetAll();
            var customerDTOList = result.Select(customer => new CustomerResponseModel
            {
                Name = customer.Name,
                Surname = customer.Surname,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            }).ToList();

            return View(customerDTOList);
        }

        [HttpPost]   
        public async Task<IActionResult> AddNewCustomer(CustomerRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new()
                {
                    Name= model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Birthday=model.Birthday,
                    Address=model.Address,
                    Job=model.Job
                };
                
                await _customerRepository.Create(customer);
                return RedirectToAction("GetCustomerList", "Customer");
            }
            else
            {
                ViewBag.ErrorMessage = "Model is not valid.";
                return View();
            }
            return Ok();
        }

        public  IActionResult AddNewCustomer()
        {
            return View();
        }
    }
}