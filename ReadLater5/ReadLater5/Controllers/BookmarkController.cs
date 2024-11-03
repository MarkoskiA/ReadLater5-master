using Contracts.DTOs;
using Contracts.Request;
using Contracts.Services;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Services;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ReadLater5.Controllers
{
    [ApiController]
    [Route("api/bookmarks")]
    public class BookmarkController : Controller
    {
        private readonly IBookmarkService _bookmarkService;
        //Checking for the current user is set in the controler on purpose so I can show returning different status codes.
        //Idealy checking the user should be in the service with rest of the logic for the method.
        private readonly ICurrenUserService _CurrentUser;
        private readonly ILogger<BookmarkService> _Logger;


        public BookmarkController(IBookmarkService bookmarkService, ICurrenUserService currenUser, ILogger<BookmarkService> logger)
        {
            _bookmarkService = bookmarkService;
            _CurrentUser = currenUser;
            _Logger = logger;
        }

        //Get all Bookmarks for user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookmarkDto>>> GetBookmarks()
        {
            var currenUser = await _CurrentUser.GetCurrentUserAsync();

            if (currenUser == null)
            {
                _Logger.LogInformation("No current user");
                return NotFound();
            }
            var bookmarks = await _bookmarkService.GetBookmarks(currenUser.Id);
            return Ok(bookmarks);
        }

        //Get specific Bookmark for user
        [HttpGet("{id}", Name ="SpecificBookmark")]
        public async Task<IActionResult> GetBookmark(int id)
        {
            var currenUser = await _CurrentUser.GetCurrentUserAsync();

            if (currenUser == null)
            {
                _Logger.LogInformation("No current user");
                return NotFound();
            }
            var bookmark = await _bookmarkService.GetBookmark(id, currenUser.Id);
            return Ok(bookmark);
        }

        //Create Bookmark for user
        [HttpPost]
        public async Task<ActionResult<BookmarkDto>> CreateBookmark(BookmarkRequest bookmark) {
            var currenUser = await _CurrentUser.GetCurrentUserAsync();

            if (currenUser == null)
            {
                _Logger.LogInformation("No current user");
                return NotFound();
            }

            var createdBookmark = await _bookmarkService.CreateBookmark(bookmark,"asdasd");
            return CreatedAtRoute("SpecificBookmark", createdBookmark);
        }
        //Delete bookmark for user
        [HttpDelete]
        public async Task<ActionResult> DeleteBookmark(BookmarkRequest bookmark)
        {
            var currenUser = await _CurrentUser.GetCurrentUserAsync();

            if (currenUser == null)
            {
                _Logger.LogInformation("No current user");
                return NotFound();
            }
            _bookmarkService.DeleteBookmark(bookmark, currenUser.Id);
            return NoContent();
        }
        //Update bookmark for user
        [HttpPut]
        public async Task<ActionResult> UpdateBookmark(BookmarkRequest bookmark)
        {
            var currenUser = await _CurrentUser.GetCurrentUserAsync();

            if (currenUser == null)
            {
                _Logger.LogInformation("No current user");
                return NotFound();
            }
            _bookmarkService.UpdateBookmark(bookmark, currenUser.Id); 
            return NoContent();
        }
    }
}
