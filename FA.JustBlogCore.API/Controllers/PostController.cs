using AutoMapper;
using FA.JustBlogCore.API.Models.DTO.Post;
using FA.JustBlogCore.API.Utilities;
using FA.JustBlogCore.Services.Model;
using FA.JustBlogCore.Services.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlogCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list all published post
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllPost()
        {
            var postListDto = this._mapper.Map<IList<PostDTO>>(_unitOfWork.PostRepository.GetAll());
            return Ok(postListDto);
        }

        /// <summary>
        /// Get post by id of post
        /// </summary>
        /// <param name="id">Guid of post</param>
        /// <returns></returns>
        [HttpGet("{id:guid}", Name = "GetPostById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDTO))]
        public IActionResult GetPostById(Guid id)
        {
            var post = this._unitOfWork.PostRepository.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            var postDto = this._mapper.Map<PostDTO>(post);

            return Ok(postDto);
        }

        /// <summary>
        /// Create a new post
        /// </summary>
        /// <param name="postCreateDTO">Object post</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PostCreateDTO))]
        public IActionResult CreatePost([FromBody] PostCreateDTO postCreateDTO)
        {
            if (postCreateDTO == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = this._mapper.Map<Post>(postCreateDTO);
            // Insert tag from list tag id
            PostUtilities.InsertTagsInPost(this._unitOfWork, post, postCreateDTO.TagsGuid);
            this._unitOfWork.PostRepository.Add(post);
            if (this._unitOfWork.SaveChanges() == 0)
            {
                ModelState.AddModelError("error", $"Some thing wrong");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return CreatedAtRoute("GetPostById", new { id = post.Id }, postCreateDTO);
        }

        /// <summary>
        /// Update post
        /// </summary>
        /// <param name="postUpdateDTO">Updated post data</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePost([FromBody] PostUpdateDTO postUpdateDTO)
        {
            if (postUpdateDTO == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (this._unitOfWork.PostRepository.Find(postUpdateDTO.Id) == null)
            {
                return NotFound();
            }

            var post = this._mapper.Map<Post>(postUpdateDTO);
            // Insert tag from list tag id
            PostUtilities.InsertTagsInPost(this._unitOfWork, post, postUpdateDTO.TagsGuid);
            // Insert tag from list tag id
            PostUtilities.InsertCommentsInPost(this._unitOfWork, post, postUpdateDTO.CommentsGuid);

            this._unitOfWork.PostRepository.Update(post);
            if (this._unitOfWork.SaveChanges() == 0)
            {
                ModelState.AddModelError("error", $"Something went wrong");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <param name="id">Guid of post</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeletePost(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var post = this._unitOfWork.PostRepository.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            // Delete post
            this._unitOfWork.PostRepository.Delete(post);
            if (this._unitOfWork.SaveChanges() == 0)
            {
                ModelState.AddModelError("error", $"Something went wrong");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Get latest post
        /// </summary>
        /// <param name="size">Number of records</param>
        /// <returns></returns>
        [HttpGet("GetLatestPost/{size:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<PostDTO>))]
        public IActionResult GetLatestPost(int size)
        {
            if (size < 1)
            {
                return BadRequest();
            }

            var postsList = this._unitOfWork.PostRepository.GetLastestPost(size);
            var postDTOsList = this._mapper.Map<IList<PostDTO>>(postsList);

            return Ok(postDTOsList);
        }

        /// <summary>
        /// Get most viewed post
        /// </summary>
        /// <param name="size">Number of records</param>
        /// <returns></returns>
        [HttpGet("GetMostViewedPost/{size:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<PostDTO>))]
        public IActionResult GetMostViewedPost(int size)
        {
            if (size < 1)
            {
                return BadRequest();
            }

            var postsList = this._unitOfWork.PostRepository.GetMostViewedPost(size);
            var postsDTOList = this._mapper.Map<IList<PostDTO>>(postsList);

            return Ok(postsDTOList);
        }

        /// <summary>
        /// Get most rated post
        /// </summary>
        /// <param name="size">Number of records</param>
        /// <returns></returns>
        [HttpGet("GetHighestPosts/{size:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<PostDTO>))]
        public IActionResult GetHighestPosts(int size)
        {
            if (size < 1)
            {
                return BadRequest();
            }

            var postsList = this._unitOfWork.PostRepository.GetHighestPosts(size);
            var postsDTOList = this._mapper.Map<IList<PostDTO>>(postsList);

            return Ok(postsDTOList);
        }

        /// <summary>
        /// Get all published post
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPublishedPost")]
        public IActionResult GetAllPublishedPost()
        {
            var postListDto = this._mapper.Map<IList<PostDTO>>(_unitOfWork.PostRepository.GetPublishedPost());
            return Ok(postListDto);
        }

        /// <summary>
        /// Get post by datetime, optimize SEO keyword and it posted
        /// </summary>
        /// <param name="year">Year of post</param>
        /// <param name="month">Month of post</param>
        /// <param name="urlSlug">Url slug of post</param>
        /// <returns></returns>
        [HttpGet("{year:int}/{month:int}/{urlSlug}", Name = "GetPostByMonthYear")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<PostDTO>))]
        public IActionResult GetPostByMonthYear(int year, int month, string urlSlug)
        {
            var post = this._unitOfWork.PostRepository.Find(year, month, urlSlug);
            if (post == null)
            {
                return NotFound();
            }

            var postDto = this._mapper.Map<PostDTO>(post);

            return Ok(postDto);
        }
    }
}