﻿using LibApp.Application.Interfaces;
using LibApp.Application.Models.Requests;
using LibApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowController : BaseController
    {
        private readonly IBorrowService _borrowService;
        public BorrowController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        /// <summary>
        /// Create borrow
        /// </summary>
        /// <param name="req">Data</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBorrow(CreateBorrowReq req)
        {
            return Ok(await _borrowService.CreateBorrow(req, GetUserId()));
        }

        /// <summary>
        /// Get detail borrow
        /// </summary>
        /// <param name="id">id borrow</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDetailBorrow(Guid id)
        {
            return Ok(await _borrowService.GetBorrow(id));
        }

        /// <summary>
        /// Get borrow list by filter
        /// </summary>
        /// <param name="req">Filter</param>
        /// <returns>return borrow list and information page</returns>
        [HttpPost]
        [Route("GetPageBorrow")]
        public async Task<IActionResult> GetPageBook(ListBorrowFilter req)
        {
            return Ok(await _borrowService.GetListBorrowByFilter(req));
        }
    }
}
